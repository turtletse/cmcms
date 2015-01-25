DROP procedure if EXISTS sp_examination_result_lv4_get;
delimiter $$
CREATE PROCEDURE sp_examination_result_lv4_get (IN in_lv1 INT, IN in_lv2 INT, IN in_lv3 INT)
BEGIN
	SELECT result_code, result_desc
    FROM examination_results_list
    WHERE lv1 = in_lv1 AND lv2 = in_lv2 AND lv3 = in_lv3 AND lv4<>0
    ORDER BY lv4;
END $$
delimiter ;

-- CALL sp_examination_result_lv4_get (10,10,0);