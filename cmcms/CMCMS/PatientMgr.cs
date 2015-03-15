using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CMCMS
{
    class PatientMgr
    {
        DBMgr dbmgr = new DBMgr();

        //PatientRegistration
        public bool insertPatientRecord(String chiName, String engName, String pw, String idDocType, String idNo, String phoneNo, String dob, String sex, bool isG6PD, String addr, String allergicDrugIds, bool isPregnant, bool isRecordShared, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_insert_patient_record ('" + Utilities.stringDataParse4SQL(chiName) + "', '" + Utilities.stringDataParse4SQL(engName) + "', '" + Utilities.stringDataParse4SQL(pw) + "', '" + Utilities.stringDataParse4SQL(idDocType) + "', '" + Utilities.stringDataParse4SQL(idNo) + "', '" + Utilities.stringDataParse4SQL(phoneNo) + "', '" + Utilities.stringDataParse4SQL(dob) + "', '" + Utilities.stringDataParse4SQL(sex) + "', " + (isG6PD ? "1" : "0") + ", '" + Utilities.stringDataParse4SQL(addr) + "', '" + Utilities.stringDataParse4SQL(allergicDrugIds) + "', " + (isPregnant ? "1" : "0") + ", " + (isRecordShared ? "1" : "0") + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        //searchPatientPanel
        public void setSearchPatientResultListbox(System.Windows.Forms.ListBox Listbox, String patientId, String hkid, String phoneNo, bool inclDeceased)
        {
            Listbox.Items.Clear();
            String pid = patientId.Trim();
            if (pid.Length == 0)
                pid = "NULL";
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_patient_listbox_get (" + pid + ", '" + Utilities.stringDataParse4SQL(hkid) + "', '" + Utilities.stringDataParse4SQL(phoneNo) + "', " + (inclDeceased ? "1" : "0") + ")");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    Listbox.Items.Add(new PatientObj(int.Parse(dr["patient_id"].ToString()), dr["chin_name"].ToString(), dr["eng_name"].ToString(), dr["hashed_password"].ToString(), dr["id_doc_type"].ToString(), dr["id_doc_no"].ToString(), dr["phone_no"].ToString(), dr["dob"].ToString(), dr["sex"].ToString(), Convert.ToBoolean(dr["isG6PD"]), dr["addr"].ToString(), dr["allergic_drug_ids"].ToString(), Convert.ToBoolean(dr["isDeceased"]), dr["deceased_record_dtm"].ToString(), Convert.ToBoolean(dr["isPregnant"]), Convert.ToBoolean(dr["isRecordShared"])));
                }
            }
        }

        //amdPatientData
        public bool amdPatientRecordByPatient(int patId, String chiName, String engName, String pw, String idDocType, String idNo, String phoneNo, String dob, String sex, bool isG6PD, String addr, String allergicDrugIds, bool isPregnant, bool isRecordShared, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_update_patient_record (" + patId + ", '" + Utilities.stringDataParse4SQL(chiName) + "', '" + Utilities.stringDataParse4SQL(engName) + "', '" + Utilities.stringDataParse4SQL(pw) + "', '" + Utilities.stringDataParse4SQL(idDocType) + "', '" + Utilities.stringDataParse4SQL(idNo) + "', '" + Utilities.stringDataParse4SQL(phoneNo) + "', '" + Utilities.stringDataParse4SQL(dob) + "', '" + Utilities.stringDataParse4SQL(sex) + "', " + (isG6PD ? "1" : "0") + ", '" + Utilities.stringDataParse4SQL(addr) + "', '" + Utilities.stringDataParse4SQL(allergicDrugIds) + "', " + "0" + ", " + (isPregnant ? "1" : "0") + ", " + (isRecordShared ? "1" : "0") + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public bool amdPatientRecord(int patId, String chiName, String engName, String pw, String idDocType, String idNo, String phoneNo, String dob, String sex, bool isG6PD, String addr, String allergicDrugIds, bool isDeceased, bool isPregnant, bool isRecordShared, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_update_patient_record (" + patId + ", '" + Utilities.stringDataParse4SQL(chiName) + "', '" + Utilities.stringDataParse4SQL(engName) + "', '" + Utilities.stringDataParse4SQL(pw) + "', '" + Utilities.stringDataParse4SQL(idDocType) + "', '" + Utilities.stringDataParse4SQL(idNo) + "', '" + Utilities.stringDataParse4SQL(phoneNo) + "', '" + Utilities.stringDataParse4SQL(dob) + "', '" + Utilities.stringDataParse4SQL(sex) + "', " + (isG6PD ? "1" : "0") + ", '" + Utilities.stringDataParse4SQL(addr) + "', '" + Utilities.stringDataParse4SQL(allergicDrugIds) + "', " + (isDeceased ? "1" : "0") + ", " + (isPregnant ? "1" : "0") + ", " + (isRecordShared ? "1" : "0") + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        //patientPwChk
        public String patPwChk(int patId, String pw)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL patient_pw_check (" + patId + ", '" + Utilities.stringDataParse4SQL(pw) + "')");
            return data.Rows[0]["isMatch"].ToString();
        }

        //Queuing
        public bool enterQueue(int patId, String clinicId, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_enter_patient_queue (" + patId + ", '" + Utilities.stringDataParse4SQL(clinicId) + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public bool leaveQueue(int patId, String clinicId, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_leave_patient_queue (" + patId + ", '" + Utilities.stringDataParse4SQL(clinicId) + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        //WaitingList
        public void refreshWaitingList(System.Windows.Forms.ListView lv)
        {
            lv.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_patient_queue_for_waitingList_get ('" + (Login.clinic == null ? "" : Utilities.stringDataParse4SQL(Login.clinic.ClinicId)) + "')");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    string[] row = { dr["seq"].ToString(), dr["patient_id"].ToString(), dr["chin_name"].ToString(), dr["eng_name"].ToString(), dr["sex"].ToString(), dr["dob"].ToString(), dr["enter_dtm"].ToString(), dr["status_desc"].ToString(), dr["MOIC"].ToString() };
                    System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem(row);
                    lv.Items.Add(item);
                }
            }
        }

        //Staff_QueuingForm
        public bool staffAssignPriorityConsultation(int patId, String moicId, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_patient_queue_to_priority_consultation (" + patId + ", '" + (Login.clinic == null ? "" : Utilities.stringDataParse4SQL(Login.clinic.ClinicId)) + "', '" + Utilities.stringDataParse4SQL(moicId) + "', '" + (Login.user == null ? "" : Utilities.stringDataParse4SQL(Login.user.UserId)) + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public bool changeMOIC(int patId, String moicId, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_patient_queue_change_assigned_moic (" + patId + ", '" + (Login.clinic == null ? "" : Utilities.stringDataParse4SQL(Login.clinic.ClinicId)) + "', '" + Utilities.stringDataParse4SQL(moicId) + "', '" + (Login.user == null ? "" : Utilities.stringDataParse4SQL(Login.user.UserId)) + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public bool staffCallNextPat(String moicId, ref String msg)
        {
            msg ="";
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_patient_queue_staff_call_next_pat ('" + (Login.clinic == null ? "" : Utilities.stringDataParse4SQL(Login.clinic.ClinicId)) + "', '" + Utilities.stringDataParse4SQL(moicId) + "', '" + (Login.user == null?"":Utilities.stringDataParse4SQL(Login.user.UserId)) + "')");
            if (data != null && data.Rows.Count > 0)
            {
                if (int.Parse(data.Rows[0]["status_id"].ToString()) == 0)
                {
                    msg = "以下病人是否在診所?\n\n";
                    msg += "病人編號: " + data.Rows[0]["patient_id"] + "\n";
                    msg += "中文姓名: " + data.Rows[0]["chin_name"] + "\n";
                    msg += "英文姓名: " + data.Rows[0]["eng_name"] + "\n";
                    msg += "性別: " + data.Rows[0]["sex"] + "\n";
                    msg += "出生日期: " + data.Rows[0]["dob"];
                    return true;
                }
                else
                {
                    msg = data.Rows[0]["status_desc"].ToString();
                    return false;
                }
            }
            else
            {
                msg = "所有輪候中的病人已叫名一次/沒有病人在輪候";
                return false;
            }
        }

        public bool stopCallNextPat(ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_patient_queue_staff_call_release_lock ('" + (Login.clinic == null ? "" : Utilities.stringDataParse4SQL(Login.clinic.ClinicId)) + "', '" + (Login.user == null ? "" : Utilities.stringDataParse4SQL(Login.user.UserId)) + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public bool staffCallNextPatAnswered(String moicId, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_patient_queue_staff_call_answered ('" + (Login.clinic == null ? "" : Utilities.stringDataParse4SQL(Login.clinic.ClinicId)) + "', '" + Utilities.stringDataParse4SQL(moicId) + "', '" + (Login.user == null ? "" : Utilities.stringDataParse4SQL(Login.user.UserId)) + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        //Doctor_QueuingForm
        public bool doctorCallNextPat(ref String msg)
        {
            msg = "";
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_patient_queue_doctor_call_next_pat ('" + (Login.clinic == null ? "" : Utilities.stringDataParse4SQL(Login.clinic.ClinicId)) + "', '" + (Login.user == null ? "" : Utilities.stringDataParse4SQL(Login.user.UserId)) + "')");
            if (data != null && data.Rows.Count > 0)
            {
                if (int.Parse(data.Rows[0]["status_id"].ToString()) == 0)
                {
                    msg = "以下病人是否在診所?\n\n";
                    msg += "病人編號: " + data.Rows[0]["patient_id"] + "\n";
                    msg += "中文姓名: " + data.Rows[0]["chin_name"] + "\n";
                    msg += "英文姓名: " + data.Rows[0]["eng_name"] + "\n";
                    msg += "性別: " + data.Rows[0]["sex"] + "\n";
                    msg += "出生日期: " + data.Rows[0]["dob"];
                    return true;
                }
                else
                {
                    msg = data.Rows[0]["status_desc"].ToString();
                    return false;
                }
            }
            else
            {
                msg = "所有輪候中的病人已叫名一次/沒有病人在輪候";
                return false;
            }
        }

        public bool doctorCallNextPatAnswered(ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_patient_queue_doctor_call_answered ('" + (Login.clinic == null ? "" : Utilities.stringDataParse4SQL(Login.clinic.ClinicId)) + "', '" + (Login.user == null ? "" : Utilities.stringDataParse4SQL(Login.user.UserId)) + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public bool doctorSeeCalledPat(ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_patient_queue_doctor_see_called_pat ('" + (Login.clinic == null ? "" : Utilities.stringDataParse4SQL(Login.clinic.ClinicId)) + "', '" + (Login.user == null ? "" : Utilities.stringDataParse4SQL(Login.user.UserId)) + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public bool doctorAssignPriorityConsultation(int patId, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_patient_queue_doctor_priority_consultation (" + patId + ", '" + (Login.clinic == null ? "" : Utilities.stringDataParse4SQL(Login.clinic.ClinicId)) + "', '" + (Login.user == null ? "" : Utilities.stringDataParse4SQL(Login.user.UserId)) + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        //consultation
        public bool setPatientInfoForConsultation(System.Windows.Forms.TextBox tbPatId, System.Windows.Forms.TextBox tbChiName, System.Windows.Forms.TextBox tbEngName, System.Windows.Forms.TextBox tbHKID, System.Windows.Forms.TextBox tbSex, System.Windows.Forms.CheckBox cbIsPregnant, System.Windows.Forms.TextBox tbDOB, System.Windows.Forms.TextBox tbAge, System.Windows.Forms.CheckBox cbIsG6PD, System.Windows.Forms.TextBox tbAllergicDrug, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_consultation_currentPatientGet ('" + (Login.clinic == null ? "" : Utilities.stringDataParse4SQL(Login.clinic.ClinicId)) + "', '" + (Login.user == null ? "" : Utilities.stringDataParse4SQL(Login.user.UserId)) + "')");
            if (data != null && data.Rows.Count > 0)
            {
                tbPatId.Text = data.Rows[0]["patient_id"].ToString();
                tbChiName.Text = data.Rows[0]["chin_name"].ToString();
                tbEngName.Text = data.Rows[0]["eng_name"].ToString();
                tbHKID.Text = data.Rows[0]["id_doc_no"].ToString();
                tbSex.Text = data.Rows[0]["sex"].ToString();
                cbIsPregnant.Checked = Convert.ToBoolean(data.Rows[0]["isPregnant"]);
                tbDOB.Text = data.Rows[0]["dob"].ToString();
                tbAge.Text = data.Rows[0]["age"].ToString();
                cbIsG6PD.Checked = Convert.ToBoolean(data.Rows[0]["isG6PD"]);
                tbAllergicDrug.Text = data.Rows[0]["allergic_drug"].ToString();
                return true;
            }
            else
            {
                statusMsg = "沒有正在診治的病人";
                return false;
            }
        }
    }
}
