DROP PROCEDURE IF EXISTS sp_delete_predefined_instruction;

DELIMITER $$
CREATE PROCEDURE sp_delete_predefined_instruction (
	IN in_inst_id INT
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
		DELETE FROM predef_instruction_list WHERE instruction_id = in_inst_id;
		IF (SELECT ROW_COUNT())=0 THEN
			SET curr_status_id = 5;
		END IF;
	COMMIT;
	SET AUTOCOMMIT = 1;
	SELECT status_id, status_desc FROM insert_record_status where status_id = curr_status_id;
    
END $$

DELIMITER ;

-- CALL sp_delete_predefined_instruction(99)