DROP PROCEDURE IF EXISTS sp_crrpt_full_consultation_report_get;
DELIMITER $$
CREATE PROCEDURE sp_crrpt_full_consultation_report_get(IN in_clinic_id VARCHAR(10), IN in_pat_id INT, IN in_cons_id INT)
BEGIN

	SELECT cons_id, clinic_id, dr_id, user_account.chin_name dr_name, consultation_record.patient_id, id_doc_no, CASE WHEN patient_record.chin_name IS NULL OR LENGTH(TRIM(patient_record.chin_name)) = 0 THEN patient_record.eng_name ELSE patient_record.chin_name END pat_name, DATE_FORMAT(first_record_dtm, '%d/%m/%Y %T') first_record_dtm, DATE_FORMAT(consultation_record.last_update_dtm, '%d/%m/%Y %T') last_update_dtm, ex_desc, diff_desc, dx_desc, prescription.pres_id, method_of_treatment, instruction, drug_name, CONCAT_WS(' ', TRIM(TRAILING '.' FROM TRIM(TRAILING '0' FROM dosage)), dosage_unit.unit_desc) dosage, preparation_method.method_id, CASE WHEN method_desc = '-' THEN '正常煎煮' ELSE method_desc end method_desc, display_order, no_of_dose, acupuncture_desc, dr_rmk
    FROM consultation_record LEFT JOIN prescription ON consultation_record.pres_id REGEXP CONCAT('(^|[0-9]\\|{2})', prescription.pres_id, '(\\|{2}[0-9]|$)')
		LEFT JOIN prescription_dt ON prescription.pres_id = prescription_dt.pres_id
        LEFT JOIN dosage_unit ON prescription_dt.unit = dosage_unit.unit_id
        LEFT JOIN user_account ON dr_id = user_id
        LEFT JOIN patient_record ON consultation_record.patient_id = patient_record.patient_id
        LEFT JOIN preparation_method ON prescription_dt.preparation_method = preparation_method.method_id
    WHERE consultation_record.clinic_id = in_clinic_id 
		AND consultation_record.patient_id = in_pat_id
		AND consultation_record.isFinished > 0 
		AND (in_cons_id IS NULL OR (in_cons_id IS NOT NULL AND consultation_record.cons_id = in_cons_id))
	ORDER BY cons_id, pres_id, preparation_method, display_order;
	
END $$
DELIMITER ;

-- CALL sp_crrpt_full_consultation_report_get('CITYC', 2, NULL)
