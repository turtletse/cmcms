DROP TABLE IF EXISTS user_clinic_role_mapping;
CREATE TABLE user_clinic_role_mapping(
	user_id varchar(10),
    clinic_id varchar(10),
    user_role_id int
);
CREATE INDEX user_clinic_role_mapping_x1 on user_clinic_role_mapping(user_id, clinic_id, user_role_id);
insert into user_clinic_role_mapping values ('SYSADM', 'ALL', 40);