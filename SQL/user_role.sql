DROP TABLE IF EXISTS user_role;
CREATE TABLE user_role(
	-- 0=no access, 10=staff, 20=doctor, 30=clinic admin, 40=system admin
	role_id int,
    role_desc varchar(255)
);
CREATE INDEX user_role_x1 ON user_role(role_id);
insert into user_role values (0, '不能存取');
insert into user_role values (10, '職員');
insert into user_role values (20, '醫生');
insert into user_role values (30, '診所管理員');
insert into user_role values (40, '系統管理員');