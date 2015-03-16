DROP procedure if EXISTS sp_crrpt_preg_cert_get;
delimiter $$
CREATE PROCEDURE sp_crrpt_preg_cert_get (
	IN in_cert_id INT
)
BEGIN
	SELECT cert_id,
			CASE WHEN patient_record.chin_name = '' THEN patient_record.eng_name ELSE patient_record.chin_name END pat_name,
            CASE WHEN patient_record.id_doc_type = 'HKID' THEN '香港身份證' WHEN patient_record.id_doc_type = 'PASSPORT' THEN '護照' ELSE '' END id_doc_type,
            id_doc_no,
            consultation_id,
            DATE_FORMAT(consultation_record.last_update_dtm,'%d/%m/%Y') cons_date,
            pregnant_cert.isPregnant isPregnant,
            DATE_FORMAT(edc, '%d/%m/%Y') edc,
            clinic_id,
            user_account.chin_name dr_name,
            reg_no,
            DATE_FORMAT(sysdate(), '%d/%m/%Y') issueDate
    FROM pregnant_cert JOIN consultation_record ON consultation_id = cons_id 
		JOIN patient_record ON consultation_record.patient_id = patient_record.patient_id
        JOIN user_account ON consultation_record.dr_id = user_account.user_id
	WHERE cert_id = in_cert_id;
		
END $$
delimiter ;


-- select * from sick_leave_cert
-- CALL sp_crrpt_preg_cert_get(1);