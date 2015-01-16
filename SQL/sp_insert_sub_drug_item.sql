DROP PROCEDURE IF EXISTS sp_insert_sub_drug_item;

DELIMITER $$
CREATE PROCEDURE sp_insert_sub_drug_item (
	IN in_drug_id int,
    IN in_sub_drug_name VARCHAR(255)
)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
        SET curr_status_id = 2;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	END;
	if (select count(*) from master_drug_list where drug_id = in_drug_id) = 0 THEN
        SET curr_status_id = 3;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	ELSEIF (select count(*) from master_sub_drug_list where sub_drug_name = in_sub_drug_name) > 0 THEN
        SET curr_status_id = 1;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	ELSE
		START TRANSACTION;
			INSERT INTO master_sub_drug_list (
				drug_id,
                sub_drug_id,
                sub_drug_name
				)
			VALUES (
				in_drug_id,
				(SELECT IFNULL(max(x.sub_drug_id)+1, 1) from master_sub_drug_list x where drug_id = in_drug_id),
                in_sub_drug_name
            );
		COMMIT;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
    END IF;
END $$

DELIMITER ;

-- CALL sp_insert_sub_drug_item (101001, '淨麻黃');
-- select * from debug_log order by log_dtm desc

/*
select * from master_sub_drug_list;
*/