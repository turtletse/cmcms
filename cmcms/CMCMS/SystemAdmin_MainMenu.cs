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
    public partial class SystemAdmin_MainMenu : Form
    {
        public SystemAdmin_MainMenu()
        {
            InitializeComponent();
        }

        private void button_NewPatient_Click(object sender, EventArgs e)
        {
            NewPatientForm newPat = new NewPatientForm();
            newPat.ShowDialog();
        }

        private void button_amdPatData_Click(object sender, EventArgs e)
        {
            AmdPatientDataForm amdPatDataForm = new AmdPatientDataForm();
            amdPatDataForm.ShowDialog();
        }

        private void button_drugAdm_Click(object sender, EventArgs e)
        {
            DrugAdmin drugAdm = new DrugAdmin();
            drugAdm.ShowDialog();
        }

        private void button_newClinic_Click(object sender, EventArgs e)
        {
            NewClinicForm newClinicForm = new NewClinicForm();
            newClinicForm.ShowDialog();
        }

        private void button_amdClinic_Click(object sender, EventArgs e)
        {
            AmdClinicDataForm amdClinicDataForm = new AmdClinicDataForm();
            amdClinicDataForm.ShowDialog();
        }

        private void button_userAdm_Click(object sender, EventArgs e)
        {
            UserAdm userAdm = new UserAdm();
            userAdm.ShowDialog();
        }

        private void SystemAdmin_MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserClinicMgr ucMgr = new UserClinicMgr();

            String statusMsg = "";
            bool isSuccess;
            isSuccess = ucMgr.logout(ref statusMsg);
            if (isSuccess)
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_newPredefPres_Click(object sender, EventArgs e)
        {
            AddFormulaForm newPredefPresForm = new AddFormulaForm();
            newPredefPresForm.ShowDialog();
        }

        private void button_updatePredefPres_Click(object sender, EventArgs e)
        {
            UpdateFormulaForm updatePredefPresForm = new UpdateFormulaForm();
            updatePredefPresForm.ShowDialog();
        }

    }
}
