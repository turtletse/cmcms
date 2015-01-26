DROP TABLE IF EXISTS dr_rmk_perdefined_list;

CREATE TABLE dr_rmk_perdefined_list(
	rmk_id INT,
    rmk_desc VARCHAR(255)
);

CREATE INDEX dr_rmk_perdefined_list_x1 ON dr_rmk_perdefined_list(rmk_id);
CREATE INDEX dr_rmk_perdefined_list_x2 ON dr_rmk_perdefined_list(rmk_desc);

CALL sp_insert_dr_rmk_predefined('忌');
CALL sp_insert_dr_rmk_predefined('宜');
CALL sp_insert_dr_rmk_predefined('醫囑一');
CALL sp_insert_dr_rmk_predefined('醫囑二');
CALL sp_insert_dr_rmk_predefined('醫囑三');

-- SELECT * FROM dr_rmk_perdefined_list
