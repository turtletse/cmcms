drop table if exists incompatible_drug;
create table incompatible_drug(
	drug_id INT,
	incompatible_with VARCHAR(255) default '||'
);
create index incompatible_drug_x1 on incompatible_drug(drug_id);