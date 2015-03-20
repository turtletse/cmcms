DROP PROCEDURE IF EXISTS sp_insert_instruction_predefined;

DELIMITER $$
CREATE PROCEDURE sp_insert_instruction_predefined (
	IN in_instruction VARCHAR(255)
)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
        SET curr_status_id = 2;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	END;
	if (select count(*) from predef_instruction_list where instruction_desc = TRIM(in_instruction)) > 0 THEN
        SET curr_status_id = 1;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	ELSE
		SET AUTOCOMMIT = 0;
		START TRANSACTION;
            INSERT INTO predef_instruction_list (
				instruction_id,
                instruction_desc
			) VALUES (
				get_predef_instruction_id(),
				TRIM(in_instruction)
            );
		COMMIT;
        SET AUTOCOMMIT = 1;
        SELECT status_id, status_desc FROM insert_record_status where status_id = curr_status_id;
        
    END IF;
    
END $$

DELIMITER ;