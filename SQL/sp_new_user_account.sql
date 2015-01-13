DROP PROCEDURE IF EXISTS sp_new_user_account;

DELIMITER $$
CREATE PROCEDURE sp_new_user_account (
	IN in_user_id varchar(10),
    IN in_chin_name varchar(21),
    IN in_eng_name varchar(70),
    IN in_reg_no varchar(20),
    IN in_hashed_password char(64),
    IN in_clinic_id varchar(10),
    IN in_user_role_id int,
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
	if (select count(*) from user_account where user_id = in_user_id) > 0 THEN
        SET curr_status_id = 9;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	ELSEIF (select count(*) from user_account where reg_no = in_reg_no AND reg_no IS NOT NULL AND LENGTH(reg_no)<>0) > 0 THEN
        SET curr_status_id = 10;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	ELSE
		-- SET pid = get_new_patient_id();
		START TRANSACTION;
            INSERT INTO user_account (
				user_id,
				chin_name,
				eng_name,
				reg_no,
				hashed_password,
                isSuspended)
			VALUES (
				in_user_id,
				in_chin_name,
				UPPER(in_eng_name),
				CASE
					WHEN LENGTH(in_reg_no)=0 THEN NULL
                    ELSE in_reg_no
				END,
				in_hashed_password,
                in_isSuspended
            );
            
            INSERT INTO user_clinic_role_mapping (
				user_id,
				clinic_id,
				user_role_id)
			VALUES (
				in_user_id,
				in_clinic_id,
				in_user_role_id
            );
            
		COMMIT;
        
        SELECT status_id, status_desc FROM insert_record_status where status_id = curr_status_id;
        
    END IF;
    
END $$

DELIMITER ;

-- select * from patient_record;
-- CALL sp_insert_patient_record ('一', 'yat', '26d6a8ad97c75ffc548f6873e5e93ce475479e3e1a1097381e54221fb53ec1d2', 'HKID', '2', '1', '09/01/2015', 'M', 1, '123', '101001')
-- DELETE FROM patient_record WHERE patient_id>0