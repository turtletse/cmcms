DROP PROCEDURE IF EXISTS sp_acupuncture_lv1_get;

DELIMITER $$
CREATE PROCEDURE sp_acupuncture_lv1_get()
BEGIN
	SELECT mv_id, mv_desc
    FROM acupuncture_meridian_vessel
    UNION (SELECT 0, '全部')
    ORDER BY mv_id;
END $$
delimiter ;