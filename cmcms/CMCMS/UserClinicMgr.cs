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
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_login_user_get ('" + Utilities.stringDataParse4SQL(userId) + "', '" + Utilities.stringDataParse4SQL(clinicId) + "', " + roleId + ")");
            if (data!=null && data.Rows.Count > 0)
            {
                DataRow dr = data.Rows[0];
                return new UserObj(dr["user_id"].ToString(), dr["hashed_password"].ToString(), dr["chin_name"].ToString(), dr["eng_name"].ToString(), dr["reg_no"].ToString(), dr["last_logout_dtm"].ToString(), dr["last_logout_clinic_id"].ToString(), int.Parse(dr["current_login_role_id"].ToString()), dr["current_login_clinic_id"].ToString(), Convert.ToBoolean(dr["isSuspended"]));
            }
            else
            {
                ErrMsg = "登入名稱/診所/用戶不正確\n或\n用戶沒有任何診所之存取權限";
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
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_insert_clinic ('" + Utilities.stringDataParse4SQL(clinicId) + "', '" + Utilities.stringDataParse4SQL(chiName) + "', '" + Utilities.stringDataParse4SQL(engName) + "', '" + Utilities.stringDataParse4SQL(addr) + "', '" + Utilities.stringDataParse4SQL(phoneNo) + "', " + (isSuspended ? "1" : "0") + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        //AmdClinic
        public void setAmdClinicCombo(System.Windows.Forms.ComboBox cb)
        {
            cb.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_amd_clinic_get ('" + Utilities.stringDataParse4SQL(Login.clinic.ClinicId) + "')");
            foreach (DataRow dr in data.Rows)
            {
                cb.Items.Add(new ClinicObj(dr["clinic_id"].ToString(), dr["clinic_chin_name"].ToString(), dr["clinic_eng_name"].ToString(), dr["clinic_addr"].ToString(), dr["clinic_phone_no"].ToString(), Convert.ToBoolean(dr["isSuspended"])));
            }
        }

        public bool updateClinic(String clinicId, String chiName, String engName, String addr, String phoneNo, bool isSuspended, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_update_clinic ('" + Utilities.stringDataParse4SQL(clinicId) + "', '" + Utilities.stringDataParse4SQL(chiName) + "', '" + Utilities.stringDataParse4SQL(engName) + "', '" + Utilities.stringDataParse4SQL(addr) + "', '" + Utilities.stringDataParse4SQL(phoneNo) + "', " + (isSuspended ? "1" : "0") + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        //userAdmin
        public void setUserPermissibleClinicCombo(System.Windows.Forms.ComboBox cb)
        {
            cb.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_new_user_clinic_get ('" + (Login.user == null ? "ALL" : Utilities.stringDataParse4SQL(Login.user.CurrentLoginClinicId)) + "', " + (Login.user == null ? 0 : Login.user.CurrentLoginRole) + ")");
            foreach (DataRow dr in data.Rows)
            {
                cb.Items.Add(new ClinicObj(dr["clinic_id"].ToString(), dr["clinic_chin_name"].ToString(), dr["clinic_eng_name"].ToString(), dr["clinic_addr"].ToString(), dr["clinic_phone_no"].ToString(), Convert.ToBoolean(dr["isSuspended"])));
            }
        }

        public void setUserPermissibleRoleCombo(System.Windows.Forms.ComboBox cb)
        {
            cb.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_new_user_role_get (" + (Login.user == null ? 0 : Login.user.CurrentLoginRole) + ")");
            foreach (DataRow dr in data.Rows)
            {
                cb.Items.Add(new PermissibleValueObj(dr["role_desc"].ToString(), dr["role_id"].ToString()));
            }
        }

        //newUser
        public bool createAccount(String userId, String chiName, String engName, String regNo, String hashedPw, String clinicId, int roleId, bool isSuspended, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_new_user_account ('" + Utilities.stringDataParse4SQL(userId) + "', '" + Utilities.stringDataParse4SQL(chiName) + "', '" + Utilities.stringDataParse4SQL(engName) + "', '" + Utilities.stringDataParse4SQL(regNo) + "', '" + Utilities.stringDataParse4SQL(hashedPw) + "', '" + Utilities.stringDataParse4SQL(clinicId) + "', " + roleId + ", " +(isSuspended ? "1" : "0") + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        //amdUser
        public void setAmdUserCombo(System.Windows.Forms.ComboBox cb)
        {
            cb.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_amd_user_account_get ('" + (Login.user == null ? "SYSADM" : Utilities.stringDataParse4SQL(Login.user.CurrentLoginClinicId)) + "', " + (Login.user == null ? 0 : Login.user.CurrentLoginRole) + ")");
            foreach (DataRow dr in data.Rows)
            {
                cb.Items.Add(new UserObj(dr["user_id"].ToString(), dr["hashed_password"].ToString(), dr["chin_name"].ToString(), dr["eng_name"].ToString(), dr["reg_no"].ToString(), dr["last_logout_dtm"].ToString(), dr["last_logout_clinic_id"].ToString(), Convert.ToBoolean(dr["isSuspended"])));
            }
        }

        public bool amdUserAccount(String userId, String hashedPw, String chiName, String engName, String regNo, bool isSuspended, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_update_user_account ('" + Utilities.stringDataParse4SQL(userId) + "', '" + Utilities.stringDataParse4SQL(hashedPw) + "', '" + Utilities.stringDataParse4SQL(chiName) + "', '" + Utilities.stringDataParse4SQL(engName) + "', '" + Utilities.stringDataParse4SQL(regNo) + "', " + (isSuspended ? "1" : "0") + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        //amdRole
        public void setGrantedClinicRoleListbox(System.Windows.Forms.ListBox listbox, String userId)
        {
            listbox.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_granted_clinic_role_get ('" + Utilities.stringDataParse4SQL(userId) + "', '" + (Login.user == null ? "ALL" : Utilities.stringDataParse4SQL(Login.user.CurrentLoginClinicId)) + "', " + (Login.user == null ? 0 : Login.user.CurrentLoginRole) + ")");
            foreach (DataRow dr in data.Rows)
            {
                listbox.Items.Add(new PermissibleValueObj(dr["display_name"].ToString(), dr["sp_value"].ToString()));
            }
        }

        public bool addRole(String userId, String clinicId, String roleId, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_add_user_clinic_role ('" + Utilities.stringDataParse4SQL(userId) + "', '" + Utilities.stringDataParse4SQL(clinicId) + "', " + roleId + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public bool removeRole(String userId, String clinicId, String roleId, ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_remove_user_clinic_role ('" + Utilities.stringDataParse4SQL(userId) + "', '" + Utilities.stringDataParse4SQL(clinicId) + "', " + roleId + ")");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        public void setAmdRoleUserCombo(System.Windows.Forms.ComboBox cb)
        {
            cb.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_amd_role_user_account_get ()");
            foreach (DataRow dr in data.Rows)
            {
                cb.Items.Add(new UserObj(dr["user_id"].ToString(), dr["hashed_password"].ToString(), dr["chin_name"].ToString(), dr["eng_name"].ToString(), dr["reg_no"].ToString(), dr["last_logout_dtm"].ToString(), dr["last_logout_clinic_id"].ToString(), Convert.ToBoolean(dr["isSuspended"])));
            }
        }

        //Logout
        public bool logout(ref String statusMsg)
        {
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_user_logout ('" + (Login.user == null ? "SYSADM" : Utilities.stringDataParse4SQL(Login.user.UserId)) + "', '" + (Login.user == null ? "ALL" : Utilities.stringDataParse4SQL(Login.user.CurrentLoginClinicId)) + "')");
            statusMsg = data.Rows[0]["status_desc"].ToString();
            return (int)data.Rows[0]["status_id"] > 0 ? false : true;
        }

        //Staff_QueuingForm
        public void setMOICcombobox(System.Windows.Forms.ComboBox cb)
        {
            cb.Items.Clear();
            DataTable data = dbmgr.execSelectStmtSP("CALL sp_MOIC_combobox_get ('" + (Login.clinic == null ? "ALL" : Utilities.stringDataParse4SQL(Login.clinic.ClinicId)) + "')");
            if (data != null && data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    cb.Items.Add(new UserObj(dr["user_id"].ToString(), dr["hashed_password"].ToString(), dr["chin_name"].ToString(), dr["eng_name"].ToString(), dr["reg_no"].ToString(), dr["last_logout_dtm"].ToString(), dr["last_logout_clinic_id"].ToString(), Convert.ToBoolean(dr["isSuspended"])));
                }
            }
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
    }
}
