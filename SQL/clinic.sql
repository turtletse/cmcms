DROP TABLE IF EXISTS clinic;
CREATE TABLE clinic(
	-- id CANNOT BE ALL
	clinic_id varchar(10),
    clinic_chin_name varchar(60),
    clinic_eng_name varchar(255),
    clinic_addr varchar(1000),
    clinic_phone_no varchar(30),
    isSuspended int(1) default 0,
    last_update_dtm DATETIME(3)
);
CREATE INDEX clinic_x1 on clinic(clinic_id, isSuspended);
insert into clinic values ('ALL', '系統管理', 'SYSTEM ADMIN', '-', '-', 0, sysdate(3));