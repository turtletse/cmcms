using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMCMS
{
    public partial class UserRegistration : UserControl
    {
        public UserRegistration()
        {
            InitializeComponent();
            reset();
        }

        public void reset()
        {
            UserClinicMgr ucMgr = new UserClinicMgr();
            textBox_userId.Clear();
            textBox_chiName.Clear();
            textBox_engName.Clear();
            textBox_regNo.Clear();
            textBox_password.Clear();
            textBox_cmfPassword.Clear();
            ucMgr.setNewUserClinicCombo(comboBox_clinic);
            comboBox_clinic.SelectedIndex = 0;
            ucMgr.setNewUserRoleCombo(comboBox_role);
            comboBox_role.SelectedIndex = 0;
            checkBox_isSuspended.Checked = false;
        }

        public void setShowIsSuspendedCB(bool isShow)
        {
            if (isShow)
                checkBox_isSuspended.Show();
            else
                checkBox_isSuspended.Hide();
        }

        public String getUserId()
        {
            return textBox_userId.Text.Trim();
        }

        public String getChineseName()
        {
            return textBox_chiName.Text.Trim();
        }

        public String getEnglishName()
        {
            return textBox_engName.Text.Trim();
        }

        public String getRegNo()
        {
            return textBox_regNo.Text.Trim();
        }

        public String getHashedPassword()
        {
            return PasswordHash.getHashedPw(textBox_password.Text);
        }

        public String getClinicId()
        {
            return ((ClinicObj)(comboBox_clinic.SelectedItem)).ClinicId;
        }

        public int getRoleId()
        {
            return int.Parse(((PermissibleValueObj)comboBox_role.SelectedItem).getValue());
        }

        public bool isDataValid()
        {
            if (textBox_password.Text != textBox_cmfPassword.Text)
                return false;
            return true;
        }

        public bool getIsSuspended()
        {
            return checkBox_isSuspended.Checked;
        }
    }
}
