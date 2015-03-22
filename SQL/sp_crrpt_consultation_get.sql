DROP procedure if EXISTS sp_crrpt_consultation_get;
delimiter $$
CREATE PROCEDURE sp_crrpt_consultation_get (IN in_cons_id VARCHAR(10))
BEGIN

	DROP TEMPORARY TABLE IF EXISTS consData;
    CREATE TEMPORARY TABLE consData
	select clinic_id, cons_id, dr_id, CASE WHEN char_length(patient_record.chin_name)>0 THEN patient_record.chin_name ELSE patient_record.eng_name END pat_name, patient_record.patient_id patient_id, user_account.chin_name dr_name, reg_no, dx_desc, dr_rmk, consultation_record.last_update_dtm last_update_dtm, pres_id pres_id_data_str
	from consultation_record JOIN user_account ON dr_id = user_id JOIN patient_record ON consultation_record.patient_id = patient_record.patient_id
    WHERE cons_id=in_cons_id;
    
    CALL cmcis.related_pharm_get((SELECT clinic_id FROM consultation_record WHERE cons_id = in_cons_id));
    
    CALL split((SELECT pres_id_data_str FROM consData),'||');
    
    DROP TEMPORARY TABLE IF EXISTS presIds;
    CREATE TEMPORARY TABLE presIds
    SELECT CONVERT(split_value, UNSIGNED) pres_id FROM splitResult WHERE length(split_value)>0;
    
    DROP TEMPORARY TABLE IF EXISTS presDt;
    CREATE TEMPORARY TABLE presDt
    SELECT pres_id, instruction, no_of_dose, method_of_treatment, drug_name, CONCAT_WS(' ', TRIM(TRAILING '.' FROM TRIM(TRAILING '0' FROM dosage)), unit_desc) dosage, preparation_method, method_desc, display_order 
    FROM prescription NATURAL JOIN prescription_dt JOIN dosage_unit ON unit = unit_id JOIN preparation_method ON preparation_method = method_id
    WHERE pres_id IN (SELECT pres_id FROM presIds);
    
    DROP TEMPORARY TABLE IF EXISTS result;
    CREATE TEMPORARY TABLE result
    SELECT clinic_id, cons_id, pat_name, patient_id, dr_name, reg_no, dx_desc, dr_rmk, DATE_FORMAT(last_update_dtm, '%d/%m/%Y %T') last_update_dtm, pres_id, instruction, no_of_dose, method_of_treatment, drug_name, dosage, preparation_method, case when method_desc = '-' then '正常煎煮' else method_desc end method_desc, display_order, CONCAT_WS('/', clinic_id, consData.dr_id, patient_id, cons_id, pres_id, DATE_FORMAT(last_update_dtm, '%Y%m%d%H%i%s')) pres_dataString_barcode, isSame_Location, pharm_id, pharm_chin_name, pharm_addr, pharm_phone_no
    FROM (consData JOIN presDt) JOIN cmcis.related_pharm;
    
    IF (SELECT COUNT(*) FROM result) = 0 THEN
		INSERT INTO result (clinic_id, cons_id, pat_name, patient_id, dr_name, reg_no, dx_desc, dr_rmk, last_update_dtm)
        SELECT clinic_id, cons_id, pat_name, patient_id, dr_name, reg_no, dx_desc, dr_rmk, last_update_dtm
        FROM consData;
    END IF;
    
    SELECT clinic_id, cons_id, pat_name, patient_id, dr_name, reg_no, dx_desc, dr_rmk, last_update_dtm, pres_id, instruction, no_of_dose, method_of_treatment, drug_name, dosage, preparation_method, method_desc, display_order, pres_dataString_barcode , isSame_Location, pharm_id, pharm_chin_name, pharm_addr, pharm_phone_no
    FROM result 
    ORDER BY pres_id, preparation_method, display_order;
    
    DROP TEMPORARY TABLE presDt;
    DROP TEMPORARY TABLE presIds;
    DROP TEMPORARY TABLE consData;
    DROP TEMPORARY TABLE splitResult;
END $$
delimiter ;

-- CALL sp_crrpt_consultation_get(9);
-- select * from presDt
-- SELECT * FROM consData
-- SELECT * FROM (consData JOIN presDt) JOIN cmcis.related_pharm
-- SELECT * FROM cmcis.related_pharm
-- SELECT * FROM result