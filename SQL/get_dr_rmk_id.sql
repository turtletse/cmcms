DROP FUNCTION IF EXISTS get_dr_rmk_id;
DELIMITER $$
CREATE FUNCTION get_dr_rmk_id()
RETURNS INT
BEGIN
    DECLARE rmk_id INT;
	UPDATE system_parm SET parm_value = CAST(LAST_INSERT_ID(cast(parm_value AS UNSIGNED)+1) AS CHAR) WHERE parm_name = 'dr_rmk_cnt';
	SET rmk_id = last_insert_id();
    RETURN rmk_id;
END $$

DELIMITER ;