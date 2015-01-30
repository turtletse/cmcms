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
    public partial class Doctor_MainMenu : Form
    {
        public Doctor_MainMenu()
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

        private void button_newPredefPres_Click(object sender, EventArgs e)
        {
            AddFormulaForm newPredefPres = new AddFormulaForm();
            newPredefPres.ShowDialog();
        }

        private void button_updatePredefPres_Click(object sender, EventArgs e)
        {
            UpdateFormulaForm updatePredefPresForm = new UpdateFormulaForm();
            updatePredefPresForm.ShowDialog();
        }

        private void button_consultation_Click(object sender, EventArgs e)
        {
            Doctor_QueuingForm drQFrom = new Doctor_QueuingForm();
            drQFrom.ShowDialog();
        }

        private void Doctor_MainMenu_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
