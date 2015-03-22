CREATE SCHEMA `cmcis` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
GRANT SELECT ON cmcis.* TO 'cmcms'@'%';
GRANT SELECT ON cmcis.* TO 'cmpms'@'%';
GRANT CREATE TEMPORARY TABLES ON cmcis.* TO 'cmcms'@'%';
GRANT CREATE TEMPORARY TABLES ON cmcis.* TO 'cmpms'@'%';

DROP TABLE IF EXISTS clinic_pharm_mapping;
CREATE TABLE clinic_pharm_mapping(
	clinic_id VARCHAR(10) DEFAULT NULL,
	clinic_chin_name VARCHAR(60) DEFAULT NULL,
	clinic_eng_name VARCHAR(255) DEFAULT NULL,
	clinic_addr VARCHAR(1000) DEFAULT NULL,
	clinic_phone_no VARCHAR(30) DEFAULT NULL,
	pharm_id VARCHAR(10) DEFAULT NULL,
	pharm_chin_name VARCHAR(60) DEFAULT NULL,
	pharm_eng_name VARCHAR(255) DEFAULT NULL,
	pharm_addr VARCHAR(1000) DEFAULT NULL,
	pharm_phone_no VARCHAR(30) DEFAULT NULL
);
CREATE INDEX clinic_pharm_mapping_x1 ON clinic_pharm_mapping(clinic_id);
CREATE INDEX clinic_pharm_mapping_x2 ON clinic_pharm_mapping(pharm_id);

DROP PROCEDURE IF EXISTS clinic_pharm_mapping_update_by_cmcms;
DELIMITER $$
CREATE PROCEDURE clinic_pharm_mapping_update_by_cmcms(
	IN in_clinic_id VARCHAR(10), 
	IN in_clinic_chin_name VARCHAR(60),
	IN in_clinic_eng_name VARCHAR(255),
	IN in_clinic_addr VARCHAR(1000),
	IN in_clinic_phone_no VARCHAR(30))
BEGIN
	DECLARE cnt INT DEFAULT 0;
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
		SET AUTOCOMMIT = 1;
		SET @update_status = 0;
	END;
	
	SET AUTOCOMMIT = 0;
	START TRANSACTION;
		SELECT COUNT(*) INTO cnt FROM clinic_pharm_mapping WHERE clinic_id = in_clinic_id;
		IF cnt = 0 THEN
			INSERT INTO clinic_pharm_mapping (clinic_id, clinic_chin_name, clinic_eng_name, clinic_addr, clinic_phone_no)
			VALUES (in_clinic_id, in_clinic_chin_name, in_clinic_eng_name, in_clinic_addr, in_clinic_phone_no);
		ELSE
			UPDATE clinic_pharm_mapping
			SET clinic_chin_name = in_clinic_chin_name,
				clinic_eng_name = in_clinic_eng_name,
				clinic_addr = in_clinic_addr,
				clinic_phone_no = in_clinic_phone_no
			WHERE clinic_id = in_clinic_id;
		END IF;
	COMMIT;
	SET AUTOCOMMIT = 1;
	SET @update_status = 1;
END $$
DELIMITER ;
GRANT EXECUTE ON PROCEDURE cmcis.clinic_pharm_mapping_update_by_cmcms TO 'cmcms'@'%';

DROP PROCEDURE IF EXISTS clinic_pharm_mapping_update_by_cmpms;
DELIMITER $$
CREATE PROCEDURE clinic_pharm_mapping_update_by_cmpms(
	IN in_clinic_id VARCHAR(10),
	IN in_pharm_id VARCHAR(10), 
	IN in_pharm_chin_name VARCHAR(60),
	IN in_pharm_eng_name VARCHAR(255),
	IN in_pharm_addr VARCHAR(1000),
	IN in_pharm_phone_no VARCHAR(30))
BEGIN
	DECLARE cnt INT DEFAULT 0;
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
		SET AUTOCOMMIT = 1;
		SET @update_status = 0;
	END;
	
	SET AUTOCOMMIT = 0;
	START TRANSACTION;
		SELECT COUNT(*) INTO cnt FROM clinic_pharm_mapping WHERE clinic_id = in_clinic_id;
		IF cnt = 0 THEN
			SET @update_status = -1;
		ELSE
			UPDATE clinic_pharm_mapping
			SET pharm_id = in_pharm_id,
				pharm_chin_name = in_pharm_chin_name,
				pharm_eng_name = in_pharm_eng_name,
				pharm_addr = in_pharm_addr,
				pharm_phone_no = in_pharm_phone_no
			WHERE clinic_id = in_clinic_id;
		END IF;
	COMMIT;
	SET AUTOCOMMIT = 1;
	SET @update_status = 1;
