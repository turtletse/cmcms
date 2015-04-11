CREATE TABLE dosage_unit (
	unit_id int,
    unit_desc VARCHAR(10),
    promote_val int,
    promote_to_id int,
    decrease_to_id int
);
CREATE INDEX dosage_unit_x1 on dosage_unit(unit_id);

insert into dosage_unit VALUES(10, '分', 10, 20, 0);
insert into dosage_unit VALUES(20, '錢', 10, 30, 10);
insert into dosage_unit VALUES(30, '兩', 16, 40, 20);
insert into dosage_unit VALUES(40, '斤', 0, 0, 30);
insert into dosage_unit VALUES(50, '克', 0, 0, 0);
insert into dosage_unit VALUES(110, '枚', 0, 0, 0);