DROP PROCEDURE IF EXISTS sp_crrpt_user_listing;
DELIMITER $$
CREATE PROCEDURE sp_crrpt_user_listing (IN in_clinic_id VARCHAR(10))
BEGIN
	IF isCmpmsExist() THEN
		INSERT INTO user_account (user_id, hashed_password, chin_name, eng_name, last_update_dtm)
        SELECT user_id, hashed_password, chin_name, eng_name, last_update_dtm
        FROM cmcis.common_user
        WHERE user_id NOT IN (SELECT user_id FROM user_account);
        
        UPDATE user_account a, cmcis.common_user b
        SET a.hashed_password = b.hashed_password, 
            a.chin_name = b.chin_name, 
            a.eng_name = b.eng_name, 
            a.last_update_dtm = b.last_update_dtm
		WHERE a.user_id = b.user_id AND a.last_update_dtm<b.last_update_dtm;
		
    END IF;

	SELECT user_account.user_id, 
		chin_name, 
        IFNULL(eng_name, '') eng_name, 
        IFNULL(reg_no, '') reg_no,
        DATE_FORMAT(last_logout_dtm, '%d/%m/%Y %T') last_logout_dtm,
        CASE WHEN isSuspended = 1 THEN '是' ELSE '否' END isSuspended,
        CASE WHEN in_clinic_id = 'ALL' THEN last_logout_clinic_id 
			WHEN last_logout_clinic_id <> in_clinic_id THEN '***'
			WHEN last_logout_clinic_id IS NULL THEN '' 
            ELSE last_logout_clinic_id END last_logout_clinic_id,
        DATE_FORMAT(user_account.last_update_dtm, '%d/%m/%Y %T') last_update_dtm,
        user_clinic_role_mapping.clinic_id,
        role_desc
    FROM user_account 
		LEFT JOIN user_clinic_role_mapping ON user_account.user_id = user_clinic_role_mapping.user_id
        LEFT JOIN user_role ON user_role_id = role_id
	WHERE user_clinic_role_mapping.clinic_id = in_clinic_id OR in_clinic_id = 'ALL'
    ORDER BY user_id, user_clinic_role_mapping.clinic_id, role_id;
    
END $$
DELIMITER ;

-- CALL sp_crrpt_user_listing('ALL')