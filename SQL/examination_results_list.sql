DROP TABLE IF EXISTS examination_results_list;

CREATE TABLE examination_results_list(
	result_code VARCHAR(15),
    lv INT,
    result_desc VARCHAR(255)
);
CREATE INDEX examination_results_list_x1 ON examination_results_list(result_code, lv);
CREATE INDEX examination_results_list_x2 ON examination_results_list(result_desc);