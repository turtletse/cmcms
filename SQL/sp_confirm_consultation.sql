DROP PROCEDURE IF EXISTS sp_confirm_consultation;

DELIMITER $$
CREATE PROCEDURE sp_confirm_consultation (
	IN in_cons_id INT
)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
		SET curr_status_id = 2;
		SELECT * FROM insert_record_status where status_id = curr_status_id;
	END;
    
	SET AUTOCOMMIT = 0;
    
	START TRANSACTION;
		UPDATE consultation_record
        SET	isFinished = 1
        WHERE cons_id = in_cons_id
            AND isFinished = 0;
	
    IF (SELECT ROW_COUNT()) = 0 THEN
		ROLLBACK;
		SET curr_status_id = 1;
    END IF;
    
    COMMIT;
    SET AUTOCOMMIT = 1;
    
    SELECT * FROM insert_record_status where status_id = curr_status_id;
END $$

DELIMITER ;


-- SELECT * from prescription_dt
-- CALL sp_pres_dt_get (1)