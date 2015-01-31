DROP FUNCTION IF EXISTS get_preg_cert_id;
DELIMITER $$
CREATE FUNCTION get_preg_cert_id()
RETURNS INT
BEGIN
    DECLARE preg_cert_id INT;
	UPDATE system_parm SET parm_value = CAST(LAST_INSERT_ID(cast(parm_value AS UNSIGNED)+1) AS CHAR) WHERE parm_name = 'preg_cert_cnt';
	SET preg_cert_id = last_insert_id();
    RETURN preg_cert_id;
END $$

DELIMITER ;