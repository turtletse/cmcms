DROP procedure if EXISTS sp_amd_role_user_account_get;
delimiter $$
CREATE PROCEDURE sp_amd_role_user_account_get ()
BEGIN
	select
		user_id,
		hashed_password,
		chin_name,
		eng_name,
		reg_no,
		last_logout_dtm,
		last_logout_clinic_id,
		isSuspended
	from user_account natural join user_clinic_role_mapping
	ORDER BY user_id;
END $$
delimiter ;

-- CALL sp_amd_role_user_account_get();