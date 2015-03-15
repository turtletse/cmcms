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
    public partial class EnterQueue : Form
    {
        PatientMgr patMgr = new PatientMgr();
        public EnterQueue()
        {
            InitializeComponent();
            searchPatientInputPanel1.setShowInclDeceasedCB(false);
            searchPatientInputPanel1.setInclDeceased(false);
        }

        public void reset()
        {
            searchPatientInputPanel1.reset();
        }

        private void button_enterQueue_Click(object sender, EventArgs e)
        {
            String statusMsg = "";
            //bool isSuccess;
            PatientObj pat = searchPatientInputPanel1.getSelectedPatient();
            if (pat == null)
                return;
            //isSuccess = patMgr.enterQueue(int.Parse(pat.getValue()), Login.clinic.ClinicId, ref statusMsg);
            patMgr.enterQueue(int.Parse(pat.getValue()), Login.clinic.ClinicId, ref statusMsg);
            MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reset();
        }

        private void button_leaveQ_Click(object sender, EventArgs e)
        {
            String statusMsg = "";
            //bool isSuccess;
            PatientObj pat = searchPatientInputPanel1.getSelectedPatient();
            if (pat == null)
                return;

            PermissibleValueObj pwChkStatus = new PermissibleValueObj("", "0");
            PatientPwChk patPwChk = new PatientPwChk();
            patPwChk.setPatIdSuccessFlag(pat.PatientId, ref pwChkStatus);
            patPwChk.ShowDialog();
            if (pwChkStatus.Value == "0")
                return;

            //isSuccess = patMgr.leaveQueue(int.Parse(pat.getValue()), Login.clinic.ClinicId, ref statusMsg);
            patMgr.leaveQueue(int.Parse(pat.getValue()), Login.clinic.ClinicId, ref statusMsg);
            MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reset();
        }
    }
}
