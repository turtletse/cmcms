using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CMCMS
{
    class ConsultationMgr
    {
        DBMgr dbmgr = new DBMgr();

        //examinationResultSelectionForm
        public void setExamLv1(System.Windows.Forms.ListBox Listbox)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_examination_result_lv1_get ()");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    Listbox.Items.Add(new PermissibleValueObj (dr["result_desc"].ToString(), dr["lv1"].ToString()));
                }
            }
        }

        public void setExamLv2(System.Windows.Forms.ListBox Listbox, int lv1)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_examination_result_lv2_get (" + lv1 + ")");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    Listbox.Items.Add(new PermissibleValueObj(dr["result_desc"].ToString(), dr["lv2"].ToString()));
                }
            }
        }

        public void setExamLv3(System.Windows.Forms.ListBox Listbox, int lv1, int lv2)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_examination_result_lv3_get (" + lv1 +", " + lv2 + ")");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    Listbox.Items.Add(new PermissibleValueObj(dr["result_desc"].ToString(), dr["lv3"].ToString()));
                }
            }
        }

        public void setExamLv4(System.Windows.Forms.ListBox Listbox, int lv1, int lv2, int lv3)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_examination_result_lv4_get (" + lv1 + ", " + lv2 + ", " + lv3 + ")");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    Listbox.Items.Add(new PermissibleValueObj(dr["result_desc"].ToString(), dr["result_code"].ToString()));
                }
            }
        }

        public void setExamLv4BySearch(System.Windows.Forms.ListBox Listbox, String keywords)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_examination_result_search_get ('" + keywords + "')");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    Listbox.Items.Add(new PermissibleValueObj(dr["result_desc"].ToString(), dr["result_code"].ToString()));
                }
            }
        }


        //DifferentiationResultSearchForm
        public void setDiffLv1(System.Windows.Forms.ListBox Listbox)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_differentiation_result_lv1_get ()");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    Listbox.Items.Add(new PermissibleValueObj(dr["result_desc"].ToString(), dr["lv1"].ToString()));
                }
            }
        }

        public void setDiffLv2(System.Windows.Forms.ListBox Listbox, int lv1)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_differentiation_result_lv2_get (" + lv1 + ")");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    Listbox.Items.Add(new PermissibleValueObj(dr["result_desc"].ToString(), dr["lv2"].ToString()));
                }
            }
        }

        public void setDiffLv3(System.Windows.Forms.ListBox Listbox, int lv1, int lv2)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_differentiation_result_lv3_get (" + lv1 + ", " + lv2 + ")");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    Listbox.Items.Add(new PermissibleValueObj(dr["result_desc"].ToString(), dr["result_code"].ToString()));
                }
            }
        }

        public void setDiffLv3BySearch(System.Windows.Forms.ListBox Listbox, String keywords)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_differentiation_result_search_get ('" + keywords + "')");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    Listbox.Items.Add(new PermissibleValueObj(dr["result_desc"].ToString(), dr["result_code"].ToString()));
                }
            }
        }


        //DxResultSelectionForm
        public void setDxLv1(System.Windows.Forms.ListBox Listbox)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_dx_result_lv1_get ()");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    Listbox.Items.Add(new PermissibleValueObj(dr["result_desc"].ToString(), dr["lv1"].ToString()));
                }
            }
        }

        public void setDxLv2(System.Windows.Forms.ListBox Listbox, int lv1)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_dx_result_lv2_get (" + lv1 + ")");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    Listbox.Items.Add(new PermissibleValueObj(dr["result_desc"].ToString(), dr["result_code"].ToString()));
                }
            }
        }

        public void setDxLv2BySearch(System.Windows.Forms.ListBox Listbox, String keywords)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_dx_result_search_get ('" + keywords + "')");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    Listbox.Items.Add(new PermissibleValueObj(dr["result_desc"].ToString(), dr["result_code"].ToString()));
                }
            }
        }


        //DrRmkEditForm
        public void setDrRmkPredefined(System.Windows.Forms.ComboBox cb)
        {
            cb.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_dr_rmk_predefined_get ()");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    cb.Items.Add(new PermissibleValueObj(dr["rmk_desc"].ToString(), dr["rmk_id"].ToString()));
                }
            }
        }


        //prescriptionForm
        public bool newPrescription(String instruction, int nDose, String methodOftreatment, String presDataString, ref String presId, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_new_pres ('" + instruction + "', " + nDose + ", '" + methodOftreatment + "', '" + presDataString + "')");
            presId = data.Rows[0]["pres_id"].ToString();
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public bool updatePrescription(int presId, String instruction, int nDose, String methodOftreatment, String presDataString, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_update_pres (" + presId + ", '" + instruction + "', " + nDose + ", '" + methodOftreatment + "', '" + presDataString + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public List<List<String>> getPrescriptionDtById(int presId)
        {
            List<List<String>> pres = new List<List<String>>();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_pres_dt_get (" + presId + ")");
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

        public Dictionary<String, String> getPrescriptionById(int presId)
        {
            Dictionary<String, String> pres = new Dictionary<String, String>();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_pres_get (" + presId + ")");
            foreach (DataRow dr in data.Rows)
            {
                pres.Add("instruction", dr["instruction"].ToString());
                pres.Add("no_of_dose", dr["no_of_dose"].ToString());
                pres.Add("method_of_treatment", dr["method_of_treatment"].ToString());
            }
            return pres;
        }

        public Dictionary<String, String> startConsultation(int patId)
        {
            Dictionary<String, String> pres = new Dictionary<String, String>();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_start_consultation ('" + (Login.clinic == null ? "" : Login.clinic.Value) + "', '" + (Login.user == null ? "" : Login.user.Value) + ", " + patId + ")");
            foreach (DataRow dr in data.Rows)
            {
                pres.Add("cons_id", dr["cons_id"].ToString());
                pres.Add("clinic_id", dr["clinic_id"].ToString());
                pres.Add("dr_id", dr["dr_id"].ToString());
                pres.Add("patient_id", dr["patient_id"].ToString());
                pres.Add("first_record_dtm", dr["first_record_dtm"].ToString());
                pres.Add("ex_code", dr["ex_code"].ToString());
                pres.Add("ex_desc", dr["ex_desc"].ToString());
                pres.Add("diff_code", dr["diff_code"].ToString());
                pres.Add("diff_desc", dr["diff_desc"].ToString());
                pres.Add("dx_code", dr["dx_code"].ToString());
                pres.Add("dx_desc", dr["dx_desc"].ToString());
                pres.Add("pres_id", dr["pres_id"].ToString());
                pres.Add("dr_rmk", dr["dr_rmk"].ToString());
                pres.Add("isFinished", dr["isFinished"].ToString());
                pres.Add("last_update_dtm", dr["last_update_dtm"].ToString());
            }
            return pres;
        }
    }
}
