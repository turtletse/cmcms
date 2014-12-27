CREATE TABLE insert_record_status (
	status_id INT,
    status_desc VARCHAR(255)
);
CREATE INDEX insert_record_status_x1 on insert_record_status(status_id);

insert into insert_record_status values (0, '成功!');
insert into insert_record_status values (1, '失敗! 原因: 新增項目已經存在');
insert into insert_record_status values (2, '失敗! 原因: 不明');
