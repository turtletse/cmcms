DROP PROCEDURE IF EXISTS sp_insert_predef_pres;

DELIMITER $$
CREATE PROCEDURE sp_insert_predef_pres (
	IN in_predef_pres_name VARCHAR(255),
    IN in_drug_data_str VARCHAR(10000)
)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    DECLARE pres_id INT;
    DECLARE done INT DEFAULT FALSE;
    DECLARE tmp_drug_str VARCHAR(40);
    DECLARE tmp_drug_code VARCHAR(15);
    DECLARE tmp_sub_drug_code VARCHAR(2);
    DECLARE tmp_dosage DECIMAL;
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
	if (select count(*) from predefined_prescription where predef_pres_name = in_predef_pres_name) > 0 THEN
        SET curr_status_id = 4;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	ELSE
		SET AUTOCOMMIT =0;
		START TRANSACTION;
            CALL split(in_drug_data_str, '##');
            DROP TEMPORARY TABLE IF EXISTS drug_data_str;
            CREATE TEMPORARY TABLE drug_data_str
            SELECT split_value drug_data FROM splitResult;
            DROP TEMPORARY TABLE splitResult;
            
            INSERT INTO predefined_prescription (
				predef_pres_id,
                predef_pres_name
			)VALUES (
				LAST_INSERT_ID(get_new_predef_pres_id()),
                in_predef_pres_name
            );
            SET pres_id = LAST_INSERT_ID();
            
            OPEN cur1;
            REPEAT
				FETCH cur1 INTO tmp_drug_str;
				IF NOT done THEN
					SET tmp_drug_code = stringSplit(tmp_drug_str,'^^',1);
                    SET tmp_sub_drug_code = stringSplit(tmp_drug_code,'||',2);
                    SET tmp_drug_code = stringSplit(tmp_drug_code,'||',1);
                    SET tmp_dosage = CAST(stringSplit(tmp_drug_str,'^^',2) AS DECIMAL);
                    SET tmp_unit = CAST(stringSplit(tmp_drug_str,'^^',3) AS UNSIGNED);
                    SET tmp_method = CAST(stringSplit(tmp_drug_str,'^^',4) AS UNSIGNED);
                    if LENGTH(TRIM(tmp_sub_drug_code))=0 THEN
						SET tmp_sub_drug_code = '0';
					END IF;
                    
                    INSERT INTO predefined_prescription_dt(
						predef_pres_id,
						drug_id,
						sub_drug_id,
						dosage,
						unit,
						preparation_method
					)VALUES(
						pres_id,
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
        DROP TEMPORARY TABLE drug_data_str;
        SELECT status_id, status_desc FROM insert_record_status where status_id = curr_status_id;
        
    END IF;
    
END $$

DELIMITER ;


-- CALL sp_insert_predef_pres('ABC', '101001||1^^1^^10^^20##101002^^3^^20^^10');
-- SELECT * FROM system_parm;
-- SELECT * FROM predefined_prescription;
-- SELECT * FROM predefined_prescription_dt;

-- delete from predefined_prescription;
-- delete from predefined_prescription_dt;