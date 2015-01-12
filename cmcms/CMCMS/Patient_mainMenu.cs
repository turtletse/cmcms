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
    public partial class Patient_mainMenu : Form
    {
        public Patient_mainMenu()
        {
            InitializeComponent();
        }

        private void button_newPatient_Click(object sender, EventArgs e)
        {
            NewPatientForm newPatForm = new NewPatientForm();
            newPatForm.ShowDialog();
        }

        private void button_amdPatientData_Click(object sender, EventArgs e)
        {
            AmdPatientDataForm amdPatDataForm = new AmdPatientDataForm();
            amdPatDataForm.ShowDialog();
        }
    }
}
