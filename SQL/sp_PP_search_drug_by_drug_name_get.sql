DROP procedure if EXISTS sp_PP_search_drug_by_drug_name_get;
delimiter $$
CREATE PROCEDURE sp_PP_search_drug_by_drug_name_get (IN in_drug_names VARCHAR(1000))
BEGIN
	CALL split(in_drug_names, ',');
    DROP TEMPORARY TABLE IF EXISTS drug_names;
    CREATE TEMPORARY TABLE drug_names
    SELECT split_value in_drug_name FROM splitResult;
    DROP TEMPORARY TABLE splitResult;
    DROP TEMPORARY TABLE IF EXISTS result;
    CREATE TEMPORARY TABLE result(
		isFound int,
		drug_id VARCHAR(15),
        drug_name VARCHAR(255)
    );

	INSERT INTO result (isFound, drug_id, drug_name)
	SELECT 1, CAST(drug_id AS CHAR), drug_name
	FROM master_drug_list
	WHERE drug_name IN (SELECT in_drug_name FROM drug_names);

	INSERT INTO result (isFound, drug_id, drug_name)
	SELECT 1, CONCAT_WS('||',drug_id,sub_drug_id), sub_drug_name
	FROM master_sub_drug_list
	WHERE sub_drug_name IN (SELECT in_drug_name FROM drug_names);

    CREATE TEMPORARY TABLE tmp_result
	SELECT 0 isFound, NULL drug_id, in_drug_name drug_name
	FROM drug_names
    WHERE in_drug_name NOT IN (SELECT drug_name FROM result);
    
    INSERT INTO result (isFound, drug_id, drug_name)
    SELECT isFound, drug_id, drug_name
	FROM tmp_result;
    
    DROP TEMPORARY TABLE tmp_result;
    
    SELECT isFound, drug_id, drug_name from result;
    DROP TEMPORARY TABLE result;
    DROP TEMPORARY TABLE IF EXISTS drug_names;
    
END $$
delimiter ;
-- CALL sp_PP_search_drug_by_drug_name_get ('淨麻黃,你好,紫蘇');

-- SELECT * FROM debug_log ORDER BY log_dtm desc
