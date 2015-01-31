DROP procedure if EXISTS sp_crrpt_consultation_cert_get;
delimiter $$
CREATE PROCEDURE sp_crrpt_consultation_cert_get (
	IN in_cons_id INT
)
BEGIN
	SELECT cons_id,
			CASE WHEN patient_record.chin_name = '' THEN patient_record.eng_name ELSE patient_record.chin_name END pat_name,
            CASE WHEN patient_record.id_doc_type = 'HKID' THEN '香港身份證' WHEN patient_record.id_doc_type = 'PASSPORT' THEN '護照' ELSE '' END id_doc_type,
            id_doc_no,
            DATE_FORMAT(first_record_dtm,'%d/%m/%Y') cons_date,
            dx_desc,
            clinic_id,
            user_account.chin_name dr_name,
            reg_no,
            DATE_FORMAT(sysdate(), '%d/%m/%Y') issueDate
    FROM consultation_record JOIN patient_record ON consultation_record.patient_id = patient_record.patient_id
        JOIN user_account ON consultation_record.dr_id = user_account.user_id
	WHERE cons_id = in_cons_id;
		
END $$
delimiter ;


-- select * from sick_leave_cert
-- CALL sp_crrpt_sick_leave_cert_get(1);