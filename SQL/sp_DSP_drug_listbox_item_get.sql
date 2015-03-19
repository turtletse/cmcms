DROP procedure if EXISTS sp_DSP_drug_listbox_item_get;
delimiter $$
CREATE PROCEDURE sp_DSP_drug_listbox_item_get (
	IN in_pri_type int,
    IN in_sec_type int,
    IN in_nStrokes int,
    IN in_len int,
    IN in_4q5w VARCHAR(255),
    IN in_incl_deleted int)
BEGIN
	DECLARE q1, q2, q3, q4, w1, w2, w3, w4, w5, w6 int DEFAULT 0;
    -- DECLARE parm_4q5w VARCHAR(255);
    DECLARE tmp_4q5w VARCHAR(10);
    DECLARE done INT DEFAULT FALSE;
    DECLARE cur1 CURSOR FOR SELECT item FROM selected_4q5w;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
    
    -- SET parm_4q5w=in_4q5w;
	If length(in_4q5w) = 0 THEN
		SET in_4q5w = 'q1||q2||q3||q4||w1||w2||w3||w4||w5||w5';
	END IF;
    CALL split(in_4q5w, '||');
    DROP TEMPORARY TABLE IF EXISTS selected_4q5w;
    CREATE TEMPORARY TABLE selected_4q5w
    SELECT split_value item FROM splitResult;
    DROP TEMPORARY TABLE splitResult;
    OPEN cur1;
    REPEAT
		FETCH cur1 INTO tmp_4q5w;
        IF NOT done THEN
			CASE tmp_4q5w
				WHEN 'q1' THEN SET q1=1;
				WHEN 'q2' THEN SET q2=1;
				WHEN 'q3' THEN SET q3=1;
				WHEN 'q4' THEN SET q4=1;
				WHEN 'w1' THEN SET w1=1;
				WHEN 'w2' THEN SET w2=1;
				WHEN 'w3' THEN SET w3=1;
				WHEN 'w4' THEN SET w4=1;
				WHEN 'w5' THEN SET w5=1;
				WHEN 'w6' THEN SET w6=1;
			END CASE;
		END IF;
	UNTIL done END REPEAT;
    CLOSE cur1;
    DROP TEMPORARY TABLE selected_4q5w;
    DROP TEMPORARY TABLE IF EXISTS result;
	CREATE TEMPORARY TABLE result
		select drug_name, m.drug_id, drug_min_dosage_val, drug_min_dosage_unit, drug_max_dosage_val, drug_max_dosage_unit, drug_pri_type, drug_sec_type, isDeleted, drug_q1, drug_q2, drug_q3, drug_q4, drug_w1, drug_w2, drug_w3, drug_w4, drug_w5, drug_w6, pregnancy, g6pd
        from master_drug_list m LEFT JOIN drug_admin_abs_contraindication c
		ON m.drug_id=c.drug_id
        where (in_pri_type = 0 or (in_pri_type <> 0 and drug_pri_type = in_pri_type)) 
        and (in_sec_type = 0 or (in_sec_type <> 0 and drug_sec_type = in_sec_type))
        and (in_nStrokes = 0 or (in_nStrokes <> 0 and drug_name_stroke_idx = in_nStrokes))
        and (in_len = 0 or (in_len <> 0 and drug_name_length = in_len))
        and isDeleted <= in_incl_deleted
        and (
				(q1 <> 0 and drug_q1 = 1)
            or	(q2 <> 0 and drug_q2 = 1)
            or	(q3 <> 0 and drug_q3 = 1)
            or	(q4 <> 0 and drug_q4 = 1)
            or	(w1 <> 0 and drug_w1 = 1)
            or	(w2 <> 0 and drug_w2 = 1)
            or	(w3 <> 0 and drug_w3 = 1)
            or	(w4 <> 0 and drug_w4 = 1)
            or	(w5 <> 0 and drug_w5 = 1)
            or	(w6 <> 0 and drug_w6 = 1)
        );
    SELECT distinct drug_name, drug_id, drug_min_dosage_val, drug_min_dosage_unit, drug_max_dosage_val, drug_max_dosage_unit, drug_pri_type, drug_sec_type, isDeleted, drug_q1, drug_q2, drug_q3, drug_q4, drug_w1, drug_w2, drug_w3, drug_w4, drug_w5, drug_w6, IFNULL(pregnancy, 0) pregnancy, IFNULL(g6pd, 0) g6pd FROM result ORDER BY drug_id;
    DROP TEMPORARY TABLE result;
END $$
delimiter ;
-- select * from master_drug_list;

-- CALL sp_DSP_drug_listbox_item_get (0, 0, 0, 0, '', 0);