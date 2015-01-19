DROP PROCEDURE IF EXISTS sp_predef_pres_list_get;

DELIMITER $$
CREATE PROCEDURE sp_predef_pres_list_get (
	IN in_incl_deleted INT
)
BEGIN
	SELECT predef_pres_id, predef_pres_name, isDeleted
    FROM predefined_prescription
    WHERE isDeleted<=in_incl_deleted
    ORDER BY predef_pres_id;
    
END $$

DELIMITER ;

-- CALL sp_predef_pres_list_get(0)