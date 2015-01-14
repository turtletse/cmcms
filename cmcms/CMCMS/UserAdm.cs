using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMCMS
{
    public partial class UserAdm : Form
    {
        UserClinicMgr ucMgr = new UserClinicMgr();
        public UserAdm()
        {
            InitializeComponent();
        }

        private void button_newUser_reset_Click(object sender, EventArgs e)
        {
            userRegistration_newUser.reset();
        }

        private void button_newUser_Click(object sender, EventArgs e)
        {
            //input validation
            userRegistration_newUser.Enabled = false;
            if (!userRegistration_newUser.isDataValid())
                return;

            String statusMsg = "";
            bool isSuccess;
            isSuccess = ucMgr.createAccount(userRegistration_newUser.getUserId(), userRegistration_newUser.getChineseName(), userRegistration_newUser.getEnglishName(), userRegistration_newUser.getRegNo(), userRegistration_newUser.getHashedPassword(), userRegistration_newUser.getClinicId(), userRegistration_newUser.getRoleId(), userRegistration_newUser.getIsSuspended(), ref statusMsg);
            if (isSuccess)
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button_newUser_reset_Click(sender, e);
            }
            else
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            userRegistration_newUser.Enabled = true;
        }

        private void tabPage_newUser_Enter(object sender, EventArgs e)
        {
            userRegistration_newUser.reset();
        }

        private void tabPage_amdUserData_Enter(object sender, EventArgs e)
        {
            ucMgr.setAmdUserCombo(comboBox_amdUser_userId);
            comboBox_amdUser_userId.SelectedIndex = 0;
            userRegistration_amdUser.setShowIsSuspendedCB(true);
            userRegistration_amdUser.setShowClinicRole(false);
        }

        private void button_amdUser_reset_Click(object sender, EventArgs e)
        {
            ucMgr.setAmdUserCombo(comboBox_amdUser_userId);
            comboBox_amdUser_userId.SelectedIndex = 0;
            userRegistration_amdUser.reset();
        }

        private void button_amdUser_Click(object sender, EventArgs e)
        {
            userRegistration_amdUser.Enabled = false;

            if (!userRegistration_amdUser.isDataValid())
                return;

            String statusMsg = "";
            bool isSuccess;
            isSuccess = ucMgr.amdUserAccount(userRegistration_amdUser.getUserId(), (userRegistration_amdUser.getPlainTextPassword().Length > 0 ? userRegistration_amdUser.getHashedPassword() : ""), userRegistration_amdUser.getChineseName(), userRegistration_amdUser.getEnglishName(), userRegistration_amdUser.getRegNo(), userRegistration_amdUser.getIsSuspended(), ref statusMsg);
            if (isSuccess)
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button_amdUser_reset_Click(sender, e);
            }
            else
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            userRegistration_amdUser.Enabled = true;
        }

        private void tabPage_amdRole_Enter(object sender, EventArgs e)
        {
            textBox_amdRole_userId.Clear();
            ucMgr.setAmdRoleUserCombo(comboBox_amdRole_user);
            comboBox_amdRole_user.SelectedIndex = 0;
            ucMgr.setUserPermissibleClinicCombo(comboBox_amdRole_clinic);
            comboBox_amdRole_clinic.SelectedIndex = 0;
            ucMgr.setUserPermissibleRoleCombo(comboBox_amdRole_role);
            comboBox_amdRole_role.SelectedIndex = 0;
            listBox_amdRole_grantedClinicRole.Items.Clear();
        }

        private void button_amdRole_add_Click(object sender, EventArgs e)
        {
            if (textBox_amdRole_userId.Text.Trim().Length == 0)
                return;
            tabControl1.Enabled = false;
            String statusMsg = "";
            bool isSuccess;
            isSuccess = ucMgr.addRole(textBox_amdRole_userId.Text, ((ClinicObj)comboBox_amdRole_clinic.SelectedItem).ClinicId, ((PermissibleValueObj)comboBox_amdRole_role.SelectedItem).getValue(), ref statusMsg);
            if (isSuccess)
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ucMgr.setGrantedClinicRoleListbox(listBox_amdRole_grantedClinicRole, textBox_amdRole_userId.Text);
            }
            else
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tabControl1.Enabled = true;
        }

        private void button_amdRole_reset_Click(object sender, EventArgs e)
        {
            tabPage_amdRole_Enter(sender, e);
        }

        private void button_amdRole_delete_Click(object sender, EventArgs e)
        {
            if (listBox_amdRole_grantedClinicRole.SelectedIndex == -1)
                return;

            tabControl1.Enabled = false;
            String statusMsg = "";
            bool isSuccess;
            String[] data = ((PermissibleValueObj)(listBox_amdRole_grantedClinicRole.SelectedItem)).getValue().Split(new String[]{"^^"}, StringSplitOptions.None);
            isSuccess = ucMgr.removeRole(textBox_amdRole_userId.Text, data[0], data[1], ref statusMsg);
            if (isSuccess)
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ucMgr.setGrantedClinicRoleListbox(listBox_amdRole_grantedClinicRole, textBox_amdRole_userId.Text);
            }
            else
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tabControl1.Enabled = true;
        }

        private void comboBox_amdUser_userId_SelectedIndexChanged(object sender, EventArgs e)
        {
            userRegistration_amdUser.setUser((UserObj)comboBox_amdUser_userId.SelectedItem);
        }

        private void comboBox_amdRole_user_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_amdRole_userId.Text = ((UserObj)(comboBox_amdRole_user.SelectedItem)).UserId;
            ucMgr.setGrantedClinicRoleListbox(listBox_amdRole_grantedClinicRole, textBox_amdRole_userId.Text);
        }
        

    }
}
