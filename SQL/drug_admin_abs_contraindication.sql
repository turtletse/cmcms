CREATE TABLE drug_admin_abs_contraindication (
	drug_id int,				-- fk master_drug_list
    pregnancy SMALLINT,			-- 0=no restriction, 1=avoid, 2=forbidden
    g6pd smallint
);
CREATE INDEX drug_admin_abs_contraindication_x1 ON drug_admin_abs_contraindication (drug_id);