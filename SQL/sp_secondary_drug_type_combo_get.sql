delimiter $$
DROP procedure if EXISTS sp_secondary_drug_type_combo_get $$
CREATE PROCEDURE sp_secondary_drug_type_combo_get (IN pri_type_id int)
BEGIN
	CREATE TEMPORARY TABLE result
	select * from master_drug_type where pri_type = pri_type_id and sec_type<>0 order by pri_type;	
    if (select count(*) from result)=0 THEN
		insert into result values (pri_type_id, 0, '-');
	END IF;
    SELECT pri_type, sec_type, type_desc from result;
    DROP TEMPORARY TABLE result;
END $$
delimiter ;

-- CALL sp_secondary_drug_type_combo_get (10);

-- drop TEMPORARY table result