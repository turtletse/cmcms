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
        UserClinicMgr ucMgr = new UserClinicMgr();
        public Staff_QueuingForm()
        {
            InitializeComponent();
            nextPatReset();
            changeMOICReset();
            waitingList1.refresh();
        }

        public void enterQueueReset()
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
            enterQueueReset();
            waitingList1.refresh();
        }

        private void button_seaechPanel_leaveQ_Click(object sender, EventArgs e)
        {
            String statusMsg = "";
            PatientObj pat = searchPatientInputPanel1.getSelectedPatient();
            if (pat == null)
                return;
            patMgr.leaveQueue(int.Parse(pat.getValue()), Login.clinic.ClinicId, ref statusMsg);
            MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            enterQueueReset();
            waitingList1.refresh();
        }

        public void nextPatReset()
        {
            ucMgr.setMOICcombobox(comboBox_NextPat_MOIC);
            if (comboBox_NextPat_MOIC.Items.Count > 0)
                comboBox_NextPat_MOIC.SelectedIndex = 0;
            textBox_piorityCons_patId.Clear();
        }

        public void changeMOICReset()
        {
            ucMgr.setMOICcombobox(comboBox_changeMOIC_MOIC);
            if (comboBox_changeMOIC_MOIC.Items.Count > 0)
                comboBox_changeMOIC_MOIC.SelectedIndex = 0;
            textBox_changeMOIC_patId.Clear();
        }

        private void button_NextPat_reset_Click(object sender, EventArgs e)
        {
            nextPatReset();
        }

        private void button_changeMOIC_reset_Click(object sender, EventArgs e)
        {
            changeMOICReset();
        }

        private void button_piorityCons_Click(object sender, EventArgs e)
        {
            String statusMsg = "";
            patMgr.staffAssignPriorityConsultation(int.Parse(textBox_piorityCons_patId.Text), ((UserObj)(comboBox_NextPat_MOIC.SelectedItem)).Value, ref statusMsg);
            MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            nextPatReset();
            waitingList1.refresh();
        }

        private void button_changeMOIC_Click(object sender, EventArgs e)
        {
            String statusMsg = "";
            patMgr.changeMOIC(int.Parse(textBox_changeMOIC_patId.Text), ((UserObj)(comboBox_changeMOIC_MOIC.SelectedItem)).Value, ref statusMsg);
            MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            changeMOICReset();
            waitingList1.refresh();
        }

        private void button_callNext_Click(object sender, EventArgs e)
        {
            bool isGetPatSuccess;
            String msg = "";

            callNextPatient:
                isGetPatSuccess=patMgr.staffCallNextPat(((UserObj)(comboBox_NextPat_MOIC.SelectedItem)).Value, ref msg);
                if (isGetPatSuccess)
                {
                    DialogResult isHere;
                    isHere = MessageBox.Show(msg, "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (isHere == System.Windows.Forms.DialogResult.Yes)
                    {
                        patMgr.staffCallNextPatAnswered(((UserObj)(comboBox_NextPat_MOIC.SelectedItem)).Value, ref msg);
                    }
                    else if (isHere == System.Windows.Forms.DialogResult.No)
                    {
                        goto callNextPatient;
                    }
                    else if (isHere == System.Windows.Forms.DialogResult.Cancel)
                    {
                        patMgr.stopCallNextPat(ref msg);
                    }
                }
                else
                {
                    MessageBox.Show(msg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                waitingList1.refresh();
        }

    }
}
