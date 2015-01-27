DROP PROCEDURE IF EXISTS sp_patient_queue_doctor_priority_consultation;

DELIMITER $$
CREATE PROCEDURE sp_patient_queue_doctor_priority_consultation (
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

	SET AUTOCOMMIT=0;
	START TRANSACTION;
		SET @sql_str = CONCAT('SELECT parm_value into @tablock FROM system_parm WHERE parm_name =''',tabname,'_LOCK'' FOR UPDATE');
		PREPARE stmt FROM @sql_str;
		EXECUTE stmt;
		IF @tablock IS NULL OR @tablock = in_moic_id THEN
			SET @sql_str = CONCAT('UPDATE system_parm SET parm_value =''', in_moic_id,''' WHERE parm_name = ''',tabname,'_LOCK''');
			PREPARE stmt FROM @sql_str;
			EXECUTE stmt;
			COMMIT;
			SET @sql_str = CONCAT('UPDATE ', tabname, ' SET patient_status = 30, doctor_in_charge =''', in_moic_id,'''WHERE (patient_id = ', in_patient_id, ' AND patient_status IN (0, 40)) OR (patient_id = ', in_patient_id, ' AND patient_status = 30 AND doctor_in_charge=''', in_moic_id, ''')');
			PREPARE stmt FROM @sql_str;
			EXECUTE stmt;
			IF (SELECT ROW_COUNT()) > 0 THEN
				SET curr_status_id = 0;
			ELSE
				SET curr_status_id = 12;
			END IF;
			SELECT status_id, status_desc FROM insert_record_status where status_id = curr_status_id;
			CALL sp_patient_queue_staff_call_release_lock(in_clinic_id, in_moic_id);
		ELSE
			SET curr_status_id = 15;
			SELECT status_id, status_desc FROM insert_record_status where status_id = curr_status_id;
		END IF;
	COMMIT;
	SET AUTOCOMMIT=1;
	
    DEALLOCATE PREPARE stmt;
END $$

DELIMITER ;

-- CALL sp_patient_queue_to_priority_consultation (2, 'CITYC', 'CSM')
-- CALL sp_patient_queue_to_priority_consultation (2, 'CITYC', 'CITYCD1')
-- CALL sp_patient_queue_doctor_priority_consultation (2, 'CITYC', 'CSM')
