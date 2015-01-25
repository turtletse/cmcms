DROP procedure if EXISTS sp_differentiation_result_lv2_get;
delimiter $$
CREATE PROCEDURE sp_differentiation_result_lv2_get (IN in_lv1 INT)
BEGIN
	SELECT lv2, result_desc
    FROM differentiation_results_list
    WHERE lv1 = in_lv1 AND lv3 = 0
		AND ((lv2<>0)
			OR (lv2=0 AND (SELECT COUNT(*) FROM differentiation_results_list WHERE lv1 = in_lv1 AND lv2 = 0 AND lv3 <> 0)>0))
    ORDER BY lv2;
END $$
delimiter ;

-- CALL sp_differentiation_result_lv2_get (10);