END $$
DELIMITER ;
GRANT EXECUTE ON PROCEDURE cmcis.clinic_pharm_mapping_update_by_cmpms TO 'cmpms'@'%';

DROP PROCEDURE IF EXISTS related_pharm_get;
DELIMITER $$
CREATE PROCEDURE related_pharm_get (IN in_clinic_id VARCHAR(10))
BEGIN
	DROP TEMPORARY TABLE IF EXISTS related_pharm;
	CREATE TEMPORARY TABLE related_pharm
	SELECT clinic_addr = pharm_addr isSame_Location, pharm_id, pharm_chin_name, pharm_addr, pharm_phone_no
	FROM clinic_pharm_mapping
	WHERE clinic_id = in_clinic_id;
	IF (SELECT COUNT(*) FROM related_pharm)=0 THEN
		INSERT INTO related_pharm (isSame_Location) VALUES (1);
    END IF;
END $$
DELIMITER ;
GRANT EXECUTE ON PROCEDURE cmcis.related_pharm_get TO 'cmcms'@'%';

DROP PROCEDURE IF EXISTS related_clinics_get;
DELIMITER $$
CREATE PROCEDURE related_clinics_get (IN in_pharm_id VARCHAR(10))
BEGIN
	DROP TEMPORARY TABLE IF EXISTS related_clinics;
	CREATE TEMPORARY TABLE related_clinics
	SELECT clinic_addr = pharm_addr isSame_Location, clinic_id, clinic_chin_name, clinic_addr, clinic_phone_no
	FROM clinic_pharm_mapping
	WHERE pharm_id = in_pharm_id;
END $$
DELIMITER ;
GRANT EXECUTE ON PROCEDURE cmcis.related_clinics_get TO 'cmpms'@'%';

DROP TABLE IF EXISTS common_user;
CREATE TABLE common_user(
	user_id VARCHAR(10),
	hashed_password CHAR(64),
	chin_name VARCHAR(21),
	eng_name VARCHAR(70),
    last_update_dtm DATETIME(3)
);
CREATE INDEX common_user_x1 ON common_user(user_id);

/*DROP PROCEDURE IF EXISTS common_user_get;
DELIMITER $$
CREATE PROCEDURE common_user_get(IN in_user_id VARCHAR(10))
BEGIN
		DROP TEMPORARY TABLE IF EXISTS tmp_common_user_get_result;
		CREATE TEMPORARY TABLE tmp_common_user_get_result
		SELECT user_id, hashed_password, chin_name, eng_name, last_update_dtm
		FROM common_user
		WHERE user_id = in_user_id;
END $$
DELIMITER ;
GRANT EXECUTE ON PROCEDURE cmcis.common_user_get TO 'cmcms'@'%';
GRANT EXECUTE ON PROCEDURE cmcis.common_user_get TO 'cmpms'@'%';*/

DROP PROCEDURE IF EXISTS common_user_update;
DELIMITER $$
CREATE PROCEDURE common_user_update(
	IN in_user_id VARCHAR(10),
	IN in_hashed_password CHAR(64),
	IN in_chin_name VARCHAR(21),
	IN in_eng_name VARCHAR(70))
BEGIN
	DECLARE cnt INT DEFAULT 0;
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
		SET AUTOCOMMIT = 1;
		SET @update_status = 0;
	END;
	
    IF (in_user_id <> 'SYSADM') THEN
		SET AUTOCOMMIT = 0;
		START TRANSACTION;
			SELECT COUNT(*) INTO cnt FROM common_user WHERE user_id = in_user_id;
			IF cnt = 0 THEN
				INSERT INTO common_user (user_id, hashed_password, chin_name, eng_name, last_update_dtm)
				VALUES (in_user_id, in_hashed_password, in_chin_name, in_eng_name, sysdate(3));
			ELSE
				UPDATE common_user
				SET hashed_password = in_hashed_password,
					chin_name = in_chin_name,
					eng_name = in_eng_name,
					last_update_dtm = sysdate(3)
				WHERE user_id = in_user_id;
			END IF;
		COMMIT;
		SET AUTOCOMMIT = 1;
	END IF;
	SET @update_status = 1;
