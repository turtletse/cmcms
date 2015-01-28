DROP PROCEDURE IF EXISTS sp_start_consultation;

DELIMITER $$
CREATE PROCEDURE sp_start_consultation (
	IN in_clinic_id VARCHAR(10),
    IN in_dr_id VARCHAR(10),
    IN in_pat_id INT
)
BEGIN
    IF(SELECT COUNT(*) FROM consultation_record WHERE clinic_id = in_clinic_id AND dr_id = in_dr_id AND patient_id = in_pat_id AND isFinished IN (0, 1))=0 THEN
		INSERT INTO consultation_record (
			cons_id,
			clinic_id,
			dr_id,
			patient_id,
			first_record_dtm,
			ex_code,
			ex_desc,
			diff_code,
			diff_desc,
			dx_code,
			dx_desc,
			pres_id,
			dr_rmk,
			isFinished,
			last_update_dtm
        ) VALUES (
			get_new_cons_id(),
            in_clinic_id,
            in_dr_id,
            in_pat_id,
            sysdate(),
            '',
            '',
            '',
            '',
            '',
            '',
            '',
            '',
            0,
            sysdate()
        );
    END IF;
	
    SELECT cons_id, clinic_id, dr_id, patient_id, DATE_FORMAT(first_record_dtm, '%d/%m/%Y %T') first_record_dtm, ex_code, ex_desc, diff_code, diff_desc, dx_code, dx_desc, pres_id, dr_rmk, isFinished, DATE_FORMAT(last_update_dtm, '%d/%m/%Y %T') last_update_dtm
    FROM consultation_record
    WHERE clinic_id = in_clinic_id AND dr_id = in_dr_id AND patient_id = in_pat_id AND isFinished IN (0, 1);
END $$

DELIMITER ;



-- CALL sp_start_consultation ('CITYC', 'CSM', 1)