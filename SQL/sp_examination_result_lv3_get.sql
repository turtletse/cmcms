DROP procedure if EXISTS sp_examination_result_lv3_get;
delimiter $$
CREATE PROCEDURE sp_examination_result_lv3_get (IN in_lv1 INT, IN in_lv2 INT)
BEGIN
	SELECT lv3, result_desc
    FROM examination_results_list
    WHERE lv1 = in_lv1 AND lv2 = in_lv2 AND lv4 = 0
		AND ((lv3<>0)
			OR (lv3=0 AND (SELECT COUNT(*) FROM examination_results_list WHERE lv1 = in_lv1 AND lv2 = in_lv2 AND lv3=0 AND lv4 <> 0)>0))
    ORDER BY lv3;
END $$
delimiter ;

-- CALL sp_examination_result_lv3_get (10,10);