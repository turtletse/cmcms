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

        private void button_recordCert_Click(object sender, EventArgs e)
        {
            PrintMedicalReportForm pmrf = new PrintMedicalReportForm();
            pmrf.ShowDialog();
        }

        private void button_clinicConsStatByDay30_Click(object sender, EventArgs e)
        {
            ReportViewer rptViewer = new ReportViewer();
            rptViewer.prepareClinicConsStatByDay30(Login.user.CurrentLoginClinicId);
            rptViewer.ShowDialog();
        }

        private void button_patListing_Click(object sender, EventArgs e)
        {
            ReportViewer rptViewer = new ReportViewer();
            rptViewer.preparePatientListing(Login.user.CurrentLoginClinicId, Login.user.UserId);
            rptViewer.ShowDialog();
        }
    }
}
