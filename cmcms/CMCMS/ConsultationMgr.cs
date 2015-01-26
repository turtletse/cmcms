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
        public bool newPrescription(String instruction, int nDose, String methodOftreatment, String presDataString, ref String presId)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_new_pres ('" + instruction + "', " + nDose + ", '" + methodOftreatment + "', '" + presDataString + "')");
            if (data != null)
            {
                if (data.Rows[0]["status_id"].ToString() == "0")
                {
                    presId = data.Rows[0]["pres_id"].ToString();
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
