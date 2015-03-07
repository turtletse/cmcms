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
    public partial class UserAmdInfo : Form
    {
        public UserAmdInfo()
        {
            InitializeComponent();
            userRegistration1.setShowIsSuspendedCB(false);
            userRegistration1.setShowClinicRole(false);
        }

        private void button_amdUser_reset_Click(object sender, EventArgs e)
        {
            userRegistration1.setUser(Login.user);

        }

        private void button_amdUser_Click(object sender, EventArgs e)
        {
            UserClinicMgr ucMgr = new UserClinicMgr();
            userRegistration1.Enabled = false;

            if (!userRegistration1.isDataValid())
                return;

            String statusMsg = "";
            bool isSuccess;
            isSuccess = ucMgr.amdUserAccount(userRegistration1.getUserId(), (userRegistration1.getPlainTextPassword().Length > 0 ? userRegistration1.getHashedPassword() : ""), userRegistration1.getChineseName(), userRegistration1.getEnglishName(), userRegistration1.getRegNo(), false, ref statusMsg);
            if (isSuccess)
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login.user.ChineseName = userRegistration1.getChineseName();
                Login.user.EnglishName = userRegistration1.getEnglishName();
                Login.user.RegNo = userRegistration1.getRegNo();
                if (userRegistration1.getPlainTextPassword().Length > 0)
                {
                    Login.user.HashedPw = userRegistration1.getHashedPassword();
                }
                button_amdUser_reset_Click(sender, e);
            }
            else
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            userRegistration1.Enabled = true;
        }

        private void UserAmdInfo_Shown(object sender, EventArgs e)
        {
            userRegistration1.setUser(Login.user);
        }
    }
}
