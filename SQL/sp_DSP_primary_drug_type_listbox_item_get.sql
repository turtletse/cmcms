DROP procedure if EXISTS sp_DSP_primary_drug_type_listbox_item_get;
delimiter $$
CREATE PROCEDURE sp_DSP_primary_drug_type_listbox_item_get (IN in_incl_deleted int)
BEGIN
	DROP TEMPORARY TABLE IF EXISTS result;
	CREATE TEMPORARY TABLE result
		select distinct pri_type, type_desc 
        from master_drug_type a LEFT JOIN master_drug_list b
        ON a.pri_type=b.drug_pri_type
        where sec_type=0 and isDeleted<=in_incl_deleted;
    INSERT INTO result VALUES (0, '全部');
    SELECT * FROM result ORDER BY pri_type;
    DROP TEMPORARY TABLE IF EXISTS result;
END $$
delimiter ;

-- CALL sp_DSP_primary_drug_type_listbox_item_get (0);