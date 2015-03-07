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
    DECLARE isPreg INT;
    DECLARE isG6PD INT;
    DECLARE curr_pres_id INT;
    DECLARE done INT DEFAULT FALSE;
    DECLARE cur2 CURSOR FOR SELECT pres_id FROM tmp_pres_id_list;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
    
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
    
    SELECT patient_record.isPregnant, patient_record.isG6PD INTO isPreg, isG6PD FROM patient_record WHERE patient_id = in_patient_id;
    
    DROP TEMPORARY TABLE IF EXISTS pres_with_contraindication;
    CREATE TEMPORARY TABLE pres_with_contraindication (pres_id INT);
    CALL split(in_pres_id, '||');
    
    DROP TEMPORARY TABLE IF EXISTS tmp_pres_id_list;
    
    CREATE TEMPORARY TABLE tmp_pres_id_list
    SELECT CAST(split_value AS UNSIGNED) pres_id
    FROM splitResult
    WHERE split_value <> '';
    
    DROP TEMPORARY TABLE IF EXISTS splitResult;
    
    OPEN cur2;
		REPEAT
			FETCH cur2 INTO curr_pres_id;
			IF NOT done THEN
				IF (prescription_safety_check(curr_pres_id, isPreg, isG6PD)) = 1 THEN
					INSERT INTO pres_with_contraindication (pres_id) VALUES (curr_pres_id);
                END IF;
			END IF;
		UNTIL done END REPEAT;
	CLOSE cur2;
    COMMIT;
    SET AUTOCOMMIT = 1;
    IF (SELECT COUNT(*) FROM pres_with_contraindication) = 0 THEN
		SELECT status_id, status_desc FROM insert_record_status where status_id = curr_status_id;
	ELSE
		SET curr_status_id = 19;
		SELECT status_id, CONCAT(status_desc, ':\n', (SELECT GROUP_CONCAT(pres_id SEPARATOR '\n') FROM pres_with_contraindication ORDER BY pres_id), '\n\n需要修改?') status_desc 
        FROM insert_record_status 
        where status_id = curr_status_id;
    END IF;
END $$

DELIMITER ;

-- CALL sp_save_consultation (9, 'CSM', 'CSM', 2, '2.2.16||2.2.19||2.3.113', '噴嚏; 喘鳴; 鼻塞; ', '2.6.2', '外風證; ', '3.1.7', '感冒; ', '14', '宜醫囑一')
-- SELECT * from consultation_record
-- CALL sp_pres_dt_get (1)
-- SELECT * FROM DEBUG_LOG ORDER BY log_dtm desc