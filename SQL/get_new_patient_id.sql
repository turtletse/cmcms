DROP FUNCTION IF EXISTS get_new_patient_id;

DELIMITER $$
CREATE FUNCTION get_new_patient_id ()
RETURNS INT
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    DECLARE pat_id INT;
	UPDATE system_parm SET parm_value = CAST(LAST_INSERT_ID(cast(parm_value AS UNSIGNED)+1) AS CHAR) WHERE parm_name = 'pat_id_cnt';
	SET pat_id = last_insert_id();
    RETURN pat_id;
END $$

DELIMITER ;

-- SELECT get_new_patient_id();