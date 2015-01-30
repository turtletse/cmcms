DROP TABLE IF EXISTS sick_leave_cert;

CREATE TABLE sick_leave_cert(
	cert_id INT,
    consultation_id INT,
    start_date DATE,
    end_date DATE,
    nDays INT,
    isVoid INT
);

CREATE INDEX sick_leave_cert_x1 ON sick_leave_cert(cert_id);
CREATE INDEX sick_leave_cert_x2 ON sick_leave_cert(consultation_id);
CREATE INDEX sick_leave_cert_x3 ON sick_leave_cert(start_date);
CREATE INDEX sick_leave_cert_x4 ON sick_leave_cert(isVoid);
CREATE INDEX sick_leave_cert_x5 ON sick_leave_cert(nDays);