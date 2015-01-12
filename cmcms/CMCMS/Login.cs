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
    public partial class Login : Form
    {
        UserClinicMgr ucMgr = new UserClinicMgr();
        public Login()
        {
            InitializeComponent();
            reset();
        }

        public void reset()
        {
            textBox_userName.Clear();
            ucMgr.setLoginClinicCombo(comboBox_clinicId);
            comboBox_clinicId.SelectedIndex = 0;
            ucMgr.setLoginRoleCombo(comboBox_role);
            comboBox_role.SelectedIndex = 0;
            textBox_password.Clear();
            textBox_userName.Select();
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            String ErrMsg ="";
            this.Enabled = false;
            UserObj user = ucMgr.getUserByUserClinicRoleId(textBox_userName.Text, ((ClinicObj)(comboBox_clinicId.SelectedItem)).ClinicId, int.Parse(((PermissibleValueObj)(comboBox_role.SelectedItem)).getValue()), ref ErrMsg);
            if (user != null)
            {
                if (PasswordHash.getHashedPw(textBox_password.Text) == user.HashedPw)
                {
                    MessageBox.Show("DONE!");
                }
                else
                {
                    textBox_userName.Text = PasswordHash.getHashedPw(textBox_password.Text);
                    MessageBox.Show("密碼錯誤", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(ErrMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Enabled = true;
        }
    }
}
