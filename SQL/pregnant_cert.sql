DROP TABLE IF EXISTS pregnant_cert;

CREATE TABLE pregnant_cert(
	cert_id INT,
    consultation_id INT,
    isPregnant INT,
	edc DATE DEFAULT NULL,
    isVoid INT DEFAULT 0
);

CREATE INDEX pregnant_cert_x1 ON pregnant_cert(cert_id);
CREATE INDEX pregnant_cert_x2 ON pregnant_cert(consultation_id);
CREATE INDEX pregnant_cert_x3 ON pregnant_cert(edc);
CREATE INDEX pregnant_cert_x4 ON pregnant_cert(isVoid);
CREATE INDEX pregnant_cert_x5 ON pregnant_cert(isPregnant);
