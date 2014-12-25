using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CMCMS
{
    class DrugMgr
    {
        DBMgr dbmgr = new DBMgr();

        public void setPrimaryDrugTypeCombo(System.Windows.Forms.ComboBox cb)
        {
            cb.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("SELECT pri_type, type_desc FROM master_drug_type WHERE sec_type=0 ORDER BY pri_type, sec_type");
            foreach (DataRow dr in data.Rows)
            {
                cb.Items.Add(new permissibleValueObj(dr["type_desc"].ToString(), dr["pri_type"].ToString()));
            }
            cb.SelectedIndex = 0;
        }

        public void setSecondaryDrugTypeCombo(System.Windows.Forms.ComboBox cb, String pri_type)
        {
            cb.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("SELECT sec_type, type_desc FROM master_drug_type WHERE pri_type = '" + pri_type + "' AND sec_type<>0 ORDER BY sec_type, sec_type");
            foreach (DataRow dr in data.Rows)
            {
                cb.Items.Add(new permissibleValueObj(dr["type_desc"].ToString(), dr["sec_type"].ToString()));
            }
            if (data.Rows.Count == 0)
            {
                cb.Items.Add(new permissibleValueObj("-", "0"));
            }
            cb.SelectedIndex = 0;
        }

        public void setDosageUnitCombo(System.Windows.Forms.ComboBox cb)
        {
            cb.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("SELECT unit_id, unit_desc FROM dosage_unit ORDER BY unit_id");
            foreach (DataRow dr in data.Rows)
            {
                cb.Items.Add(new permissibleValueObj(dr["unit_desc"].ToString(), dr["unit_id"].ToString()));
            }
            cb.SelectedIndex = 0;
        }

        public void setContraindicationLevelCombo(System.Windows.Forms.ComboBox cb)
        {
            cb.Items.Clear();
            cb.Items.Add(new permissibleValueObj("沒有禁忌", "0"));
            cb.Items.Add(new permissibleValueObj("避免使用", "1"));
            cb.Items.Add(new permissibleValueObj("禁止使用", "2"));
            cb.SelectedIndex = 0;
        }
    }
}
