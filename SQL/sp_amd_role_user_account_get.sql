DROP procedure if EXISTS sp_amd_role_user_account_get;
delimiter $$
CREATE PROCEDURE sp_amd_role_user_account_get ()
BEGIN
	IF isCmpmsExist() THEN
		INSERT INTO user_account (user_id, hashed_password, chin_name, eng_name, last_update_dtm)
        SELECT UPPER(user_id), hashed_password, chin_name, eng_name, last_update_dtm
        FROM cmcis.common_user
        WHERE UPPER(user_id) NOT IN (SELECT UPPER(user_id) FROM user_account);
        
        UPDATE user_account a, cmcis.common_user b
        SET a.hashed_password = b.hashed_password, 
            a.chin_name = b.chin_name, 
            a.eng_name = b.eng_name, 
            a.last_update_dtm = b.last_update_dtm
		WHERE UPPER(a.user_id) = UPPER(b.user_id) AND a.last_update_dtm<b.last_update_dtm;
		
    END IF;

	select distinct
		UPPER(user_id) user_id,
		hashed_password,
		chin_name,
		eng_name,
		reg_no,
		last_logout_dtm,
		last_logout_clinic_id,
		isSuspended
	from user_account -- natural join user_clinic_role_mapping
	ORDER BY user_id;
END $$
delimiter ;

-- CALL sp_amd_role_user_account_get();