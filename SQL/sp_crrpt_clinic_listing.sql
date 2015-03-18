DROP PROCEDURE IF EXISTS sp_crrpt_clinic_listing;
DELIMITER $$
CREATE PROCEDURE sp_crrpt_clinic_listing()
BEGIN
	SELECT clinic.clinic_id, 
		clinic_chin_name, 
        clinic_eng_name, 
        clinic_addr, 
        clinic_phone_no, 
        CASE WHEN isSuspended = 1 THEN '是' ELSE '否' END isSuspended, 
        DATE_FORMAT(last_update_dtm, '%d/%m/%Y %T') last_update_dtm,
        COUNT(DISTINCT user_id) user_cnt
    FROM clinic
		JOIN user_clinic_role_mapping ON clinic.clinic_id = user_clinic_role_mapping.clinic_id
	GROUP BY clinic.clinic_id
    ORDER BY clinic.clinic_id;
END $$
DELIMITER ;