delimiter $$
DROP procedure if EXISTS sp_dosage_unit_combo_get $$
CREATE PROCEDURE sp_dosage_unit_combo_get ()
BEGIN
    SELECT unit_id, unit_desc FROM dosage_unit ORDER BY unit_id;
END $$
delimiter ;

-- CALL sp_dosage_unit_combo_get ();