DROP procedure if EXISTS sp_incompatible_drug_update;
delimiter $$
CREATE PROCEDURE sp_incompatible_drug_update (
	IN in_drug_id INT,
    IN in_incompatible_drug_list VARCHAR(255)
)
BEGIN
	DECLARE tmp_imcomp_drug_id VARCHAR(10);
    DECLARE cnt INT;
    DECLARE done INT DEFAULT FALSE;
	DECLARE cur1 CURSOR FOR SELECT imcomp_drug_id FROM tmp_incomp_drug;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;

	if (select count(*) from incompatible_drug where drug_id = in_drug_id)=0 then
		insert into incompatible_drug (drug_id) values (in_drug_id);
    end if;    

	CALL split(in_incompatible_drug_list, '||');
	DROP temporary table if exists tmp_incomp_drug;
	create temporary table tmp_incomp_drug select split_value imcomp_drug_id from splitResult;
	
	OPEN cur1;
		REPEAT
			FETCH cur1 INTO tmp_imcomp_drug_id;
			IF NOT done THEN
				select count(*) into cnt
				from incompatible_drug
				where drug_id = in_drug_id
					AND (
						drug_id = CAST(tmp_imcomp_drug_id AS unsigned)
						OR incompatible_with like CONCAT('%||', tmp_imcomp_drug_id, '||%')
					);
				if cnt = 0 then
					update incompatible_drug
					set incompatible_with = CONCAT(incompatible_with, tmp_imcomp_drug_id, '||')
					where drug_id = in_drug_id;
				end if;
				
				if (select count(*) from incompatible_drug where drug_id = CAST(tmp_imcomp_drug_id AS UNSIGNED))=0 then
					insert into incompatible_drug (drug_id) values (CAST(tmp_imcomp_drug_id AS UNSIGNED));
				end if;
				select count(*) into cnt
				from incompatible_drug
				where drug_id = CAST(tmp_imcomp_drug_id AS UNSIGNED)
					AND (
						drug_id = in_drug_id
						OR incompatible_with like CONCAT('%||', in_drug_id, '||%')
					);
				if cnt = 0 then
					update incompatible_drug
					set incompatible_with = CONCAT(incompatible_with, in_drug_id, '||')
					where drug_id = CAST(tmp_imcomp_drug_id AS UNSIGNED);
				end if;
				
			END IF;
		UNTIL done END REPEAT;
		CLOSE cur1;
    
    drop temporary table if exists splitResult;
    drop temporary table if exists tmp_incomp_drug;
END $$
delimiter ;

-- CALL sp_incompatible_drug_insert(101001, '101002||101003');
-- CALL sp_incompatible_drug_insert(102001, '101002||101005');

-- select * from incompatible_drug;

-- select * from master_drug_list;