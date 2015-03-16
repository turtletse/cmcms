DROP procedure if EXISTS sp_issue_sick_leave_cert;
delimiter $$
CREATE PROCEDURE sp_issue_sick_leave_cert (
	IN in_cons_id INT,
    IN in_start_date VARCHAR(10),
    IN in_end_date VARCHAR(10),
    IN in_tot_days INT
)
BEGIN
	DECLARE cons_end_dtm DATETIME;
    DECLARE cons_start_dtm DATETIME;
    DECLARE isFinished INT;
    SELECT last_update_dtm, consultation_record.isFinished, first_record_dtm INTO cons_end_dtm, isFinished, cons_start_dtm
    FROM consultation_record
    WHERE cons_id = in_cons_id;
    
    IF (cons_end_dtm + INTERVAL 1 DAY) < sysdate() AND isFinished = 2 THEN
		SELECT -1 cert_id;
	ELSEIF (cons_start_dtm - INTERVAL 1 DAY) > STR_TO_DATE(in_start_date, '%d/%m/%Y') THEN
		SELECT -2 cert_id;
	ELSE
		INSERT INTO sick_leave_cert(
			cert_id,
			consultation_id,
			start_date,
			end_date,
			nDays
		) VALUES (
			last_insert_id(get_sick_leave_cert_id()),
			in_cons_id,
			STR_TO_DATE(in_start_date, '%d/%m/%Y'),
			STR_TO_DATE(in_end_date, '%d/%m/%Y'),
			in_tot_days
		);
		SELECT last_insert_id() cert_id;
	END IF;
END $$
delimiter ;

-- CALL sp_issue_sick_leave_cert('9', '16/03/2015', '16/03/2015', 1);