END $$
DELIMITER ;
GRANT EXECUTE ON PROCEDURE cmcis.common_user_update TO 'cmcms'@'%';
GRANT EXECUTE ON PROCEDURE cmcis.common_user_update TO 'cmpms'@'%';




DROP TABLE IF EXISTS common_prescribe_drug_list;
CREATE TABLE common_prescribe_drug_list(
	drug_id int,
	sub_drug_id INT,
    drug_name varchar(30)
);
CREATE INDEX common_prescribe_drug_list_x1 ON common_prescribe_drug_list(drug_id, sub_drug_id);

DROP PROCEDURE IF EXISTS common_prescribe_drug_list_update_by_cmcms;
DELIMITER $$
CREATE PROCEDURE common_prescribe_drug_list_update_by_cmcms(IN in_drug_id INT, IN in_sub_drug_id INT(2), IN in_drug_name VARCHAR(30))
BEGIN
	DECLARE cnt INT DEFAULT 0;
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
		SET AUTOCOMMIT = 1;
		SET @update_status = 0;
	END;
	
	SET AUTOCOMMIT = 0;
	START TRANSACTION;
		SELECT COUNT(*) INTO cnt FROM common_prescribe_drug_list WHERE drug_id = in_drug_id AND sub_drug_id = in_sub_drug_id;
		IF cnt = 0 THEN
			INSERT INTO common_prescribe_drug_list (drug_id, sub_drug_id, drug_name)
			VALUES (in_drug_id, in_sub_drug_id, in_drug_name);
		ELSE
			UPDATE common_prescribe_drug_list
			SET drug_name = in_drug_name
			WHERE drug_id = in_drug_id 
				AND sub_drug_id = in_sub_drug_id;
		END IF;
	COMMIT;
	SET AUTOCOMMIT = 1;
	SET @update_status = 1;
END $$
DELIMITER ;
GRANT EXECUTE ON PROCEDURE cmcis.common_prescribe_drug_list_update_by_cmcms TO 'cmcms'@'%';




DROP PROCEDURE IF EXISTS sp_get_prescription_by_id;
DELIMITER $$
CREATE PROCEDURE sp_get_prescription_by_id(IN in_pres_id INT, IN in_nDose INT)
BEGIN
	DECLARE isIssuedPres INT DEFAULT 0;
    DECLARE factor DECIMAL(8,4) DEFAULT 1;
    DECLARE smaller_unit INT DEFAULT 0;
    DECLARE done INT DEFAULT FALSE;
    DECLARE curr_drug_id INT;
    DECLARE curr_sub_drug_id INT;
    DECLARE cur1 CURSOR FOR SELECT drug_id, sub_drug_id FROM result_prescription;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
    
    DROP TEMPORARY TABLE IF EXISTS result_prescription;
    CREATE TEMPORARY TABLE result_prescription(
		drug_id INT,
        sub_drug_id INT,
        drug_name VARCHAR(255),
        dosage DECIMAL(12,4),
        unit_id INT,
        unit_desc VARCHAR(255),
        dose INT,
        total_amt DECIMAL(24,4),
        unit VARCHAR(255)
	);
    
    SELECT 1 INTO isIssuedPres
    FROM cmcms.consultation_record
    WHERE pres_id REGEXP CONCAT('(^|[0-9]\\|{2})', in_pres_id, '(\\|{2}[0-9]|$)')
		AND isFinished = 2;
    
    IF isIssuedPres = 1 THEN
		INSERT INTO result_prescription (drug_id, sub_drug_id, drug_name, dosage, unit_id, dose)
		SELECT drug_id, sub_drug_id, drug_name, dosage, unit, in_nDose
		FROM cmcms.prescription_dt
		WHERE pres_id = in_pres_id;
        
        OPEN cur1;
            REPEAT
				FETCH cur1 INTO curr_drug_id, curr_sub_drug_id;
				IF NOT done THEN
					SET factor = 1;
                    SET smaller_unit = 0;
					REPEAT
						SELECT decrease_to_id INTO smaller_unit FROM cmcms.dosage_unit WHERE unit_id = (SELECT unit_id FROM result_prescription WHERE drug_id = curr_drug_id AND sub_drug_id = curr_sub_drug_id);
						IF smaller_unit <> 0 THEN
							SELECT promote_val*factor INTO factor FROM cmcms.dosage_unit WHERE unit_id = smaller_unit;
                            UPDATE result_prescription, cmcms.dosage_unit
                            SET result_prescription.unit_id = dosage_unit.unit_id
                            WHERE dosage_unit.unit_id = smaller_unit
								AND result_prescription.drug_id = curr_drug_id
								AND result_prescription.sub_drug_id = curr_sub_drug_id;
						END IF;
					UNTIL smaller_unit = 0 END REPEAT;
					IF (SELECT unit_id FROM result_prescription WHERE drug_id = curr_drug_id AND sub_drug_id = curr_sub_drug_id) = 50 THEN
						SET factor = factor/0.3779936375;
						UPDATE result_prescription
						SET unit_id = 10
						WHERE drug_id = curr_drug_id
							AND sub_drug_id = curr_sub_drug_id;
					END IF;
                    UPDATE result_prescription
					SET dosage = dosage * factor
					WHERE drug_id = curr_drug_id
						AND sub_drug_id = curr_sub_drug_id;
				END IF;
			UNTIL done END REPEAT;
		CLOSE cur1;
        
        UPDATE result_prescription r, cmcms.dosage_unit d
        SET r.unit_desc = d.unit_desc, total_amt = dosage * dose, r.unit = d.unit_desc
        WHERE r.unit_id = d.unit_id;
	END IF;
