DROP PROCEDURE IF EXISTS sp_pres_get;

DELIMITER $$
CREATE PROCEDURE sp_pres_get (
	IN in_pres_id INT
)
BEGIN
	SELECT
		instruction,
		no_of_dose,
		method_of_treatment
    FROM prescription
    WHERE pres_id = in_pres_id;

END $$

DELIMITER ;



-- SELECT * from prescription_dt
-- CALL sp_pres_dt_get (1)