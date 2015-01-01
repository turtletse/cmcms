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

        //Add Drug Tab
        public void setPrimaryDrugTypeCombo(System.Windows.Forms.ComboBox cb)
        {
            cb.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_primary_drug_type_combo_get ()");
            foreach (DataRow dr in data.Rows)
            {
                cb.Items.Add(new PermissibleValueObj(dr["type_desc"].ToString(), dr["pri_type"].ToString()));
            }
            cb.SelectedIndex = 0;
        }

        public void setSecondaryDrugTypeCombo(System.Windows.Forms.ComboBox cb, String pri_type)
        {
            cb.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_secondary_drug_type_combo_get (" + pri_type + ")");
            foreach (DataRow dr in data.Rows)
            {
                cb.Items.Add(new PermissibleValueObj(dr["type_desc"].ToString(), dr["sec_type"].ToString()));
            }
            /*if (data.Rows.Count == 0)
            {
                cb.Items.Add(new permissibleValueObj("-", "0"));
            }*/
            cb.SelectedIndex = 0;
        }

        public void setDosageUnitCombo(System.Windows.Forms.ComboBox cb)
        {
            cb.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_dosage_unit_combo_get ()");
            foreach (DataRow dr in data.Rows)
            {
                cb.Items.Add(new PermissibleValueObj(dr["unit_desc"].ToString(), dr["unit_id"].ToString()));
            }
            cb.SelectedIndex = 0;
        }

        public void setContraindicationLevelCombo(System.Windows.Forms.ComboBox cb)
        {
            cb.Items.Clear();
            cb.Items.Add(new PermissibleValueObj("沒有禁忌", "0"));
            cb.Items.Add(new PermissibleValueObj("避免使用", "1"));
            cb.Items.Add(new PermissibleValueObj("禁止使用", "2"));
            cb.SelectedIndex = 0;
        }

        public bool insertDrugRecord(String drugName, int minDoseVal, int minDoseUnit, int maxDoseVal, int maxDoseUnit, int priTypeId, int secTypeId, bool q1, bool q2, bool q3, bool q4, bool w1, bool w2, bool w3, bool w4, bool w5, bool w6, int pregContraLvId, int g6pdContraLvId, ref String statusMsg)
        {

            DataTable data = dbmgr.execSelectStmtSP("CALL sp_insert_drug_item ('" + drugName + "'," + minDoseVal + "," + minDoseUnit + "," + maxDoseVal + "," + maxDoseUnit + "," + priTypeId + "," + secTypeId + "," + (q1 ? "1" : "0") + "," + (q2 ? "1" : "0") + "," + (q3 ? "1" : "0") + "," + (q4 ? "1" : "0") + "," + (w1 ? "1" : "0") + "," + (w2 ? "1" : "0") + "," + (w3 ? "1" : "0") + "," + (w4 ? "1" : "0") + "," + (w5 ? "1" : "0") + "," + (w6 ? "1" : "0") + "," + pregContraLvId + "," + g6pdContraLvId + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"]>0?false:true;
        }


        //Drug Selection Panel
        public void setDSPPrimaryDrugTypeListBox(System.Windows.Forms.ListBox Listbox)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_DSP_primary_drug_type_listbox_item_get ()");
            foreach (DataRow dr in data.Rows)
            {
                Listbox.Items.Add(new PermissibleValueObj(dr["type_desc"].ToString(), dr["pri_type"].ToString()));
            }
            Listbox.SelectedIndex = 0;
        }

        public void setDSPSecondaryDrugTypeListBox(System.Windows.Forms.ListBox Listbox, int priTypeId)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_DSP_secondary_drug_type_listbox_item_get (" + priTypeId + ")");
            foreach (DataRow dr in data.Rows)
            {
                Listbox.Items.Add(new PermissibleValueObj(dr["type_desc"].ToString(), dr["sec_type"].ToString()));
            }
            Listbox.SelectedIndex = 0;
        }

        public void setDSPnStrokesListBox(System.Windows.Forms.ListBox Listbox, int priTypeId, int secTypeId)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_DSP_nStroke_listbox_item_get (" + priTypeId + ", " + secTypeId + ")");
            foreach (DataRow dr in data.Rows)
            {
                Listbox.Items.Add(new PermissibleValueObj(dr["nStrokes_desc"].ToString(), dr["nStrokes"].ToString()));
            }
            Listbox.SelectedIndex = 0;
        }

        public void setDSPLengthListBox(System.Windows.Forms.ListBox Listbox, int priTypeId, int secTypeId, int nStrokes)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_DSP_length_listbox_item_get (" + priTypeId + ", " + secTypeId + ", " + nStrokes + ")");
            foreach (DataRow dr in data.Rows)
            {
                Listbox.Items.Add(new PermissibleValueObj(dr["nameLength_desc"].ToString(), dr["nameLength"].ToString()));
            }
            Listbox.SelectedIndex = 0;
        }

        public void setDSP4q5wListBox(System.Windows.Forms.CheckedListBox Listbox, int priTypeId, int secTypeId, int nStrokes, int nameLen)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_DSP_4q5w_listbox_item_get (" + priTypeId + ", " + secTypeId + ", " + nStrokes + ", " + nameLen + ")");
            foreach (DataRow dr in data.Rows)
            {
                Listbox.Items.Add(new PermissibleValueObj(dr["display_name"].ToString(), dr["option_value"].ToString()));
            }
            
        }

        public void setDSPDrugListBox(System.Windows.Forms.ListBox Listbox, int priTypeId, int secTypeId, int nStrokes, int nameLen, String selected4q5w)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_DSP_drug_listbox_item_get (" + priTypeId + ", " + secTypeId + ", " + nStrokes + ", " + nameLen + ", '" + selected4q5w + "')");
            foreach (DataRow dr in data.Rows)
            {
                Listbox.Items.Add(new PermissibleValueObj(dr["drug_name"].ToString(), dr["drug_id"].ToString()));
            }
            Listbox.SelectedIndex = 0;
        }
    }
}
