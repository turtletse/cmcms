DROP TABLE IF EXISTS prescription;
CREATE TABLE prescription(
	pres_id int,
    instruction VARCHAR(255),
    no_of_dose int,
    method_of_treatment VARCHAR(255),
    last_update_dtm DATETIME(3)
);
CREATE INDEX prescription_x1 ON prescription(pres_id);
CREATE INDEX prescription_x2 ON prescription(last_update_dtm);