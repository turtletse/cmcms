DROP PROCEDURE IF EXISTS sp_insert_patient_record;

DELIMITER $$
CREATE PROCEDURE sp_insert_patient_record (
	IN in_chin_name varchar(21),
    IN in_eng_name varchar(70),
    IN in_hashed_password CHAR(64),
    IN in_id_doc_type varchar(10),
    IN in_id_doc_no varchar(20),
    IN in_phone_no varchar(13),
    IN in_dob VARCHAR(10),
    IN in_sex varchar(1),
    IN in_isG6PD INT(1),
    IN in_addr varchar(300),
    IN in_allergic_drug_ids varchar(1000),
    IN in_isPregnant INT(1)
)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    -- DECLARE pid INT;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
        SET curr_status_id = 2;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	END;
	if (select count(*) from patient_record where id_doc_type = in_id_doc_type and id_doc_no = in_id_doc_no) > 0 THEN
        SET curr_status_id = 6;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	ELSE
		-- SET pid = get_new_patient_id();
		START TRANSACTION;
            INSERT INTO patient_record (
				patient_id,
				chin_name,
				eng_name,
				hashed_password,
				id_doc_type,
				id_doc_no,
				phone_no,
				dob,
				sex,
				isG6PD,
				addr,
				allergic_drug_ids,
                isPregnant)
			VALUES (
				LAST_INSERT_ID(get_new_patient_id()),
                in_chin_name,
				UPPER(in_eng_name),
				in_hashed_password,
				in_id_doc_type,
				in_id_doc_no,
				in_phone_no,
				STR_TO_DATE(in_dob, '%d/%m/%Y'),
				in_sex,
				in_isG6PD,
				in_addr,
				in_allergic_drug_ids,
                in_isPregnant
            );
		COMMIT;
        
        SELECT status_id, CONCAT(status_desc, '\n病人編號: ', LAST_INSERT_ID()) status_desc FROM insert_record_status where status_id = curr_status_id;
        
    END IF;
    
END $$

DELIMITER ;

-- select * from patient_record;
-- CALL sp_insert_patient_record ('一', 'yat', '26d6a8ad97c75ffc548f6873e5e93ce475479e3e1a1097381e54221fb53ec1d2', 'HKID', '2', '1', '09/01/2015', 'M', 1, '123', '101001')
-- DELETE FROM patient_record WHERE patient_id>0