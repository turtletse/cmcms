DROP PROCEDURE IF EXISTS sp_crrpt_dx_stat_rpt;

DELIMITER $$
CREATE PROCEDURE sp_crrpt_dx_stat_rpt (IN in_clinic_id VARCHAR(10))
BEGIN
	DECLARE start_date DATE;
    DECLARE end_date DATE;
    DECLARE done INT DEFAULT FALSE;
    DECLARE curr_cons_id INT;
    DECLARE curr_clinic_id VARCHAR(10);
    DECLARE curr_patient_id INT;
    DECLARE curr_first_record_dtm DATETIME;
    DECLARE curr_dx_code VARCHAR(255);
    DECLARE is_sys_new_case INT DEFAULT 0;
    DECLARE is_clinic_new_case INT DEFAULT 0;
    DECLARE cur1 CURSOR FOR SELECT cons_id FROM tmp_cons_rec ORDER BY first_record_dtm;
    DECLARE cur2 CURSOR FOR SELECT dx_code FROM curr_dx_list;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
    
    SET end_date = CURDATE();
    SET start_date = end_date - INTERVAL 30 DAY;
    
    DROP TEMPORARY TABLE IF EXISTS tmp_dx_list;
    CREATE TEMPORARY TABLE tmp_dx_list (lv1 INT, lv2 INT, dx_code VARCHAR(15), dx_desc VARCHAR(255), sys_pat_cnt INT DEFAULT 0, sys_new_cnt INT DEFAULT 0, clinic_pat_cnt INT DEFAULT 0, clinic_new_cnt INT DEFAULT 0, incl_in_sys_new INT DEFAULT 0);
    INSERT INTO tmp_dx_list (lv1, lv2, dx_code, dx_desc)
    SELECT lv1, lv2, result_code, GROUP_CONCAT(result_desc SEPARATOR ', ') FROM dx_results_list GROUP BY result_code;
    INSERT INTO tmp_dx_list (lv1, lv2, dx_code, dx_desc) VALUES (999, 999, 'FreeText', '自定義診斷');
    
    DROP TEMPORARY TABLE IF EXISTS tmp_cons_rec;
    CREATE TEMPORARY TABLE tmp_cons_rec
    SELECT cons_id, clinic_id, patient_id, first_record_dtm, dx_code
    FROM consultation_record WHERE isFinished > 0 AND first_record_dtm BETWEEN start_date and end_date;
    
     OPEN cur1;
		REPEAT
			FETCH cur1 INTO curr_cons_id;
			IF NOT done THEN
				SELECT clinic_id, patient_id, first_record_dtm, dx_code INTO curr_clinic_id, curr_patient_id, curr_first_record_dtm, curr_dx_code FROM tmp_cons_rec WHERE cons_id = curr_cons_id;
                CALL SPLIT(curr_dx_code, '||');
                
                DROP TEMPORARY TABLE IF EXISTS curr_dx_list;
                CREATE TEMPORARY TABLE curr_dx_list (dx_code VARCHAR(255));
                INSERT INTO curr_dx_list SELECT split_value dx_code FROM splitResult WHERE LENGTH(TRIM(split_value))>0;
                
                IF (SELECT COUNT(*) FROM curr_dx_list) > 0 THEN
					OPEN cur2;
						REPEAT
							FETCH cur2 INTO curr_dx_code;
							IF NOT done THEN
								SET is_sys_new_case = 0;
                                SET is_clinic_new_case = 0;
								IF (SELECT COUNT(*) 
									FROM consultation_record 
                                    WHERE patient_id = curr_patient_id 
										AND dx_code REGEXP CONCAT('(^|[0-9]+\\.[0-9]+\\.[0-9]+\\|{2})', curr_dx_code, '(\\|{2}[0-9]+\\.[0-9]+\\.[0-9]+|$)')
                                        AND first_record_dtm BETWEEN (DATE(curr_first_record_dtm) - INTERVAL 30 DAY) AND DATE(curr_first_record_dtm)) = 0 THEN
									SET is_sys_new_case = 1;
								END IF;
                                IF curr_clinic_id = in_clinic_id AND (SELECT COUNT(*) 
										FROM consultation_record 
										WHERE patient_id = curr_patient_id 
											AND dx_code REGEXP CONCAT('(^|[0-9]+\\.[0-9]+\\.[0-9]+\\|{2})', curr_dx_code, '(\\|{2}[0-9]+\\.[0-9]+\\.[0-9]+|$)')
											AND first_record_dtm BETWEEN (DATE(curr_first_record_dtm) - INTERVAL 30 DAY) AND DATE(curr_first_record_dtm)
                                            AND clinic_id = curr_clinic_id) = 0 THEN
									SET is_clinic_new_case = 1;
								END IF;
                                
                                UPDATE tmp_dx_list
                                SET sys_pat_cnt = sys_pat_cnt + 1,
									sys_new_cnt = sys_new_cnt + is_sys_new_case,
									clinic_pat_cnt = CASE WHEN curr_clinic_id = in_clinic_id THEN clinic_pat_cnt + 1 ELSE clinic_pat_cnt END,
                                    clinic_new_cnt = clinic_new_cnt + is_clinic_new_case,
                                    incl_in_sys_new = CASE WHEN is_sys_new_case AND is_clinic_new_case THEN incl_in_sys_new + 1 ELSE incl_in_sys_new END
								WHERE dx_code = curr_dx_code;
								
                                UPDATE tmp_cons_rec SET dx_code = REPLACE(dx_code, curr_dx_code, '') WHERE patient_id = curr_patient_id;

							END IF;
						UNTIL done END REPEAT;
					CLOSE cur2;
                    SET done = FALSE;
                END IF;
                
			END IF;
		UNTIL done END REPEAT;
	CLOSE cur1;
    
    SELECT dx_code, dx_desc, sys_pat_cnt, sys_new_cnt, clinic_pat_cnt, clinic_new_cnt, incl_in_sys_new
    FROM tmp_dx_list WHERE sys_pat_cnt > 0
    ORDER BY lv1, lv2;
    
END $$
DELIMITER ;
-- SELECT dx_code, dx_desc, sys_pat_cnt, sys_new_cnt, sys_new_cnt/(sys_new_cnt-sys_new_cnt), pat_cnt, new_cnt FROM tmp_dx_list
-- CALL sp_crrpt_dx_stat_rpt('CSM');
-- SELECT * FROM tmp_cons_rec