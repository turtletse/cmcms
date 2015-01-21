DROP TABLE IF EXISTS consultation_record;
CREATE TABLE consultation_record(
	cons_id int,
    clinic_id VARCHAR(10),
    dr_id VARCHAR(10),
    cons_dtm DATETIME,
    -- ex_code VARCHAR(255),
    ex_desc VARCHAR(255),
    -- diff_code VARCHAR(255),
    diff_desc VARCHAR(255),
    dx_code VARCHAR(255),
    dx_desc VARCHAR(255),
    pres_id VARCHAR(255),
    dr_rmk VARCHAR(450)
);
CREATE INDEX consultation_record_x1 ON consultation_record(clinic_id, cons_id);
CREATE INDEX consultation_record_x2 ON consultation_record(cons_id);
CREATE INDEX consultation_record_x3 ON consultation_record(dr_id);



DROP TABLE IF EXISTS prescription;
CREATE TABLE prescription(
	pres_id int,
    instruction VARCHAR(255),
    no_of_dose int,
    method_of_treatment VARCHAR(255)
);
CREATE INDEX prescription_x1 ON prescription(pres_id);



DROP TABLE IF EXISTS prescription_dt;
CREATE TABLE prescription_dt(
	pres_id int,
    drug_id int,
    sub_drug_id int,
    drug_name VARCHAR(255),
    dosage int,
    unit int,
    display_order int
);
CREATE INDEX prescription_dt_x1 ON prescription_dt(pres_id, display_order);