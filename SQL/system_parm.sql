DROP TABLE IF EXISTS system_parm;

CREATE TABLE system_parm(
	parm_name varchar(30),
    parm_value varchar(255),
    parm_desc varchar(255)
);

CREATE INDEX system_parm_x1 on system_parm (parm_name);

-- INSERT INTO system_parm VALUES ('pat_id_cnt', '0', 'for generation of patient_id');
-- SELECT * FROM SYSTEM_PARM
-- UPDATE system_parm SET parm_value = '0' where parm_name = 'pat_id_cnt'

-- INSERT INTO system_parm VALUES ('predef_prescription_cnt', '0', 'for generation of predef_pres_id');
-- UPDATE system_parm SET parm_value = '0' where parm_name = 'predef_prescription_cnt'

-- INSERT INTO system_parm VALUES ('consultation_cnt', '0', 'for generation of cons_id');

-- INSERT INTO system_parm VALUES ('prescription_cnt', '0', 'for generation of pres_id');

-- INSERT INTO system_parm VALUES ('dr_rmk_cnt', '0', 'for generation of rmk_id for dr_rmk_prefined_list');