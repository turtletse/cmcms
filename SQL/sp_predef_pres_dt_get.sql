DROP PROCEDURE IF EXISTS sp_predef_pres_dt_get;

DELIMITER $$
CREATE PROCEDURE sp_predef_pres_dt_get (
	IN in_pres_id INT
)
BEGIN
	SELECT 
    CASE WHEN sub_drug_id>0 THEN CONCAT_WS('||', drug_id, sub_drug_id)
			ELSE drug_id
			END drug_code,
	drug_name,
    dosage,
    unit_desc,
    method_desc
    FROM predefined_prescription NATURAL JOIN predefined_prescription_dt JOIN preparation_method ON preparation_method=method_id JOIN dosage_unit ON unit = unit_id NATURAL JOIN master_drug_list 
    WHERE predef_pres_id = in_pres_id;

END $$

DELIMITER ;



SELECT * from predefined_prescription_dt