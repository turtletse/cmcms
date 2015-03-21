DROP PROCEDURE IF EXISTS sp_drug_reservation;
DELIMITER $$
CREATE PROCEDURE sp_drug_reservation(IN in_clinic_id VARCHAR(10), IN in_cons_id INT)
BEGIN
	DECLARE return_msg VARCHAR(1000) DEFAULT '';
    DECLARE curr_pres_ids VARCHAR(255);
    DECLARE return_status INT DEFAULT 999;
    
    IF (isCmpmsExist() = 0) THEN
		SET return_status = -1;
	ELSE
		SELECT pres_id INTO curr_pres_ids FROM consultation_record WHERE cons_id = in_cons_id AND clinic_id = in_clinic_id;
		CALL cmcis.sp_stock_reservation(in_clinic_id, curr_pres_ids);
		SELECT reserv_status INTO return_status FROM cmcis.tmp_result;
    END IF;
    
    SELECT return_status;
    
END $$
DELIMITER ;

-- CALL sp_drug_reservation('CSM', 9)