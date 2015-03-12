DROP PROCEDURE IF EXISTS sp_update_sub_drug_item;

DELIMITER $$
CREATE PROCEDURE sp_update_sub_drug_item (
	IN in_drug_id INT,
    IN in_sub_drug_id INT,
	IN in_sub_drug_name varchar(255),
    IN in_isDeleted INT
)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
        SET curr_status_id = 2;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	END;
	if (select count(*) from master_sub_drug_list where sub_drug_name = in_sub_drug_name and sub_drug_id <> in_sub_drug_id) > 0 THEN
        SET curr_status_id = 4;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	ELSEIF (select count(*) from master_sub_drug_list where sub_drug_id = in_sub_drug_id and drug_id = in_drug_id) <> 1 THEN
		SET curr_status_id = 5;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	ELSE
		START TRANSACTION;
			UPDATE master_sub_drug_list 
			SET	sub_drug_name = in_sub_drug_name,
                isDeleted = in_isDeleted
			WHERE drug_id = in_drug_id AND sub_drug_id = in_sub_drug_id;
		COMMIT;
        CALL cmcis.common_prescribe_drug_list_update_by_cmcms(in_drug_id, in_sub_drug_id, in_sub_drug_name);
        SELECT * FROM insert_record_status where status_id = curr_status_id;
        
    END IF;
    
END $$

DELIMITER ;

-- CALL sp_update_sub_drug_item (101001, 1, '淨麻黃',0)
-- select * from debug_log order by log_dtm desc
-- select count(*) from master_sub_drug_list where sub_drug_name = '淨麻黃' and sub_drug_id <> 1
-- select count(*) from master_sub_drug_list where sub_drug_id = 1 and drug_id = 101001