DROP FUNCTION IF EXISTS get_predef_instruction_id;

DELIMITER $$
CREATE FUNCTION get_predef_instruction_id ()
RETURNS INT
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    DECLARE cons_id INT;
	UPDATE system_parm SET parm_value = CAST(LAST_INSERT_ID(cast(parm_value AS UNSIGNED)+1) AS CHAR) WHERE parm_name = 'instruction_cnt';
	SET cons_id = last_insert_id();
    RETURN cons_id;
END $$

DELIMITER ;

-- SELECT get_new_patient_id();