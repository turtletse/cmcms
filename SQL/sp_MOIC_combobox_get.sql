DROP PROCEDURE IF EXISTS sp_MOIC_combobox_get;

DELIMITER $$
CREATE PROCEDURE sp_MOIC_combobox_get (
    IN in_clinic_id VARCHAR(10)
)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    /*DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
        SET curr_status_id = 2;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	END;*/
    
    SELECT user_id, hashed_password, chin_name, eng_name, reg_no, last_logout_dtm, last_logout_clinic_id, isSuspended
    FROM user_clinic_role_mapping NATURAL JOIN user_account
    WHERE clinic_id = in_clinic_id
		AND user_id NOT IN (
			SELECT user_id 
            FROM user_clinic_role_mapping 
            WHERE clinic_id = in_clinic_id 
				AND user_role_id = 0
		)
        AND user_role_id=20;
    
END $$

DELIMITER ;



-- CALL sp_MOIC_combobox_get('CITYC');


