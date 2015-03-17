DROP PROCEDURE IF EXISTS sp_crrpt_clinic_cons_cnt_by_day;
DELIMITER $$
CREATE PROCEDURE sp_crrpt_clinic_cons_cnt_by_day(IN in_clinic_id VARCHAR(10))
BEGIN
	DECLARE start_date DATE;
    DECLARE end_date DATE;
    SET end_date = CURDATE();
    SET start_date = end_date - INTERVAL 30 DAY;
    
    DROP TEMPORARY TABLE IF EXISTS result;
    CREATE TEMPORARY TABLE result(
		cons_date DATE,
        cons_cnt INT,
        pres_cnt INT,
        w_pres INT,
        w_pres_percent DECIMAL(5,2),
        w_acupt INT,
        w_acupt_percent DECIMAL(5,2)
    );
    
    REPEAT
		INSERT INTO result
        SELECT start_date, 
			COUNT(DISTINCT cons_id), 
            COUNT(DISTINCT prescription.pres_id), 
            COUNT(DISTINCT CASE WHEN consultation_record.pres_id REGEXP '^[0-9]+(\\|\\|[0-9]+)*$' THEN cons_id ELSE 0 END),
            (COUNT(DISTINCT CASE WHEN consultation_record.pres_id REGEXP '^[0-9]+(\\|\\|[0-9]+)*$' THEN cons_id ELSE 0 END)/COUNT(DISTINCT cons_id))*100,
            COUNT(DISTINCT CASE WHEN LENGTH(TRIM(acupuncture_code))>0 THEN cons_id ELSE 0 END),
            (COUNT(DISTINCT CASE WHEN LENGTH(TRIM(acupuncture_code))>0 THEN cons_id ELSE 0 END)/COUNT(DISTINCT cons_id))*100
		FROM consultation_record LEFT JOIN prescription ON consultation_record.pres_id REGEXP CONCAT('(^|[0-9]\\|{2})', prescription.pres_id, '(\\|{2}[0-9]|$)')
        -- WHERE DATE(first_record_dtm) = start_date;
        WHERE clinic_id = in_clinic_id AND DATE(first_record_dtm) = start_date;
		SET start_date = start_date + INTERVAL 1 DAY;
    UNTIL start_date = end_date END REPEAT;
    
    SELECT DATE_FORMAT(cons_date, '%d/%m/%Y') cons_date, cons_cnt, pres_cnt, w_pres, IFNULL(w_pres_percent, '-') w_pres_percent, w_acupt, IFNULL(w_acupt_percent, '-') w_acupt_percent from result;
    
    -- WHERE DATE(first_record_dtm) + INTERVAL 30 DAY >= CURDATE();
END $$
DELIMITER ;

-- CALL sp_crrpt_clinic_cons_cnt_by_day('CSM');
