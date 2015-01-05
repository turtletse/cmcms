CREATE TABLE master_drug_type (
	pri_type int,
    sec_type int,
    type_desc VARCHAR(30)
);
CREATE INDEX master_drug_type_x1 on master_drug_type (pri_type, sec_type);
CREATE INDEX master_drug_type_x2 on master_drug_type (sec_type);

CREATE TABLE dosage_unit (
	unit_id int,
    unit_desc VARCHAR(10),
    promote_val int,	--進位
    promote_to_id int,	--UNIT
    decrease_to_id int	--退位UNIT
);
CREATE INDEX dosage_unit_x1 on dosage_unit(unit_id);

CREATE TABLE master_drug_list (
	drug_id int,				--pri_type*10000+sec_type*10000+id (>pri_type*10000+sec_type*10000, <=pri_type*10000+sec_type*10000+99)
    drug_name varchar(30),
    drug_min_dosage_val int,
    drug_min_dosage_unit int,
    drug_max_dosage_val int,
    drug_man_dosage_unit int,
    drug_pri_type int,			--fk master_drug_type
    drug_sec_type int,			--fk master_drug_type
    drug_name_stroke_idx int,	--第一個字劃數
    drug_name_length int,		--字數
    drug_q1 smallint,			--寒, 四氣, 1=TRUE 0=FALSE
    drug_q2 SMALLINT,			--熱
    drug_q3 SMALLINT,			--溫
    drug_q4 SMALLINT,			--涼
    drug_w1 SMALLINT,			--辛, 五味
    drug_w2 SMALLINT,			--甘
    drug_w3 SMALLINT,			--酸
    drug_w4 SMALLINT,			--苦
    drug_w5 SMALLINT,			--鹹
    drug_w6 SMALLINT			--淡
    isDeleted INT
);
CREATE INDEX master_drug_list_x1 ON master_drug_list (drug_id);
CREATE INDEX master_drug_list_x2 ON master_drug_list (drug_pri_type, drug_sec_type);
CREATE INDEX master_drug_list_x3 ON master_drug_list (drug_name_stroke_idx);
CREATE INDEX master_drug_list_x4 ON master_drug_list (drug_name_length);
CREATE INDEX master_drug_list_x5 ON master_drug_list (drug_name);
CREATE INDEX master_drug_list_x6 ON master_drug_list (drug_pri_type, drug_sec_type, isDeleted);

CREATE TABLE drug_admin_abs_contraindication (
	drug_id int,				--fk master_drug_list
    pregnancy SMALLINT,			--0=no restriction, 1=avoid, 2=forbidden
    g6pd smallint
);
CREATE INDEX drug_admin_abs_contraindication_x1 ON drug_admin_abs_contraindication (drug_id);