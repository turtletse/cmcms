DROP TABLE IF EXISTS prescription_dt;
CREATE TABLE prescription_dt(
	pres_id int,
    drug_id int,
    sub_drug_id int,
    drug_name VARCHAR(255),
    dosage DECIMAL(8,4),
    unit int,
    preparation_method int,
    display_order int
);
CREATE INDEX prescription_dt_x1 ON prescription_dt(pres_id, display_order);