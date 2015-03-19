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
    public partial class SysAdm_reporting : Form
    {
        public SysAdm_reporting()
        {
            InitializeComponent();
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



    }
}
