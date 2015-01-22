DROP PROCEDURE IF EXISTS sp_get_patient_queue_for_waitingList;

DELIMITER $$
CREATE PROCEDURE sp_get_patient_queue_for_waitingList (
    IN in_clinic_id VARCHAR(10)
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
		SET @sql_str = CONCAT('CREATE TABLE ', tabname, ' (patient_id int, enter_dtm DATETIME, missed_call int default 0, patient_status int default 0, doctor_in_charge VARCHAR(10) DEFAULT NULL);');
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
    SET @cnt = 0;
	SET @sql_str = CONCAT('SELECT @cnt=@cnt+1 seq, patient_id, chin_name, eng_name, sex, dob, enter_dtm, patient_status, doctor_in_charge FROM ', tabname,' NATURAL JOIN patient_record ORDER BY enter_dtm asc;');
    PREPARE stmt FROM @sql_str;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
END $$

DELIMITER ;



-- CALL sp_enter_patient_queue(1, 'CITYC');
-- DROP TABLE queuing_table_CITYC;
-- SELECT * FROM SYSTEM_PARM
-- SELECT * FROM queuing_table_CITYC;