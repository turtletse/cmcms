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
            if (!userRegistration_newUser.isDataValid())
                return;

            UserClinicMgr ucMgr = new UserClinicMgr();
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
        }

    }
}
