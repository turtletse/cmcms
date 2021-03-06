﻿using System;
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
        }

        public void setSecondaryDrugTypeCombo(System.Windows.Forms.ComboBox cb, String pri_type)
        {
            cb.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_secondary_drug_type_combo_get (" + pri_type + ")");
            foreach (DataRow dr in data.Rows)
            {
                cb.Items.Add(new PermissibleValueObj(dr["type_desc"].ToString(), dr["sec_type"].ToString()));
            }
        }

        public void setDosageUnitCombo(System.Windows.Forms.ComboBox cb)
        {
            cb.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_dosage_unit_combo_get ()");
            foreach (DataRow dr in data.Rows)
            {
                cb.Items.Add(new PermissibleValueObj(dr["unit_desc"].ToString(), dr["unit_id"].ToString()));
            }
        }

        public void setContraindicationLevelCombo(System.Windows.Forms.ComboBox cb)
        {
            cb.Items.Clear();
            cb.Items.Add(new PermissibleValueObj("沒有禁忌", "0"));
            cb.Items.Add(new PermissibleValueObj("避免使用", "1"));
            cb.Items.Add(new PermissibleValueObj("禁止使用", "2"));
        }

        public bool insertDrugRecord(String drugName, decimal minDoseVal, int minDoseUnit, decimal maxDoseVal, int maxDoseUnit, int priTypeId, int secTypeId, bool q1, bool q2, bool q3, bool q4, bool w1, bool w2, bool w3, bool w4, bool w5, bool w6, int pregContraLvId, int g6pdContraLvId, ref String statusMsg)
        {

            DataTable data = dbmgr.execSelectStmtSP("CALL sp_insert_drug_item ('" + Utilities.stringDataParse4SQL(drugName) + "'," + minDoseVal + "," + minDoseUnit + "," + maxDoseVal + "," + maxDoseUnit + "," + priTypeId + "," + secTypeId + "," + (q1 ? "1" : "0") + "," + (q2 ? "1" : "0") + "," + (q3 ? "1" : "0") + "," + (q4 ? "1" : "0") + "," + (w1 ? "1" : "0") + "," + (w2 ? "1" : "0") + "," + (w3 ? "1" : "0") + "," + (w4 ? "1" : "0") + "," + (w5 ? "1" : "0") + "," + (w6 ? "1" : "0") + "," + pregContraLvId + "," + g6pdContraLvId + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"]>0?false:true;
        }

        public bool insertSubDrugRecord(int drugId, String subDrugName, ref String statusMsg)
        {

            DataTable data = dbmgr.execSelectStmtSP("CALL sp_insert_sub_drug_item (" + drugId + ", '" + Utilities.stringDataParse4SQL(subDrugName) + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        //Amend Drug Tab
        public bool updateDrugRecord(String drugId, String drugName, decimal minDoseVal, int minDoseUnit, decimal maxDoseVal, int maxDoseUnit, int priTypeId, int secTypeId, bool q1, bool q2, bool q3, bool q4, bool w1, bool w2, bool w3, bool w4, bool w5, bool w6, int pregContraLvId, int g6pdContraLvId, bool isDeleted, ref String statusMsg)
        {

            DataTable data = dbmgr.execSelectStmtSP("CALL sp_update_drug_item (" + drugId + ", '" + Utilities.stringDataParse4SQL(drugName) + "'," + minDoseVal + "," + minDoseUnit + "," + maxDoseVal + "," + maxDoseUnit + "," + priTypeId + "," + secTypeId + "," + (q1 ? "1" : "0") + "," + (q2 ? "1" : "0") + "," + (q3 ? "1" : "0") + "," + (q4 ? "1" : "0") + "," + (w1 ? "1" : "0") + "," + (w2 ? "1" : "0") + "," + (w3 ? "1" : "0") + "," + (w4 ? "1" : "0") + "," + (w5 ? "1" : "0") + "," + (w6 ? "1" : "0") + "," + pregContraLvId + "," + g6pdContraLvId + ", " + (isDeleted ? "1" : "0") + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();

            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public bool updateSubDrugRecord(String subDrugCode, String drugName, bool isDeleted, ref String statusMsg)
        {
            String[] ids = subDrugCode.Split(new String[] { "||" }, System.StringSplitOptions.None);
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_update_sub_drug_item (" + ids[0] + ", " + ids[1] + ", '" + Utilities.stringDataParse4SQL(drugName) + "'," + (isDeleted ? "1" : "0") + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();

            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        //incompatible tab
        public void setSelectedIncompatibleListbox(System.Windows.Forms.ListBox Listbox, int drugId)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_incompatible_drug_get (" + drugId + ")");
            foreach (DataRow dr in data.Rows)
            {
                Listbox.Items.Add(new PermissibleValueObj(dr["drug_name"].ToString(), dr["drug_id"].ToString()));
            }
        }

        public bool updateIncompatibleDrug(int drugId, String incompatibleWith, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_incompatible_drug_update (" + drugId + ", '"+ Utilities.stringDataParse4SQL(incompatibleWith) + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();

            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }


        //Drug Selection Panel
        public void setDSPPrimaryDrugTypeListBox(System.Windows.Forms.ListBox Listbox, int inclDeleted)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_DSP_primary_drug_type_listbox_item_get (" + inclDeleted + ")");
            foreach (DataRow dr in data.Rows)
            {
                Listbox.Items.Add(new PermissibleValueObj(dr["type_desc"].ToString(), dr["pri_type"].ToString()));
            }
        }

        public void setDSPSecondaryDrugTypeListBox(System.Windows.Forms.ListBox Listbox, int priTypeId, int inclDeleted)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_DSP_secondary_drug_type_listbox_item_get (" + priTypeId + ", " + inclDeleted + ")");
            foreach (DataRow dr in data.Rows)
            {
                Listbox.Items.Add(new PermissibleValueObj(dr["type_desc"].ToString(), dr["sec_type"].ToString()));
            }
        }

        public void setDSPnStrokesListBox(System.Windows.Forms.ListBox Listbox, int priTypeId, int secTypeId, int inclDeleted)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_DSP_nStroke_listbox_item_get (" + priTypeId + ", " + secTypeId + ", " + inclDeleted + ")");
            foreach (DataRow dr in data.Rows)
            {
                Listbox.Items.Add(new PermissibleValueObj(dr["nStrokes_desc"].ToString(), dr["nStrokes"].ToString()));
            }
        }

        public void setDSPLengthListBox(System.Windows.Forms.ListBox Listbox, int priTypeId, int secTypeId, int nStrokes, int inclDeleted)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_DSP_length_listbox_item_get (" + priTypeId + ", " + secTypeId + ", " + nStrokes + ", " + inclDeleted + ")");
            foreach (DataRow dr in data.Rows)
            {
                Listbox.Items.Add(new PermissibleValueObj(dr["nameLength_desc"].ToString(), dr["nameLength"].ToString()));
            }
        }

        public void setDSP4q5wListBox(System.Windows.Forms.CheckedListBox Listbox, int priTypeId, int secTypeId, int nStrokes, int nameLen, int inclDeleted)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_DSP_4q5w_listbox_item_get (" + priTypeId + ", " + secTypeId + ", " + nStrokes + ", " + nameLen + ", " + inclDeleted + ")");
            foreach (DataRow dr in data.Rows)
            {
                Listbox.Items.Add(new PermissibleValueObj(dr["display_name"].ToString(), dr["option_value"].ToString()));
            }
            
        }

        public void setDSPDrugListBox(System.Windows.Forms.ListBox Listbox, int priTypeId, int secTypeId, int nStrokes, int nameLen, String selected4q5w, int inclDeleted)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_DSP_drug_listbox_item_get (" + priTypeId + ", " + secTypeId + ", " + nStrokes + ", " + nameLen + ", '" + Utilities.stringDataParse4SQL(selected4q5w) + "', " + inclDeleted + ")");
            foreach (DataRow dr in data.Rows)
            {
                Listbox.Items.Add(new DrugObj(dr["drug_name"].ToString(), dr["drug_id"].ToString(), decimal.Parse(dr["drug_min_dosage_val"].ToString()), (int)dr["drug_min_dosage_unit"], decimal.Parse(dr["drug_max_dosage_val"].ToString()), (int)dr["drug_max_dosage_unit"], (int)dr["drug_pri_type"], (int)dr["drug_sec_type"], Convert.ToBoolean(dr["isDeleted"]), Convert.ToBoolean(dr["drug_q1"]), Convert.ToBoolean(dr["drug_q2"]), Convert.ToBoolean(dr["drug_q3"]), Convert.ToBoolean(dr["drug_q4"]), Convert.ToBoolean(dr["drug_w1"]), Convert.ToBoolean(dr["drug_w2"]), Convert.ToBoolean(dr["drug_w3"]), Convert.ToBoolean(dr["drug_w4"]), Convert.ToBoolean(dr["drug_w5"]), Convert.ToBoolean(dr["drug_w6"]), dr["pregnancy"].ToString(), dr["g6pd"].ToString()));
            }
        }

        public void setDSPSubDrugListBox(System.Windows.Forms.ListBox Listbox, int drugId, int incl_not_specified, int inclDeleted)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_DSP_sub_drug_listbox_item_get (" + drugId + ", " + incl_not_specified + ", " + inclDeleted + ")");
            foreach (DataRow dr in data.Rows)
            {
                Listbox.Items.Add(new PermissibleValueObjWithDelFlag(dr["item_name"].ToString(), dr["item_id"].ToString(), Convert.ToBoolean(dr["isDeleted"])));
            }
        }

        //PatientRegiatration
        public void setDrugListBoxItemsByDrugIds(System.Windows.Forms.ListBox Listbox, String drugIds)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_drug_item_get_by_id (" + (drugIds.Length==0?"NULL":"'"+Utilities.stringDataParse4SQL(drugIds)+"'") + ")");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    Listbox.Items.Add(new DrugObj(dr["drug_name"].ToString(), dr["drug_id"].ToString(), decimal.Parse(dr["drug_min_dosage_val"].ToString()), (int)dr["drug_min_dosage_unit"], decimal.Parse(dr["drug_max_dosage_val"].ToString()), (int)dr["drug_max_dosage_unit"], (int)dr["drug_pri_type"], (int)dr["drug_sec_type"], Convert.ToBoolean(dr["isDeleted"]), Convert.ToBoolean(dr["drug_q1"]), Convert.ToBoolean(dr["drug_q2"]), Convert.ToBoolean(dr["drug_q3"]), Convert.ToBoolean(dr["drug_q4"]), Convert.ToBoolean(dr["drug_w1"]), Convert.ToBoolean(dr["drug_w2"]), Convert.ToBoolean(dr["drug_w3"]), Convert.ToBoolean(dr["drug_w4"]), Convert.ToBoolean(dr["drug_w5"]), Convert.ToBoolean(dr["drug_w6"]), dr["pregnancy"].ToString(), dr["g6pd"].ToString()));
                }
            }
        }

        //PrescroptionPanel
        public List<PermissibleValueObj> getPermissibleUnitForDrug(String drugId)
        {
            List<PermissibleValueObj> units = new List<PermissibleValueObj>();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_permissible_dosage_unit_for_drug_get (" + drugId + ")");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    units.Add(new PermissibleValueObj(dr["unit_desc"].ToString(), dr["unit_id"].ToString()));
                }
            }
            return units;
        }

        public Dictionary<String,String> getDosageUnitForDrug()
        {
            Dictionary<String, String> units = new Dictionary<String, String>();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_dosage_unit_combo_get ()");
            foreach (DataRow dr in data.Rows)
            {
                units.Add(dr["unit_desc"].ToString(), dr["unit_id"].ToString());
            }
            return units;
        }

        public List<PermissibleValueObj> getDrugIdByNames(String drugNames, ref String notFoundDrugs)
        {
            List<PermissibleValueObj> drugs = new List<PermissibleValueObj>();
            notFoundDrugs = "";
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_PP_search_drug_by_drug_name_get ('" + Utilities.stringDataParse4SQL(drugNames) + "')");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    if (Convert.ToBoolean(dr["isFound"]))
                        drugs.Add(new PermissibleValueObj(dr["drug_name"].ToString(), dr["drug_id"].ToString()));
                    else
                        notFoundDrugs += ", " + dr["drug_name"].ToString();
                }
            }
            if (notFoundDrugs.Length > 0)
                notFoundDrugs = notFoundDrugs.Substring(2);
            return drugs;
        }

        public Dictionary<String, String> getPrepMethod()
        {
            Dictionary<String, String> methods = new Dictionary<String, String>();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_PP_preparation_method_get ()");
            foreach (DataRow dr in data.Rows)
            {
                methods.Add(dr["method_desc"].ToString(), dr["method_id"].ToString());
            }
            return methods;
        }

        public bool insertPredefinedPrescription(String presName, String drugDataString, ref String statusMsg)
        {

            DataTable data = dbmgr.execSelectStmtSP("CALL sp_insert_predef_pres ('" + Utilities.stringDataParse4SQL(presName) + "', '" + Utilities.stringDataParse4SQL(drugDataString) + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public List<List<String>> getPredefPrescriptionById(int presId)
        {
            List<List<String>> pres = new List<List<string>>();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_predef_pres_dt_get (" + presId + ")");
            foreach (DataRow dr in data.Rows)
            {
                List<String> row = new List<String>();
                row.Add(dr["drug_code"].ToString());
                row.Add(dr["drug_name"].ToString());
                row.Add(dr["dosage"].ToString());
                row.Add(dr["unit_desc"].ToString());
                row.Add(dr["method_desc"].ToString());
                pres.Add(row);
            }
            return pres;
        }

        public void setPredefPresCB(System.Windows.Forms.ComboBox cb, bool isInclDeleted)
        {
            cb.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_predef_pres_list_get (" + (isInclDeleted ? 1 : 0) + ")");
            foreach (DataRow dr in data.Rows)
            {
                cb.Items.Add(new PermissibleValueObjWithDelFlag(dr["predef_pres_name"].ToString(), dr["predef_pres_id"].ToString(), Convert.ToBoolean(dr["isDeleted"])));
            }
        }

        //UpdatePredefPres
        public bool UpdatePredefinedPrescription(int predefPresId, String presName, String drugDataString, bool isDeleted, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_update_predef_pres (" + predefPresId + ", '" + Utilities.stringDataParse4SQL(presName) + "', '" + Utilities.stringDataParse4SQL(drugDataString) + "', " + (isDeleted ? "1" : "0") + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }
    }
}
