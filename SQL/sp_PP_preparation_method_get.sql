DROP procedure if EXISTS sp_PP_preparation_method_get;
delimiter $$
CREATE PROCEDURE sp_PP_preparation_method_get ()
BEGIN
	SELECT method_id, method_desc
    FROM preparation_method
    ORDER BY method_id;
    
END $$
delimiter ;
-- CALL sp_PP_preparation_method_get ();
