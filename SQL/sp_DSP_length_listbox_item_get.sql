DROP procedure if EXISTS sp_DSP_length_listbox_item_get;
delimiter $$
CREATE PROCEDURE sp_DSP_length_listbox_item_get (IN in_pri_type int, IN in_sec_type int, IN in_nStrokes int, IN in_incl_deleted int)
BEGIN
	DROP TEMPORARY TABLE IF EXISTS result;
	CREATE TEMPORARY TABLE result
		select distinct drug_name_length nameLength, CAST(drug_name_length AS CHAR) nameLength_desc
        from master_drug_list 
        where (in_pri_type = 0 or (in_pri_type <> 0 and drug_pri_type = in_pri_type)) 
        and (in_sec_type = 0 or (in_sec_type <> 0 and drug_sec_type = in_sec_type))
        and (in_nStrokes = 0 or (in_nStrokes <> 0 and drug_name_stroke_idx = in_nStrokes))
        and isDeleted<=in_incl_deleted;
    INSERT INTO result VALUES (0, '全部');
    SELECT nameLength, nameLength_desc FROM result ORDER BY nameLength;
    DROP TEMPORARY TABLE IF EXISTS result;
END $$
delimiter ;

-- CALL sp_DSP_length_listbox_item_get (0, 0, 0);