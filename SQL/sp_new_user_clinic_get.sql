DROP procedure if EXISTS sp_new_user_clinic_get;
delimiter $$
CREATE PROCEDURE sp_new_user_clinic_get (IN in_clinic_id VARCHAR(10), IN in_role_id int)
BEGIN
	select
		clinic_id,
		clinic_chin_name,
		clinic_eng_name,
		clinic_addr,
		clinic_phone_no,
        isSuspended
	from clinic
    WHERE (in_role_id = 40 OR (in_role_id <> 40 AND clinic_id = in_clinic_id))
	ORDER BY clinic_id;
END $$
delimiter ;

-- CALL sp_new_user_clinic_get('CITYC', 3);
-- CALL sp_new_user_clinic_get ('ALL', 40);