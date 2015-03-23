DROP procedure if EXISTS sp_dr_rmk_predefined_get;
delimiter $$
CREATE PROCEDURE sp_dr_rmk_predefined_get ()
BEGIN
	SELECT rmk_id, rmk_desc
    FROM dr_rmk_perdefined_list
    ORDER BY CHAR_LENGTH(rmk_desc), rmk_id, rmk_desc;
END $$
delimiter ;

-- CALL sp_dr_rmk_predefined_get ();