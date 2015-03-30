DROP procedure if EXISTS sp_login_clinic_get;
delimiter $$
CREATE PROCEDURE sp_login_clinic_get ()
BEGIN
	select
		clinic_id,
		clinic_chin_name,
		clinic_eng_name,
		clinic_addr,
		clinic_phone_no,
        isSuspended
	from clinic
    where isSuspended = 0
	ORDER BY clinic_id;
END $$
delimiter ;

-- CALL sp_login_clinic_get();