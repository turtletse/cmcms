DROP PROCEDURE IF EXISTS sp_patient_queue_for_waitingList_get;

DELIMITER $$
CREATE PROCEDURE sp_patient_queue_for_waitingList_get (
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
    SET @cnt = 0;
	SET @sql_str = CONCAT('SELECT x.*, @cnt:=@cnt+1 seq FROM (SELECT patient_id, patient_record.chin_name chin_name, patient_record.eng_name eng_name, patient_record.sex sex, DATE_FORMAT(patient_record.dob, ''%d/%m/%Y'') dob, DATE_FORMAT(enter_dtm, ''%d/%m/%Y %T'') enter_dtm, status_desc, CONCAT_WS(''/'', user_account.chin_name, doctor_in_charge) MOIC FROM ', tabname,' NATURAL JOIN patient_record JOIN patient_status ON patient_status = status_id LEFT JOIN user_account ON doctor_in_charge = user_id ORDER BY ', tabname,'.enter_dtm asc) x;');
    PREPARE stmt FROM @sql_str;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
END $$

DELIMITER ;
SET @cnt=0;

-- CALL sp_get_patient_queue_for_waitingList('CITYC');


