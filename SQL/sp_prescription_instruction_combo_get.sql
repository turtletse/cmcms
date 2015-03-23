delimiter $$
DROP procedure if EXISTS sp_prescription_instruction_combo_get $$
CREATE PROCEDURE sp_prescription_instruction_combo_get ()
BEGIN
    SELECT instruction_desc FROM predef_instruction_list ORDER BY CHAR_LENGTH(instruction_desc), instruction_id, instruction_desc;
END $$
delimiter ;

-- CALL sp_dosage_unit_combo_get ();