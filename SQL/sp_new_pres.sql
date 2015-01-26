DROP PROCEDURE IF EXISTS sp_new_pres;

DELIMITER $$
CREATE PROCEDURE sp_new_pres (
	IN in_instruction VARCHAR(255),
    IN in_no_of_dose INT,
    IN in_method_of_treatment VARCHAR(255),
    IN in_drug_data_str VARCHAR(10000)
)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    DECLARE pres_id INT;
    DECLARE done INT DEFAULT FALSE;
    DECLARE tmp_drug_str VARCHAR(40);
    DECLARE tmp_drug_code VARCHAR(15);
    DECLARE tmp_drug_name VARCHAR(255);
    DECLARE tmp_sub_drug_code VARCHAR(2);
    DECLARE tmp_dosage DECIMAL(8,4);
    DECLARE tmp_unit INT;
    DECLARE tmp_method INT;
    DECLARE cnt INT;
    DECLARE cur1 CURSOR FOR SELECT drug_data FROM drug_data_str;
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
		
		INSERT INTO prescription (pres_id, instruction, no_of_dose, method_of_treatment)
        VALUES (LAST_INSERT_ID(get_pres_id()), in_instruction, in_no_of_dose, in_method_of_treatment);
        SET pres_id = LAST_INSERT_ID();
		
        SET cnt = 0;
        
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
					pres_id,
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
	COMMIT;
	DROP TEMPORARY TABLE drug_data_str;
	SELECT status_id, status_desc, pres_id FROM insert_record_status where status_id = curr_status_id;
    
END $$

DELIMITER ;


-- CALL sp_new_pres('ABC', 1, 'DEF', '101001||1^^一^^1^^10^^20##101002^^二^^3^^20^^10');
-- SELECT * FROM system_parm;
-- SELECT * FROM prescription;
-- SELECT * FROM prescription_dt;
-- UPDATE system_parm SET parm_value = '0' where parm_name = 'prescription_cnt'
-- delete from prescription;
-- delete from prescription_dt;