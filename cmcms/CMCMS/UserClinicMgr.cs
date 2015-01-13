using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CMCMS
{
    public class UserClinicMgr
    {
        DBMgr dbmgr = new DBMgr();

        //login
        public UserObj getUserByUserClinicRoleId(String userId, String clinicId, int roleId, ref String ErrMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_login_user_get ('" + userId + "', '" + clinicId + "', " + roleId + ")");
            if (data!=null && data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return new UserObj(dr["user_id"].ToString(), dr["hashed_password"].ToString(), dr["chin_name"].ToString(), dr["eng_name"].ToString(), dr["reg_no"].ToString(), dr["last_logout_dtm"].ToString(), dr["last_logout_clinic_id"].ToString(), int.Parse(dr["current_login_role_id"].ToString()), dr["current_login_clinic_id"].ToString(), Convert.ToBoolean(dr["isSuspended"]));
            }
            else
            {
                ErrMsg = "登入名稱/診所/用戶不正確";
                return null;
            }
        }

        public void setLoginClinicCombo(System.Windows.Forms.ComboBox cb)
        {
            cb.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_login_clinic_get ()");
            foreach (DataRow dr in data.Rows)
            {
                cb.Items.Add(new ClinicObj(dr["clinic_id"].ToString(), dr["clinic_chin_name"].ToString(), dr["clinic_eng_name"].ToString(), dr["clinic_addr"].ToString(), dr["clinic_phone_no"].ToString(), Convert.ToBoolean(dr["isSuspended"])));
            }
        }

        public void setLoginRoleCombo(System.Windows.Forms.ComboBox cb)
        {
            cb.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_login_role_get ()");
            foreach (DataRow dr in data.Rows)
            {
                cb.Items.Add(new PermissibleValueObj(dr["role_desc"].ToString(), dr["role_id"].ToString()));
            }
        }


        //NewClinic
        public bool insertClinic(String clinicId, String chiName, String engName, String addr, String phoneNo, bool isSuspended, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_insert_clinic ('" + clinicId + "', '" + chiName + "', '" + engName + "', '" + addr + "', '" + phoneNo + "', " + (isSuspended ? "1" : "0") + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        //AmdClinic
        public void setAmdClinicCombo(System.Windows.Forms.ComboBox cb)
        {
            cb.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_amd_clinic_get ('"+Login.clinic.ClinicId+"')");
            foreach (DataRow dr in data.Rows)
            {
                cb.Items.Add(new ClinicObj(dr["clinic_id"].ToString(), dr["clinic_chin_name"].ToString(), dr["clinic_eng_name"].ToString(), dr["clinic_addr"].ToString(), dr["clinic_phone_no"].ToString(), Convert.ToBoolean(dr["isSuspended"])));
            }
        }

        public bool updateClinic(String clinicId, String chiName, String engName, String addr, String phoneNo, bool isSuspended, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_update_clinic ('" + clinicId + "', '" + chiName + "', '" + engName + "', '" + addr + "', '" + phoneNo + "', " + (isSuspended ? "1" : "0") + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        //userRegistration
        public void setNewUserClinicCombo(System.Windows.Forms.ComboBox cb)
        {
            cb.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_new_user_clinic_get ('" + Login.user.CurrentLoginClinicId + "', " + Login.user.CurrentLoginRole + ")");
            foreach (DataRow dr in data.Rows)
            {
                cb.Items.Add(new ClinicObj(dr["clinic_id"].ToString(), dr["clinic_chin_name"].ToString(), dr["clinic_eng_name"].ToString(), dr["clinic_addr"].ToString(), dr["clinic_phone_no"].ToString(), Convert.ToBoolean(dr["isSuspended"])));
            }
        }

        public void setNewUserRoleCombo(System.Windows.Forms.ComboBox cb)
        {
            cb.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_new_user_role_get (" + Login.user.CurrentLoginRole + ")");
            foreach (DataRow dr in data.Rows)
            {
                cb.Items.Add(new PermissibleValueObj(dr["role_desc"].ToString(), dr["role_id"].ToString()));
            }
        }

        //newUserForm
        public bool createAccount(String userId, String chiName, String engName, String regNo, String hashedPw, String clinicId, int roleId, bool isSuspended, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_new_user_account ('" + userId + "', '" + chiName + "', '" + engName + "', '" + regNo + "', '" + hashedPw + "', '" + clinicId + "', " + roleId + ", " +(isSuspended ? "1" : "0") + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }
    }
}
