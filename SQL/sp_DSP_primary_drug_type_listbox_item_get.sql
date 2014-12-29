DROP procedure if EXISTS sp_DSP_primary_drug_type_listbox_item_get;
delimiter $$
CREATE PROCEDURE sp_DSP_primary_drug_type_listbox_item_get ()
BEGIN
	CREATE TEMPORARY TABLE result
		select pri_type, type_desc from master_drug_type where sec_type=0;
    INSERT INTO result VALUES (0, '全部');
    SELECT * FROM result ORDER BY pri_type;
    DROP TEMPORARY TABLE result;
END $$
delimiter ;

-- CALL sp_DSP_primary_drug_type_listbox_item_get ();