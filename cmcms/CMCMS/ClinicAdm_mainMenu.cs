﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMCMS
{
    public partial class ClinicAdm_mainMenu : Form
    {
        public ClinicAdm_mainMenu()
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

        private void ClinicAdm_mainMenu_FormClosing(object sender, FormClosingEventArgs e)
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
            AddFormulaForm newPredefPres = new AddFormulaForm();
            newPredefPres.ShowDialog();
        }

        private void button_updatePredefPres_Click(object sender, EventArgs e)
        {
            UpdateFormulaForm updatePredefPresForm = new UpdateFormulaForm();
            updatePredefPresForm.ShowDialog();
        }

        private void button_queuingMgt_Click(object sender, EventArgs e)
        {
            Staff_QueuingForm sqf = new Staff_QueuingForm();
            sqf.Show();
        }

        private void button_reporting_Click(object sender, EventArgs e)
        {
            ClinicAdm_reporting car = new ClinicAdm_reporting();
            this.Hide();
            car.ShowDialog();
            this.Show();
        }
    }
}
