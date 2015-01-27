DROP PROCEDURE IF EXISTS sp_cons_later;

DELIMITER $$
CREATE PROCEDURE sp_cons_later (
	IN in_cons_id INT,
	IN in_clinic_id VARCHAR(10),
	IN in_dr_id VARCHAR(10),
	IN in_patient_id INT,
	IN in_ex_code VARCHAR(255),
	IN in_ex_desc VARCHAR(255),
	IN in_diff_code VARCHAR(255),
	IN in_diff_desc VARCHAR(255),
	IN in_dx_code VARCHAR(255),
	IN in_dx_desc VARCHAR(255),
	IN in_pres_id VARCHAR(255),
	IN in_dr_rmk VARCHAR(450)
)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    DECLARE tabname VARCHAR(255);
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
		SET curr_status_id = 2;
		SELECT * FROM insert_record_status where status_id = curr_status_id;
	END;
    
	SET AUTOCOMMIT = 0;
    
	START TRANSACTION;
		SET tabname = CONCAT('queuing_table_', in_clinic_id);
		SET @sql_str = CONCAT('UPDATE ', tabname, ' SET patient_status = 40 WHERE patient_id = ', in_patient_id, ' AND patient_status = 30 AND doctor_in_charge=''', in_dr_id, '''');
		PREPARE stmt FROM @sql_str;
		EXECUTE stmt;
        
        SET @sql_str = CONCAT('SELECT count(*) INTO @cnt FROM ', tabname, ' WHERE patient_id = ', in_patient_id, ' AND patient_status = 40 AND doctor_in_charge=''', in_dr_id, '''');
		PREPARE stmt FROM @sql_str;
		EXECUTE stmt;
        
        IF (@cnt<>1) THEN
			ROLLBACK;
			SET curr_status_id = 8;
			SELECT * FROM insert_record_status where status_id = curr_status_id;
        ELSE
			UPDATE consultation_record
			SET	ex_code = in_ex_code,
				ex_desc = in_ex_desc,
				diff_code = in_diff_code,
				diff_desc = in_diff_desc,
				dx_code = in_dx_code,
				dx_desc = in_dx_desc,
				pres_id = in_pres_id,
				dr_rmk = in_dr_rmk,
				last_update_dtm = sysdate()
			WHERE cons_id = in_cons_id
				AND clinic_id = in_clinic_id
				AND dr_id = in_dr_id
				AND patient_id = in_patient_id
				AND isFinished <> -1;
		
			IF (SELECT ROW_COUNT()) = 0 THEN
				ROLLBACK;
				SET curr_status_id = 1;
			END IF;    
		END IF;
    COMMIT;
    
    SET AUTOCOMMIT = 1;
    
    SELECT * FROM insert_record_status where status_id = curr_status_id;
END $$

DELIMITER ;



-- SELECT * from prescription_dt
-- CALL sp_pres_dt_get (1)