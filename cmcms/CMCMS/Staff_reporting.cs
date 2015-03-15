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
    public partial class Staff_reporting : Form
    {
        public Staff_reporting()
        {
            InitializeComponent();
        }

        private void button_reporting_Click(object sender, EventArgs e)
        {
            PrintMedicalReportForm pmrf = new PrintMedicalReportForm();
            pmrf.ShowDialog();
        }
    }
}
