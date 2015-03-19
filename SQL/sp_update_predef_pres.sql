DROP PROCEDURE IF EXISTS sp_update_predef_pres;

DELIMITER $$
CREATE PROCEDURE sp_update_predef_pres (
	IN in_predef_pres_id int,
	IN in_predef_pres_name VARCHAR(255),
    IN in_drug_data_str VARCHAR(10000),
    IN in_isDeleted int
)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    DECLARE done INT DEFAULT FALSE;
    DECLARE tmp_drug_str VARCHAR(40);
    DECLARE tmp_drug_code VARCHAR(15);
    DECLARE tmp_sub_drug_code VARCHAR(2);
    DECLARE tmp_dosage DECIMAL(8,4);
    DECLARE tmp_unit INT;
    DECLARE tmp_method INT;
    DECLARE cur1 CURSOR FOR SELECT drug_data FROM drug_data_str;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
    
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
        SET curr_status_id = 2;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	END;
    CALL debug_logger('START');
	if (select count(*) from predefined_prescription where predef_pres_id = in_predef_pres_id) = 0 THEN
        SET curr_status_id = 5;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	ELSE
		SET AUTOCOMMIT =0;
		START TRANSACTION;
            CALL split(in_drug_data_str, '##');
            DROP TEMPORARY TABLE IF EXISTS drug_data_str;
            CREATE TEMPORARY TABLE drug_data_str
            SELECT split_value drug_data FROM splitResult;
            DROP TEMPORARY TABLE splitResult;
			UPDATE predefined_prescription
            SET	predef_pres_name = in_predef_pres_name,
				isDeleted = in_isDeleted
			WHERE predef_pres_id = in_predef_pres_id;
            
            DELETE FROM predefined_prescription_dt
            WHERE predef_pres_id = in_predef_pres_id;
            OPEN cur1;
            REPEAT
				FETCH cur1 INTO tmp_drug_str;
				IF NOT done THEN
					SET tmp_drug_code = stringSplit(tmp_drug_str,'^^',1);
                    SET tmp_sub_drug_code = stringSplit(tmp_drug_code,'||',2);
                    SET tmp_drug_code = stringSplit(tmp_drug_code,'||',1);
                    SET tmp_dosage = CAST(stringSplit(tmp_drug_str,'^^',2) AS DECIMAL(8,4));
                    SET tmp_unit = CAST(stringSplit(tmp_drug_str,'^^',3) AS UNSIGNED);
                    SET tmp_method = CAST(stringSplit(tmp_drug_str,'^^',4) AS UNSIGNED);
                    if LENGTH(TRIM(tmp_sub_drug_code))=0 THEN
						SET tmp_sub_drug_code = '0';
					END IF;
                    CALL debug_logger(CONCAT('B ',tmp_drug_code));
                    INSERT INTO predefined_prescription_dt(
						predef_pres_id,
						drug_id,
						sub_drug_id,
						dosage,
						unit,
						preparation_method
					)VALUES(
						in_predef_pres_id,
                        CAST(tmp_drug_code AS UNSIGNED),
                        CAST(tmp_sub_drug_code AS UNSIGNED),
                        tmp_dosage,
                        tmp_unit,
                        tmp_method
                    );
				END IF;
			UNTIL done END REPEAT;
			CLOSE cur1;
		COMMIT;
        SET AUTOCOMMIT =1;
        DROP TEMPORARY TABLE drug_data_str;
        SELECT status_id, status_desc FROM insert_record_status where status_id = curr_status_id;
        
    END IF;
    
END $$

DELIMITER ;

-- SELECT * FROM predefined_prescription_dt
-- CALL sp_update_predef_pres (13, '再造散', '1401004^^2.0000^^20^^20##1401001^^1.0000^^20^^20##101002^^1.0000^^20^^20##1403003^^1.0000^^20^^20##1401011^^0.5000^^20^^20##800001||4^^1.0000^^20^^20##101009^^1.0000^^20^^20##101006^^1.0000^^20^^20##1302001^^1.0000^^20^^20##1401010^^2^^110^^20##101011||1^^1^^20^^20', 0)
-- SELECT * FROM debug_log ORDER BY log_dtm DESC