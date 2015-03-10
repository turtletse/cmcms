DROP PROCEDURE IF EXISTS sp_acupuncture_keywords_search_get;

DELIMITER $$
CREATE PROCEDURE sp_acupuncture_keywords_search_get(IN keywords VARCHAR(255))
BEGIN
	CALL split(keywords, ',');
    DROP TEMPORARY TABLE IF EXISTS keyword_list;
    CREATE TEMPORARY TABLE keyword_list
    SELECT split_value keyword
    FROM splitResult
    WHERE split_value IS NOT NULL AND length(split_value)>0;
    
	SELECT pt_cd, CONCAT(pt_desc, ' (', pt_cd, ')') pt_desc
    FROM acupuncture_point
    WHERE pt_desc REGEXP (SELECT group_concat(keyword SEPARATOR '|') FROM keyword_list)
    ORDER BY mv_id, length(pt_cd), pt_cd;
END $$
delimiter ;

-- CALL sp_acupuncture_keywords_search_get('中,少');