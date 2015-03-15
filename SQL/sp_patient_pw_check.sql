DROP PROCEDURE IF EXISTS sp_patient_pw_check;
DELIMITER $$
CREATE PROCEDURE sp_patient_pw_check (IN in_pat_id INT, IN in_hashed_pw CHAR(64))
BEGIN
	SELECT hashed_password = in_hashed_pw isMatch
    FROM patient_record
    WHERE patient_id = in_pat_id;

END $$
DELIMITER ;

-- CALL patient_pw_check (1, '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5')