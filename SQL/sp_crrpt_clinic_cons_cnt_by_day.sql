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
        cons_cnt INT
    );
    
    REPEAT
		INSERT INTO result
        SELECT start_date, COUNT(*)
		FROM consultation_record
        WHERE clinic_id = in_clinic_id AND DATE(first_record_dtm) = start_date;
		SET start_date = start_date + INTERVAL 1 DAY;
    UNTIL start_date = end_date END REPEAT;
    
    SELECT DATE_FORMAT(cons_date, '%d/%m/%Y') cons_date, cons_cnt from result;
    
    -- WHERE DATE(first_record_dtm) + INTERVAL 30 DAY >= CURDATE();
END $$
DELIMITER ;

-- CALL sp_crrpt_clinic_cons_cnt_by_day('CITYC');
