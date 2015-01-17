DROP TABLE IF EXISTS predefined_prescription;
CREATE TABLE predefined_prescription(
	predef_pres_id INT,
    predef_pres_name VARCHAR(255),
    isDeleted INT DEFAULT 0
);
CREATE INDEX predefined_prescription_x1 ON predefined_prescription(predef_pres_id);

DROP TABLE IF EXISTS predefined_prescription_dt;
CREATE TABLE predefined_prescription_dt(
	predef_pres_id INT,
    drug_id INT,
    sub_drug_id INT,
    dosage DECIMAL(8, 4),
    unit INT,
    preparation_method INT
);
CREATE INDEX predefined_prescription_dt_x1 ON predefined_prescription_dt(predef_pres_id);
