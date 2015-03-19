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
    public partial class Doctor_QueuingForm : Form
    {
        PatientMgr patMgr = new PatientMgr();
        UserClinicMgr ucMgr = new UserClinicMgr();

        public Doctor_QueuingForm()
        {
            InitializeComponent();
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

        private void button_callNext_Click(object sender, EventArgs e)
        {
            bool isGetPatSuccess;
            String msg = "";

        callNextPatient:
            isGetPatSuccess = patMgr.doctorCallNextPat(ref msg);
            if (isGetPatSuccess)
            {
                DialogResult isHere;
                isHere = MessageBox.Show(msg, "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (isHere == System.Windows.Forms.DialogResult.Yes)
                {
                    patMgr.doctorCallNextPatAnswered(ref msg);
                    openConsultationForm();
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

        private void button_calledPat_Click(object sender, EventArgs e)
        {
            String statusMsg = "";
            bool isSuccess;
            isSuccess = patMgr.doctorSeeCalledPat(ref statusMsg);
            if (isSuccess)
            {
                openConsultationForm();
            }
            else
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void Doctor_QueuingForm_Shown(object sender, EventArgs e)
        {
            reset();
        }

        private void reset()
        {
            enterQueueReset();
            nextPatReset();
            waitingList1.refresh();
        }

        private void button_piorityCons_Click(object sender, EventArgs e)
        {
            String statusMsg = "";
            bool isSuccess;
            isSuccess = patMgr.doctorAssignPriorityConsultation(int.Parse(textBox_piorityCons_patId.Text), ref statusMsg);
            if (isSuccess)
            {
                openConsultationForm();
            }
            else
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void nextPatReset()
        {
            textBox_piorityCons_patId.Clear();
        }

        private void button_NextPat_reset_Click(object sender, EventArgs e)
        {
            nextPatReset();
        }

        private void openConsultationForm()
        {
            ConsultationForm consForm = new ConsultationForm();
            this.Hide();
            consForm.ShowDialog();
            reset();
            this.Show();
        }

        private void textBox_piorityCons_patId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                button_piorityCons_Click(sender, e);
            }
        }
    }
}
