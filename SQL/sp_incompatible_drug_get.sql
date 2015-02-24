DROP procedure if EXISTS sp_incompatible_drug_get;
delimiter $$
CREATE PROCEDURE sp_incompatible_drug_get (
	IN in_drug_id INT
)
BEGIN
	DECLARE incompatibleDrugIds VARCHAR(255);
    
    SELECT incompatible_with INTO incompatibleDrugIds FROM incompatible_drug WHERE drug_id = in_drug_id;
    
    CALL split(incompatibleDrugIds, '||');
    DROP TEMPORARY TABLE IF EXISTS tmp_incompatible_drug;
    CREATE TEMPORARY TABLE tmp_incompatible_drug
    SELECT CAST(split_value AS UNSIGNED) drug_id FROM splitResult WHERE length(TRIM(split_value))>0;
    DROP TEMPORARY TABLE IF EXISTS splitResult;
    
    SELECT drug_name, drug_id
    FROM master_drug_list
    WHERE drug_id IN (SELECT drug_id FROM tmp_incompatible_drug)
    ORDER BY CHAR_LENGTH(drug_name), drug_name;
    
    DROP TEMPORARY TABLE IF EXISTS tmp_incompatible_drug;
END $$
delimiter ;

-- CALL sp_incompatible_drug_get(101001);

-- select * from incompatible_drug;

-- select * from master_drug_list;