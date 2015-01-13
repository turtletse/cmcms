DROP procedure if EXISTS sp_login_user_get;
delimiter $$
CREATE PROCEDURE sp_login_user_get (
	IN in_user_id varchar(10),
    IN in_clinic_id varchar(10),
    IN in_role_id int
)
BEGIN
	DROP TEMPORARY TABLE IF EXISTS result;
    CREATE TEMPORARY TABLE result
	select
		user_id,
        hashed_password,
        chin_name,
        eng_name,
        reg_no,
        DATE_FORMAT(last_logout_dtm, '%d/%m/%Y %T') last_logout_dtm,
        last_logout_clinic_id,
        clinic_id current_login_clinic_id,
        min(user_role_id) current_login_role_id,
        isSuspended
	from user_account natural join user_clinic_role_mapping
	where 
		user_id = in_user_id
        AND clinic_id = in_clinic_id
        AND (user_role_id = in_role_id OR user_role_id = 0);
	SELECT * FROM RESULT WHERE user_id IS NOT NULL;
    DROP TEMPORARY TABLE result;
END $$
delimiter ;

-- CALL sp_login_user_get('SYSADM', 'ALL', 40);

