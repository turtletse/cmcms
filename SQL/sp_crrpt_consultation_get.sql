DROP procedure if EXISTS sp_crrpt_consultation_get;
delimiter $$
CREATE PROCEDURE sp_crrpt_consultation_get (IN in_cons_id VARCHAR(10))
BEGIN
	select cons_id, CONCAT('*',cons_id,'*') cons_id_barcode, CONCAT(patient_record.chin_name, ' (', patient_record.patient_id,')') pat_name, user_account.chin_name dr_name, dx_desc, dr_rmk, DATE_FORMAT(last_update_dtm, '%d/%m/%Y %T') last_update_dtm
	from consultation_record JOIN user_account ON dr_id = user_id JOIN patient_record ON consultation_record.patient_id = patient_record.patient_id
    WHERE cons_id=in_cons_id;
END $$
delimiter ;

-- CALL sp_crrpt_consultation_get(1);
