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
        public static UserObj user;
        public static ClinicObj clinic;
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
            clinic = (ClinicObj)(comboBox_clinicId.SelectedItem);
            user = ucMgr.getUserByUserClinicRoleId(textBox_userName.Text, clinic.ClinicId, int.Parse(((PermissibleValueObj)(comboBox_role.SelectedItem)).getValue()), ref ErrMsg);
            if (user != null)
            {
                if (PasswordHash.getHashedPw(textBox_password.Text) == user.HashedPw)
                {
                    if (user.CurrentLoginRole == 4)
                    {
                        SystemAdmin_MainMenu sysAdmMainMenu = new SystemAdmin_MainMenu();
                        this.Hide();
                        sysAdmMainMenu.ShowDialog();
                        this.Show();
                    }
                }
                else
                {
                    MessageBox.Show("密碼錯誤", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(ErrMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Enabled = true;
        }

        private void button_patSys_Click(object sender, EventArgs e)
        {
            String ErrMsg = "";
            this.Enabled = false;
            clinic = (ClinicObj)(comboBox_clinicId.SelectedItem);
            user = ucMgr.getUserByUserClinicRoleId(textBox_userName.Text, clinic.ClinicId, int.Parse(((PermissibleValueObj)(comboBox_role.SelectedItem)).getValue()), ref ErrMsg);
            if (user != null)
            {
                if (PasswordHash.getHashedPw(textBox_password.Text) == user.HashedPw)
                {
                    Patient_mainMenu patMainMenu = new Patient_mainMenu();
                    user = null; 
                    this.Hide();
                    patMainMenu.ShowDialog();
                    this.Show();
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
