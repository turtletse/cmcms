DROP TABLE IF EXISTS predef_instruction_list;

CREATE TABLE predef_instruction_list(
	instruction_id INT,
    instruction_desc VARCHAR(255)
);

CREATE INDEX predef_instruction_list_x1 ON predef_instruction_list(instruction_id);
CREATE INDEX predef_instruction_list_x2 ON predef_instruction_list(instruction_desc);

INSERT INTO predef_instruction_list VALUES (get_predef_instruction_id(), '每日一次');
INSERT INTO predef_instruction_list VALUES (get_predef_instruction_id(), '每次一服');
INSERT INTO predef_instruction_list VALUES (get_predef_instruction_id(), '翻煎');
INSERT INTO predef_instruction_list VALUES (get_predef_instruction_id(), '四碗水煎煮一碗');
INSERT INTO predef_instruction_list VALUES (get_predef_instruction_id(), '外用忌食');
INSERT INTO predef_instruction_list VALUES (get_predef_instruction_id(), '一');
INSERT INTO predef_instruction_list VALUES (get_predef_instruction_id(), '二');
INSERT INTO predef_instruction_list VALUES (get_predef_instruction_id(), '三');
INSERT INTO predef_instruction_list VALUES (get_predef_instruction_id(), '四');
INSERT INTO predef_instruction_list VALUES (get_predef_instruction_id(), '五');
INSERT INTO predef_instruction_list VALUES (get_predef_instruction_id(), '六');
INSERT INTO predef_instruction_list VALUES (get_predef_instruction_id(), '七');
INSERT INTO predef_instruction_list VALUES (get_predef_instruction_id(), '八');
INSERT INTO predef_instruction_list VALUES (get_predef_instruction_id(), '九');
INSERT INTO predef_instruction_list VALUES (get_predef_instruction_id(), '十');
INSERT INTO predef_instruction_list VALUES (get_predef_instruction_id(), '空腹服用');
INSERT INTO predef_instruction_list VALUES (get_predef_instruction_id(), '飯前服用');
INSERT INTO predef_instruction_list VALUES (get_predef_instruction_id(), '飯後服用');
INSERT INTO predef_instruction_list VALUES (get_predef_instruction_id(), '睡前服用');

