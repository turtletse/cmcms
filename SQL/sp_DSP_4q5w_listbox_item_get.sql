DROP procedure if EXISTS sp_DSP_4q5w_listbox_item_get;
delimiter $$
CREATE PROCEDURE sp_DSP_4q5w_listbox_item_get (IN in_pri_type int, IN in_sec_type int, IN in_nStrokes int, IN in_len int, IN in_incl_deleted int)
BEGIN
	
    DECLARE q1_sum, q2_sum, q3_sum, q4_sum, w1_sum, w2_sum, w3_sum, w4_sum, w5_sum, w6_sum int;
	CREATE TEMPORARY TABLE result (
		display_name VARCHAR(10),
        option_value VARCHAR(5),
        sort_field INT
	);
    
	select SUM(drug_q1), SUM(drug_q2), SUM(drug_q3), SUM(drug_q4), SUM(drug_w1), SUM(drug_w2), SUM(drug_w3), SUM(drug_w4), SUM(drug_w5), SUM(drug_w6)
    INTO q1_sum, q2_sum, q3_sum, q4_sum, w1_sum, w2_sum, w3_sum, w4_sum, w5_sum, w6_sum
    from master_drug_list 
    where (in_pri_type = 0 or (in_pri_type <> 0 and drug_pri_type = in_pri_type)) 
    and (in_sec_type = 0 or (in_sec_type <> 0 and drug_sec_type = in_sec_type))
    and (in_nStrokes = 0 or (in_nStrokes <> 0 and drug_name_stroke_idx = in_nStrokes))
    and (in_len = 0 or (in_len <> 0 and drug_name_length = in_len))
    and isDeleted<=in_incl_deleted;
    
    if q1_sum > 0 THEN
		INSERT INTO result VALUES ('寒', 'q1', 0);
	END IF;
    if q2_sum > 0 THEN
		INSERT INTO result VALUES ('熱', 'q2', 1);
	END IF;
    if q3_sum > 0 THEN
		INSERT INTO result VALUES ('溫', 'q3', 2);
	END IF;
    if q4_sum > 0 THEN
		INSERT INTO result VALUES ('涼', 'q4', 3);
    END IF;
    if w1_sum > 0 THEN
		INSERT INTO result VALUES ('辛', 'w1', 4);
    END IF;
    if w2_sum > 0 THEN
		INSERT INTO result VALUES ('甘', 'w2', 5);
    END IF;
    if w3_sum > 0 THEN
		INSERT INTO result VALUES ('酸', 'w3', 6);
    END IF;
    if w4_sum > 0 THEN
		INSERT INTO result VALUES ('苦', 'w4', 7);
    END IF;
    if w5_sum > 0 THEN
		INSERT INTO result VALUES ('鹹', 'w5', 8);
    END IF;
    if w6_sum > 0 THEN
		INSERT INTO result VALUES ('淡', 'w6', 9);
    END IF;
    
    SELECT display_name, option_value FROM result ORDER BY sort_field;
    DROP TEMPORARY TABLE result;
    
END $$
delimiter ;

-- CALL sp_DSP_4q5w_listbox_item_get (10, 20, 0, 2);