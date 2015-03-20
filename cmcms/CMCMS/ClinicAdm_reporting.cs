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
    public partial class ClinicAdm_reporting : Form
    {
        public ClinicAdm_reporting()
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

        private void button_dxStat_Click(object sender, EventArgs e)
        {
            ReportViewer rptViewer = new ReportViewer();
            rptViewer.prepareLast30DaysDxStat(Login.user.CurrentLoginClinicId);
            rptViewer.ShowDialog();
        }

        private void button_suspiciousPresList_Click(object sender, EventArgs e)
        {
            ReportViewer rptViewer = new ReportViewer();
            rptViewer.prepareSuspiciousPresList(Login.user.CurrentLoginClinicId);
            rptViewer.ShowDialog();
        }

        private void button_userListing_Click(object sender, EventArgs e)
        {
            ReportViewer rptViewer = new ReportViewer();
            rptViewer.prepareUserListing(Login.user.CurrentLoginClinicId);
            rptViewer.ShowDialog();
        }

        private void button_clinicListing_Click(object sender, EventArgs e)
        {
            ReportViewer rptViewer = new ReportViewer();
            rptViewer.prepareClinicListing(Login.user.CurrentLoginClinicId);
            rptViewer.ShowDialog();
        }

        private void button_drugListing_Click(object sender, EventArgs e)
        {
            ReportViewer rptViewer = new ReportViewer();
            rptViewer.prepareDrugListing(Login.user.CurrentLoginClinicId);
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
