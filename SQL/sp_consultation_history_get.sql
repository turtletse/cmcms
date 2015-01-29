DROP procedure if EXISTS sp_consultation_history_get;
delimiter $$
CREATE PROCEDURE sp_consultation_history_get (IN in_clinic_id VARCHAR(10), IN in_dr_id VARCHAR(10), IN in_pat_id INT)
BEGIN
	DECLARE tmp_pres_id_str VARCHAR(255);
    DECLARE tmp_cons_id INT;
    DECLARE done INT DEFAULT FALSE;
    DECLARE cur1 CURSOR FOR SELECT cons_id, pres_data_str FROM consData;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
    
    DROP TEMPORARY TABLE IF EXISTS consData;    
    CREATE TEMPORARY TABLE consData
	select cons_id, last_update_dtm, dx_desc, ex_desc, diff_desc, pres_id pres_data_str
	from consultation_record JOIN patient_record ON consultation_record.patient_id = patient_record.patient_id
    WHERE (clinic_id = in_clinic_id OR dr_id = in_dr_id) AND isFinished = 2 AND consultation_record.patient_id = in_pat_id;
	
    OPEN cur1;
		REPEAT
			FETCH cur1 INTO tmp_cons_id, tmp_pres_id_str;
			IF NOT done THEN
				CALL split(tmp_pres_id_str,'||');
    
				DROP TEMPORARY TABLE IF EXISTS presIds;
				CREATE TEMPORARY TABLE presIds
				SELECT CONVERT(split_value, UNSIGNED) pres_id FROM splitResult;
				
				DROP TEMPORARY TABLE IF EXISTS presDt;
				CREATE TEMPORARY TABLE presDt
				SELECT GROUP_CONCAT(drug_name ORDER BY display_order SEPARATOR ', ') presStr
				FROM prescription NATURAL JOIN prescription_dt JOIN dosage_unit ON unit = unit_id JOIN preparation_method ON preparation_method = method_id
				WHERE pres_id IN (SELECT pres_id FROM presIds)
				GROUP BY pres_id;
                
                UPDATE consData SET pres_data_str = (SELECT CONCAT('[',GROUP_CONCAT(presStr SEPARATOR '] ['),']') FROM presDt) WHERE cons_id = tmp_cons_id;
			END IF;
		UNTIL done END REPEAT;
		CLOSE cur1;
    
    SELECT cons_id, DATE_FORMAT(last_update_dtm, '%d/%m/%Y %T') cons_dtm, dx_desc, ex_desc, diff_desc, pres_data_str
    FROM consData
    ORDER BY last_update_dtm;
        
    DROP TEMPORARY TABLE presDt;
    DROP TEMPORARY TABLE presIds;
    DROP TEMPORARY TABLE consData;
    DROP TEMPORARY TABLE splitResult;
END $$
delimiter ;


-- CALL sp_consultation_history_get('CITYC', 'CSM', 1)