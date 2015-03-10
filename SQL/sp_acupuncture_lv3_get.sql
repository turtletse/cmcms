DROP PROCEDURE IF EXISTS sp_acupuncture_lv3_get;

DELIMITER $$
CREATE PROCEDURE sp_acupuncture_lv3_get(IN in_mv_id INT, IN in_part_id INT)
BEGIN
	SELECT pt_cd, CONCAT(pt_desc, ' (', pt_cd, ')') pt_desc
    FROM acupuncture_point
    WHERE (in_mv_id = 0 OR (in_mv_id <> 0 AND mv_id = in_mv_id))
	AND (in_part_id = 0 OR (in_part_id <> 0  AND body_part_id = in_part_id))
    ORDER BY mv_id, length(pt_cd), pt_cd;
END $$
delimiter ;

-- CALL sp_acupuncture_lv3_get (0, 0)