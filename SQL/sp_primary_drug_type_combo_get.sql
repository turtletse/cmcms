delimiter $$
DROP procedure if EXISTS sp_primary_drug_type_combo_get $$
CREATE PROCEDURE sp_primary_drug_type_combo_get ()
BEGIN
	select * from master_drug_type where sec_type=0 order by pri_type;	
END $$
delimiter ;

-- CALL sp_primary_drug_type_combo_get ();