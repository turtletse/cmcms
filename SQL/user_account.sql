DROP TABLE IF EXISTS user_account;
CREATE TABLE user_account(
	user_id varchar(10),
    hashed_password char(64),
    chin_name varchar(21),
    eng_name varchar(70),
    reg_no varchar(20) DEFAULT NULL,
    last_logout_dtm DATETIME DEFAULT NULL,
    last_logout_clinic_id varchar(10) DEFAULT NULL,
    isSuspended int(1) DEFAULT 0,
    last_update_dtm DATETIME(3)
);
CREATE INDEX user_account_x1 on user_account(user_id, isSuspended);
insert into user_account values ('SYSADM', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', '系統管理員', 'SYSTEM ADMIN', null, null, null, 0, SYSDATE(3));