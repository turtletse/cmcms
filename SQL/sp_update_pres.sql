DROP PROCEDURE IF EXISTS sp_update_pres;

DELIMITER $$
CREATE PROCEDURE sp_update_pres (
	IN in_presId int,
	IN in_instruction VARCHAR(255),
    IN in_no_of_dose INT,
    IN in_method_of_treatment VARCHAR(255),
    IN in_drug_data_str VARCHAR(10000),
    IN in_pat_id INT
)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    DECLARE pat_isPreg INT;
    DECLARE pat_isG6PD INT;
    DECLARE pat_drug_allergy VARCHAR(1000);
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
    DECLARE curr_dosage DECIMAL(8,4);
    DECLARE curr_unit INT;
    DECLARE return_msg VARCHAR(1000);
    DECLARE cur1 CURSOR FOR SELECT drug_data FROM drug_data_str;
    DECLARE cur2 CURSOR FOR SELECT prescription_dt.drug_id, master_drug_list.drug_name, prescription_dt.dosage, prescription_dt.unit FROM prescription_dt JOIN master_drug_list ON prescription_dt.drug_id = master_drug_list.drug_id WHERE prescription_dt.pres_id = in_presId;
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
            method_of_treatment = in_method_of_treatment,
            last_update_dtm = sysdate(3)
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
					in_presId,
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
		WHERE drug_id IN (SELECT drug_id FROM prescription_dt WHERE prescription_dt.pres_id = in_presId);
		
		SET done = FALSE;
		OPEN cur2;
			REPEAT
				FETCH cur2 INTO curr_drug_id, curr_drug_name, curr_dosage, curr_unit;
				IF NOT done THEN
					INSERT INTO chk_result (chk_id, result_desc)
					SELECT 1, CONCAT_WS(' - ', curr_drug_name, master_drug_list.drug_name)
					FROM tmp_incompatible_drug NATURAL JOIN master_drug_list
					WHERE drug_id <> curr_drug_id AND incompatible_with like CONCAT('%||', curr_drug_id, '||%');
					
					DELETE FROM tmp_incompatible_drug WHERE drug_id = curr_drug_id;
					
					UPDATE tmp_incompatible_drug
					SET incompatible_with = REPLACE(incompatible_with, CONCAT('||', curr_drug_id), '');
					
					CASE drug_dosage_chk(curr_drug_id, curr_dosage, curr_unit)
						WHEN -2 THEN INSERT INTO chk_result (chk_id, result_desc) VALUES (6, curr_drug_name);
						WHEN -1 THEN INSERT INTO chk_result (chk_id, result_desc) VALUES (7, curr_drug_name);
						WHEN 1 THEN INSERT INTO chk_result (chk_id, result_desc) VALUES (8, curr_drug_name);
                        ELSE
							BEGIN
							END;
					END CASE;
				END IF;
			UNTIL done END REPEAT;
		CLOSE cur2;
        
        SELECT isG6PD, isPregnant, allergic_drug_ids INTO pat_isG6PD, pat_isPreg, pat_drug_allergy FROM patient_record WHERE patient_id = in_pat_id;
        
        IF pat_isG6PD > 0 THEN
			INSERT INTO chk_result (chk_id, result_desc)
			SELECT 2, master_drug_list.drug_name
			FROM prescription_dt NATURAL JOIN drug_admin_abs_contraindication NATURAL JOIN master_drug_list
			WHERE prescription_dt.pres_id = in_presId AND g6pd = 1;
			
			INSERT INTO chk_result (chk_id, result_desc)
			SELECT 3, master_drug_list.drug_name
			FROM prescription_dt NATURAL JOIN drug_admin_abs_contraindication NATURAL JOIN master_drug_list
			WHERE prescription_dt.pres_id = in_presId AND g6pd = 2;
		END IF;
		
		IF pat_isPreg > 0 THEN
			INSERT INTO chk_result (chk_id, result_desc)
			SELECT 4, master_drug_list.drug_name
			FROM prescription_dt NATURAL JOIN drug_admin_abs_contraindication NATURAL JOIN master_drug_list
			WHERE prescription_dt.pres_id = in_presId AND pregnancy = 1;
			
			INSERT INTO chk_result (chk_id, result_desc)
			SELECT 5, master_drug_list.drug_name
			FROM prescription_dt NATURAL JOIN drug_admin_abs_contraindication NATURAL JOIN master_drug_list
			WHERE prescription_dt.pres_id = in_presId AND pregnancy = 2;
		END IF;
        

        CALL split(pat_drug_allergy, '||');
    
		DROP TEMPORARY TABLE IF EXISTS drug_allergy_list;
		CREATE TEMPORARY TABLE drug_allergy_list
		SELECT CAST(split_value AS UNSIGNED) drug_id FROM splitResult WHERE split_value IS NOT NULL AND length(split_value)>0;
		
		DROP TEMPORARY TABLE IF EXISTS matched_allergy_item;
		CREATE TEMPORARY TABLE matched_allergy_item(
			drug_id INT,
			sub_drug_id INT,
			drug_name VARCHAR(255)
		);
		
		INSERT INTO matched_allergy_item (drug_id, sub_drug_id)
		SELECT drug_id, sub_drug_id
		FROM prescription_dt
		WHERE prescription_dt.pres_id = in_presId AND drug_id IN (SELECT drug_id FROM drug_allergy_list);
		
		UPDATE matched_allergy_item m, master_drug_list d
		SET m.drug_name = d.drug_name
		WHERE m.sub_drug_id = 0 AND m.drug_id = d.drug_id;
		
		UPDATE matched_allergy_item m, master_sub_drug_list s
		SET m.drug_name = s.sub_drug_name
		WHERE m.sub_drug_id > 0 AND m.drug_id = s.drug_id AND m.sub_drug_id = s.sub_drug_id;
		
		INSERT INTO chk_result (chk_id, result_desc)
		SELECT 9, drug_name FROM matched_allergy_item;
	
    
    COMMIT;
    SET AUTOCOMMIT=1;
    
    CALL debug_logger((SELECT GROUP_CONCAT(DISTINCT chk_id SEPARATOR '||' )FROM chk_result));
    CALL sp_pres_ignore_safety_chk_logger(in_presId, (SELECT GROUP_CONCAT(DISTINCT chk_id SEPARATOR '||' )FROM chk_result));
    
    IF (SELECT count(*) FROM chk_result)>0 THEN
		SET curr_status_id = 18;
        SET return_msg = '系統發現處方有以下問題:\n\n';
        SELECT CONCAT(return_msg, GROUP_CONCAT(a.msg ORDER BY a.chk_id SEPARATOR '\n\n')) INTO return_msg FROM (
			SELECT 
				chk_id,
				CONCAT_WS('\n', 
				CASE chk_id
					WHEN 1 THEN '配伍禁忌:'
					WHEN 2 THEN 'G6PD 慎用:'
					WHEN 3 THEN 'G6PD 禁用:'
					WHEN 4 THEN '孕婦慎用:'
					WHEN 5 THEN '孕婦禁用:'
					WHEN 6 THEN '沒有輸入劑量/0劑量:'
                    WHEN 7 THEN '劑量低於系統建議下限:'
                    WHEN 8 THEN '劑量超出系統建議上限:'
                    WHEN 9 THEN '病人藥物敏感史:'
					ELSE ''
				END,
				GROUP_CONCAT(result_desc SEPARATOR '\n')) msg
			FROM chk_result
			GROUP BY chk_id
		) a;
        SELECT status_id, return_msg status_desc FROM insert_record_status where status_id = curr_status_id;
	ELSE
		SELECT status_id, status_desc FROM insert_record_status where status_id = curr_status_id;
	END IF;
    
END $$

DELIMITER ;


-- CALL sp_update_pres (33, '', 1, '', '101001^^麻黃^^0.0000^^10^^20', 0, 0)
-- SELECT * FROM system_parm;
-- SELECT * FROM prescription;
-- SELECT * FROM prescription_dt;
-- UPDATE system_parm SET parm_value = '0' where parm_name = 'prescription_cnt'
-- delete from prescription;
-- delete from prescription_dt;