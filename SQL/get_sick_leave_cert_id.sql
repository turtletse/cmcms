DROP FUNCTION IF EXISTS get_sick_leave_cert_id;
DELIMITER $$
CREATE FUNCTION get_sick_leave_cert_id()
RETURNS INT
BEGIN
    DECLARE sick_leave_cert_id INT;
	UPDATE system_parm SET parm_value = CAST(LAST_INSERT_ID(cast(parm_value AS UNSIGNED)+1) AS CHAR) WHERE parm_name = 'sick_leave_cert_cnt';
	SET sick_leave_cert_id = last_insert_id();
    RETURN sick_leave_cert_id;
END $$

DELIMITER ;