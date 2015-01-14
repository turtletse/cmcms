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
    last_logout_dtm DATETIME DEFAULT NULL,
    last_logout_clinic_id varchar(10) DEFAULT NULL,
    isSuspended int(1) DEFAULT 0
);
CREATE INDEX user_account_x1 on user_account(user_id, isSuspended);
insert into user_account values ('SYSADM', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', '系統管理員', 'SYSTEM ADMIN', null, null, null,0);
insert into user_account values ('CITYCD1', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', '醫師甲', 'CITYC DOCTOR A', 1234567, null, null,0);
insert into user_account values ('CITYCA1', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', '管理員甲', 'CITYC ADM A', null, null, null,0);
insert into user_account values ('CITYCS1', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', '職員甲', 'CITYC STAFF A', null, null, null,0);

CREATE TABLE user_clinic_role_mapping(
	user_id varchar(10),
    clinic_id varchar(10),
    user_role_id int
);
CREATE INDEX user_clinic_role_mapping_x1 on user_clinic_role_mapping(user_id, clinic_id, user_role_id);
insert into user_clinic_role_mapping values ('SYSADM', 'ALL', 40);
insert into user_clinic_role_mapping values ('CITYCD1', 'CITYC', 20);
insert into user_clinic_role_mapping values ('CITYCA1', 'CITYC', 30);
insert into user_clinic_role_mapping values ('CITYCS1', 'CITYC', 10);

CREATE TABLE user_role(
	-- 0=no access, 1=staff, 2=doctor, 3=clinic admin, 4=system admin
	role_id int,
    role_desc varchar(255)
);
insert into user_role values (0, '不能存取');
insert into user_role values (10, '職員');
insert into user_role values (20, '醫生');
insert into user_role values (30, '診所管理員');
insert into user_role values (40, '系統管理員');

CREATE TABLE clinic(
	-- id CANNOT BE ALL
	clinic_id varchar(10),
    clinic_chin_name varchar(60),
    clinic_eng_name varchar(255),
    clinic_addr varchar(1000),
    clinic_phone_no varchar(30),
    isSuspended int(1) default 0
);
CREATE INDEX clinic_x1 on clinic(clinic_id, isSuspended);
insert into clinic values ('ALL', '系統管理', 'SYSTEM ADMIN', '-', '-', 0);
insert into clinic values ('CITYC', '城市診所', 'CITY CLINIC', '1 CITY RD', '23456788, 23456789, 23000000', 0);

-- select * from user_account;
-- select * from clinic