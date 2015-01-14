DROP procedure if EXISTS sp_permissible_dosage_unit_for_drug_get;
delimiter $$
CREATE PROCEDURE sp_permissible_dosage_unit_for_drug_get (IN in_drug_id INT)
BEGIN
	DECLARE min_unit, max_unit INT;
	SELECT drug_min_dosage_unit, drug_max_dosage_unit 
    INTO min_unit, max_unit
    FROM master_drug_list 
    WHERE drug_id = in_drug_id;
    IF (min_unit>100 AND max_unit>100) THEN
		SELECT unit_id, unit_desc
        FROM dosage_unit
        WHERE unit_id IN (min_unit, max_unit)
        ORDER BY unit_id;
	ELSE
		SELECT unit_id, unit_desc
        FROM dosage_unit
        WHERE unit_id <100
        ORDER BY unit_id;
	END IF;
END $$
delimiter ;
-- CALL sp_permissible_dosage_unit_for_drug_get (101001);

