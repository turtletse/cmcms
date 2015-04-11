CREATE TABLE master_drug_type (
	pri_type int,
    sec_type int,
    type_desc VARCHAR(30)
);
CREATE INDEX master_drug_type_x1 on master_drug_type (pri_type, sec_type);
CREATE INDEX master_drug_type_x2 on master_drug_type (sec_type);

BEGIN WORK;
insert into master_drug_type VALUES (10,0,'解表');				
insert into master_drug_type VALUES (10,5,'解表');
insert into master_drug_type VALUES (10,10,'辛溫解表');
insert into master_drug_type VALUES (10,20,'辛涼解表');
insert into master_drug_type VALUES (20,0,'湧吐');
insert into master_drug_type VALUES (30,0,'瀉下');
insert into master_drug_type VALUES (30,5,'瀉下');
insert into master_drug_type VALUES (30,10,'攻下');
insert into master_drug_type VALUES (30,20,'潤下');
insert into master_drug_type VALUES (30,30,'峻下逐水');
insert into master_drug_type VALUES (40,0,'清熱');
insert into master_drug_type VALUES (40,5,'清熱');
insert into master_drug_type VALUES (40,10,'清熱瀉火');
insert into master_drug_type VALUES (40,20,'清熱涼血');
insert into master_drug_type VALUES (40,30,'清熱燥濕');
insert into master_drug_type VALUES (40,40,'清熱解毒');
insert into master_drug_type VALUES (40,50,'清熱解暑');
insert into master_drug_type VALUES (50,0,'芳香化濕');
insert into master_drug_type VALUES (60,0,'利水滲濕');
insert into master_drug_type VALUES (70,0,'袪風濕');
insert into master_drug_type VALUES (80,0,'溫裡');
insert into master_drug_type VALUES (90,0,'芳香開竅');
insert into master_drug_type VALUES (100,5,'安神');
insert into master_drug_type VALUES (100,0,'安神');
insert into master_drug_type VALUES (100,10,'重鎮安神');
insert into master_drug_type VALUES (100,20,'養心安神');
insert into master_drug_type VALUES (110,0,'平肝息風');
insert into master_drug_type VALUES (120,0,'理氣');
insert into master_drug_type VALUES (130,0,'理血');
insert into master_drug_type VALUES (130,5,'理血');
insert into master_drug_type VALUES (130,10,'止血');
insert into master_drug_type VALUES (130,20,'活血袪瘀');
insert into master_drug_type VALUES (140,0,'補益');
insert into master_drug_type VALUES (140,5,'補益');
insert into master_drug_type VALUES (140,10,'補氣');
insert into master_drug_type VALUES (140,20,'補陽');
insert into master_drug_type VALUES (140,30,'補血');
insert into master_drug_type VALUES (140,40,'補陰');
insert into master_drug_type VALUES (140,50,'補虛');
insert into master_drug_type VALUES (150,0,'消導');
insert into master_drug_type VALUES (160,0,'化痰止咳');
insert into master_drug_type VALUES (160,5,'化痰止咳');
insert into master_drug_type VALUES (160,10,'溫化寒痰');
insert into master_drug_type VALUES (160,20,'清化熱痰');
insert into master_drug_type VALUES (160,30,'止咳平喘');
insert into master_drug_type VALUES (170,0,'收澀');
insert into master_drug_type VALUES (180,0,'驅蟲');
insert into master_drug_type VALUES (190,0,'外用');
select * from master_drug_type;
commit work;
