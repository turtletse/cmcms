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
    public partial class NewClinicForm : Form
    {
        public NewClinicForm()
        {
            InitializeComponent();
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            clinicRegistration1.reset();
        }

        private void button_newClinic_Click(object sender, EventArgs e)
        {
            UserClinicMgr ucMgr = new UserClinicMgr();
            String statusMsg = "";
            bool isSuccess;
            isSuccess = ucMgr.insertClinic(clinicRegistration1.getClinicId(), clinicRegistration1.getChineseName(), clinicRegistration1.getEnglishName(), clinicRegistration1.getAddr(), clinicRegistration1.getPhoneNo(), clinicRegistration1.getIsSuspended(), ref statusMsg);
            if (isSuccess)
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button_reset_Click(sender, e);
            }
            else
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
