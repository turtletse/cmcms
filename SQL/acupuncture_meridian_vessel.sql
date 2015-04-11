DROP TABLE IF EXISTS acupuncture_meridian_vessel;
CREATE TABLE acupuncture_meridian_vessel(
	mv_id INT,
    mv_desc VARCHAR(30)
);
CREATE INDEX acupuncture_meridian_vessel_x1 ON acupuncture_meridian_vessel(mv_id);

INSERT INTO acupuncture_meridian_vessel(mv_id, mv_desc) VALUES (10, '手太陰肺經');
INSERT INTO acupuncture_meridian_vessel(mv_id, mv_desc) VALUES (20, '手陽明大腸經');
INSERT INTO acupuncture_meridian_vessel(mv_id, mv_desc) VALUES (30, '足陽明胃經');
INSERT INTO acupuncture_meridian_vessel(mv_id, mv_desc) VALUES (40, '足太陰脾經');
INSERT INTO acupuncture_meridian_vessel(mv_id, mv_desc) VALUES (50, '手少陰心經');
INSERT INTO acupuncture_meridian_vessel(mv_id, mv_desc) VALUES (60, '手太陽小腸經');
INSERT INTO acupuncture_meridian_vessel(mv_id, mv_desc) VALUES (70, '足太陽膀胱經');
INSERT INTO acupuncture_meridian_vessel(mv_id, mv_desc) VALUES (80, '足少陰腎經');
INSERT INTO acupuncture_meridian_vessel(mv_id, mv_desc) VALUES (90, '手厥陰心包經');
INSERT INTO acupuncture_meridian_vessel(mv_id, mv_desc) VALUES (100, '手少陽三焦經');
INSERT INTO acupuncture_meridian_vessel(mv_id, mv_desc) VALUES (110, '足少陽膽經');
INSERT INTO acupuncture_meridian_vessel(mv_id, mv_desc) VALUES (120, '足厥陰肝經');
INSERT INTO acupuncture_meridian_vessel(mv_id, mv_desc) VALUES (130, '督脈');
INSERT INTO acupuncture_meridian_vessel(mv_id, mv_desc) VALUES (140, '任脈');