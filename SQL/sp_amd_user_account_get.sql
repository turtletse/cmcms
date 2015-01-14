DROP procedure if EXISTS sp_amd_user_account_get;
delimiter $$
CREATE PROCEDURE sp_amd_user_account_get (IN in_clinic_id VARCHAR(10), IN in_role_id int)
BEGIN
	select distinct
		user_id,
		hashed_password,
		chin_name,
		eng_name,
		reg_no,
		last_logout_dtm,
		last_logout_clinic_id,
		isSuspended
	from user_account natural join user_clinic_role_mapping
    WHERE (in_role_id = 40 OR (in_role_id <> 40 AND clinic_id = in_clinic_id))
	ORDER BY user_id;
END $$
delimiter ;

-- CALL sp_amd_user_account_get('CITYC', 3);
-- CALL sp_amd_user_account_get ('ALL', 40);