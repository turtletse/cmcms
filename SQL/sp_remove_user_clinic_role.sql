DROP procedure if EXISTS sp_remove_user_clinic_role;
delimiter $$
CREATE PROCEDURE sp_remove_user_clinic_role (IN in_user_id VARCHAR(10), IN in_clinic_id VARCHAR(10), IN in_role_id int)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
        SET curr_status_id = 2;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	END;
	START TRANSACTION;
		DELETE FROM user_clinic_role_mapping
        WHERE user_id = in_user_id
        AND clinic_id = in_clinic_id
        AND user_role_id = in_role_id;
	COMMIT;
	
	SELECT status_id, status_desc FROM insert_record_status where status_id = curr_status_id;
END $$
delimiter ;

-- CALL sp_granted_clinic_role_get('CITYCD1','CITYC', 30);
-- CALL sp_granted_clinic_role_get ('CITYCS1','ALL', 40);