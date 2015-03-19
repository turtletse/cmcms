DROP PROCEDURE IF EXISTS sp_update_drug_item;

DELIMITER $$
CREATE PROCEDURE sp_update_drug_item (
	IN in_drug_id int,
	IN in_drug_name varchar(30),
	IN in_drug_min_dosage_val decimal(8,4),
    IN in_drug_min_dosage_unit int,
    IN in_drug_max_dosage_val decimal(8,4),
    IN in_drug_max_dosage_unit int,
    IN in_drug_pri_type int,
    IN in_drug_sec_type int,
    IN in_drug_q1 smallint,
    IN in_drug_q2 SMALLINT,
    IN in_drug_q3 SMALLINT,
    IN in_drug_q4 SMALLINT,
    IN in_drug_w1 SMALLINT,
    IN in_drug_w2 SMALLINT,
    IN in_drug_w3 SMALLINT,
    IN in_drug_w4 SMALLINT,
    IN in_drug_w5 SMALLINT,
    IN in_drug_w6 SMALLINT,
    IN in_pregnancy_contraindication_id SMALLINT,
    IN in_g6pd_contraindication_id SMALLINT,
    IN in_isDeleted INT
)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    DECLARE min_dosage DECIMAL(12,4);
    DECLARE min_unit INT;
    DECLARE max_dosage DECIMAL(12,4);
    DECLARE max_unit INT;
    DECLARE factor DECIMAL(8,4) DEFAULT 1;
    DECLARE smaller_unit INT DEFAULT 0;
    
    /*DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
        SET curr_status_id = 2;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	END;*/
	if (select count(*) from master_drug_list where drug_name = in_drug_name and drug_id <> in_drug_id) > 0 THEN
        SET curr_status_id = 4;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	ELSEIF (select count(*) from master_drug_list where drug_id = in_drug_id) <> 1 THEN
        SET curr_status_id = 5;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	ELSE
		SET min_dosage = in_drug_min_dosage_val;
        SET min_unit = in_drug_min_dosage_unit;
        SET max_dosage = in_drug_max_dosage_val;
        SET max_unit = in_drug_max_dosage_unit;
        REPEAT
			SELECT decrease_to_id INTO smaller_unit FROM dosage_unit WHERE unit_id = max_unit;
			IF smaller_unit <> 0 THEN
				SELECT promote_val*factor, unit_id INTO factor, max_unit FROM dosage_unit WHERE unit_id = smaller_unit;
			END IF;
		UNTIL smaller_unit = 0 END REPEAT;
		IF max_unit=50 THEN
			SET factor = factor/0.3779936375;
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
			SET factor = factor/0.3779936375;
			SET min_unit = 10;
		END IF;
		SET min_dosage = min_dosage*factor;
        IF max_unit <> min_unit THEN
			SET curr_status_id = 20;
			SELECT * FROM insert_record_status where status_id = curr_status_id;
        ELSEIF min_dosage>max_dosage THEN
			SET curr_status_id = 21;
			SELECT * FROM insert_record_status where status_id = curr_status_id;
        ELSE
        
			SET AUTOCOMMIT = 0;
			START TRANSACTION;
				UPDATE master_drug_list 
				SET	drug_name = in_drug_name,
					drug_min_dosage_val = in_drug_min_dosage_val,
					drug_min_dosage_unit = in_drug_min_dosage_unit,
					drug_max_dosage_val = in_drug_max_dosage_val,
					drug_max_dosage_unit = in_drug_max_dosage_unit,
					drug_pri_type = in_drug_pri_type,
					drug_sec_type = in_drug_sec_type,
					drug_name_stroke_idx = (SELECT nStrokes FROM unihan_ktotalstrokes_data where word = LEFT(in_drug_name, 1)),
					drug_name_length = CHAR_LENGTH(in_drug_name),
					drug_q1 = in_drug_q1,
					drug_q2 = in_drug_q2,
					drug_q3 = in_drug_q3,
					drug_q4 = in_drug_q4,
					drug_w1 = in_drug_w1,
					drug_w2 = in_drug_w2,
					drug_w3 = in_drug_w3,
					drug_w4 = in_drug_w4,
					drug_w5 = in_drug_w5,
					drug_w6 = in_drug_w6,
					isDeleted = in_isDeleted
				WHERE drug_id = in_drug_id;

				IF (select count(*) from drug_admin_abs_contraindication where drug_id = in_drug_id)>0 THEN
					UPDATE drug_admin_abs_contraindication
					SET pregnancy = in_pregnancy_contraindication_id,
						g6pd = in_g6pd_contraindication_id
					WHERE drug_id = in_drug_id;
				ELSEIF in_pregnancy_contraindication_id + in_g6pd_contraindication_id > 0 THEN
					INSERT INTO drug_admin_abs_contraindication (
						drug_id,
						pregnancy,
						g6pd)
					VALUES (
						in_drug_id,
						in_pregnancy_contraindication_id,
						in_g6pd_contraindication_id
					);                
				END IF;
                
                DROP TEMPORARY TABLE IF EXISTS predef_pres_ids;
                CREATE TEMPORARY TABLE predef_pres_ids (predef_pres_id INT, deleted_cnt INT DEFAULT 0);
                INSERT INTO predef_pres_ids(predef_pres_id)
                SELECT DISTINCT predef_pres_id 
                FROM predefined_prescription_dt
                WHERE drug_id = in_drug_id;
                
                DROP TEMPORARY TABLE IF EXISTS del_cnt_list;
                CREATE TEMPORARY TABLE del_cnt_list
                SELECT predef_pres_id, SUM(isDeleted) deleted_cnt
                FROM predefined_prescription_dt JOIN master_drug_list ON predefined_prescription_dt.drug_id = master_drug_list.drug_id
                WHERE predefined_prescription_dt.predef_pres_id IN (SELECT predef_pres_id FROM predef_pres_ids)
                GROUP BY predef_pres_id;
                
                UPDATE predef_pres_ids, del_cnt_list
                SET predef_pres_ids.deleted_cnt = predef_pres_ids.deleted_cnt + del_cnt_list.deleted_cnt
                WHERE predef_pres_ids.predef_pres_id = del_cnt_list.predef_pres_id;
                
                DROP TEMPORARY TABLE IF EXISTS del_cnt_list;
                CREATE TEMPORARY TABLE del_cnt_list
                SELECT predef_pres_id, SUM(isDeleted) deleted_cnt
                FROM predefined_prescription_dt JOIN master_sub_drug_list ON predefined_prescription_dt.drug_id = master_sub_drug_list.drug_id AND predefined_prescription_dt.sub_drug_id = master_sub_drug_list.sub_drug_id
                WHERE predefined_prescription_dt.predef_pres_id IN (SELECT predef_pres_id FROM predef_pres_ids)
                GROUP BY predef_pres_id;
                
                UPDATE predef_pres_ids, del_cnt_list
                SET predef_pres_ids.deleted_cnt = predef_pres_ids.deleted_cnt + del_cnt_list.deleted_cnt
                WHERE predef_pres_ids.predef_pres_id = del_cnt_list.predef_pres_id;
                
                UPDATE predefined_prescription, predef_pres_ids
                SET isSystemSuspended = CASE WHEN predef_pres_ids.deleted_cnt>0 THEN 1 ELSE 0 END
                WHERE predefined_prescription.predef_pres_id = predef_pres_ids.predef_pres_id;
				
			COMMIT;
			SET AUTOCOMMIT = 1;
            
			CALL cmcis.common_prescribe_drug_list_update_by_cmcms(in_drug_id, 0, in_drug_name);
			
			SELECT * FROM insert_record_status where status_id = curr_status_id;
        END IF;
    END IF;
    
END $$

DELIMITER ;

-- CALL sp_update_drug_item (101001, '麻黃',5.0000,10,3.0000,20,10,10,0,0,1,0,1,0,0,1,0,0,0,1, 1)

-- select * from debug_log order by log_dtm desc

/*select * from master_drug_list;
select * from drug_admin_abs_contraindication;*/
/*delete from master_drug_list where drug_id > 0;
delete from drug_admin_abs_contraindication where drug_id > 0;*/