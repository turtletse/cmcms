DROP PROCEDURE IF EXISTS sp_check_stocks;
DELIMITER $$
CREATE PROCEDURE sp_check_stocks(IN in_clinic_id VARCHAR(10), IN in_cons_id INT)
BEGIN
	DECLARE return_msg VARCHAR(10000) DEFAULT '';
    DECLARE curr_pres_ids VARCHAR(255);
    DECLARE return_status INT;
    
	DROP TEMPORARY TABLE IF EXISTS result;
    CREATE TEMPORARY TABLE result(
		chk_status INT,
        pres_id INT,
        drug_id INT,
        sub_drug_id INT,
        drug_name VARCHAR(255)
	);
    IF (isCmpmsExist() = 0) THEN
		INSERT INTO result(chk_status) VALUES (3);
	ELSE
		SELECT pres_id INTO curr_pres_ids FROM consultation_record WHERE cons_id = in_cons_id AND clinic_id = in_clinic_id;
		CALL cmcis.sp_stock_enquiry(in_clinic_id, curr_pres_ids);
		INSERT INTO result (chk_status, pres_id, drug_name)
		SELECT stock_status, pres_id, drug_name FROM cmcis.tmp_prescription;
    END IF;
    
    SELECT MAX(chk_status) INTO return_status FROM result;
	SELECT return_status, GROUP_CONCAT(c.sub_msg ORDER BY c.chk_status SEPARATOR '\n\n') status_msg
	FROM(
		SELECT chk_status, 
			CONCAT_WS('\n',
				CASE chk_status
					WHEN 1 THEN '以下藥物可能藥房存貨不足:'
					WHEN 0 THEN '以下藥物藥房沒有存貨:'
					ELSE ''
				END, 
				GROUP_CONCAT(b.drug ORDER BY b.pres_id SEPARATOR '\n')) sub_msg
		FROM (
			SELECT chk_status, pres_id, CONCAT('處方編號: ', pres_id, ' 藥物: ',GROUP_CONCAT(a.drug_name ORDER BY a.drug_id, a.sub_drug_id SEPARATOR ', ')) drug
			FROM result a
			WHERE chk_status > 0
			GROUP BY a.chk_status, a.pres_id) b
		GROUP BY b.chk_status) c;
END $$
DELIMITER ;

-- CALL sp_check_stocks('CSM', 9)