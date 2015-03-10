DROP TABLE IF EXISTS consultation_record;
CREATE TABLE consultation_record(
	cons_id int,
    clinic_id VARCHAR(10),
    dr_id VARCHAR(10),
    patient_id INT,
    first_record_dtm DATETIME,
    ex_code VARCHAR(255),
    ex_desc VARCHAR(255),
    diff_code VARCHAR(255),
    diff_desc VARCHAR(255),
    dx_code VARCHAR(255),
    dx_desc VARCHAR(255),
    pres_id VARCHAR(255),
    acupuncture_code VARCHAR(255),
    acupuncture_desc VARCHAR(255),
    dr_rmk VARCHAR(450),
    isFinished int DEFAULT 0,
    last_update_dtm DATETIME
);
CREATE INDEX consultation_record_x1 ON consultation_record(clinic_id, cons_id);
CREATE INDEX consultation_record_x2 ON consultation_record(first_record_dtm);
CREATE INDEX consultation_record_x3 ON consultation_record(dr_id);
CREATE INDEX consultation_record_x4 ON consultation_record(last_update_dtm);
CREATE INDEX consultation_record_x5 ON consultation_record(isFinished);
CREATE INDEX consultation_record_x6 ON consultation_record(patient_id);



DROP TABLE IF EXISTS prescription;
CREATE TABLE prescription(
	pres_id int,
    instruction VARCHAR(255),
    no_of_dose int,
    method_of_treatment VARCHAR(255)
    -- isIssued int
);
CREATE INDEX prescription_x1 ON prescription(pres_id);
-- CREATE INDEX prescription_x2 ON prescription(isIssued);



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