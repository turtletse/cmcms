DROP procedure if EXISTS sp_differentiation_result_lv3_get;
delimiter $$
CREATE PROCEDURE sp_differentiation_result_lv3_get (IN in_lv1 INT, IN in_lv2 INT)
BEGIN
	SELECT result_code, result_desc
    FROM differentiation_results_list
    WHERE lv1 = in_lv1 AND lv2 = in_lv2 AND lv3 <> 0
    ORDER BY lv3;
END $$
delimiter ;

-- CALL sp_differentiation_result_lv3_get (20, 0);