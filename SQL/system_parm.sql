DROP TABLE IF EXISTS system_parm;

CREATE TABLE system_parm(
	parm_name varchar(30),
    parm_value varchar(255),
    parm_desc varchar(255)
);

CREATE INDEX system_parm_x1 on system_parm (parm_name);

INSERT INTO system_parm VALUES ('pat_id_cnt', '0', 'for generation of patient_id');
INSERT INTO system_parm VALUES ('predef_prescription_cnt', '0', 'for generation of predef_pres_id');
INSERT INTO system_parm VALUES ('dr_rmk_cnt', '0', 'for generation of rmk_id for dr_rmk_prefined_list');
INSERT INTO system_parm VALUES ('prescription_cnt', '0', 'for generation of pres_id');
INSERT INTO system_parm VALUES ('consultation_cnt', '0', 'for generation of cons_id');
INSERT INTO system_parm VALUES ('instruction_cnt', '0', 'for generation of insturction_id');
INSERT INTO system_parm VALUES ('sick_leave_cert_cnt', '0', 'for generation of sick_leave_cert_id');
INSERT INTO system_parm VALUES ('preg_cert_cnt', '0', 'for generation of preg_cert_id');
INSERT INTO system_parm VALUES ('pres_clean_up_to_dtm', null, 'Last run of sp_prescription_clean_up covered prescription updated before the value');
INSERT INTO system_parm VALUES ('pres_clean_up_error', 'N', 'Error occured in the last run of sp_prescription_clean_up');