﻿using System;
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
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_examination_result_search_get ('" + Utilities.stringDataParse4SQL(keywords) + "')");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    Listbox.Items.Add(new PermissibleValueObj(dr["result_desc"].ToString(), dr["result_code"].ToString()));
                }
            }
        }

        //AcupunctureSelectionForm
        public void setAPLv1(System.Windows.Forms.ListBox Listbox)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_acupuncture_lv1_get ()");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    Listbox.Items.Add(new PermissibleValueObj(dr["mv_desc"].ToString(), dr["mv_id"].ToString()));
                }
            }
        }

        public void setAPLv2(System.Windows.Forms.ListBox Listbox, int mvId)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_acupuncture_lv2_get (" + mvId + ")");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    Listbox.Items.Add(new PermissibleValueObj(dr["part_desc"].ToString(), dr["part_id"].ToString()));
                }
            }
        }

        public void setAPLv3(System.Windows.Forms.ListBox Listbox, int mvId, int partId)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_acupuncture_lv3_get (" + mvId + ", " + partId + ")");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    Listbox.Items.Add(new PermissibleValueObj(dr["pt_desc"].ToString(), dr["pt_cd"].ToString()));
                }
            }
        }

        public void setAPLv3ByKeywordsSearch(System.Windows.Forms.ListBox Listbox, String keywords)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_acupuncture_keywords_search_get ('" + Utilities.stringDataParse4SQL(keywords) + "')");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    Listbox.Items.Add(new PermissibleValueObj(dr["pt_desc"].ToString(), dr["pt_cd"].ToString()));
                }
            }
        }

        public void setAPLv3ByCodeSearch(System.Windows.Forms.ListBox Listbox, String codes)
        {
            Listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_acupuncture_code_search_get ('" + Utilities.stringDataParse4SQL(codes) + "')");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    Listbox.Items.Add(new PermissibleValueObj(dr["pt_desc"].ToString(), dr["pt_cd"].ToString()));
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
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_differentiation_result_search_get ('" + Utilities.stringDataParse4SQL(keywords) + "')");
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
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_dx_result_search_get ('" + Utilities.stringDataParse4SQL(keywords) + "')");
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


        //DrRmk
        public bool newDrRmk(String drRmk, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_insert_dr_rmk_predefined ('" + Utilities.stringDataParse4SQL(drRmk) + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public bool delDrRmk(int drRmkId, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_delete_dr_rmk_predefined (" + drRmkId + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        //Instruction
        public bool newInstruction(String inst, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_insert_instruction_predefined ('" + Utilities.stringDataParse4SQL(inst) + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public bool delInstruction(int instId, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_delete_predefined_instruction (" + instId + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }



        //prescriptionForm
        public int newPrescription(String instruction, int nDose, String methodOftreatment, String presDataString, int patId, String clinicId, ref String presId, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_new_pres ('" + Utilities.stringDataParse4SQL(instruction) + "', " + nDose + ", '" + Utilities.stringDataParse4SQL(methodOftreatment) + "', '" + Utilities.stringDataParse4SQL(presDataString) + "', " + patId + ", '" + clinicId + "')");
            presId = data.Rows[0]["pres_id"].ToString();
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"];
        }

        public int updatePrescription(int presId, String instruction, int nDose, String methodOftreatment, String presDataString, int patId, String clinicId, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_update_pres (" + presId + ", '" + Utilities.stringDataParse4SQL(instruction) + "', " + nDose + ", '" + Utilities.stringDataParse4SQL(methodOftreatment) + "', '" + Utilities.stringDataParse4SQL(presDataString) + "', " + patId + ", '" + clinicId + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"];
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

        public void setPredefInstructionCB(System.Windows.Forms.ComboBox cb)
        {
            cb.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_prescription_instruction_combo_get ()");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    cb.Items.Add(new PermissibleValueObj(dr["instruction_desc"].ToString(), dr["instruction_desc"].ToString()));
                }
            }
        }

        public void setPredefMOTCB(System.Windows.Forms.ComboBox cb)
        {
            cb.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_prescription_MOT_combo_get ()");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    cb.Items.Add(new PermissibleValueObj(dr["result_desc"].ToString(), dr["result_desc"].ToString()));
                }
            }
        }


        //consultationForm
        public Dictionary<String, String> startConsultation(int patId)
        {
            Dictionary<String, String> cons = new Dictionary<String, String>();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_start_consultation ('" + (Login.clinic == null ? "" : Utilities.stringDataParse4SQL(Login.clinic.Value)) + "', '" + (Login.user == null ? "" : Utilities.stringDataParse4SQL(Login.user.Value)) + "', " + patId + ")");
            foreach (DataRow dr in data.Rows)
            {
                cons.Add("cons_id", dr["cons_id"].ToString());
                cons.Add("clinic_id", dr["clinic_id"].ToString());
                cons.Add("dr_id", dr["dr_id"].ToString());
                cons.Add("patient_id", dr["patient_id"].ToString());
                cons.Add("first_record_dtm", dr["first_record_dtm"].ToString());
                cons.Add("ex_code", dr["ex_code"].ToString());
                cons.Add("ex_desc", dr["ex_desc"].ToString());
                cons.Add("diff_code", dr["diff_code"].ToString());
                cons.Add("diff_desc", dr["diff_desc"].ToString());
                cons.Add("dx_code", dr["dx_code"].ToString());
                cons.Add("dx_desc", dr["dx_desc"].ToString());
                cons.Add("pres_id", dr["pres_id"].ToString());
                cons.Add("dr_rmk", dr["dr_rmk"].ToString());
                cons.Add("isFinished", dr["isFinished"].ToString());
                cons.Add("last_update_dtm", dr["last_update_dtm"].ToString());
            }
            return cons;
        }

        public Dictionary<String, String> getConsultation(int consId)
        {
            Dictionary<String, String> cons = new Dictionary<String, String>();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_consultation_get ('" + (Login.clinic == null ? "" : Utilities.stringDataParse4SQL(Login.clinic.Value)) + "', '" + (Login.user == null ? "" : Utilities.stringDataParse4SQL(Login.user.Value)) + "', " + consId + ")");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    cons.Add("cons_id", dr["cons_id"].ToString());
                    cons.Add("clinic_id", dr["clinic_id"].ToString());
                    cons.Add("dr_id", dr["dr_id"].ToString());
                    cons.Add("patient_id", dr["patient_id"].ToString());
                    cons.Add("first_record_dtm", dr["first_record_dtm"].ToString());
                    cons.Add("ex_code", dr["ex_code"].ToString());
                    cons.Add("ex_desc", dr["ex_desc"].ToString());
                    cons.Add("diff_code", dr["diff_code"].ToString());
                    cons.Add("diff_desc", dr["diff_desc"].ToString());
                    cons.Add("dx_code", dr["dx_code"].ToString());
                    cons.Add("dx_desc", dr["dx_desc"].ToString());
                    cons.Add("pres_id", dr["pres_id"].ToString());
                    cons.Add("dr_rmk", dr["dr_rmk"].ToString());
                    cons.Add("isFinished", dr["isFinished"].ToString());
                    cons.Add("last_update_dtm", dr["last_update_dtm"].ToString());
                }
            }
            return cons;
        }

        public int saveConsultation(String consId, String patId, String examCode, String examDesc, String diffCode, String diffDesc, String dxCode, String dxDesc, String presIds, String acupunctureCode, String acupunctureDesc, String drRmk, ref String statusMsg){
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_save_consultation (" + consId + ", '" + (Login.clinic == null ? "" : Utilities.stringDataParse4SQL(Login.clinic.Value)) + "', '" + (Login.user == null ? "" : Utilities.stringDataParse4SQL(Login.user.Value)) + "', " + patId + ", '" + Utilities.stringDataParse4SQL(examCode) + "', '" + Utilities.stringDataParse4SQL(examDesc) + "', '" + Utilities.stringDataParse4SQL(diffCode) + "', '" + Utilities.stringDataParse4SQL(diffDesc) + "', '" + Utilities.stringDataParse4SQL(dxCode) + "', '" + Utilities.stringDataParse4SQL(dxDesc) + "', '" + Utilities.stringDataParse4SQL(presIds) + "', '" + Utilities.stringDataParse4SQL(acupunctureCode) + "', '" + Utilities.stringDataParse4SQL(acupunctureDesc) + "', '" + Utilities.stringDataParse4SQL(drRmk) + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"];
        }

        public bool confirmedConsultation(String consId, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_confirm_consultation (" + consId + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public bool consLater(String consId, String patId, String examCode, String examDesc, String diffCode, String diffDesc, String dxCode, String dxDesc, String presIds, String acupunctureCode, String acupunctureDesc, String drRmk, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_cons_later (" + consId + ", '" + (Login.clinic == null ? "" : Utilities.stringDataParse4SQL(Login.clinic.Value)) + "', '" + (Login.user == null ? "" : Utilities.stringDataParse4SQL(Login.user.Value)) + "', " + patId + ", '" + Utilities.stringDataParse4SQL(examCode) + "', '" + Utilities.stringDataParse4SQL(examDesc) + "', '" + Utilities.stringDataParse4SQL(diffCode) + "', '" + Utilities.stringDataParse4SQL(diffDesc) + "', '" + Utilities.stringDataParse4SQL(dxCode) + "', '" + Utilities.stringDataParse4SQL(dxDesc) + "', '" + Utilities.stringDataParse4SQL(presIds) + "', '" + Utilities.stringDataParse4SQL(acupunctureCode) + "', '" + Utilities.stringDataParse4SQL(acupunctureDesc) + "', '" + Utilities.stringDataParse4SQL(drRmk) + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public void updatePtPregFlag(int patId, bool isPregnant)
        {
            dbmgr.execSelectStmtSP("CALL sp_update_pat_preg_flag (" + patId + ", " + (isPregnant ? "1" : "0") + ")");
        }

        public bool finishConsultation(String consId, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_finish_consultation (" + consId + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public int chkPharmStock(String clinicId, int consId, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_check_stocks ('" + clinicId + "', "+ consId + ")");
            statusMsg = data.Rows[0]["status_msg"].ToString();
            return int.Parse((data.Rows[0]["return_status"]).ToString());
            /*if ((int)data.Rows[0]["return_status"] == 2 || (int)data.Rows[0]["return_status"] == 3)
            {
                return true;
            }
            else if ((int)data.Rows[0]["return_status"] == -1)
            {
                statusMsg = "診所沒有聯繫藥房, 詳情請聯絡系統管理員";
                return true;
            }
            return false;*/
        }

        public bool pharmStockReserv(String clinicId, int consId)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_drug_reservation ('" + clinicId + "', " + consId + ")");
            return (int)data.Rows[0]["return_status"] == 0 ? false : true;
        }

        public void refreshHistoryLV(System.Windows.Forms.ListView lv, int patId)
        {
            lv.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_consultation_history_get ('" + (Login.clinic == null ? "" : Utilities.stringDataParse4SQL(Login.clinic.Value)) + "', '" + (Login.user == null ? "" : Utilities.stringDataParse4SQL(Login.user.Value)) + "', " + patId + ")");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    string[] row = { dr["cons_id"].ToString(), dr["cons_dtm"].ToString(), dr["dx_desc"].ToString(), dr["ex_desc"].ToString(), dr["diff_desc"].ToString(), dr["pres_data_str"].ToString(), dr["acupuncture_desc"].ToString() };
                    System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem(row);
                    lv.Items.Add(item);
                }
            }
        }

        public bool usePreviousConsultationAsTemplate(int currConsId, int prevConsId, ref String statusMsg)
        {
            Dictionary<String, String> cons = new Dictionary<String, String>();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_use_selected_cons_as_template ('" + (Login.clinic == null ? "" : Utilities.stringDataParse4SQL(Login.clinic.Value)) + "', '" + (Login.user == null ? "" : Utilities.stringDataParse4SQL(Login.user.Value)) + "', " + currConsId + ", " + prevConsId + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public int issue_sick_leave_cert(int consId, String startDate, String endDate, int nDays)
        {
            Dictionary<String, String> cons = new Dictionary<String, String>();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_issue_sick_leave_cert (" + consId + ", '" + Utilities.stringDataParse4SQL(startDate) + "', '" + Utilities.stringDataParse4SQL(endDate) + "', " + nDays + ")");
            return int.Parse(data.Rows[0]["cert_id"].ToString());
        }

        public int issue_preg_cert(int consId, bool isPreg, String edc)
        {
            Dictionary<String, String> cons = new Dictionary<String, String>();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_issue_preg_cert (" + consId + ", " + (isPreg ? "1" : "0") + ", " + (isPreg ? ("'" + Utilities.stringDataParse4SQL(edc) + "'") : "NULL") + ")");
            return int.Parse(data.Rows[0]["cert_id"].ToString());
        }

        //printMedicalReport
        public void refreshMedicalRecordLV(System.Windows.Forms.ListView lv, int patId)
        {
            lv.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_medical_history_get ('" + (Login.clinic == null ? "" : Utilities.stringDataParse4SQL(Login.clinic.Value)) + "', " + patId + ")");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    string[] row = { dr["cons_id"].ToString(), dr["cons_dtm"].ToString(), dr["dx_desc"].ToString(), dr["ex_desc"].ToString(), dr["diff_desc"].ToString(), dr["pres_data_str"].ToString(), dr["acupuncture_desc"].ToString() };
                    System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem(row);
                    lv.Items.Add(item);
                }
            }
        }
    }
}