END $$
DELIMITER ;
GRANT EXECUTE ON PROCEDURE cmcis.sp_get_prescription_by_id TO 'cmcms'@'%';
GRANT EXECUTE ON PROCEDURE cmcis.sp_get_prescription_by_id TO 'cmpms'@'%';




DROP PROCEDURE IF EXISTS sp_get_prescription_by_id_for_check_stock;
DELIMITER $$
CREATE PROCEDURE sp_get_prescription_by_id_for_check_stock(IN in_pres_id INT)
BEGIN
	DECLARE isIssuedPres INT DEFAULT 0;
    DECLARE factor DECIMAL(8,4) DEFAULT 1;
    DECLARE smaller_unit INT DEFAULT 0;
    DECLARE done INT DEFAULT FALSE;
    DECLARE curr_drug_id INT;
    DECLARE curr_sub_drug_id INT;
    DECLARE cur1 CURSOR FOR SELECT drug_id, sub_drug_id FROM result_prescription;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
    
    DROP TEMPORARY TABLE IF EXISTS result_prescription;
    CREATE TEMPORARY TABLE result_prescription(
		drug_id INT,
        sub_drug_id INT,
        drug_name VARCHAR(255),
        dosage DECIMAL(12,4),
        unit_id INT,
        unit_desc VARCHAR(255),
        dose INT,
        total_amt DECIMAL(24,4),
        unit VARCHAR(255)
	);
    
    SELECT 1 INTO isIssuedPres
    FROM cmcms.consultation_record
    WHERE pres_id REGEXP CONCAT('(^|[0-9]\\|{2})', in_pres_id, '(\\|{2}[0-9]|$)');
    
    IF isIssuedPres = 1 THEN
		INSERT INTO result_prescription (drug_id, sub_drug_id, drug_name, dosage, unit_id, dose)
		SELECT drug_id, sub_drug_id, drug_name, dosage, unit, no_of_dose
		FROM cmcms.prescription_dt JOIN cmcms.prescription ON prescription_dt.pres_id = prescription.pres_id
		WHERE prescription_dt.pres_id = in_pres_id;
        
        OPEN cur1;
            REPEAT
				FETCH cur1 INTO curr_drug_id, curr_sub_drug_id;
				IF NOT done THEN
					SET factor = 1;
                    SET smaller_unit = 0;
					REPEAT
						SELECT decrease_to_id INTO smaller_unit FROM cmcms.dosage_unit WHERE unit_id = (SELECT unit_id FROM result_prescription WHERE drug_id = curr_drug_id AND sub_drug_id = curr_sub_drug_id);
						IF smaller_unit <> 0 THEN
							SELECT promote_val*factor INTO factor FROM cmcms.dosage_unit WHERE unit_id = smaller_unit;
                            UPDATE result_prescription, cmcms.dosage_unit
                            SET result_prescription.unit_id = dosage_unit.unit_id
                            WHERE dosage_unit.unit_id = smaller_unit
								AND result_prescription.drug_id = curr_drug_id
								AND result_prescription.sub_drug_id = curr_sub_drug_id;
						END IF;
					UNTIL smaller_unit = 0 END REPEAT;
					IF (SELECT unit_id FROM result_prescription WHERE drug_id = curr_drug_id AND sub_drug_id = curr_sub_drug_id) = 50 THEN
						SET factor = factor/0.3779936375;
						UPDATE result_prescription
						SET unit_id = 10
						WHERE drug_id = curr_drug_id
							AND sub_drug_id = curr_sub_drug_id;
					END IF;
                    UPDATE result_prescription
					SET dosage = dosage * factor
					WHERE drug_id = curr_drug_id
						AND sub_drug_id = curr_sub_drug_id;
				END IF;
			UNTIL done END REPEAT;
		CLOSE cur1;
        
        UPDATE result_prescription r, cmcms.dosage_unit d
        SET r.unit_desc = d.unit_desc, total_amt = dosage * dose, r.unit = d.unit_desc
        WHERE r.unit_id = d.unit_id;
	END IF;
