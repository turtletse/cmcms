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
    public partial class Staff_MainMenu : Form
    {
        public Staff_MainMenu()
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

        private void button_queuingMgt_Click(object sender, EventArgs e)
        {
            Staff_QueuingForm sqf = new Staff_QueuingForm();
            sqf.Show();
        }

    }
}
