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
    public partial class PrintMedicalReportForm : Form
    {
        ReportViewer rptViewer = new ReportViewer();
        PatientObj pat;
        public PrintMedicalReportForm()
        {
            InitializeComponent();
            searchPatientInputPanel1.setShowInclDeceasedCB(true);
        }

        private void button_prnWholeRec_Click(object sender, EventArgs e)
        {
            pat = searchPatientInputPanel1.getSelectedPatient();
            if (pat == null)
                return;
            rptViewer.prepareMedicalReport(Login.user.CurrentLoginClinicId, pat.PatientId, 0);
            rptViewer.ShowDialog();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            pat = searchPatientInputPanel1.getSelectedPatient();
            if (pat == null)
                return;
            ConsultationMgr consMgr = new ConsultationMgr();
            consMgr.refreshMedicalRecordLV(listView1, pat.PatientId);
        }

        private void button_prnSelected_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;
            if (pat == null)
                return;

            rptViewer.prepareMedicalReport(Login.user.CurrentLoginClinicId, pat.PatientId, int.Parse((listView1.SelectedItems[0].Text).ToString()));
            rptViewer.ShowDialog();
        }

    }
}