END $$
DELIMITER ;
GRANT EXECUTE ON PROCEDURE cmcis.sp_get_prescription_by_id_for_check_stock TO 'cmcms'@'%';
GRANT EXECUTE ON PROCEDURE cmcis.sp_get_prescription_by_id_for_check_stock TO 'cmpms'@'%';





DROP PROCEDURE IF EXISTS sp_get_prescription_by_pres_barcode;
DELIMITER $$
CREATE PROCEDURE sp_get_prescription_by_pres_barcode(IN in_barcode VARCHAR(255))
BEGIN
	DECLARE b_clinic_id VARCHAR(10);
    DECLARE b_dr_id VARCHAR(10);
    DECLARE b_pat_id INT;
    DECLARE b_cons_id INT;
    DECLARE b_pres_id INT;
    DECLARE b_last_update_dtm VARCHAR(255);
    
    SET b_clinic_id = cmcms.stringSplit(in_barcode, '/', 1);
    SET b_dr_id = cmcms.stringSplit(in_barcode, '/', 2);
    SET b_pat_id = CAST(cmcms.stringSplit(in_barcode, '/', 3) AS UNSIGNED);
    SET b_cons_id = CAST(cmcms.stringSplit(in_barcode, '/', 4) AS UNSIGNED);
    SET b_pres_id = CAST(cmcms.stringSplit(in_barcode, '/', 5) AS UNSIGNED);
    SET b_last_update_dtm = cmcms.stringSplit(in_barcode, '/', 6);
    
	CALL sp_get_prescription_by_id(
		(SELECT b_pres_id 
			FROM cmcms.consultation_record 
            WHERE clinic_id = b_clinic_id 
				AND dr_id = b_dr_id 
                AND patient_id = b_pat_id
                AND cons_id = b_cons_id
                AND DATE_FORMAT(last_update_dtm, '%Y%m%d%H%i%s') = b_last_update_dtm
                AND pres_id REGEXP CONCAT('(^|[0-9]\\|{2})', b_pres_id, '(\\|{2}[0-9]|$)') 
                AND isFinished = 2),
        (SELECT no_of_dose FROM cmcms.prescription WHERE pres_id = b_pres_id));
    
END $$
DELIMITER ;
GRANT EXECUTE ON PROCEDURE cmcis.sp_get_prescription_by_pres_barcode TO 'cmcms'@'%';
GRANT EXECUTE ON PROCEDURE cmcis.sp_get_prescription_by_pres_barcode TO 'cmpms'@'%';




