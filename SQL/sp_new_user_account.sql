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
    DECLARE update_dtm DATETIME(3);
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
	ELSEIF (select count(*) from cmcis.common_user where user_id = in_user_id) > 0 THEN
		INSERT INTO user_account(user_id, chin_name, eng_name, reg_no, hashed_password, isSuspended, last_update_dtm)
			SELECT user_id, chin_name, eng_name, '', hashed_password, 0, sysdate(3) FROM cmcis.common_user WHERE user_id = in_user_id;
		SET curr_status_id = 9;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	ELSEIF (select count(*) from user_account where reg_no = in_reg_no AND reg_no IS NOT NULL AND LENGTH(reg_no)<>0) > 0 THEN
        SET curr_status_id = 10;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	ELSE
		-- SET pid = get_new_patient_id();
        CALL cmcis.common_user_update(in_user_id, in_hashed_password, in_chin_name, UPPER(in_eng_name));
        SELECT last_update_dtm INTO update_dtm FROM cmcis.common_user WHERE user_id = in_user_id;
        SET AUTOCOMMIT = 0;
		START TRANSACTION;
            INSERT INTO user_account (
				user_id,
				chin_name,
				eng_name,
				reg_no,
				hashed_password,
                isSuspended,
                last_update_dtm)
			VALUES (
				in_user_id,
				in_chin_name,
				UPPER(in_eng_name),
				CASE
					WHEN LENGTH(in_reg_no)=0 THEN NULL
                    ELSE in_reg_no
				END,
				in_hashed_password,
                in_isSuspended,
                update_dtm
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
        
        SET AUTOCOMMIT = 1;
        
        SELECT status_id, status_desc FROM insert_record_status where status_id = curr_status_id;
        
    END IF;
    
END $$

DELIMITER ;

-- select * from patient_record;
-- CALL sp_insert_patient_record ('一', 'yat', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 'HKID', '2', '1', '09/01/2015', 'M', 1, '123', '101001')
-- DELETE FROM patient_record WHERE patient_id>0