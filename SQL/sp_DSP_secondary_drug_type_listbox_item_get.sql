DROP procedure if EXISTS sp_DSP_secondary_drug_type_listbox_item_get;
delimiter $$
CREATE PROCEDURE sp_DSP_secondary_drug_type_listbox_item_get (IN in_pri_type int)
BEGIN
	CREATE TEMPORARY TABLE result
		select pri_type, sec_type, type_desc from master_drug_type where pri_type = in_pri_type and sec_type <> 0;
    INSERT INTO result VALUES (0, 0, '全部');
    SELECT sec_type, type_desc FROM result ORDER BY pri_type, sec_type;
    DROP TEMPORARY TABLE result;
END $$
delimiter ;

-- CALL sp_DSP_secondary_drug_type_listbox_item_get (10);