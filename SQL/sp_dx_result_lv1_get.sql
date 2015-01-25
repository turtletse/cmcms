DROP procedure if EXISTS sp_dx_result_lv1_get;
delimiter $$
CREATE PROCEDURE sp_dx_result_lv1_get ()
BEGIN
	SELECT lv1, result_desc
    FROM dx_results_list
    WHERE lv2 = 0
    ORDER BY lv1;
END $$
delimiter ;

-- CALL sp_dx_result_lv1_get ();