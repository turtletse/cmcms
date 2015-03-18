DROP PROCEDURE IF EXISTS sp_prescription_clean_up;
DELIMITER $$
CREATE PROCEDURE sp_prescription_clean_up()
BEGIN
	DECLARE last_run_up_to_dtm DATETIME(3);
    DECLARE covers_up_to_dtm DATETIME;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		UPDATE system_parm SET parm_value = 'Y' WHERE parm_value = 'pres_clean_up_error';
		ROLLBACK;
	END;
    
    SET covers_up_to_dtm = sysdate()-INTERVAL 1 DAY;
	
    SELECT STR_TO_DATE(parm_value, '%d/%m/%Y %T.%f') INTO last_run_up_to_dtm
    FROM system_parm
    WHERE parm_name = 'pres_clean_up_to_dtm';
    
    IF (last_run_up_to_dtm IS NULL AND (SELECT COUNT(*)FROM system_parm WHERE parm_name = 'pres_clean_up_to_dtm') = 0) THEN
		INSERT INTO system_parm(parm_name, parm_value, parm_desc)
        VALUES ('pres_clean_up_to_dtm', NULL, 'Last run of sp_prescription_clean_up covered prescription updated before the value');
    END IF;
    
    IF (SELECT COUNT(*)FROM system_parm WHERE parm_name = 'pres_clean_up_error') = 0 THEN
		INSERT INTO system_parm(parm_name, parm_value, parm_desc)
        VALUES ('pres_clean_up_error', NULL, 'Error occured in the last run of sp_prescription_clean_up');
    END IF;
    
    DROP TEMPORARY TABLE IF EXISTS tmp_pres_ids;
    CREATE TEMPORARY TABLE tmp_pres_ids
    SELECT pres_id
    FROM prescription
    WHERE (last_run_up_to_dtm IS NULL OR last_update_dtm > last_run_up_to_dtm) AND (last_update_dtm<=covers_up_to_dtm)
		AND pres_id NOT IN (
			SELECT prescription.pres_id
            FROM prescription 
				JOIN consultation_record ON consultation_record.pres_id REGEXP CONCAT('(^|[0-9]\\|{2})', prescription.pres_id, '(\\|{2}[0-9]|$)'));
    
    SET AUTOCOMMIT = 0;
    
    START TRANSACTION;
		DELETE FROM prescription WHERE pres_id IN (SELECT pres_id FROM tmp_pres_ids);
		DELETE FROM prescription_dt WHERE pres_id IN (SELECT pres_id FROM tmp_pres_ids);
		DELETE FROM pres_ignore_safety_chk WHERE pres_id IN (SELECT pres_id FROM tmp_pres_ids);
        
		UPDATE system_parm SET parm_value = 'N' WHERE parm_name = 'pres_clean_up_error';
		UPDATE system_parm SET parm_value = DATE_FORMAT(covers_up_to_dtm, '%d/%m/%Y %T.%f') WHERE parm_name = 'pres_clean_up_to_dtm';
	COMMIT;
    
    SET AUTOCOMMIT = 1;
    
END $$
DELIMITER ;

-- CALL sp_prescription_clean_up()