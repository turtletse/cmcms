DROP procedure if EXISTS sp_patient_listbox_get;
delimiter $$
CREATE PROCEDURE sp_patient_listbox_get (
	IN in_patient_id INT,
    IN in_hkid VARCHAR(20),
    IN in_phone_no VARCHAR(13),
    IN in_incl_deceased INT
)
BEGIN    
	select
		patient_id,
		chin_name,
		eng_name,
		hashed_password,
		id_doc_type,
		id_doc_no,
		phone_no,
		DATE_FORMAT(dob, '%d/%m/%Y') dob,
		sex,
		isG6PD,
		addr,
		allergic_drug_ids,
		isDeceased,
		IFNULL(DATE_FORMAT(deceased_record_dtm, '%d/%m/%Y'), '') deceased_record_dtm
	from patient_record
	where 
		(in_patient_id IS NULL OR patient_id = in_patient_id)
        AND (CHAR_LENGTH(in_hkid)=0 OR id_doc_no = in_hkid)
        AND (CHAR_LENGTH(in_phone_no)=0 OR phone_no = in_phone_no)
        AND (isDeceased<=in_incl_deceased);
END $$
delimiter ;

-- CALL sp_patient_listbox_get( NULL , '', '34567890', 0)