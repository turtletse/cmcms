DROP TABLE IF EXISTS dr_rmk_perdefined_list;

CREATE TABLE dr_rmk_perdefined_list(
	rmk_id INT,
    rmk_desc VARCHAR(255)
);

CREATE INDEX dr_rmk_perdefined_list_x1 ON dr_rmk_perdefined_list(rmk_id);
CREATE INDEX dr_rmk_perdefined_list_x2 ON dr_rmk_perdefined_list(rmk_desc);

CALL sp_insert_dr_rmk_predefined('忌');
CALL sp_insert_dr_rmk_predefined('宜');
CALL sp_insert_dr_rmk_predefined('食');
CALL sp_insert_dr_rmk_predefined('生冷');
CALL sp_insert_dr_rmk_predefined('油膩');
CALL sp_insert_dr_rmk_predefined('海鮮');
CALL sp_insert_dr_rmk_predefined('食物');
CALL sp_insert_dr_rmk_predefined('多喝開水');

-- SELECT * FROM dr_rmk_perdefined_list
