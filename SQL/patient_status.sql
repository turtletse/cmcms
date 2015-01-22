DROP TABLE IF EXISTS patient_status;

CREATE TABLE patient_status(
	status_id int,
    status_desc varchar(255)
);

CREATE INDEX patient_status_x1 ON patient_status(status_id);

INSERT INTO patient_status VALUES (0, '輪候中');
INSERT INTO patient_status VALUES (10, '呼喚');
INSERT INTO patient_status VALUES (20, '進入診症');
INSERT INTO patient_status VALUES (30, '診症');
INSERT INTO patient_status VALUES (40, '稍後再診');