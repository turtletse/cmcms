DROP PROCEDURE IF EXISTS sp_crrpt_suspecious_pres_listing;
DELIMITER $$
CREATE PROCEDURE sp_crrpt_suspecious_pres_listing(IN in_clinic_id VARCHAR(10))
BEGIN
    SELECT pres_ignore_safety_chk.pres_id, 
		dr_id, 
        chin_name, 
        patient_id, 
        cons_id, 
        DATE_FORMAT(consultation_record.last_update_dtm, '%d/%m/%Y %T') last_update_dtm,
        CASE WHEN incompatible_drug = 1 THEN 'P' ELSE '' END incompatible_drug, 
        CASE WHEN g6pd_not_recommended = 1 THEN 'P' ELSE '' END g6pd_not_recommended,
        CASE WHEN g6pd_forbidden = 1 THEN 'P' ELSE '' END g6pd_forbidden,
        CASE WHEN pregnant_not_recommended = 1 THEN 'P' ELSE '' END pregnant_not_recommended,
        CASE WHEN pregnant_forbidden = 1 THEN 'P' ELSE '' END pregnant_forbidden,
        CASE WHEN drug_wo_dosage = 1 THEN 'P' ELSE '' END drug_wo_dosage,
        CASE WHEN drug_below_min_dosage = 1 THEN 'P' ELSE '' END drug_below_min_dosage,
        CASE WHEN drug_exceed_max_dosage = 1 THEN 'P' ELSE '' END drug_exceed_max_dosage,
        CASE WHEN patient_allergy = 1 THEN 'P' ELSE '' END patient_allergy,
        DATE_FORMAT(record_dtm, '%d/%m/%Y %T') record_dtm
    FROM consultation_record 
		JOIN pres_ignore_safety_chk ON consultation_record.pres_id REGEXP CONCAT('(^|[0-9]\\|{2})', pres_ignore_safety_chk.pres_id, '(\\|{2}[0-9]|$)')
        JOIN user_account ON dr_id = user_id
    WHERE clinic_id = in_clinic_id
    ORDER BY pres_ignore_safety_chk.record_dtm DESC;
END $$
DELIMITER ;