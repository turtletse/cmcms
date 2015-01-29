DROP procedure if EXISTS sp_use_selected_cons_as_template;
delimiter $$
CREATE PROCEDURE sp_use_selected_cons_as_template (IN in_clinic_id VARCHAR(10), IN in_dr_id VARCHAR(10), IN in_curr_cons_id INT, IN in_sel_cons_id INT)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    DECLARE tmp_pres_id_str VARCHAR(255);
	DECLARE tmp_pres_id INT;
    DECLARE curr_pres_id INT;
    DECLARE done INT DEFAULT FALSE;
    DECLARE cur1 CURSOR FOR SELECT pres_id FROM presIds;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
    
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
        SET curr_status_id = 2;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	END;
    
    DROP TEMPORARY TABLE IF EXISTS consData;    
    CREATE TEMPORARY TABLE consData
	select cons_id, last_update_dtm, dx_desc, ex_desc, diff_desc, pres_id pres_data_str
	from consultation_record JOIN patient_record ON consultation_record.patient_id = patient_record.patient_id
    WHERE (clinic_id = in_clinic_id OR dr_id = in_dr_id) AND isFinished = 2 AND consultation_record.patient_id = in_pat_id;
	
    SET AUTOCOMMIT = 0;
    START TRANSACTION;
		
        SELECT pres_id INTO tmp_pres_id_str FROM consultation_record WHERE cons_id = in_sel_cons_id;
		CALL split(tmp_pres_id_str,'||');

		DROP TEMPORARY TABLE IF EXISTS presIds;
		CREATE TEMPORARY TABLE presIds
		SELECT CONVERT(split_value, UNSIGNED) pres_id FROM splitResult;
        
        DROP TEMPORARY TABLE IF EXISTS newPres;
		CREATE TEMPORARY TABLE newPres(pres_id INT);
        
		OPEN cur1;
		REPEAT
			FETCH cur1 INTO tmp_pres_id;
			IF NOT done THEN
				SET curr_pres_id = get_pres_id();
                
                INSERT INTO prescription(pres_id,instruction,no_of_dose,method_of_treatment)
                SELECT curr_pres_id, a.instruction, a.no_of_dose, a.method_of_treatment
                FROM prescription a
                WHERE pres_id = tmp_pres_id;
                
                INSERT INTO prescription_dt(pres_id, drug_id, sub_drug_id, drug_name, dosage, unit, preparation_method, display_order)
                SELECT curr_pres_id, a.drug_id, a.sub_drug_id, a.drug_name, a.dosage, a.unit, a.preparation_method, a.display_order
                FROM prescription_dt a
                WHERE pres_id = tmp_pres_id;
                
                INSERT INTO newPres VALUES (curr_pres_id);
			END IF;
		UNTIL done END REPEAT;
		CLOSE cur1;
    
    
		UPDATE consultation_record a, consultation_record b
		SET	a.ex_code = b.ex_code,
			a.ex_desc = b.ex_desc,
			a.diff_code = b.diff_code,
			a.diff_desc = b.diff_desc,
			a.dx_code = b.dx_code,
			a.dx_desc = b.dx_desc,
            a.pres_id = (SELECT group_concat(pres_id SEPARATOR '||') FROM newPres),
			a.dr_rmk = b.dr_rmk,
            a.last_update_dtm = sysdate()
		WHERE b.cons_id = in_cons_id;
	COMMIT;
    SET AUTOCOMMIT=1;
        
	DROP TEMPORARY TABLE newPres;
    DROP TEMPORARY TABLE presDt;
    DROP TEMPORARY TABLE presIds;
    DROP TEMPORARY TABLE consData;
    DROP TEMPORARY TABLE splitResult;
    SELECT * FROM insert_record_status where status_id = curr_status_id;
    -- CALL sp_consultation_get (in_clinic_id, in_dr_id, in_cons_id);
END $$
delimiter ;


-- CALL sp_consultation_history_get('CITYC', 'CSM', 1)