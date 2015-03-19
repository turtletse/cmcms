DROP PROCEDURE IF EXISTS sp_crrpt_drug_listing;
DELIMITER $$
CREATE PROCEDURE sp_crrpt_drug_listing()
BEGIN
	SELECT a.type_desc pri_desc, 
		b.type_desc sec_desc, 
        drug_name_stroke_idx,
        drug_name_length,
		master_drug_list.drug_name, 
        CONCAT('[ ', 
        CONCAT_WS(' ', TRIM(TRAILING '.' FROM TRIM(TRAILING '0' FROM drug_min_dosage_val)), c.unit_desc), ' - ',
        CONCAT_WS(' ', TRIM(TRAILING '.' FROM TRIM(TRAILING '0' FROM drug_max_dosage_val)), d.unit_desc), ' ]') dosage_range,
        CASE WHEN master_drug_list.isDeleted = 1 THEN '是' ELSE '否' END master_isDeleted,
        sub_drug_name,
        CASE WHEN master_sub_drug_list.isDeleted IS NULL THEN NULL WHEN master_sub_drug_list.isDeleted = 1 THEN '是' ELSE '否' END sub_drug_isDeleted
    FROM master_drug_list JOIN master_drug_type a ON master_drug_list.drug_pri_type = a.pri_type AND a.sec_type = 0
		JOIN master_drug_type b ON master_drug_list.drug_pri_type = b.pri_type AND master_drug_list.drug_sec_type = b.sec_type
		LEFT JOIN master_sub_drug_list ON master_drug_list.drug_id = master_sub_drug_list.drug_id
        JOIN dosage_unit c ON master_drug_list.drug_min_dosage_unit = c.unit_id
        JOIN dosage_unit d ON master_drug_list.drug_max_dosage_unit = d.unit_id
	ORDER BY master_drug_list.drug_pri_type, master_drug_list.drug_sec_type, master_drug_list.isDeleted, drug_name_length, drug_name_stroke_idx, master_drug_list.drug_id, master_sub_drug_list.isDeleted, master_sub_drug_list.sub_drug_id;
END $$
DELIMITER ;

-- CALL sp_crrpt_drug_listing()