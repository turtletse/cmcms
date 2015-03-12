DROP PROCEDURE IF EXISTS sp_insert_clinic;

DELIMITER $$
CREATE PROCEDURE sp_insert_clinic (
	IN in_clinic_id varchar(10),
    IN in_clinic_chin_name varchar(60),
    IN in_clinic_eng_name varchar(255),
    IN in_clinic_addr varchar(1000),
    IN in_clinic_phone_no varchar(30),
    IN in_isSuspended int(1)
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
	if (select count(*) from clinic where clinic_id = in_clinic_id) > 0 THEN
        SET curr_status_id = 7;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	ELSE
		-- SET pid = get_new_patient_id();
        SET AUTOCOMMIT = 0;
		START TRANSACTION;
            INSERT INTO clinic (
				clinic_id,
				clinic_chin_name,
				clinic_eng_name,
				clinic_addr,
				clinic_phone_no,
				isSuspended,
                last_update_dtm)
			VALUES (
				UPPER(in_clinic_id),
				in_clinic_chin_name,
				UPPER(in_clinic_eng_name),
				in_clinic_addr,
				in_clinic_phone_no,
				in_isSuspended,
                sysdate(3)
            );
			
            CALL cmcis.clinic_pharm_mapping_update_by_cmcms(UPPER(in_clinic_id), in_clinic_chin_name, UPPER(in_clinic_eng_name), in_clinic_addr, in_clinic_phone_no);
        COMMIT;
        SET AUTOCOMMIT = 1;
        SELECT status_id, status_desc FROM insert_record_status where status_id = curr_status_id;
        
    END IF;
    
END $$

DELIMITER ;

-- select * from patient_record;
-- CALL sp_insert_patient_record ('一', 'yat', '26d6a8ad97c75ffc548f6873e5e93ce475479e3e1a1097381e54221fb53ec1d2', 'HKID', '2', '1', '09/01/2015', 'M', 1, '123', '101001')
-- DELETE FROM patient_record WHERE patient_id>0