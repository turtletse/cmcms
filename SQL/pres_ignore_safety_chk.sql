DROP TABLE IF EXISTS pres_ignore_safety_chk;
CREATE TABLE pres_ignore_safety_chk(
	pres_id INT,
    incompatible_drug INT(1) DEFAULT 0, -- 1
    g6pd_not_recommended INT(1) DEFAULT 0, -- 2
    g6pd_forbidden INT(1) DEFAULT 0, -- 3
    pregnant_not_recommended INT(1) DEFAULT 0, -- 4
    pregnant_forbidden INT(1) DEFAULT 0, -- 5
    drug_wo_dosage INT(1) DEFAULT 0, -- 6
    drug_below_min_dosage INT(1) DEFAULT 0, -- 7
    drug_exceed_max_dosage INT(1) DEFAULT 0, -- 8
    record_dtm DATETIME(3)
);

CREATE INDEX pres_ignore_safety_chk_x1 ON pres_ignore_safety_chk(pres_id);
CREATE INDEX pres_ignore_safety_chk_x2 ON pres_ignore_safety_chk(record_dtm);
CREATE INDEX pres_ignore_safety_chk_x3 ON pres_ignore_safety_chk(incompatible_drug);
CREATE INDEX pres_ignore_safety_chk_x4 ON pres_ignore_safety_chk(g6pd_not_recommended);
CREATE INDEX pres_ignore_safety_chk_x5 ON pres_ignore_safety_chk(g6pd_forbidden);
CREATE INDEX pres_ignore_safety_chk_x6 ON pres_ignore_safety_chk(pregnant_not_recommended);
CREATE INDEX pres_ignore_safety_chk_x7 ON pres_ignore_safety_chk(pregnant_forbidden);
CREATE INDEX pres_ignore_safety_chk_x8 ON pres_ignore_safety_chk(drug_wo_dosage);
CREATE INDEX pres_ignore_safety_chk_x9 ON pres_ignore_safety_chk(drug_below_min_dosage);
CREATE INDEX pres_ignore_safety_chk_x10 ON pres_ignore_safety_chk(drug_exceed_max_dosage);

-- SELECT * FROM pres_ignore_safety_chk;