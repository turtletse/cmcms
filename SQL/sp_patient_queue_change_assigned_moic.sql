DROP PROCEDURE IF EXISTS sp_patient_queue_change_assigned_moic;

DELIMITER $$
CREATE PROCEDURE sp_patient_queue_change_assigned_moic (
	IN in_patient_id int,
    IN in_clinic_id VARCHAR(10),
    IN in_moic_id VARCHAR(10)
)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    DECLARE tabname VARCHAR(100);
    
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
        SET curr_status_id = 2;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	END;
    SET tabname = CONCAT('queuing_table_', in_clinic_id);
	IF (SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = 'cmcms' AND table_name = tabname) = 0 THEN
		SET @sql_str = CONCAT('CREATE TABLE ', tabname, ' (patient_id int, enter_dtm DATETIME(6), missed_call int default 0, patient_status int default 0, doctor_in_charge VARCHAR(10) DEFAULT NULL);');
		PREPARE stmt FROM @sql_str;
		EXECUTE stmt;
		SET @sql_str = CONCAT('CREATE INDEX ', tabname, '_x1 ON ', tabname,'(enter_dtm, patient_id);');
		PREPARE stmt FROM @sql_str;
		EXECUTE stmt;
		SET @sql_str = CONCAT('CREATE INDEX ', tabname, '_x2 ON ', tabname,'(patient_id);');
		PREPARE stmt FROM @sql_str;
		EXECUTE stmt;
        SET @sql_str = CONCAT('DELETE FROM system_parm WHERE parm_name = ''', tabname, '_LOCK'';');
		PREPARE stmt FROM @sql_str;
		EXECUTE stmt;
        SET @sql_str = CONCAT('INSERT INTO system_parm (parm_name, parm_value, parm_desc) VALUES (''', tabname, '_LOCK'', NULL, ''queue table lock for clinic ', in_clinic_id, ''')');
		PREPARE stmt FROM @sql_str;
		EXECUTE stmt;
	END IF;
	SET @sql_str = CONCAT('UPDATE ', tabname, ' SET doctor_in_charge =''', in_moic_id,'''WHERE patient_id = ', in_patient_id, ' AND patient_status > 10 AND doctor_in_charge IS NOT NULL AND CHAR_LENGTH(doctor_in_charge)>0;');
    PREPARE stmt FROM @sql_str;
    EXECUTE stmt;
    IF (SELECT ROW_COUNT()) > 0 THEN
		SET curr_status_id = 0;
	ELSE
		SET curr_status_id = 13;
    END IF;
	SELECT status_id, status_desc FROM insert_record_status where status_id = curr_status_id;
    DEALLOCATE PREPARE stmt;
END $$

DELIMITER ;

-- CALL sp_patient_queue_change_assigned_moic (1, 'CITYC', 'CSM')