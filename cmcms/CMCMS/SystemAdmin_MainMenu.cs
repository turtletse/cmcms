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

        private void button1_Click(object sender, EventArgs e)
        {
            AmdPatientDataForm amdPatDataForm = new AmdPatientDataForm();
            amdPatDataForm.ShowDialog();
        }

        private void button_drugAdm_Click(object sender, EventArgs e)
        {
            DrugAdmin drugAdm = new DrugAdmin();
            drugAdm.ShowDialog();
        }


    }
}