DROP PROCEDURE IF EXISTS sp_get_procedures_done_in_cons_by_pres_barcode;
DELIMITER $$
CREATE PROCEDURE sp_get_procedures_done_in_cons_by_pres_barcode(IN in_pharm_id VARCHAR(10), IN in_barcode VARCHAR(255))
BEGIN
	DECLARE b_clinic_id VARCHAR(10);
    DECLARE b_dr_id VARCHAR(10);
    DECLARE b_pat_id INT;
    DECLARE b_cons_id INT;
    DECLARE b_last_update_dtm VARCHAR(255);
    DECLARE cons INT DEFAULT 0;
    DECLARE acupt INT DEFAULT 0;
    
    SET b_clinic_id = cmcms.stringSplit(in_barcode, '/', 1);
    SET b_dr_id = cmcms.stringSplit(in_barcode, '/', 2);
    SET b_pat_id = CAST(cmcms.stringSplit(in_barcode, '/', 3) AS UNSIGNED);
    SET b_cons_id = CAST(cmcms.stringSplit(in_barcode, '/', 4) AS UNSIGNED);
    SET b_last_update_dtm = cmcms.stringSplit(in_barcode, '/', 6);
    
    DROP TEMPORARY TABLE IF EXISTS clinic_ids;
    CREATE TEMPORARY TABLE clinic_ids
    SELECT clinic_id
    FROM clinic_pharm_mapping
    WHERE pharm_id = in_pharm_id;
    
	SELECT 1, CASE WHEN acupuncture_code IS NULL OR LENGTH(TRIM(acupuncture_code))=0 THEN 0 ELSE 1 END INTO cons, acupt
	FROM cmcms.consultation_record 
	WHERE clinic_id = b_clinic_id 
		AND clinic_id IN (SELECT clinic_id FROM clinic_ids)
		AND dr_id = b_dr_id 
		AND patient_id = b_pat_id
		AND cons_id = b_cons_id
		AND DATE_FORMAT(last_update_dtm, '%Y%m%d%H%i%s') = b_last_update_dtm
		AND isFinished = 2;
    
    DROP TEMPORARY TABLE IF EXISTS procedure_done;
    CREATE TEMPORARY TABLE procedure_done(
		px_code INT,
        px_desc VARCHAR(255)
	);
    
    IF cons = 1 THEN
		INSERT INTO procedure_done
        VALUES (1, '診症');
    END IF;
    
    IF acupt = 1 THEN
		INSERT INTO procedure_done
        VALUES (2, '針灸');
    END IF;
    
END $$
DELIMITER ;
GRANT EXECUTE ON PROCEDURE cmcis.sp_get_procedures_done_in_cons_by_pres_barcode TO 'cmcms'@'%';
GRANT EXECUTE ON PROCEDURE cmcis.sp_get_procedures_done_in_cons_by_pres_barcode TO 'cmpms'@'%';




DROP PROCEDURE IF EXISTS sp_get_procedures_done_in_cons_by_pharm_id_cons_id;
DELIMITER $$
CREATE PROCEDURE sp_get_procedures_done_in_cons_by_pharm_id_cons_id(IN in_pharm_id VARCHAR(10), IN in_cons_id INT)
BEGIN
    DECLARE cons INT DEFAULT 0;
    DECLARE acupt INT DEFAULT 0;
    
    DROP TEMPORARY TABLE IF EXISTS clinic_ids;
    CREATE TEMPORARY TABLE clinic_ids
    SELECT clinic_id
    FROM clinic_pharm_mapping
    WHERE pharm_id = in_pharm_id;
    
    
    
	SELECT 1, CASE WHEN acupuncture_code IS NULL OR LENGTH(TRIM(acupuncture_code))=0 THEN 0 ELSE 1 END INTO cons, acupt
	FROM cmcms.consultation_record 
	WHERE clinic_id IN (SELECT clinic_id FROM clinic_ids)
		AND cons_id = in_cons_id
		AND isFinished = 2;
    
    DROP TEMPORARY TABLE IF EXISTS clinic_ids;
    
    DROP TEMPORARY TABLE IF EXISTS procedure_done;
    CREATE TEMPORARY TABLE procedure_done(
		px_code INT,
        px_desc VARCHAR(255)
	);
    
    IF cons = 1 THEN
		INSERT INTO procedure_done
        VALUES (1, '診症');
    END IF;
    
    IF acupt = 1 THEN
		INSERT INTO procedure_done
        VALUES (2, '針灸');
    END IF;
    
END $$
DELIMITER ;
GRANT EXECUTE ON PROCEDURE cmcis.sp_get_procedures_done_in_cons_by_pharm_id_cons_id TO 'cmcms'@'%';
GRANT EXECUTE ON PROCEDURE cmcis.sp_get_procedures_done_in_cons_by_pharm_id_cons_id TO 'cmpms'@'%';