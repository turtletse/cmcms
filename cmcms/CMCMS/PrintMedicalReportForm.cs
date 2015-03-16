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

        private void button_consCert_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;
            rptViewer.prepareConsultationCert(int.Parse((listView1.SelectedItems[0].Text).ToString()));
            rptViewer.ShowDialog();
        }

        private void button_issueSickLeaveCert_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            int nDays = int.Parse(((dateTimePicker_sickLeaveEnd.Value - dateTimePicker_sickLeaveStart.Value).Days + 1).ToString());
            if (nDays < 1)
            {
                MessageBox.Show("病假結束日期不能早於開始日期", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ConsultationMgr consMgr = new ConsultationMgr();
            int certId = consMgr.issue_sick_leave_cert(int.Parse((listView1.SelectedItems[0].Text).ToString()), dateTimePicker_sickLeaveStart.Value.ToString("dd/MM/yyyy"), dateTimePicker_sickLeaveEnd.Value.ToString("dd/MM/yyyy"), nDays);
            if (certId > 0)
            {
                rptViewer.prepareSickLeaveCert(certId);
                rptViewer.ShowDialog();
            }
            else if (certId == -1)
            {
                MessageBox.Show("現時距離診症完成時間已超24小時, 不能補發病假證明書", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (certId == -2)
            {
                MessageBox.Show("病假開始日期不能早於診症日期", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
