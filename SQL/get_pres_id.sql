DROP FUNCTION IF EXISTS get_pres_id;
DELIMITER $$
CREATE FUNCTION get_pres_id()
RETURNS INT
BEGIN
    DECLARE pres_id INT;
	UPDATE system_parm SET parm_value = CAST(LAST_INSERT_ID(cast(parm_value AS UNSIGNED)+1) AS CHAR) WHERE parm_name = 'prescription_cnt';
	SET pres_id = last_insert_id();
    RETURN pres_id;
END $$

DELIMITER ;