DROP procedure if EXISTS sp_dx_result_lv2_get;
delimiter $$
CREATE PROCEDURE sp_dx_result_lv2_get (IN in_lv1 INT)
BEGIN
	SELECT result_code, result_desc
    FROM dx_results_list
    WHERE lv1 = in_lv1 AND lv2 <> 0
    ORDER BY lv2;
END $$
delimiter ;

-- CALL sp_dx_result_lv2_get (10);