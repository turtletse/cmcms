DROP procedure if EXISTS sp_drug_item_get_by_id;
delimiter $$
CREATE PROCEDURE sp_drug_item_get_by_id (
	IN in_drug_ids VARCHAR(1000)
)
BEGIN    
    CALL split(in_drug_ids, '||');
    DROP TEMPORARY TABLE IF EXISTS selected_drug_ids;
    CREATE TEMPORARY TABLE selected_drug_ids
		SELECT CAST(split_value AS UNSIGNED) drug_id FROM splitResult;
    DROP TEMPORARY TABLE splitResult;
    DROP TEMPORARY TABLE IF EXISTS result;
	CREATE TEMPORARY TABLE result
		select drug_name, m.drug_id, drug_min_dosage_val, drug_min_dosage_unit, drug_max_dosage_val, drug_max_dosage_unit, drug_pri_type, drug_sec_type, isDeleted, drug_q1, drug_q2, drug_q3, drug_q4, drug_w1, drug_w2, drug_w3, drug_w4, drug_w5, drug_w6, pregnancy, g6pd
        from master_drug_list m LEFT JOIN drug_admin_abs_contraindication c
		ON m.drug_id=c.drug_id
        where m.drug_id IN (SELECT s.drug_id FROM selected_drug_ids s);
    SELECT drug_name, drug_id, drug_min_dosage_val, drug_min_dosage_unit, drug_max_dosage_val, drug_max_dosage_unit, drug_pri_type, drug_sec_type, isDeleted, drug_q1, drug_q2, drug_q3, drug_q4, drug_w1, drug_w2, drug_w3, drug_w4, drug_w5, drug_w6, IFNULL(pregnancy, 0) pregnancy, IFNULL(g6pd, 0) g6pd FROM result ORDER BY drug_id;
    DROP TEMPORARY TABLE result;
END $$
delimiter ;
-- select * from master_drug_list;
-- select * from selected_drug_ids;
-- select * from splitResult;
-- CALL sp_drug_item_get_by_id (null);