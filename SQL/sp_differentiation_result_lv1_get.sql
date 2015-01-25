DROP procedure if EXISTS sp_differentiation_result_lv1_get;
delimiter $$
CREATE PROCEDURE sp_differentiation_result_lv1_get ()
BEGIN
	SELECT lv1, result_desc
    FROM differentiation_results_list
    WHERE lv2 = 0 AND lv3 = 0
    ORDER BY lv1;
END $$
delimiter ;

-- CALL sp_differentiation_result_lv1_get ();