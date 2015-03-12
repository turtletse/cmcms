DROP FUNCTION IF EXISTS drug_dosage_chk;
DELIMITER $$
CREATE FUNCTION drug_dosage_chk(in_drug_id INT, in_dosage DECIMAL(8,4), in_unit INT) RETURNS INT
BEGIN
	DECLARE max_dosage INT;
    DECLARE max_unit INT;
    DECLARE min_dosage INT;
    DECLARE min_unit INT;
    DECLARE factor DECIMAL(8,4) DEFAULT 1;
    DECLARE smaller_unit INT DEFAULT 0;
    SELECT drug_min_dosage_val, drug_min_dosage_unit, drug_max_dosage_val, drug_max_dosage_unit
		INTO min_dosage, min_unit, max_dosage, max_unit
	FROM master_drug_list
    WHERE drug_id = in_drug_id;
    
    
    REPEAT
		SELECT decrease_to_id INTO smaller_unit FROM dosage_unit WHERE unit_id = max_unit;
        IF smaller_unit <> 0 THEN
			SELECT promote_val*factor, unit_id INTO factor, max_unit FROM dosage_unit WHERE unit_id = smaller_unit;
        END IF;
    UNTIL smaller_unit = 0 END REPEAT;
    IF max_unit=50 THEN
		SET factor = factor/0.375;
        SET max_unit = 10;
    END IF;
    SET max_dosage = max_dosage*factor;
    
    SET smaller_unit = 0;
    SET factor = 1;
    REPEAT
		SELECT decrease_to_id INTO smaller_unit FROM dosage_unit WHERE unit_id = min_unit;
        IF smaller_unit <> 0 THEN
			SELECT promote_val*factor, unit_id INTO factor, min_unit FROM dosage_unit WHERE unit_id = smaller_unit;
        END IF;
    UNTIL smaller_unit = 0 END REPEAT;
    IF min_unit=50 THEN
		SET factor = factor/0.375;
        SET min_unit = 10;
    END IF;
    SET min_dosage = min_dosage*factor;
    
    SET smaller_unit = 0;
    SET factor = 1;
    REPEAT
		SELECT decrease_to_id INTO smaller_unit FROM dosage_unit WHERE unit_id = in_unit;
        IF smaller_unit <> 0 THEN
			SELECT promote_val*factor, unit_id INTO factor, in_unit FROM dosage_unit WHERE unit_id = smaller_unit;
        END IF;
    UNTIL smaller_unit = 0 END REPEAT;
    IF in_unit=50 THEN
		SET factor = factor/0.375;
        SET in_unit = 10;
    END IF;
    SET in_dosage = in_dosage*factor;
    
    IF(in_unit <> min_unit OR min_unit <> max_unit OR max_unit <> in_unit) THEN
		RETURN 0;
	ELSEIF (in_dosage = 0) THEN
		RETURN -2;
	ELSEIF (in_dosage BETWEEN min_dosage AND max_dosage AND in_unit=min_unit AND in_unit= max_unit) THEN
		RETURN 0;
	ELSEIF (in_dosage<min_dosage AND in_unit=min_unit) THEN
		RETURN -1;
	ELSEIF (in_dosage>max_dosage AND in_unit=max_unit) THEN
		RETURN 1;
	ELSE
		RETURN 999;
	END IF;
    
END $$
DELIMITER ;

-- SELECT drug_dosage_chk(101001, 4.58,40);