DROP PROCEDURE IF EXISTS sp_crrpt_patient_listing;
DELIMITER $$
CREATE PROCEDURE sp_crrpt_patient_listing(IN in_clinic_id VARCHAR(10), IN in_user_id VARCHAR(10))
BEGIN
	DECLARE role_id INT;
    SELECT CASE WHEN MIN(user_role_id) = 0 THEN 0 ELSE MAX(user_role_id) END INTO role_id
    FROM user_clinic_role_mapping
    WHERE clinic_id = in_clinic_id AND user_id = in_user_id;
    
	SELECT patient_record.patient_id, 
		chin_name, 
        eng_name, 
        phone_no, 
        DATE_FORMAT(dob, '%d/%m/%Y') dob, 
        sex, 
        CASE WHEN isG6PD = 1 THEN '是' ELSE '否' END isG6PD,
        addr,
        IFNULL(DATE_FORMAT(MAX(consultation_record.last_update_dtm), '%d/%m/%Y'), '') last_cons_date,
        CASE WHEN isDeceased = 1 THEN '是' ELSE '否' END isDeceased
	FROM patient_record
		LEFT JOIN consultation_record ON patient_record.patient_id = consultation_record.patient_id
	WHERE role_id = 40 OR (role_id <> 0 and (in_clinic_id = 'ALL' OR clinic_id = in_clinic_id))
    GROUP BY patient_record.isDeceased DESC, eng_name ASC;
END $$
DELIMITER ;

-- CALL sp_crrpt_patient_listing('ALL', 'SYSADM');