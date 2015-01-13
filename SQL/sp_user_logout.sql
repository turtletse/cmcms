DROP PROCEDURE IF EXISTS sp_user_logout;

DELIMITER $$
CREATE PROCEDURE sp_user_logout (
	IN in_user_id varchar(10),
    IN in_clinic_id VARCHAR(10)
)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
        SET curr_status_id = 2;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	END;
	START TRANSACTION;
		UPDATE user_account 
		SET
			last_logout_dtm = now(),
			last_logout_clinic_id = in_clinic_id
		WHERE user_id = in_user_id;
	COMMIT;
        
    SELECT status_id, CONCAT('登出', status_desc) status_desc FROM insert_record_status where status_id = curr_status_id;
    
END $$

DELIMITER ;
