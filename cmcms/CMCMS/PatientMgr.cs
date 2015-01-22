﻿using System;
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
        public bool insertPatientRecord(String chiName, String engName, String pw, String idDocType, String idNo, String phoneNo, String dob, String sex, bool isG6PD, String addr, String allergicDrugIds, bool isPregnant, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_insert_patient_record ('" + chiName + "', '" + engName + "', '" + pw + "', '" + idDocType + "', '" + idNo + "', '" + phoneNo + "', '" + dob + "', '" + sex + "', " + (isG6PD ? "1" : "0") + ", '" + addr + "', '" + allergicDrugIds + "', " + (isPregnant ? "1" : "0") + ")");
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
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_patient_listbox_get (" + pid + ", '" + hkid + "', '" + phoneNo + "', " + (inclDeceased ? "1" : "0") + ")");
            if (data != null)
            {
                foreach (DataRow dr in data.Rows)
                {
                    Listbox.Items.Add(new PatientObj(int.Parse(dr["patient_id"].ToString()), dr["chin_name"].ToString(), dr["eng_name"].ToString(), dr["hashed_password"].ToString(), dr["id_doc_type"].ToString(), dr["id_doc_no"].ToString(), dr["phone_no"].ToString(), dr["dob"].ToString(), dr["sex"].ToString(), Convert.ToBoolean(dr["isG6PD"]), dr["addr"].ToString(), dr["allergic_drug_ids"].ToString(), Convert.ToBoolean(dr["isDeceased"]), dr["deceased_record_dtm"].ToString(), Convert.ToBoolean(dr["isPregnant"])));
                    //Listbox.Items.Add(new PermissibleValueObj(dr["drug_name"].ToString(), dr["drug_id"].ToString()));
                }
            }
        }

        //amdPatientData
        public bool amdPatientRecordByPatient(int patId, String chiName, String engName, String pw, String idDocType, String idNo, String phoneNo, String dob, String sex, bool isG6PD, String addr, String allergicDrugIds, bool isPregnant, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_update_patient_record (" + patId + ", '" + chiName + "', '" + engName + "', '" + pw + "', '" + idDocType + "', '" + idNo + "', '" + phoneNo + "', '" + dob + "', '" + sex + "', " + (isG6PD ? "1" : "0") + ", '" + addr + "', '" + allergicDrugIds + "', " + "0" + ", " + (isPregnant ? "1" : "0") + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public bool amdPatientRecord(int patId, String chiName, String engName, String pw, String idDocType, String idNo, String phoneNo, String dob, String sex, bool isG6PD, String addr, String allergicDrugIds, bool isDeceased, bool isPregnant, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_update_patient_record (" + patId + ", '" + chiName + "', '" + engName + "', '" + pw + "', '" + idDocType + "', '" + idNo + "', '" + phoneNo + "', '" + dob + "', '" + sex + "', " + (isG6PD ? "1" : "0") + ", '" + addr + "', '" + allergicDrugIds + "', " + (isDeceased ? "1" : "0") + ", " + (isPregnant ? "1" : "0") + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        //Queuing
        public bool enterQueue(int patId, String clinicId, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_enter_patient_queue (" + patId + ", '" + clinicId + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public bool leaveQueue(int patId, String clinicId, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_leave_patient_queue (" + patId + ", '" + clinicId + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        //WaitingList
        public void refreshWaitingList(System.Windows.Forms.ListView lv)
        {
            lv.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_patient_queue_for_waitingList_get ('" + (Login.clinic == null ? "" : Login.clinic.ClinicId) + "')");
            //DataTable data = dbmgr.execSelectStmtSP("CALL sp_get_patient_queue_for_waitingList ('CITYC')");
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
        public bool priorityConsultation(int patId, String moicId, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_patient_queue_to_priority_consultation (" + patId + ", '" + (Login.clinic == null ? "" : Login.clinic.ClinicId) + "', '" + moicId + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public bool changeMOIC(int patId, String moicId, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_patient_queue_change_assigned_moic (" + patId + ", '" + (Login.clinic == null ? "" : Login.clinic.ClinicId) + "', '" + moicId + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public bool callNextPat(String moicId, ref String msg)
        {
            msg ="";
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_patient_queue_staff_call_next_pat ('" + (Login.clinic == null ? "" : Login.clinic.ClinicId) + "', '" + moicId + "', '" + (Login.user == null?"":Login.user.UserId) + "')");
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
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_patient_queue_staff_call_release_lock ('" + (Login.clinic == null ? "" : Login.clinic.ClinicId) + "', '" + (Login.user == null ? "" : Login.user.UserId) + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public bool callNextPatAnswered(String moicId, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_patient_queue_staff_call_answered ('" + (Login.clinic == null ? "" : Login.clinic.ClinicId) + "', '" + moicId + "', '" + (Login.user == null ? "" : Login.user.UserId) + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }
    }
}
