DROP FUNCTION IF EXISTS prescription_safety_check;

DELIMITER $$

CREATE FUNCTION prescription_safety_check(in_pres_id INT, in_is_pregnant INT, in_is_g6pd INT) RETURNS int(11)
BEGIN
	DECLARE safety_violation_log VARCHAR(20);
    DECLARE safety_violation_cnt INT;
    DECLARE curr_drug_id INT;
    DECLARE done INT DEFAULT FALSE;
    DECLARE cur2 CURSOR FOR SELECT drug_id FROM prescription_dt WHERE pres_id = in_pres_id;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
    
    SET safety_violation_log = '';
    
	IF (SELECT COUNT(*) FROM prescription_dt NATURAL JOIN drug_admin_abs_contraindication WHERE pregnancy = 1 ) >0 THEN
		SET safety_violation_log = CONCAT_WS('||', safety_violation_log, 4);
	END IF;
    
    IF (SELECT COUNT(*) FROM prescription_dt NATURAL JOIN drug_admin_abs_contraindication WHERE pregnancy = 2 ) >0 THEN
		SET safety_violation_log = CONCAT_WS('||', safety_violation_log, 5);
	END IF;
	
	IF (SELECT COUNT(*) FROM prescription_dt NATURAL JOIN drug_admin_abs_contraindication WHERE g6pd = 1 ) >0 THEN
		SET safety_violation_log = CONCAT_WS('||', safety_violation_log, 3);
	END IF;
    
    IF (SELECT COUNT(*) FROM prescription_dt NATURAL JOIN drug_admin_abs_contraindication WHERE g6pd = 2 ) >0 THEN
		SET safety_violation_log = CONCAT_WS('||', safety_violation_log, 4);
	END IF;
    
	DROP TEMPORARY TABLE IF EXISTS tmp_incompatible_drug;
	CREATE TEMPORARY TABLE tmp_incompatible_drug
	SELECT drug_id, incompatible_with
	FROM incompatible_drug
	WHERE drug_id IN (SELECT drug_id FROM prescription_dt WHERE prescription_dt.pres_id = in_pres_id);
	
	SET done = FALSE;
	OPEN cur2;
		REPEAT
			FETCH cur2 INTO curr_drug_id;
			IF NOT done THEN
				IF (SELECT COUNT(*) FROM tmp_incompatible_drug NATURAL JOIN master_drug_list WHERE drug_id <> curr_drug_id AND incompatible_with like CONCAT('%||', curr_drug_id, '||%'))>0 THEN
					SET safety_violation_log = CONCAT_WS('||', safety_violation_log, 1);
                    SET done = TRUE;
                END IF;
				
				DELETE FROM tmp_incompatible_drug WHERE drug_id = curr_drug_id;
				
				UPDATE tmp_incompatible_drug
				SET incompatible_with = REPLACE(incompatible_with, CONCAT('||', curr_drug_id), '');
			END IF;
		UNTIL done END REPEAT;
	CLOSE cur2;
    
	CALL sp_pres_ignore_safety_chk_logger(in_pres_id, safety_violation_log);
    
    SELECT incompatible_drug+g6pd_not_recommended,g6pd_forbidden,pregnant_not_recommended,pregnant_forbidden INTO safety_violation_cnt
    FROM pres_ignore_safety_chk
    WHERE pres_id = in_pres_id;
    
    IF safety_violation_cnt = 0 THEN
		return 0;
	ELSE
		return 1;
	END IF;	
    
END $$

DELIMITER ;