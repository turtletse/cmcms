DROP TABLE IF EXISTS user_account;
DROP TABLE IF EXISTS user_clinic_role_mapping;
DROP TABLE IF EXISTS user_role;
DROP TABLE IF EXISTS clinic;

CREATE TABLE user_account(
	user_id varchar(10),
    hashed_password char(64),
    chin_name varchar(21),
    eng_name varchar(70),
    reg_no varchar(20) DEFAULT NULL,
    last_login_dtm DATETIME DEFAULT NULL,
    last_login_clinic_id varchar(10) DEFAULT NULL,
    last_logout_dtm DATETIME DEFAULT NULL,
    last_logout_clinic_id varchar(10) DEFAULT NULL
);
CREATE INDEX user_account_x1 on user_account(user_id);
insert into user_account values ('sysAdm', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', '系統管理員', 'SYSTEM ADMIN', null, null, null, null, null);

CREATE TABLE user_clinic_role_mapping(
	user_id varchar(10),
    clinic_id varchar(10),
    user_role_id int
);
CREATE INDEX user_clinic_role_mapping_x1 on user_clinic_role_mapping(user_id, clinic_id, user_role_id);
insert into user_clinic_role_mapping values ('sysAdm', 'ALL', 4);

CREATE TABLE user_role(
	-- 0=no access, 1=staff, 2=doctor, 3=clinic admin, 4=system admin
	role_id int,
    role_desc varchar(255)
);
insert into user_role values (0, 'no access');
insert into user_role values (1, 'staff');
insert into user_role values (2, 'doctor');
insert into user_role values (3, 'clinic admin');
insert into user_role values (4, 'system admin');

CREATE TABLE clinic(
	-- id CANNOT BE ALL
	clinic_id varchar(10),
    clinic_chin_name varchar(60),
    clinic_eng_name varchar(255),
    clinic_addr varchar(1000),
    clinic_phone_no varchar(30)
);
CREATE INDEX clinic_x1 on clinic(clinic_id);