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
        PatientMgr patMgr;
        public NewPatient()
        {
            patMgr = new PatientMgr();
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
            //input validation
            if (!patientRegistration1.input_validation())
                return;

            String statusMsg = "";
            bool isSuccess;
            isSuccess = patMgr.insertPatientRecord(patientRegistration1.getChiName(), Utilities.stringDataParse4SQL(patientRegistration1.getEngName()), patientRegistration1.getHashedPassword(), patientRegistration1.getPIDDocType(), patientRegistration1.getPIDDocNo(), patientRegistration1.getPhoneNo(), patientRegistration1.getDOB(), patientRegistration1.getSex(), patientRegistration1.getIsG6PD(), Utilities.stringDataParse4SQL(patientRegistration1.getAddr().Trim()), patientRegistration1.getAllergicDrugsIdString(), patientRegistration1.getIsPregnant(), patientRegistration1.getIsRecordShared(), ref statusMsg);
            if (isSuccess)
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button_reset_Click(sender, e);
            }
            else
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
