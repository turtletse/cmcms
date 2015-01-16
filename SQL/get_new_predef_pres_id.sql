DROP FUNCTION IF EXISTS get_new_predef_pres_id;

DELIMITER $$
CREATE FUNCTION get_new_predef_pres_id ()
RETURNS INT
BEGIN
    DECLARE predef_pres_id INT;
	UPDATE system_parm SET parm_value = CAST(LAST_INSERT_ID(cast(parm_value AS UNSIGNED)+1) AS CHAR) WHERE parm_name = 'predef_prescription_cnt';
	SET predef_pres_id = last_insert_id();
    RETURN predef_pres_id;
END $$

DELIMITER ;

-- SELECT get_new_patient_id();