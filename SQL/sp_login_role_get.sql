DROP procedure if EXISTS sp_login_role_get;
delimiter $$
CREATE PROCEDURE sp_login_role_get ()
BEGIN
	select
		role_id, role_desc
	from user_role
    WHERE role_id > 0
	ORDER BY role_id;
END $$
delimiter ;

-- CALL sp_login_role_get();