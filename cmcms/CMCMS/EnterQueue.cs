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
            PatientMgr patMgr = new PatientMgr();
            String statusMsg = "";
            bool isSuccess;
            PatientObj pat = searchPatientInputPanel1.getSelectedPatient();
            isSuccess = patMgr.enterQueue(int.Parse(pat.getValue()), Login.clinic.ClinicId, ref statusMsg);
            if (isSuccess)
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset();
            }
            else
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
