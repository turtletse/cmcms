DROP PROCEDURE IF EXISTS sp_patient_queue_staff_call_release_lock;

DELIMITER $$
CREATE PROCEDURE sp_patient_queue_staff_call_release_lock (
    IN in_clinic_id VARCHAR(10),
    IN in_user_id VARCHAR(10)
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
    
	SET AUTOCOMMIT=0;
	START TRANSACTION;
		SET @sql_str = CONCAT('SELECT parm_value into @tablock FROM system_parm WHERE parm_name =''',tabname,'_LOCK'' FOR UPDATE');
		PREPARE stmt FROM @sql_str;
		EXECUTE stmt;
		IF @tablock = in_user_id THEN
            SET @sql_str = CONCAT('UPDATE ',tabname,' SET patient_status = 0, missed_call=missed_call+1  WHERE patient_status = 10;');
			PREPARE stmt FROM @sql_str;
			EXECUTE stmt;
			SET @sql_str = CONCAT('UPDATE system_parm SET parm_value =NULL WHERE parm_name = ''',tabname,'_LOCK''');
			PREPARE stmt FROM @sql_str;
			EXECUTE stmt;
		ELSE
			SET curr_status_id = 16;
		END IF;
	COMMIT;
	SET AUTOCOMMIT=1;
    SELECT status_id, status_desc FROM insert_record_status where status_id = curr_status_id;
    DEALLOCATE PREPARE stmt;
END $$

DELIMITER ;

-- SELECT * FROM queuing_table_cityc
-- CALL sp_patient_queue_staff_call_release_lock ('CITYC', 'CITYCS1')