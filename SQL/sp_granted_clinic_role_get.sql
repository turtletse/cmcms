DROP procedure if EXISTS sp_granted_clinic_role_get;
delimiter $$
CREATE PROCEDURE sp_granted_clinic_role_get (IN in_user_id VARCHAR(10), IN in_clinic_id VARCHAR(10), IN in_role_id int)
BEGIN
	select
		concat_ws('/', clinic_id, role_desc) display_name,
        concat_ws('^^', clinic_id, role_id) sp_value
	from user_clinic_role_mapping join user_role
    ON user_role_id = role_id
    WHERE (in_role_id = 40 OR (in_role_id <> 40 AND clinic_id = in_clinic_id))
    AND user_id = in_user_id
	ORDER BY sp_value;
END $$
delimiter ;

-- CALL sp_granted_clinic_role_get('CITYCD1','CITYC', 30);
-- CALL sp_granted_clinic_role_get ('CITYCS1','ALL', 40);