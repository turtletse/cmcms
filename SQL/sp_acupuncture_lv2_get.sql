DROP PROCEDURE IF EXISTS sp_acupuncture_lv2_get;

DELIMITER $$
CREATE PROCEDURE sp_acupuncture_lv2_get(IN in_mv_id INT)
BEGIN
	SELECT part_id, part_desc
    FROM body_parts
    WHERE part_id IN (
		SELECT DISTINCT body_part_id
		FROM acupuncture_point
		WHERE in_mv_id = 0 OR (in_mv_id <> 0 AND mv_id = in_mv_id)
	)
    UNION (SELECT 0, '全部')
    ORDER BY part_id;
END $$
delimiter ;

-- CALL sp_acupuncture_lv2_get(10);