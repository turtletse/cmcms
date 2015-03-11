DROP FUNCTION IF EXISTS prescription_safety_check;

DELIMITER $$

CREATE FUNCTION prescription_safety_check(in_pres_id INT, in_pat_id INT) RETURNS int(1)
BEGIN
	DECLARE safety_violation_log VARCHAR(20);
    DECLARE safety_violation_cnt INT DEFAULT 0;
    DECLARE pat_isG6PD INT;
    DECLARE pat_isPreg INT;
    DECLARE pat_drug_allergy VARCHAR(1000);
    DECLARE curr_drug_id INT;
    DECLARE curr_dosage DECIMAL(8,4);
    DECLARE curr_unit INT;
    DECLARE done INT DEFAULT FALSE;
    DECLARE cur2 CURSOR FOR SELECT drug_id, dosage, unit FROM prescription_dt WHERE pres_id = in_pres_id;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
    
    SELECT isG6PD, isPregnant, allergic_drug_ids INTO pat_isG6PD, pat_isPreg, pat_drug_allergy FROM patient_record WHERE patient_id = in_pat_id;
    
    SET safety_violation_log = '';
    
	IF (pat_isPreg > 0) AND ((SELECT COUNT(*) FROM prescription_dt NATURAL JOIN drug_admin_abs_contraindication WHERE pregnancy = 1) >0) THEN
		IF (LENGTH(safety_violation_log) = 0) THEN
			SET safety_violation_log = '4';
		ELSE
			SET safety_violation_log = CONCAT_WS('||', safety_violation_log, 4);
		END IF;
	END IF;
    
    IF (pat_isPreg > 0) AND ((SELECT COUNT(*) FROM prescription_dt NATURAL JOIN drug_admin_abs_contraindication WHERE pregnancy = 2) >0) THEN
		IF (LENGTH(safety_violation_log) = 0) THEN
			SET safety_violation_log = '5';
		ELSE
			SET safety_violation_log = CONCAT_WS('||', safety_violation_log, 5);
		END IF;
	END IF;
	
	IF (pat_isG6PD > 0) AND ((SELECT COUNT(*) FROM prescription_dt NATURAL JOIN drug_admin_abs_contraindication WHERE g6pd = 1) >0) THEN
		IF (LENGTH(safety_violation_log) = 0) THEN
			SET safety_violation_log = '2';
		ELSE
			SET safety_violation_log = CONCAT_WS('||', safety_violation_log, 2);
		END IF;
	END IF;
    
    IF (pat_isG6PD > 0) AND ((SELECT COUNT(*) FROM prescription_dt NATURAL JOIN drug_admin_abs_contraindication WHERE g6pd = 2) >0) THEN
		IF (LENGTH(safety_violation_log) = 0) THEN
			SET safety_violation_log = '3';
		ELSE
			SET safety_violation_log = CONCAT_WS('||', safety_violation_log, 3);
		END IF;
	END IF;
        
    IF (SELECT GROUP_CONCAT(drug_id SEPARATOR '||') FROM prescription_dt WHERE prescription_dt.pres_id = in_pres_id) REGEXP CONCAT('(^|[0-9]\\|{2})(',REPLACE(pat_drug_allergy, '||', '|'),')(\\|{2}[0-9]|$)') THEN
		IF (LENGTH(safety_violation_log) = 0) THEN
			SET safety_violation_log = '9';
		ELSE
			SET safety_violation_log = CONCAT_WS('||', safety_violation_log, 9);
		END IF;
    END IF;
    
	DROP TEMPORARY TABLE IF EXISTS tmp_incompatible_drug;
	CREATE TEMPORARY TABLE tmp_incompatible_drug
	SELECT drug_id, incompatible_with
	FROM incompatible_drug
	WHERE drug_id IN (SELECT drug_id FROM prescription_dt WHERE prescription_dt.pres_id = in_pres_id);
	
	SET done = FALSE;
	OPEN cur2;
		REPEAT
			FETCH cur2 INTO curr_drug_id, curr_dosage, curr_unit;
			IF NOT done THEN
				IF (SELECT COUNT(*) FROM tmp_incompatible_drug NATURAL JOIN master_drug_list WHERE drug_id <> curr_drug_id AND incompatible_with like CONCAT('%||', curr_drug_id, '||%'))>0 THEN
					IF (safety_violation_log REGEXP '(^|[0-9]\\|{2})1(\\|{2}[0-9]|$)' = FALSE) THEN
						IF (LENGTH(safety_violation_log) = 0) THEN
							SET safety_violation_log = '1';
						ELSE
							SET safety_violation_log = CONCAT_WS('||', safety_violation_log, 1);
						END IF;
					END IF;
                END IF;
				
				DELETE FROM tmp_incompatible_drug WHERE drug_id = curr_drug_id;
				
				UPDATE tmp_incompatible_drug
				SET incompatible_with = REPLACE(incompatible_with, CONCAT('||', curr_drug_id), '');
                
                CASE drug_dosage_chk(curr_drug_id, curr_dosage, curr_unit)
					WHEN -2 THEN 
						IF (safety_violation_log REGEXP '(^|[0-9]\\|{2})6(\\|{2}[0-9]|$)' = FALSE) THEN
							IF (LENGTH(safety_violation_log) = 0) THEN
								SET safety_violation_log = '6';
							ELSE
								SET safety_violation_log = CONCAT_WS('||', safety_violation_log, 6);
							END IF;
						END IF;
					WHEN -1 THEN 
						IF (safety_violation_log REGEXP '(^|[0-9]\\|{2})7(\\|{2}[0-9]|$)' = FALSE) THEN
							IF (LENGTH(safety_violation_log) = 0) THEN
								SET safety_violation_log = '7';
							ELSE
								SET safety_violation_log = CONCAT_WS('||', safety_violation_log, 7);
							END IF;
						END IF;
					WHEN 1 THEN 
						IF (safety_violation_log REGEXP '(^|[0-9]\\|{2})8(\\|{2}[0-9]|$)' = FALSE) THEN
							IF (LENGTH(safety_violation_log) = 0) THEN
								SET safety_violation_log = '8';
							ELSE
								SET safety_violation_log = CONCAT_WS('||', safety_violation_log, 8);
							END IF;
						END IF;
					ELSE
						BEGIN
						END;
				END CASE;
			END IF;
		UNTIL done END REPEAT;
	CLOSE cur2;
    -- CALL debug_logger(safety_violation_log);
	CALL sp_pres_ignore_safety_chk_logger(in_pres_id, safety_violation_log);
    
    SELECT incompatible_drug+g6pd_not_recommended+g6pd_forbidden+pregnant_not_recommended+pregnant_forbidden+drug_wo_dosage+drug_below_min_dosage+drug_exceed_max_dosage+patient_allergy INTO safety_violation_cnt
    FROM pres_ignore_safety_chk
    WHERE pres_id = in_pres_id;
    
    IF safety_violation_cnt = NULL OR safety_violation_cnt = 0 THEN
		return 0;
	ELSE
		return 1;
	END IF;	
    
END $$

DELIMITER ;
-- SELECT * FROM debug_log ORDER BY log_dtm DESC
-- SELECT prescription_safety_check(43, 2)
-- SELECT drug_dosage_chk(101001, 2.5000, 10)
-- SELECT * FROM pres_ignore_safety_chk WHERE pres_id = 33