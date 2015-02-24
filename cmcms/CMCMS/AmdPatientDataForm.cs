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
    public partial class AmdPatientDataForm : Form
    {
        PatientObj pat;
        public AmdPatientDataForm()
        {
            InitializeComponent();
            if (Login.user == null)
            {
                patientRegistration1.setShowDeceasedCtrl(false);
                searchPatientInputPanel1.setShowInclDeceasedCB(false);
            }
            else
            {
                patientRegistration1.setShowDeceasedCtrl(true);
                searchPatientInputPanel1.setShowInclDeceasedCB(true);
            }
            pat = null;
        }

        private void button_selectPatient_Click(object sender, EventArgs e)
        {
            pat = searchPatientInputPanel1.getSelectedPatient();
            patientRegistration1.Enabled = false;
            patientRegistration1.setPatientData(pat);
            patientRegistration1.Enabled = true;
        }

        private void button_patDataReset_Click(object sender, EventArgs e)
        {
            patientRegistration1.Enabled = false;
            if (pat != null)
                patientRegistration1.setPatientData(pat);
            else
                patientRegistration1.reset();
            patientRegistration1.Enabled = true;
        }

        private void button_patDataUpdate_Click(object sender, EventArgs e)
        {
            //input validation
            if (!patientRegistration1.isDataValid())
                return;

            String statusMsg = "";
            PatientMgr patMgr = new PatientMgr();

            bool isSuccess;
            if (Login.user==null)
                isSuccess = patMgr.amdPatientRecordByPatient(pat.PatientId, patientRegistration1.getChiName(), Utilities.stringDataParse4SQL(patientRegistration1.getEngName()), (patientRegistration1.getPlainTextPassword().Trim().Length > 0 ? patientRegistration1.getHashedPassword() : ""), patientRegistration1.getPIDDocType(), patientRegistration1.getPIDDocNo(), patientRegistration1.getPhoneNo(), patientRegistration1.getDOB(), patientRegistration1.getSex(), patientRegistration1.getIsG6PD(), Utilities.stringDataParse4SQL(patientRegistration1.getAddr().Trim()), patientRegistration1.getAllergicDrugsIdString(), patientRegistration1.getIsPregnant(), patientRegistration1.getIsRecordShared(), ref statusMsg);
            else
                isSuccess = patMgr.amdPatientRecord(pat.PatientId, patientRegistration1.getChiName(), Utilities.stringDataParse4SQL(patientRegistration1.getEngName()), (patientRegistration1.getPlainTextPassword().Trim().Length > 0 ? patientRegistration1.getHashedPassword() : ""), patientRegistration1.getPIDDocType(), patientRegistration1.getPIDDocNo(), patientRegistration1.getPhoneNo(), patientRegistration1.getDOB(), patientRegistration1.getSex(), patientRegistration1.getIsG6PD(), Utilities.stringDataParse4SQL(patientRegistration1.getAddr().Trim()), patientRegistration1.getAllergicDrugsIdString(), patientRegistration1.getIsDeceased(), patientRegistration1.getIsPregnant(), patientRegistration1.getIsRecordShared(), ref statusMsg);
            if (isSuccess)
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pat = null;
                patientRegistration1.reset();
                searchPatientInputPanel1.reset();
            }
            else
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
