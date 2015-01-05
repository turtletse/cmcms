DROP procedure if EXISTS sp_DSP_sub_drug_listbox_item_get;
delimiter $$
CREATE PROCEDURE sp_DSP_sub_drug_listbox_item_get (
	IN in_drug_id INT, IN in_incl_not_specified INT, IN in_incl_deleted INT)
BEGIN
	DROP TEMPORARY TABLE IF EXISTS result;
	CREATE TEMPORARY TABLE result (sub_drug_id int, item_id VARCHAR(20), item_name VARCHAR(255), isDeleted int);
    IF (in_incl_not_specified>0) THEN
		INSERT INTO result VALUES (0, CONCAT_WS('||', in_drug_id, '0'), '-', 0);
    END IF;
    INSERT INTO result
		SELECT sub_drug_id, CONCAT_WS('||', drug_id, sub_drug_id), sub_drug_name, isDeleted
        FROM master_sub_drug_list
        WHERE drug_id = in_drug_id AND isDeleted<=in_incl_deleted;
	SELECT item_id, item_name, isDeleted FROM result ORDER BY sub_drug_id;
    DROP TEMPORARY TABLE result;
END $$
delimiter ;
-- CALL sp_DSP_sub_drug_listbox_item_get (101001, 1, 0);

