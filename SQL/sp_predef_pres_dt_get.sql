DROP PROCEDURE IF EXISTS sp_predef_pres_dt_get;

DELIMITER $$
CREATE PROCEDURE sp_predef_pres_dt_get (
	IN in_pres_id INT
)
BEGIN
	DROP TEMPORARY TABLE IF EXISTS result;
	CREATE TEMPORARY TABLE result
	SELECT
    predefined_prescription_dt.drug_id,
    predefined_prescription_dt.sub_drug_id,
    CASE WHEN sub_drug_id>0 THEN CONCAT_WS('||', predefined_prescription_dt.drug_id, sub_drug_id)
			ELSE predefined_prescription_dt.drug_id
			END drug_code,
	drug_name,
    TRIM(TRAILING '.' FROM TRIM(TRAILING '0' FROM dosage)) dosage,
    unit_desc,
    method_desc
    FROM predefined_prescription NATURAL JOIN predefined_prescription_dt JOIN preparation_method ON preparation_method=method_id JOIN dosage_unit ON unit = unit_id JOIN master_drug_list ON predefined_prescription_dt.drug_id = master_drug_list.drug_id
    WHERE predef_pres_id = in_pres_id;
    
    UPDATE result, master_sub_drug_list
    SET result.drug_name = master_sub_drug_list.sub_drug_name
	WHERE result.drug_id = master_sub_drug_list.drug_id
		AND result.sub_drug_id = master_sub_drug_list.sub_drug_id
        AND result.sub_drug_id >0;
	
    SELECT drug_code, drug_name, dosage, unit_desc, method_desc FROM result;

END $$

DELIMITER ;



-- SELECT * from predefined_prescription_dt
-- CALL sp_predef_pres_dt_get (13)