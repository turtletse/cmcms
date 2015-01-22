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
    public partial class Staff_QueuingForm : Form
    {
        PatientMgr patMgr = new PatientMgr();
        public Staff_QueuingForm()
        {
            InitializeComponent();
        }

        public void reset()
        {
            searchPatientInputPanel1.reset();
        }

        private void button_enterQueue_Click(object sender, EventArgs e)
        {
            String statusMsg = "";
            PatientObj pat = searchPatientInputPanel1.getSelectedPatient();
            if (pat == null)
                return;
            patMgr.enterQueue(int.Parse(pat.getValue()), Login.clinic.ClinicId, ref statusMsg);
            MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reset();
        }

        private void button_seaechPanel_leaveQ_Click(object sender, EventArgs e)
        {
            String statusMsg = "";
            PatientObj pat = searchPatientInputPanel1.getSelectedPatient();
            if (pat == null)
                return;
            patMgr.leaveQueue(int.Parse(pat.getValue()), Login.clinic.ClinicId, ref statusMsg);
            MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reset();
        }

    }
}
