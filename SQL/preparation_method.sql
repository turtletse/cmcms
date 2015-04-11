DROP TABLE IF EXISTS preparation_method;

CREATE TABLE preparation_method(
	method_id INT,
    method_desc VARCHAR(255)
);

CREATE INDEX preparation_method_x1 ON preparation_method(method_id);

INSERT INTO preparation_method VALUES (10, '先煎');
INSERT INTO preparation_method VALUES (20, '-');
INSERT INTO preparation_method VALUES (30, '後下');
INSERT INTO preparation_method VALUES (35, '包煎');
INSERT INTO preparation_method VALUES (36, '烊化');
INSERT INTO preparation_method VALUES (40, '另煎');
INSERT INTO preparation_method VALUES (50, '沖服');
