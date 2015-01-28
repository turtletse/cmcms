DROP PROCEDURE IF EXISTS sp_consultation_get;

DELIMITER $$
CREATE PROCEDURE sp_consultation_get (
    IN in_clinic_id VARCHAR(255),
    IN in_dr_id VARCHAR(255),
    IN in_cons_id INT
)
BEGIN
	SELECT cons_id, clinic_id, dr_id, patient_id, DATE_FORMAT(first_record_dtm, '%d/%m/%Y %T') first_record_dtm, ex_code, ex_desc, diff_code, diff_desc, dx_code, dx_desc, pres_id, dr_rmk, isFinished, DATE_FORMAT(last_update_dtm, '%d/%m/%Y %T') last_update_dtm
    FROM consultation_record
    WHERE cons_id = in_cons_id AND (clinic_id = in_clinic_id OR dr_id = in_dr_id);

END $$

DELIMITER ;



-- SELECT * from prescription_dt
-- CALL sp_pres_dt_get (1)


