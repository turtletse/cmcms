DROP procedure if EXISTS sp_amd_clinic_get;
delimiter $$
CREATE PROCEDURE sp_amd_clinic_get (IN in_clinc_id VARCHAR(10))
BEGIN
	select
		clinic_id,
		clinic_chin_name,
		clinic_eng_name,
		clinic_addr,
		clinic_phone_no,
        isSuspended
	from clinic
    WHERE (in_clinc_id='ALL' OR clinic_id=in_clinc_id)
	ORDER BY clinic_id;
END $$
delimiter ;

-- CALL sp_amd_clinic_get('CITYC');