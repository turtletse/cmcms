DROP TABLE IF EXISTS body_parts;
CREATE TABLE body_parts(
	part_id INT,
    part_desc VARCHAR(12)
);
CREATE INDEX body_parts_x1 ON body_parts(part_id);

INSERT INTO body_parts(part_id, part_desc) VALUES (10, '頭');
INSERT INTO body_parts(part_id, part_desc) VALUES (20, '頸');
INSERT INTO body_parts(part_id, part_desc) VALUES (30, '背');
INSERT INTO body_parts(part_id, part_desc) VALUES (40, '胸');
INSERT INTO body_parts(part_id, part_desc) VALUES (50, '腹');
INSERT INTO body_parts(part_id, part_desc) VALUES (60, '上肢');
INSERT INTO body_parts(part_id, part_desc) VALUES (70, '下肢');
INSERT INTO body_parts(part_id, part_desc) VALUES (80, '會陰');