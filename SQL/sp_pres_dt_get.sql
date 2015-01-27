DROP PROCEDURE IF EXISTS sp_pres_dt_get;

DELIMITER $$
CREATE PROCEDURE sp_pres_dt_get (
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
    FROM prescription_dt JOIN preparation_method ON preparation_method=method_id JOIN dosage_unit ON unit = unit_id
    WHERE pres_id = in_pres_id;

END $$

DELIMITER ;



-- SELECT * from prescription_dt
-- CALL sp_pres_dt_get (1)