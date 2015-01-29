delimiter $$
DROP procedure if EXISTS sp_prescription_MOT_combo_get $$
CREATE PROCEDURE sp_prescription_MOT_combo_get ()
BEGIN
    SELECT result_desc FROM method_of_treatment_list ORDER BY CHAR_LENGTH(result_desc), result_desc;
END $$
delimiter ;

-- CALL sp_prescription_MOT_combo_get ();