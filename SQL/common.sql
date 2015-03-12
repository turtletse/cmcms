-- CREATE SCHEMA `cmcis` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
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
		SELECT COUNT(*) INTO cnt FROM clinic_pharm_mapping WHERE pharm_id = in_pharm_id;
		IF cnt = 0 THEN
			SET @update_status = -1;
		ELSE
			UPDATE clinic_pharm_mapping
			SET pharm_chin_name = in_pharm_chin_name,
				pharm_eng_name = in_pharm_eng_name,
				pharm_addr = in_pharm_addr,
				pharm_phone_no = in_pharm_phone_no
			WHERE pharm_id = in_pharm_id;
		END IF;
	COMMIT;
	SET AUTOCOMMIT = 1;
	SET @update_status = 1;
END $$
DELIMITER ;
GRANT EXECUTE ON PROCEDURE cmcis.clinic_pharm_mapping_update_by_cmpms TO 'cmpms'@'%';




DROP TABLE IF EXISTS common_user;
CREATE TABLE common_user(
	user_id VARCHAR(10),
	hashed_password CHAR(64),
	chin_name VARCHAR(21),
	eng_name VARCHAR(70),
    update_dtm DATETIME(3)
);
CREATE INDEX common_user_x1 ON common_user(user_id);

DROP PROCEDURE IF EXISTS common_user_get;
DELIMITER $$
CREATE PROCEDURE common_user_get(IN in_user_id VARCHAR(10))
BEGIN
		DROP TEMPORARY TABLE IF EXISTS tmp_common_user_get_result;
		CREATE TEMPORARY TABLE tmp_common_user_get_result
		SELECT user_id, hashed_password, chin_name, eng_name, update_dtm
		FROM common_user
		WHERE user_id = in_user_id;
END $$
DELIMITER ;
GRANT EXECUTE ON PROCEDURE cmcis.common_user_get TO 'cmcms'@'%';
GRANT EXECUTE ON PROCEDURE cmcis.common_user_get TO 'cmpms'@'%';

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
	
	SET AUTOCOMMIT = 0;
	START TRANSACTION;
		SELECT COUNT(*) INTO cnt FROM common_user WHERE user_id = in_user_id;
		IF cnt = 0 THEN
			INSERT INTO common_user (user_id, hashed_password, chin_name, eng_name, update_dtm)
			VALUES (in_user_id, in_hashed_password, in_chin_name, in_eng_name, sysdate(3));
		ELSE
			UPDATE common_user
			SET hashed_password = in_hashed_password,
				chin_name = in_chin_name,
				eng_name = in_eng_name,
                update_dtm = sysdate(3)
			WHERE user_id = in_user_id;
		END IF;
	COMMIT;
	SET AUTOCOMMIT = 1;
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
