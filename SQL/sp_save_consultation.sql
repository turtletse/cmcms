DROP PROCEDURE IF EXISTS sp_save_consultation;

DELIMITER $$
CREATE PROCEDURE sp_save_consultation (
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
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
		SET curr_status_id = 2;
		SELECT * FROM insert_record_status where status_id = curr_status_id;
	END;
    
	SET AUTOCOMMIT = 0;
    
	START TRANSACTION;
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
    
    COMMIT;
    
    SET AUTOCOMMIT = 1;
    
    SELECT * FROM insert_record_status where status_id = curr_status_id;
END $$

DELIMITER ;

-- SELECT * from consultation_record
-- CALL sp_pres_dt_get (1)