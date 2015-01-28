DROP procedure if EXISTS sp_crrpt_consultation_get;
delimiter $$
CREATE PROCEDURE sp_crrpt_consultation_get (IN in_cons_id VARCHAR(10))
BEGIN
	DROP TEMPORARY TABLE IF EXISTS consData;
    CREATE TEMPORARY TABLE consData
	select cons_id, CONCAT('*',cons_id,'*') cons_id_barcode, CONCAT(patient_record.chin_name, ' (', patient_record.patient_id,')') pat_name, user_account.chin_name dr_name, reg_no, dx_desc, dr_rmk, DATE_FORMAT(last_update_dtm, '%d/%m/%Y %T') last_update_dtm, pres_id pres_id_data_str
	from consultation_record JOIN user_account ON dr_id = user_id JOIN patient_record ON consultation_record.patient_id = patient_record.patient_id
    WHERE cons_id=in_cons_id;
    
    CALL split((SELECT pres_id_data_str FROM consData),'||');
    
    DROP TEMPORARY TABLE IF EXISTS presIds;
    CREATE TEMPORARY TABLE presIds
    SELECT CONVERT(split_value, UNSIGNED) pres_id FROM splitResult;
    
    DROP TEMPORARY TABLE IF EXISTS presDt;
    CREATE TEMPORARY TABLE presDt
    SELECT pres_id, instruction, no_of_dose, method_of_treatment, drug_name, CONCAT(dosage, unit_desc) dosage, preparation_method, method_desc, display_order 
    FROM prescription NATURAL JOIN prescription_dt JOIN dosage_unit ON unit = unit_id JOIN preparation_method ON preparation_method = method_id
    WHERE pres_id IN (SELECT pres_id FROM presIds);
    
    SELECT cons_id, cons_id_barcode, pat_name, dr_name, reg_no, dx_desc, dr_rmk, last_update_dtm, pres_id, instruction, no_of_dose, method_of_treatment, drug_name, dosage, preparation_method, method_desc, display_order
    FROM consData JOIN presDt
    ORDER BY pres_id, preparation_method, display_order;
    
    
END $$
delimiter ;


-- CALL sp_crrpt_consultation_get(1)