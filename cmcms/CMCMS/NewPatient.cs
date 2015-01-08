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
    public partial class NewPatient : UserControl
    {
        public NewPatient()
        {
            InitializeComponent();
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            patientRegistration1.Enabled = false;
            patientRegistration1.reset();
            patientRegistration1.Enabled = true;
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            MessageBox.Show(patientRegistration1.getHashedPassword() + "\n" + patientRegistration1.getHashedPassword().Length);
        }

    }
}
