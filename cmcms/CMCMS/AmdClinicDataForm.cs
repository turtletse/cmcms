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
    public partial class AmdClinicDataForm : Form
    {
        UserClinicMgr ucMgr = new UserClinicMgr();
        public AmdClinicDataForm()
        {
            InitializeComponent();
            reset();
        }

        public void reset()
        {
            ucMgr.setAmdClinicCombo(comboBox_clinic);
            comboBox_clinic.SelectedIndex = 0;
            clinicRegistration1.reset();
        }

        private void button_select_Click(object sender, EventArgs e)
        {
            clinicRegistration1.setClinic((ClinicObj)(comboBox_clinic.SelectedItem));
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button_updateClinic_Click(object sender, EventArgs e)
        {
            if (input_validation())
            {
                UserClinicMgr ucMgr = new UserClinicMgr();
                String statusMsg = "";
                bool isSuccess;
                isSuccess = ucMgr.updateClinic(clinicRegistration1.getClinicId(), clinicRegistration1.getChineseName(), clinicRegistration1.getEnglishName(), clinicRegistration1.getAddr(), clinicRegistration1.getPhoneNo(), clinicRegistration1.getIsSuspended(), ref statusMsg);
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

        private bool input_validation()
        {
            return clinicRegistration1.input_validation();
        }
    }
}
