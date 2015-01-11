DROP PROCEDURE IF EXISTS sp_update_patient_record;

DELIMITER $$
CREATE PROCEDURE sp_update_patient_record (
	IN in_patient_id int,
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
    IN in_isDeceased int(1),
    IN in_deceased_record_dtm VARCHAR(20)
)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    /*DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
        SET curr_status_id = 2;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	END;*/
	if (select count(*) from patient_record where patient_id = in_patient_id) <> 1 THEN
        SET curr_status_id = 5;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
    ELSEIF (select count(*) from patient_record where id_doc_type = in_id_doc_type AND id_doc_no = in_id_doc_no AND patient_id<>in_patient_id) <> 0 THEN
        SET curr_status_id = 6;
        SELECT * FROM insert_record_status where status_id = curr_status_id;    
	ELSE
		START TRANSACTION;
            UPDATE patient_record 
            SET
				chin_name = in_chin_name,
				eng_name = UPPER(in_eng_name),
				hashed_password = (CASE
					WHEN LENGTH(in_hashed_password) = 0 THEN hashed_password
                    ELSE in_hashed_password
                    END),
				id_doc_type = in_id_doc_type,
				id_doc_no = in_id_doc_no,
				phone_no = in_phone_no,
				dob = STR_TO_DATE(in_dob, '%d/%m/%Y'),
				sex = in_sex,
				isG6PD = in_isG6PD,
				addr = in_addr,
				allergic_drug_ids = in_allergic_drug_ids,
                isDeceased = in_isDeceased,
                deceased_record_dtm = STR_TO_DATE(in_deceased_record_dtm, '%d/%m/%Y')
			WHERE patient_id = in_patient_id;
		COMMIT;
        
        SELECT status_id, status_desc FROM insert_record_status where status_id = curr_status_id;
        
    END IF;
    
END $$

DELIMITER ;

-- select * from patient_record;
-- CALL sp_update_patient_record (1, '一', 'yat yat yat', '', 'HKID', '1', '1', '09/01/1990', 'M', 1, '123', '', 0, NULL);
-- DELETE FROM patient_record WHERE patient_id>0