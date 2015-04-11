DROP TABLE IF EXISTS predefined_prescription;
CREATE TABLE predefined_prescription(
	predef_pres_id INT,
    predef_pres_name VARCHAR(255),
    isDeleted INT DEFAULT 0,
	isSystemSuspended INT DEFAULT 0
);
CREATE INDEX predefined_prescription_x1 ON predefined_prescription(predef_pres_id);