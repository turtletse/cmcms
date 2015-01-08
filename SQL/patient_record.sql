DROP TABLE IF EXISTS patient_record;

CREATE TABLE patient_record(
	patient_id int,
    chin_name varchar(21),
    eng_name varchar(70),
    hashed_password CHAR(64),
    id_doc_type varchar(10),
    id_doc_no varchar(20),
    phone_no varchar(13),
    dob DATE,
    sex varchar(1),
    isG6PD INT(1),
    addr varchar(300),
    allergic_drug_ids varchar(1000),
    isDeceased int(1) DEFAULT 0,
    deceased_record_dtm DATETIME DEFAULT NULL
);

CREATE INDEX patient_record_x1 on patient_record (patient_id, isDeceased);
CREATE INDEX patient_record_x2 on patient_record (id_doc_type, id_doc_no, isDeceased);
CREATE INDEX patient_record_x3 on patient_record (phone_no, isDeceased);