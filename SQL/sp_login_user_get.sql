DROP procedure if EXISTS sp_login_user_get;
delimiter $$
CREATE PROCEDURE sp_login_user_get (
	IN in_user_id varchar(10),
    IN in_clinic_id varchar(10),
    IN in_role_id int
)
BEGIN
	DECLARE cmcis_update_dtm DATETIME(3);
    DECLARE cmcms_update_dtm DATETIME(3);
    DECLARE new_pw CHAR(64);
    DECLARE new_chi_name VARCHAR(21);
    DECLARE new_eng_name VARCHAR(70);
    
    IF (in_user_id<>'SYSADM') THEN
		SELECT last_update_dtm INTO cmcis_update_dtm FROM cmcis.common_user WHERE UPPER(user_id) = UPPER(in_user_id);
		SELECT last_update_dtm INTO cmcms_update_dtm FROM user_account WHERE UPPER(user_id) = UPPER(in_user_id);
		IF (cmcis_update_dtm IS NOT NULL AND cmcms_update_dtm IS NOT NULL) THEN
			IF (cmcis_update_dtm > cmcms_update_dtm) THEN
				SELECT hashed_password, chin_name, eng_name INTO new_pw, new_chi_name, new_eng_name FROM cmcis.common_user WHERE UPPER(user_id) = UPPER(in_user_id);
				UPDATE user_account
				SET hashed_password = new_pw,
					chin_name = new_chi_name,
					eng_name = new_eng_name,
					last_update_dtm = cmcis_update_dtm
				WHERE UPPER(user_id) = UPPER(in_user_id);
			ELSEIF(cmcms_update_dtm > cmcis_update_dtm) THEN
				SELECT hashed_password, chin_name, eng_name INTO new_pw, new_chi_name, new_eng_name FROM user_account WHERE UPPER(user_id) = UPPER(in_user_id);
				CALL cmcis.common_user_update(UPPER(in_user_id), new_pw, new_chi_name, new_eng_name);
				SELECT last_update_dtm INTO cmcis_update_dtm FROM cmcis.common_user WHERE UPPER(user_id) = UPPER(in_user_id);
				UPDATE user_account
				SET last_update_dtm = cmcis_update_dtm
				WHERE UPPER(user_id) = UPPER(in_user_id);
			END IF;
		ELSEIF (cmcis_update_dtm IS NULL AND cmcms_update_dtm IS NOT NULL) THEN
			SELECT hashed_password, chin_name, eng_name INTO new_pw, new_chi_name, new_eng_name FROM user_account WHERE UPPER(user_id) = UPPER(in_user_id);
			CALL cmcis.common_user_update(UPPER(in_user_id), new_pw, new_chi_name, new_eng_name);
			SELECT last_update_dtm INTO cmcis_update_dtm FROM cmcis.common_user WHERE UPPER(user_id) = UPPER(in_user_id);
			UPDATE user_account
			SET last_update_dtm = cmcis_update_dtm
			WHERE UPPER(user_id) = UPPER(in_user_id);
		ELSEIF (cmcis_update_dtm IS NOT NULL AND cmcms_update_dtm IS NULL) THEN
			SELECT hashed_password, chin_name, eng_name INTO new_pw, new_chi_name, new_eng_name FROM cmcis.common_user WHERE UPPER(user_id) = UPPER(in_user_id);
			SELECT last_update_dtm INTO cmcis_update_dtm FROM cmcis.common_user WHERE user_id = in_user_id;
            INSERT INTO user_account (user_id, hashed_password, chin_name, eng_name, last_update_dtm)
            VALUES (UPPER(in_user_id), new_pw, new_chi_name, new_eng_name, cmcis_update_dtm);
			/*UPDATE user_account
			SET hashed_password = new_pw,
				chin_name = new_chi_name,
				eng_name = new_eng_name,
				last_update_dtm = cmcis_update_dtm
			WHERE user_id = in_user_id;*/
		END IF;
	END IF;
    
	DROP TEMPORARY TABLE IF EXISTS result;
    CREATE TEMPORARY TABLE result
	select
		UPPER(user_account.user_id) user_id,
        hashed_password,
        chin_name,
        eng_name,
        reg_no,
        DATE_FORMAT(last_logout_dtm, '%d/%m/%Y %T') last_logout_dtm,
        last_logout_clinic_id,
        clinic_id current_login_clinic_id,
        min(user_role_id) current_login_role_id,
        isSuspended
	from user_account join user_clinic_role_mapping ON UPPER(user_account.user_id) = UPPER(user_clinic_role_mapping.user_id)
	where 
		UPPER(user_account.user_id) = UPPER(in_user_id)
        AND clinic_id = in_clinic_id
        AND (user_role_id = in_role_id OR user_role_id = 0)
        AND ((in_clinic_id = 'ALL' AND in_role_id = 40) OR (in_clinic_id <> 'ALL' AND in_role_id <> 40));
	SELECT * FROM RESULT WHERE user_id IS NOT NULL;
    DROP TEMPORARY TABLE result;
END $$
delimiter ;

-- CALL sp_login_user_get('SYSADM', 'ALL', 40);