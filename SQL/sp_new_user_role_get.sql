DROP procedure if EXISTS sp_new_user_role_get;
delimiter $$
CREATE PROCEDURE sp_new_user_role_get (IN in_role_id int)
BEGIN
	select
		role_id, role_desc
	from user_role
    WHERE role_id <= in_role_id
	ORDER BY role_id;
END $$
delimiter ;

-- CALL sp_new_user_role_get(3);