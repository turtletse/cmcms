DROP PROCEDURE IF EXISTS sp_insert_dr_rmk_predefined;

DELIMITER $$
CREATE PROCEDURE sp_insert_dr_rmk_predefined (
	IN in_rmk VARCHAR(255)
)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
        SET curr_status_id = 2;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	END;
	if (select count(*) from dr_rmk_perdefined_list where rmk_desc = in_rmk) > 0 THEN
        SET curr_status_id = 1;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	ELSE
		START TRANSACTION;
            INSERT INTO dr_rmk_perdefined_list (
				rmk_id,
                rmk_desc
			) VALUES (
				get_dr_rmk_id(),
				in_rmk
            );
		COMMIT;
        
        SELECT status_id, status_desc FROM insert_record_status where status_id = curr_status_id;
        
    END IF;
    
END $$

DELIMITER ;