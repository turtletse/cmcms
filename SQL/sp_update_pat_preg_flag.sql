DROP PROCEDURE IF EXISTS sp_update_pat_preg_flag;

DELIMITER $$
CREATE PROCEDURE sp_update_pat_preg_flag (
    IN in_pat_id INT,
    IN in_isPregnant INT
)
BEGIN
	UPDATE patient_record
    SET isPregnant = in_isPregnant
    WHERE patient_id = in_pat_id;

END $$

DELIMITER ;



SELECT * FROM patient_record