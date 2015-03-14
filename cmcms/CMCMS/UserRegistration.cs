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
        bool showClinicRole = true;
        public UserRegistration()
        {
            InitializeComponent();
            reset();
        }

        public void reset()
        {
            UserClinicMgr ucMgr = new UserClinicMgr();
            textBox_userId.ReadOnly = false;
            textBox_userId.Clear();
            textBox_chiName.Clear();
            textBox_engName.Clear();
            textBox_regNo.Clear();
            textBox_password.Clear();
            textBox_cmfPassword.Clear();
            ucMgr.setUserPermissibleClinicCombo(comboBox_clinic);
            comboBox_clinic.SelectedIndex = 0;
            ucMgr.setUserPermissibleRoleCombo(comboBox_role);
            comboBox_role.SelectedIndex = 0;
            checkBox_isSuspended.Enabled = true;
            checkBox_isSuspended.Checked = false;
        }

        public bool input_validation()
        {
            if (textBox_userId.Text.Length == 0)
            {
                MessageBox.Show("請輸入用戶名稱", "用戶名稱錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_userId.Focus();
                return false;
            }
            if (!Utilities.isAlphaOnly(textBox_userId.Text))
            {
                MessageBox.Show("用戶名稱只限半形英文字母\n請重新輸入", "用戶名稱錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_userId.Focus();
                return false;
            }

            if (textBox_chiName.Text.Length == 0)
            {
                MessageBox.Show("請輸入中文姓名", "中文姓名錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_chiName.Focus();
                return false;
            }
            if (!Utilities.isCJKCharacters(textBox_chiName.Text))
            {
                MessageBox.Show("中文姓名錯誤\n請重新輸入", "中文姓名錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_chiName.Focus();
                return false;
            }

            if (!Utilities.isAlphaSpace(textBox_engName.Text))
            {
                MessageBox.Show("英文姓名只限半形英文字母及空格\n請重新輸入", "英文姓名錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_chiName.Focus();
                return false;
            }

            if (!Utilities.isInteger(textBox_regNo.Text))
            {
                MessageBox.Show("中醫註冊編號錯誤\n請重新輸入", "中醫註冊編號錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_regNo.Focus();
                return false;
            }

            if (textBox_password.Text.Length == 0)
            {
                MessageBox.Show("請輸入密碼", "密碼錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_password.Focus();
                return false;
            }
            if (textBox_password.Text != textBox_cmfPassword.Text)
            {
                MessageBox.Show("確認密碼錯誤\n請重新輸入", "確認密碼錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_regNo.Focus();
                return false;
            }

            if (((PermissibleValueObj)(comboBox_role.SelectedItem)).Value == "20")
            {
                if (textBox_regNo.Text.Length == 0)
                {
                    MessageBox.Show("請輸入中醫註冊編號\n請重新輸入", "中醫註冊編號錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_regNo.Focus();
                    return false;
                }
            }

            if (showClinicRole)
            {
                if (((PermissibleValueObj)(comboBox_role.SelectedItem)).Value == "40")
                {
                    if (((PermissibleValueObj)(comboBox_clinic.SelectedItem)).Value != "ALL")
                    {
                        MessageBox.Show("系統管理員只限選用專用診所代號\"ALL\"", "診所代號錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                if (((PermissibleValueObj)(comboBox_clinic.SelectedItem)).Value == "ALL")
                {
                    if (((PermissibleValueObj)(comboBox_role.SelectedItem)).Value != "40")
                    {
                        MessageBox.Show("系統管理員專用診所代號\"ALL\"只限系統管理員專用", "身份錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }

        public void setShowIsSuspendedCB(bool isShow)
        {
            if (isShow)
                checkBox_isSuspended.Show();
            else
                checkBox_isSuspended.Hide();
        }

        public void setShowClinicRole(bool isShow)
        {
            showClinicRole = isShow;
            if (isShow)
            {
                label_clinic.Show();
                comboBox_clinic.Show();
                label_role.Show();
                comboBox_role.Show();
            }
            else
            {
                label_clinic.Hide();
                comboBox_clinic.Hide();
                label_role.Hide();
                comboBox_role.Hide();
            }
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

        public String getPlainTextPassword()
        {
            return textBox_password.Text;
        }

        public String getClinicId()
        {
            return ((ClinicObj)(comboBox_clinic.SelectedItem)).ClinicId;
        }

        public int getRoleId()
        {
            return int.Parse(((PermissibleValueObj)comboBox_role.SelectedItem).getValue());
        }

        public bool getIsSuspended()
        {
            return checkBox_isSuspended.Checked;
        }

        public void setUser(UserObj user)
        {
            textBox_userId.Text = user.UserId;
            textBox_userId.ReadOnly = true;
            textBox_chiName.Text = user.ChineseName;
            textBox_engName.Text = user.EnglishName;
            textBox_regNo.Text = user.RegNo;
            textBox_password.Clear();
            textBox_cmfPassword.Clear();
            checkBox_isSuspended.Checked = user.IsSuspended;
            if (Login.user != null && Login.user.UserId == user.UserId)
            {
                checkBox_isSuspended.Checked = false;
                checkBox_isSuspended.Enabled = false;
            }
            else
            {
                checkBox_isSuspended.Enabled = true;
            }
        }
    }
}
