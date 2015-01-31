DROP procedure if EXISTS sp_issue_preg_cert;
delimiter $$
CREATE PROCEDURE sp_issue_preg_cert (
	IN in_cons_id INT,
    IN in_isPregnant INT,
    IN in_edc VARCHAR(10)
)
BEGIN
	INSERT INTO pregnant_cert(
		cert_id,
		consultation_id,
        isPregnant,
		edc
	) VALUES (
		last_insert_id(get_preg_cert_id()),
        in_cons_id,
        in_isPregnant,
        STR_TO_DATE(in_edc, '%d/%m/%Y')
    );
    SELECT last_insert_id() cert_id;
END $$
delimiter ;

-- CALL sp_issue_preg_cert (4, 0, NULL);