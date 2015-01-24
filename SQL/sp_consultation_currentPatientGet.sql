DROP PROCEDURE IF EXISTS sp_consultation_currentPatientGet;

DELIMITER $$
CREATE PROCEDURE sp_consultation_currentPatientGet (
    IN in_clinic_id VARCHAR(10),
    IN in_moic_id VARCHAR(10)
)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    DECLARE tabname VARCHAR(100);
    DECLARE allergic_drug VARCHAR(1000);
    
    /*DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
        SET curr_status_id = 2;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	END;*/
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
    
	SET @sql_str = CONCAT('SELECT patient_id INTO @patID FROM ', tabname, ' WHERE patient_status = 30 AND doctor_in_charge = ''', in_moic_id, ''';');
	PREPARE stmt FROM @sql_str;
	EXECUTE stmt;
	SELECT allergic_drug_ids INTO allergic_drug FROM patient_record WHERE patient_id = @patID;
	IF (allergic_drug IS NOT NULL) THEN
		CALL split(allergic_drug, '||');
		DELETE FROM splitResult WHERE split_value = '' OR split_value is null;
		DROP TEMPORARY TABLE IF EXISTS allergicDrugList;
		CREATE TEMPORARY TABLE allergicDrugList
		SELECT drug_name FROM splitResult JOIN master_drug_list ON CAST(split_value AS UNSIGNED) = drug_id;
		DROP TEMPORARY TABLE splitResult;
		SELECT group_concat(drug_name SEPARATOR ', ') INTO allergic_drug FROM allergicDrugList;
        DROP TEMPORARY TABLE allergicDrugList;
	ELSE
		SET allergic_drug = '';
	END IF;
	SELECT patient_id, chin_name, eng_name, id_doc_no, sex, isPregnant, DATE_FORMAT(dob, '%d/%m/%Y') dob, YEAR(CURRENT_TIMESTAMP)-YEAR(dob)-(RIGHT(CURRENT_TIMESTAMP, 5) < RIGHT(dob, 5)) age, isG6PD, allergic_drug
	FROM patient_record
	WHERE patient_id = @patID;
	
    DEALLOCATE PREPARE stmt;
END $$

DELIMITER ;

-- CALL sp_consultation_currentPatientGet ('CITYC', 'CITYCD1')
-- SELECT * FROM splitResult
-- SELECT * FROM patient_record