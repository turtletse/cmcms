DROP procedure if EXISTS sp_examination_result_search_get;
delimiter $$
CREATE PROCEDURE sp_examination_result_search_get (IN in_keywords VARCHAR(255))
BEGIN
	CALL split(in_keywords, ';');    
	SELECT result_code, result_desc
    FROM examination_results_list
    WHERE lv4<>0 AND result_desc REGEXP (SELECT GROUP_CONCAT(split_value SEPARATOR '|') FROM splitResult)
    ORDER BY CHAR_LENGTH(result_desc), result_desc;
    DROP TEMPORARY TABLE splitResult;
END $$
delimiter ;

-- CALL sp_examination_result_search_get ('面;色');