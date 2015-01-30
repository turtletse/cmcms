DROP procedure if EXISTS sp_issue_sick_leave_cert;
delimiter $$
CREATE PROCEDURE sp_issue_sick_leave_cert (
	IN in_cons_id INT,
    IN in_start_date VARCHAR(10),
    IN in_end_date VARCHAR(10),
    IN in_tot_days INT
)
BEGIN
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
END $$
delimiter ;

-- CALL sp_amd_clinic_get('CITYC');