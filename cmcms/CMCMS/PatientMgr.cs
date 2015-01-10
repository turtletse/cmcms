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
        public bool insertPatientRecord(String chiName, String engName, String pw, String idDocType, String idNo, String phoneNo, String dob, String sex, bool isG6PD, String addr, String allergicDrugIds, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_insert_patient_record ('" + chiName + "', '" + engName + "', '" + pw + "', '" + idDocType + "', '" + idNo + "', '" + phoneNo + "', '" + dob + "', '" + sex + "', " + (isG6PD ? "1" : "0") + ", '" + addr + "', '" + allergicDrugIds + "')");
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
            foreach (DataRow dr in data.Rows)
            {
                Listbox.Items.Add(new PatientObj(int.Parse(dr["patirnt_id"].ToString()), dr["chin_name"].ToString(), dr["eng_name"].ToString(), dr["hashed_password"].ToString(), dr["id_doc_type"].ToString(), dr["id_doc_no"].ToString(), dr["phone_no"].ToString(), dr["dob"].ToString(), dr["sex"].ToString(), Convert.ToBoolean(dr["isG6PD"]), dr["addr"].ToString(), dr["allergic_drug_ids"].ToString(), Convert.ToBoolean(dr["isDeceased"]), dr["deceased_record_dtm"].ToString()));
                //Listbox.Items.Add(new PermissibleValueObj(dr["drug_name"].ToString(), dr["drug_id"].ToString()));
            }
        }
    }
}
