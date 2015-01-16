DROP PROCEDURE IF EXISTS sp_insert_drug_item;

DELIMITER $$
CREATE PROCEDURE sp_insert_drug_item (
	IN in_drug_name varchar(30),
	IN in_drug_min_dosage_val decimal,
    IN in_drug_min_dosage_unit int,
    IN in_drug_max_dosage_val decimal,
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
    IN in_g6pd_contraindication_id SMALLINT
)
BEGIN
	DECLARE curr_status_id INT DEFAULT 0;
    
    /*DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		ROLLBACK;
        SET curr_status_id = 2;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	END;*/
    -- CALL debug_logger('sp_insert_drug_item pt0');
	if (select count(*) from master_drug_list where drug_name = in_drug_name) > 0 THEN
        SET curr_status_id = 1;
        SELECT * FROM insert_record_status where status_id = curr_status_id;
	ELSE
		START TRANSACTION;
			-- CALL debug_logger('sp_insert_drug_item pt1');
			INSERT INTO master_drug_list (
				drug_id,
				drug_name,
				drug_min_dosage_val,
				drug_min_dosage_unit,
				drug_max_dosage_val,
				drug_max_dosage_unit,
				drug_pri_type,
				drug_sec_type,
				drug_name_stroke_idx,
				drug_name_length,
				drug_q1,
				drug_q2,
				drug_q3,
				drug_q4,
				drug_w1,
				drug_w2,
				drug_w3,
				drug_w4,
				drug_w5,
				drug_w6)
			VALUES (
				(SELECT IFNULL(max(drug_id)+1 , in_drug_pri_type*10000+in_drug_sec_type*100+1) from master_drug_list x where x.drug_id BETWEEN in_drug_pri_type*10000+in_drug_sec_type*100 AND in_drug_pri_type*10000+in_drug_sec_type*100+99),
                in_drug_name,
                in_drug_min_dosage_val,
				in_drug_min_dosage_unit,
				in_drug_max_dosage_val,
				in_drug_max_dosage_unit,
				in_drug_pri_type,
				in_drug_sec_type,
                (SELECT nStrokes FROM unihan_ktotalstrokes_data where word = LEFT(in_drug_name, 1)),
                CHAR_LENGTH(in_drug_name),
                in_drug_q1,
				in_drug_q2,
				in_drug_q3,
				in_drug_q4,
				in_drug_w1,
				in_drug_w2,
				in_drug_w3,
				in_drug_w4,
				in_drug_w5,
				in_drug_w6
            );
            -- CALL debug_logger('sp_insert_drug_item pt2');
            IF in_pregnancy_contraindication_id + in_g6pd_contraindication_id > 0 THEN
				INSERT INTO drug_admin_abs_contraindication (
					drug_id,
					pregnancy,
					g6pd)
                VALUES (
					(SELECT drug_id FROM master_drug_list WHERE drug_name = in_drug_name),
                    in_pregnancy_contraindication_id,
                    in_g6pd_contraindication_id
                );                
            END IF;
            -- CALL debug_logger('sp_insert_drug_item pt3');
		COMMIT;
        -- CALL debug_logger('sp_insert_drug_item pt4');
        SELECT * FROM insert_record_status where status_id = curr_status_id;
        -- CALL debug_logger('sp_insert_drug_item pt5');
    END IF;
    -- CALL debug_logger('sp_insert_drug_item pt6');
END $$

DELIMITER ;

-- CALL sp_insert_drug_item ('一',1,10,2,20,10,10,1,1,1,1,1,1,1,1,1,1,0,0);

-- select * from debug_log order by log_dtm desc

/*select * from master_drug_list;
select * from drug_admin_abs_contraindication;*/
/*delete from master_drug_list where drug_id > 0;
delete from drug_admin_abs_contraindication where drug_id > 0;*/