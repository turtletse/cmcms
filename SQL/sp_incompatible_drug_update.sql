DROP procedure if EXISTS sp_incompatible_drug_update;
delimiter $$
CREATE PROCEDURE sp_incompatible_drug_update (
	IN in_drug_id INT,
    IN in_incompatible_drug_list VARCHAR(255)
)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
	DECLARE tmp_imcomp_drug_id VARCHAR(10);
    DECLARE originalIncompatibleDrugIds VARCHAR(255);
    DECLARE cnt INT;
    DECLARE done INT DEFAULT FALSE;
	DECLARE cur1 CURSOR FOR SELECT imcomp_drug_id FROM tmp_incomp_drug WHERE imcomp_drug_id NOT IN (SELECT drug_id FROM old_incompatible_drug);
    DECLARE cur2 CURSOR FOR SELECT drug_id FROM old_incompatible_drug WHERE drug_id NOT IN (SELECT imcomp_drug_id FROM tmp_incomp_drug);
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
    
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
        SET curr_status_id = 2;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	END;

	if (select count(*) from incompatible_drug where drug_id = in_drug_id)=0 then
		insert into incompatible_drug (drug_id) values (in_drug_id);
    end if;    

	CALL split(in_incompatible_drug_list, '||');
	DROP temporary table if exists tmp_incomp_drug;
	create temporary table tmp_incomp_drug select split_value imcomp_drug_id from splitResult WHERE length(TRIM(split_value))>0;
    
    SELECT incompatible_with INTO originalIncompatibleDrugIds FROM incompatible_drug WHERE drug_id = in_drug_id;
    CALL split(originalIncompatibleDrugIds, '||');
    DROP TEMPORARY TABLE IF EXISTS old_incompatible_drug;
    CREATE TEMPORARY TABLE old_incompatible_drug
    SELECT CAST(split_value AS UNSIGNED) drug_id FROM splitResult WHERE length(TRIM(split_value))>0;
	
    SET AUTOCOMMIT = 0;
    START TRANSACTION;
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
    
    SET done = FALSE;
    OPEN cur2;
		REPEAT
			FETCH cur2 INTO tmp_imcomp_drug_id;
			IF NOT done THEN
				UPDATE incompatible_drug
                set incompatible_with = REPLACE(incompatible_with, CONCAT('||',tmp_imcomp_drug_id), '')
				where drug_id = in_drug_id;
                
                UPDATE incompatible_drug
                set incompatible_with = REPLACE(incompatible_with, CONCAT('||',in_drug_id), '')
				where drug_id = tmp_imcomp_drug_id;
				
			END IF;
		UNTIL done END REPEAT;
	CLOSE cur2;
    
    COMMIT;
    SET AUTOCOMMIT =1;
    SELECT * FROM insert_record_status where status_id = curr_status_id;
    drop temporary table if exists splitResult;
    drop temporary table if exists tmp_incomp_drug;
    DROP TEMPORARY TABLE IF EXISTS old_incompatible_drug;
END $$
delimiter ;

-- CALL sp_incompatible_drug_update(101001, '101002||101006');
-- CALL sp_incompatible_drug_update(102001, '101002||101005');
-- CALL sp_incompatible_drug_update (100501, '')

-- select * from incompatible_drug;

-- select * from master_drug_list;