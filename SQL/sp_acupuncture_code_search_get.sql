DROP PROCEDURE IF EXISTS sp_acupuncture_code_search_get;

DELIMITER $$
CREATE PROCEDURE sp_acupuncture_code_search_get(IN codes VARCHAR(255))
BEGIN
	CALL split(codes, ',');
    DROP TEMPORARY TABLE IF EXISTS code_list;
    CREATE TEMPORARY TABLE code_list
    SELECT split_value pt_code
    FROM splitResult
    WHERE split_value IS NOT NULL AND length(split_value)>0;
    
	SELECT pt_cd, CONCAT(pt_desc, ' (', pt_cd, ')') pt_desc
    FROM acupuncture_point
    WHERE pt_cd REGEXP (SELECT group_concat(pt_code SEPARATOR '|') FROM code_list)
    ORDER BY mv_id, length(pt_cd), pt_cd;
END $$
delimiter ;

-- CALL sp_acupuncture_code_search_get('GB12,KI3');