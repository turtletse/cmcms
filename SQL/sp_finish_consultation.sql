delimiter $$
DROP procedure if EXISTS sp_finish_consultation $$
CREATE PROCEDURE sp_finish_consultation (IN in_cons_id INT)
BEGIN
    DECLARE pat_id INT DEFAULT 0;
    DECLARE tabname VARCHAR(255);
    DECLARE curr_status_id INT DEFAULT 0;
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
		SET curr_status_id = 2;
		SELECT * FROM insert_record_status where status_id = curr_status_id;
	END;
    
	SELECT patient_id, CONCAT('queuing_table_',clinic_id) INTO pat_id, tabname FROM consultation_record WHERE cons_id = in_cons_id;
    
    SET AUTOCOMMIT = 0;
    START TRANSACTION;
		UPDATE consultation_record SET isFinished = 2 WHERE cons_id = in_cons_id;
		IF (SELECT ROW_COUNT()) = 0 THEN
			SET curr_status_id = 8;
            ROLLBACK;
            SELECT * FROM insert_record_status where status_id = curr_status_id;
		ELSE
			SET @sql_str = CONCAT('DELETE FROM ', tabname, ' WHERE patient_id = ', pat_id);
			PREPARE stmt FROM @sql_str;
			EXECUTE stmt;
        END IF;
	COMMIT;
    SELECT * FROM insert_record_status where status_id = curr_status_id;
END $$
delimiter ;

-- CALL sp_dosage_unit_combo_get ();