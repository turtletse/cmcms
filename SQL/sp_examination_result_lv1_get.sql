DROP procedure if EXISTS sp_examination_result_lv1_get;
delimiter $$
CREATE PROCEDURE sp_examination_result_lv1_get ()
BEGIN
	SELECT lv1, result_desc
    FROM examination_results_list
    WHERE lv2 = 0 AND lv3 = 0 AND lv4 = 0 
    ORDER BY lv1;
END $$
delimiter ;

-- CALL sp_examination_result_lv1_get ();