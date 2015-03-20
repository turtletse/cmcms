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
    public partial class PatientPwChk : Form
    {
        int patId = 0;
        PermissibleValueObj isChkSuccess = new PermissibleValueObj();
        public PatientPwChk()
        {
            InitializeComponent();
        }

        public void setPatIdSuccessFlag(int patId, ref PermissibleValueObj isChkSuccess)
        {
            this.patId = patId;
            this.isChkSuccess = isChkSuccess;
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            PatientMgr patMgr = new PatientMgr();
            isChkSuccess.Value = patMgr.patPwChk(patId, PasswordHash.getHashedPw(textBox_pw.Text));
            if (isChkSuccess.Value == "0")
            {
                MessageBox.Show("密碼錯誤!", "密碼錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            isChkSuccess.Value = "0";
            this.Hide();
        }

        private void textBox_pw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                button_confirm_Click(sender, e);
            }
        }
    }
}
