CREATE TABLE insert_record_status (
	status_id INT,
    status_desc VARCHAR(255)
);
CREATE INDEX insert_record_status_x1 on insert_record_status(status_id);

insert into insert_record_status values (0, '成功!');
insert into insert_record_status values (1, '失敗! 原因: 新增項目已經存在');
insert into insert_record_status values (2, '失敗! 原因: 不明');
insert into insert_record_status values (3, '失敗! 原因: 主項目不存在');
insert into insert_record_status values (4, '失敗! 原因: 相同名稱之項目已存在');
insert into insert_record_status values (5, '失敗! 原因: 項目不存在');
insert into insert_record_status values (6, '失敗! 原因: 此身份證/護照號碼之前已經登記');
insert into insert_record_status values (7, '失敗! 原因: 此診所代號已經存在');
insert into insert_record_status values (8, '失敗! 原因: 紀錄錯誤');
insert into insert_record_status values (9, '失敗! 原因: 此用戶名稱已存在');
insert into insert_record_status values (10, '失敗! 原因: 中醫註冊編號已存在');
insert into insert_record_status values (11, '病人已在較早前掛號');
insert into insert_record_status values (12, '病人沒有掛號/已在診症');
insert into insert_record_status values (13, '病人未分配主診醫生/未進入診症程序');
insert into insert_record_status values (14, '醫生正在診症');
insert into insert_record_status values (15, '其他用戶正在叫名');
insert into insert_record_status values (16, '你不是在叫名狀態');
insert into insert_record_status values (17, '沒有已叫名病人');
insert into insert_record_status values (18, '處方配伍有問題');
insert into insert_record_status values (19, '以下處方有用藥禁忌');
insert into insert_record_status values (20, '失敗! 原因: 劑量上下單位不屬同一類型');
insert into insert_record_status values (21, '失敗! 原因: 劑量下限大於上限');
insert into insert_record_status values (22, '失敗! 原因: 用戶沒有中醫註冊編號, 不能擁有醫生身份');
insert into insert_record_status values (23, '失敗! 原因: 不能自行刪除管理員身份');
