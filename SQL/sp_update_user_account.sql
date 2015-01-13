DROP PROCEDURE IF EXISTS sp_update_user_account;

DELIMITER $$
CREATE PROCEDURE sp_update_user_account (
	IN in_user_id varchar(10),
    IN in_hashed_password char(64),
    IN in_chin_name varchar(21),
    IN in_eng_name varchar(70),
    IN in_reg_no varchar(20),
    IN in_isSuspended int(1)
)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
        SET curr_status_id = 2;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	END;
	if (select count(*) from user_account where user_id = in_user_id) <> 1 THEN
        SET curr_status_id = 8;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
    ELSEIF (select count(*) from user_account where reg_no = in_reg_no AND reg_no IS NOT NULL AND LENGTH(reg_no)<>0) > 0 THEN
        SET curr_status_id = 10;
        SELECT * FROM insert_record_status where status_id = curr_status_id;    
	ELSE
		START TRANSACTION;
            UPDATE user_account 
            SET
				hashed_password = CASE
					WHEN LENGTH(in_hashed_password) = 0 THEN hashed_password
                    ELSE in_hashed_password
                    END,
				chin_name = in_chin_name,
				eng_name = in_eng_name,
				reg_no = in_reg_no,
				isSuspended = in_isSuspended
			WHERE user_id = in_user_id;
		COMMIT;
        
        SELECT status_id, status_desc FROM insert_record_status where status_id = curr_status_id;
        
    END IF;
    
END $$

DELIMITER ;

-- select * from patient_record;
-- CALL sp_update_patient_record (1, '一', 'yat yat yat', '', 'HKID', '1', '1', '09/01/1990', 'M', 1, '123', '', 0, NULL);
-- DELETE FROM patient_record WHERE patient_id>0