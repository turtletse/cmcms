DROP procedure if EXISTS sp_crrpt_clinic_header_get;
delimiter $$
CREATE PROCEDURE sp_crrpt_clinic_header_get (IN in_clinc_id VARCHAR(10))
BEGIN
	select
		clinic_chin_name,
		CONCAT('地址: ',clinic_addr) clinic_addr,
		CONCAT('電話: ',clinic_phone_no) clinic_phone_no
	from clinic
    WHERE clinic_id=in_clinc_id;
END $$
delimiter ;

-- CALL sp_amd_clinic_get('CITYC');