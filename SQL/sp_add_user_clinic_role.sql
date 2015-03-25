DROP procedure if EXISTS sp_add_user_clinic_role;
delimiter $$
CREATE PROCEDURE sp_add_user_clinic_role (IN in_user_id VARCHAR(10), IN in_clinic_id VARCHAR(10), IN in_role_id int)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
        SET curr_status_id = 2;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	END;
	if (select count(*) from user_clinic_role_mapping where user_id = in_user_id AND clinic_id = in_clinic_id AND user_role_id = in_role_id) >0 THEN
        SET curr_status_id = 1;
        SELECT * FROM insert_record_status where status_id = curr_status_id; 
	ELSEIF in_role_id = 20 AND (SELECT IFNULL(LENGTH(TRIM(reg_no)), 0) FROM user_account WHERE user_id = in_user_id) = 0 THEN
		SET curr_status_id = 22;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	ELSE
		START TRANSACTION;
            INSERT INTO user_clinic_role_mapping(
				user_id,
                clinic_id,
                user_role_id
			)VALUES(
				in_user_id,
                in_clinic_id,
                in_role_id
			);
		COMMIT;
        
        SELECT status_id, status_desc FROM insert_record_status where status_id = curr_status_id;
        
    END IF;
END $$
delimiter ;

-- CALL sp_granted_clinic_role_get('CITYCD1','CITYC', 30);
-- CALL sp_granted_clinic_role_get ('CITYCS1','ALL', 40);