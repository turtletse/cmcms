DROP TABLE IF EXISTS master_sub_drug_list;

CREATE TABLE master_sub_drug_list (
	drug_id int,
    sub_drug_id int(2),
    sub_drug_name VARCHAR(255)
);

CREATE INDEX master_sub_drug_list_x1 on master_sub_drug_list(drug_id, sub_drug_id);
CREATE INDEX master_sub_drug_list_x2 on master_sub_drug_list(sub_drug_name);