DROP procedure if EXISTS sp_pres_ignore_safety_chk_logger;
delimiter $$
CREATE PROCEDURE sp_pres_ignore_safety_chk_logger (
	IN in_pres_id INT,
    IN in_violation_id VARCHAR(30)
)
BEGIN
	DELETE FROM pres_ignore_safety_chk WHERE pres_id = in_pres_id;
    IF in_violation_id <> '' THEN
		INSERT INTO pres_ignore_safety_chk(pres_id, record_dtm) VALUES (in_pres_id, SYSDATE(3));
		
        IF in_violation_id REGEXP '(^|[0-9]\\|{2})1(\\|{2}[0-9]|$)' THEN
			UPDATE pres_ignore_safety_chk SET incompatible_drug = 1, record_dtm = SYSDATE(3) WHERE pres_id = in_pres_id;
		END IF;
        IF in_violation_id REGEXP '(^|[0-9]\\|{2})2(\\|{2}[0-9]|$)' THEN
			UPDATE pres_ignore_safety_chk SET g6pd_not_recommended = 1, record_dtm = SYSDATE(3) WHERE pres_id = in_pres_id;
		END IF;
        IF in_violation_id REGEXP '(^|[0-9]\\|{2})3(\\|{2}[0-9]|$)' THEN
			UPDATE pres_ignore_safety_chk SET g6pd_forbidden = 1, record_dtm = SYSDATE(3) WHERE pres_id = in_pres_id;
		END IF;
        IF in_violation_id REGEXP '(^|[0-9]\\|{2})4(\\|{2}[0-9]|$)' THEN
			UPDATE pres_ignore_safety_chk SET pregnant_not_recommended = 1, record_dtm = SYSDATE(3) WHERE pres_id = in_pres_id;
		END IF;
        IF in_violation_id REGEXP '(^|[0-9]\\|{2})5(\\|{2}[0-9]|$)' THEN
			UPDATE pres_ignore_safety_chk SET pregnant_forbidden = 1, record_dtm = SYSDATE(3) WHERE pres_id = in_pres_id;
		END IF;
        IF in_violation_id REGEXP '(^|[0-9]\\|{2})6(\\|{2}[0-9]|$)' THEN
			UPDATE pres_ignore_safety_chk SET drug_wo_dosage = 1, record_dtm = SYSDATE(3) WHERE pres_id = in_pres_id;
		END IF;
        IF in_violation_id REGEXP '(^|[0-9]\\|{2})7(\\|{2}[0-9]|$)' THEN
			UPDATE pres_ignore_safety_chk SET drug_below_min_dosage = 1, record_dtm = SYSDATE(3) WHERE pres_id = in_pres_id;
		END IF;
        IF in_violation_id REGEXP '(^|[0-9]\\|{2})8(\\|{2}[0-9]|$)' THEN
			UPDATE pres_ignore_safety_chk SET drug_exceed_max_dosage = 1, record_dtm = SYSDATE(3) WHERE pres_id = in_pres_id;
		END IF;
        IF in_violation_id REGEXP '(^|[0-9]\\|{2})9(\\|{2}[0-9]|$)' THEN
			UPDATE pres_ignore_safety_chk SET patient_allergy = 1, record_dtm = SYSDATE(3) WHERE pres_id = in_pres_id;
		END IF;
    END IF;
END $$
delimiter ;

-- CALL sp_pres_ignore_safety_chk_logger(33,'1||2||3||4||5');