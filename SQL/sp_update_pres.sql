DROP PROCEDURE IF EXISTS sp_update_pres;

DELIMITER $$
CREATE PROCEDURE sp_update_pres (
	IN in_presId int,
	IN in_instruction VARCHAR(255),
    IN in_no_of_dose INT,
    IN in_method_of_treatment VARCHAR(255),
    IN in_drug_data_str VARCHAR(10000),
    IN in_isPreg INT,
    IN in_isG6PD INT
)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    DECLARE done INT DEFAULT FALSE;
    DECLARE tmp_drug_str VARCHAR(40);
    DECLARE tmp_drug_code VARCHAR(15);
    DECLARE tmp_drug_name VARCHAR(255);
    DECLARE tmp_sub_drug_code VARCHAR(2);
    DECLARE tmp_dosage DECIMAL(8,4);
    DECLARE tmp_unit INT;
    DECLARE tmp_method INT;
    DECLARE cnt INT;
    DECLARE curr_drug_id INT;
    DECLARE curr_drug_name VARCHAR(255);
    DECLARE return_msg VARCHAR(1000);
    DECLARE cur1 CURSOR FOR SELECT drug_data FROM drug_data_str;
    DECLARE cur2 CURSOR FOR SELECT prescription_dt.drug_id, master_drug_list.drug_name FROM prescription_dt JOIN master_drug_list ON prescription_dt.drug_id = master_drug_list.drug_id WHERE prescription_dt.pres_id = pres_id;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
    
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
        SET curr_status_id = 2;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	END;
	SET AUTOCOMMIT =0;
	START TRANSACTION;
    
		CALL split(in_drug_data_str, '##');
		DROP TEMPORARY TABLE IF EXISTS drug_data_str;
		CREATE TEMPORARY TABLE drug_data_str
		SELECT split_value drug_data FROM splitResult;
		DROP TEMPORARY TABLE splitResult;
		
        IF (SELECT COUNT(*) FROM prescription WHERE pres_id = in_presId) = 0 THEN
			INSERT INTO prescription(pres_id) VALUES (in_presId);
        END IF;
        
		UPDATE prescription 
        SET	instruction = in_instruction,
			no_of_dose = in_no_of_dose,
            method_of_treatment = in_method_of_treatment
        WHERE pres_id = in_presId;
		
        SET cnt = 0;
        
        DELETE FROM prescription_dt WHERE pres_id = in_presId;
        
		OPEN cur1;
		REPEAT
			FETCH cur1 INTO tmp_drug_str;
			IF NOT done THEN
				SET tmp_drug_code = stringSplit(tmp_drug_str,'^^',1);
				SET tmp_sub_drug_code = stringSplit(tmp_drug_code,'||',2);
				SET tmp_drug_code = stringSplit(tmp_drug_code,'||',1);
				SET tmp_drug_name = stringSplit(tmp_drug_str,'^^',2);
                SET tmp_dosage = CAST(stringSplit(tmp_drug_str,'^^',3) AS DECIMAL(8,4));
				SET tmp_unit = CAST(stringSplit(tmp_drug_str,'^^',4) AS UNSIGNED);
				SET tmp_method = CAST(stringSplit(tmp_drug_str,'^^',5) AS UNSIGNED);
				if LENGTH(TRIM(tmp_sub_drug_code))=0 THEN
					SET tmp_sub_drug_code = '0';
				END IF;
				SET cnt = cnt+1;
                
				INSERT INTO prescription_dt(
					pres_id,
					drug_id,
					sub_drug_id,
					drug_name,
					dosage,
					unit,
                    preparation_method,
					display_order
				)VALUES(
					in_pres_id,
					CAST(tmp_drug_code AS UNSIGNED),
					CAST(tmp_sub_drug_code AS UNSIGNED),
                    tmp_drug_name,
					tmp_dosage,
					tmp_unit,
					tmp_method,
                    cnt
				);
			END IF;
		UNTIL done END REPEAT;
		CLOSE cur1;
	
		DROP TEMPORARY TABLE drug_data_str;
		
		DROP TEMPORARY TABLE IF EXISTS chk_result;
		CREATE TEMPORARY TABLE chk_result(
			chk_id INT,
			result_desc VARCHAR(255)
		);
		
		DROP TEMPORARY TABLE IF EXISTS tmp_incompatible_drug;
		CREATE TEMPORARY TABLE tmp_incompatible_drug
		SELECT drug_id, incompatible_with
		FROM incompatible_drug
		WHERE drug_id IN (SELECT drug_id FROM prescription_dt WHERE prescription_dt.pres_id = pres_id);
		
		SET done = FALSE;
		OPEN cur2;
			REPEAT
				FETCH cur2 INTO curr_drug_id, curr_drug_name;
				IF NOT done THEN
					INSERT INTO chk_result (chk_id, result_desc)
					SELECT 1, CONCAT_WS(' - ', curr_drug_name, master_drug_list.drug_name)
					FROM tmp_incompatible_drug NATURAL JOIN master_drug_list
					WHERE drug_id <> curr_drug_id AND incompatible_with like CONCAT('%||', curr_drug_id, '||%');
					
					DELETE FROM tmp_incompatible_drug WHERE drug_id = curr_drug_id;
					
					UPDATE tmp_incompatible_drug
					SET incompatible_with = REPLACE(incompatible_with, CONCAT('||', curr_drug_id), '');
				END IF;
			UNTIL done END REPEAT;
		CLOSE cur2;
        
        IF in_isG6PD > 0 THEN
			INSERT INTO chk_result (chk_id, result_desc)
			SELECT 2, master_drug_list.drug_name
			FROM prescription_dt NATURAL JOIN drug_admin_abs_contraindication NATURAL JOIN master_drug_list
			WHERE prescription_dt.pres_id = pres_id AND g6pd = 1;
			
			INSERT INTO chk_result (chk_id, result_desc)
			SELECT 3, master_drug_list.drug_name
			FROM prescription_dt NATURAL JOIN drug_admin_abs_contraindication NATURAL JOIN master_drug_list
			WHERE prescription_dt.pres_id = pres_id AND g6pd = 2;
		END IF;
		
		IF in_isPreg > 0 THEN
			INSERT INTO chk_result (chk_id, result_desc)
			SELECT 4, master_drug_list.drug_name
			FROM prescription_dt NATURAL JOIN drug_admin_abs_contraindication NATURAL JOIN master_drug_list
			WHERE prescription_dt.pres_id = pres_id AND pregnancy = 1;
			
			INSERT INTO chk_result (chk_id, result_desc)
			SELECT 5, master_drug_list.drug_name
			FROM prescription_dt NATURAL JOIN drug_admin_abs_contraindication NATURAL JOIN master_drug_list
			WHERE prescription_dt.pres_id = pres_id AND pregnancy = 2;
		END IF;
        
    COMMIT;
    SET AUTOCOMMIT=1;
    
    CALL debug_logger((SELECT GROUP_CONCAT(DISTINCT chk_id SEPARATOR '||' )FROM chk_result));
    CALL sp_pres_ignore_safety_chk_logger(pres_id, (SELECT GROUP_CONCAT(DISTINCT chk_id SEPARATOR '||' )FROM chk_result));
    
    IF (SELECT count(*) FROM chk_result)>0 THEN
		SET curr_status_id = 18;
        SET return_msg = '系統發現處方有以下問題:\n\n';
        SELECT CONCAT(return_msg, GROUP_CONCAT(a.msg ORDER BY a.chk_id SEPARATOR '\n')) INTO return_msg FROM (
			SELECT 
				chk_id,
				CONCAT_WS('\n', 
				CASE chk_id
					WHEN 1 THEN '配伍禁忌:'
					WHEN 2 THEN 'G6PD 慎用:'
					WHEN 3 THEN 'G6PD 禁用:'
					WHEN 4 THEN '孕婦慎用:'
					WHEN 5 THEN '孕婦禁用:'
					ELSE ''
				END,
				GROUP_CONCAT(result_desc SEPARATOR '\n')) msg
			FROM chk_result
			GROUP BY chk_id
		) a;
        SELECT status_id, return_msg status_desc, pres_id FROM insert_record_status where status_id = curr_status_id;
	ELSE
		SELECT status_id, status_desc, pres_id FROM insert_record_status where status_id = curr_status_id;
	END IF;
    
END $$

DELIMITER ;


-- CALL sp_new_pres('ABC', 1, 'DEF', '101001||1^^一^^1^^10^^20##101002^^二^^3^^20^^10');
-- SELECT * FROM system_parm;
-- SELECT * FROM prescription;
-- SELECT * FROM prescription_dt;
-- UPDATE system_parm SET parm_value = '0' where parm_name = 'prescription_cnt'
-- delete from prescription;
-- delete from prescription_dt;