DROP PROCEDURE IF EXISTS sp_update_clinic;

DELIMITER $$
CREATE PROCEDURE sp_update_clinic (
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
	if (select count(*) from clinic where clinic_id = in_clinic_id) <> 1 THEN
        SET curr_status_id = 8;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	ELSE
		-- SET pid = get_new_patient_id();
		START TRANSACTION;
            UPDATE clinic
            SET
				clinic_chin_name = in_clinic_chin_name,
				clinic_eng_name =UPPER(in_clinic_eng_name),
				clinic_addr = in_clinic_addr,
				clinic_phone_no = in_clinic_phone_no,
				isSuspended = in_isSuspended
			WHERE clinic_id = in_clinic_id;
		COMMIT;
        
        SELECT status_id, status_desc FROM insert_record_status where status_id = curr_status_id;
        
    END IF;
    
END $$

DELIMITER ;

-- select * from patient_record;
-- CALL sp_insert_patient_record ('一', 'yat', '26d6a8ad97c75ffc548f6873e5e93ce475479e3e1a1097381e54221fb53ec1d2', 'HKID', '2', '1', '09/01/2015', 'M', 1, '123', '101001')
-- DELETE FROM patient_record WHERE patient_id>0