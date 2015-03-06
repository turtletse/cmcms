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
    public partial class ConsultationForm : Form
    {
        PatientMgr patMgr = new PatientMgr();
        ConsultationMgr consMgr = new ConsultationMgr();

        List<PermissibleValueObj> examination = new List<PermissibleValueObj>();
        List<PermissibleValueObj> differentiation = new List<PermissibleValueObj>();
        List<PermissibleValueObj> diagnosis = new List<PermissibleValueObj>();
        List<PermissibleValueObj> drRmk = new List<PermissibleValueObj>();

        ExaminationResultSelectionForm ersf = new ExaminationResultSelectionForm();
        DifferentiationResultSelectionForm drsf = new DifferentiationResultSelectionForm();
        DxResultSelectionForm dxrsf = new DxResultSelectionForm();
        DrRmkEditForm dref = new DrRmkEditForm();

        String consId = "";

        String isFinished = "0";

        public ConsultationForm()
        {
            InitializeComponent();
            ersf.setSelectedExamResult(ref examination);
            drsf.setSelectedDiffResult(ref differentiation);
            dxrsf.setSelectedDxResult(ref diagnosis);
            drRmk.Add(new PermissibleValueObj("", ""));
            dref.setRmk(ref drRmk);
        }

        private String permissibleValueObjListNameToString(List<PermissibleValueObj> list)
        {
            String s = "";
            foreach (PermissibleValueObj o in list)
            {
                if (o.Name != "" && o.Value != "")
                    s += o.Name + "; ";
            }
            return s;
        }

        private String permissibleValueObjListValueToString(List<PermissibleValueObj> list)
        {
            String s = "";
            foreach (PermissibleValueObj o in list)
            {
                if (o.Name != "" && o.Value != "")
                    s += "||"+o.Value;
            }
            if (s.Length > 0)
            {
                s = s.Substring(2);
            }
            return s;
        }



        private void ConsultationForm_Shown(object sender, EventArgs e)
        {
            String statusMsg="";
            bool isSuccess;
            isSuccess = patMgr.setPatientInfoForConsultation(textBox_patId, textBox_pat_chiName, textBox_pat_engName, textBox_pat_IDNo, textBox_pat_sex, checkBox_pat_isPregnant, textBox_pat_DOB, textBox_pat_age, checkBox_pat_isG6PD, textBox_pat_drugAllergy, ref statusMsg);
            if (!isSuccess)
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                refresh_consultation_data(true);
                consMgr.refreshHistoryLV(listView1, int.Parse(textBox_patId.Text));
            }
        }

        private void refresh_consultation_data(bool isNewCons)
        {
            Dictionary<String, String> consData;
            if (isNewCons)
                consData = consMgr.startConsultation(int.Parse(textBox_patId.Text));
            else
                consData = consMgr.getConsultation(int.Parse(consId));

            consId = consData["cons_id"];
            textBox_startDtm.Text = consData["first_record_dtm"];
            textBox_lastUpdateDtm.Text = consData["last_update_dtm"];
            dateTimePicker_sickLeaveStart.Value = DateTime.ParseExact(textBox_lastUpdateDtm.Text.Substring(0,textBox_lastUpdateDtm.Text.IndexOf(' ')) , "dd/MM/yyyy", null);
            dateTimePicker_sickLeaveStart.MinDate = dateTimePicker_sickLeaveStart.Value;
            dateTimePicker_sickLeaveEnd.MinDate = dateTimePicker_sickLeaveStart.Value;
            dateTimePicker_sickLeaveEnd.Value = DateTime.Today;
            dateTimePicker_edc.Value = DateTime.Today;
            isFinished = consData["isFinished"];

            String[] code;
            String[] desc;

            examination.Clear();
            code = consData["ex_code"].Split(new String[] { "||" }, StringSplitOptions.None);
            desc = consData["ex_desc"].Split(new String[] { "; " }, StringSplitOptions.None);
            for (int i = 0; i < code.Length; i++)
            {
                if(desc[i]!="" && code[i]!="")
                    examination.Add(new PermissibleValueObj(desc[i], code[i]));
            }
            textBox_exam.Text = permissibleValueObjListNameToString(examination);

            differentiation.Clear();
            code = consData["diff_code"].Split(new String[] { "||" }, StringSplitOptions.None);
            desc = consData["diff_desc"].Split(new String[] { "; " }, StringSplitOptions.None);
            for (int i = 0; i < code.Length; i++)
            {
                if (desc[i] != "" && code[i] != "")
                    differentiation.Add(new PermissibleValueObj(desc[i], code[i]));
            }
            textBox_diff.Text = permissibleValueObjListNameToString(differentiation);

            diagnosis.Clear();
            code = consData["dx_code"].Split(new String[] { "||" }, StringSplitOptions.None);
            desc = consData["dx_desc"].Split(new String[] { "; " }, StringSplitOptions.None);
            for (int i = 0; i < code.Length; i++)
            {
                if (desc[i] != "" && code[i] != "")
                    diagnosis.Add(new PermissibleValueObj(desc[i], code[i]));
            }
            textBox_dx.Text = permissibleValueObjListNameToString(diagnosis);

            comboBox_presId.Items.Clear();
            code = consData["pres_id"].Split(new String[] { "||" }, StringSplitOptions.None);
            for (int i = 0; i < code.Length; i++)
            {
                if (code[i] != "")
                    comboBox_presId.Items.Add(new PermissibleValueObj(code[i], code[i]));
            }
            if (comboBox_presId.Items.Count > 0)
            {
                comboBox_presId.SelectedIndex = 0;
            }

            drRmk.Clear();
            drRmk.Add(new PermissibleValueObj(consData["dr_rmk"], consData["dr_rmk"]));
            textBox_drRmk.Text = drRmk[0].Value;

            if (isFinished == "0")
            {
                groupBox_sickLeaveCert.Enabled = false;
                button_consCert.Enabled = false;
                groupBox_pregCert.Enabled = false;
                button_change_exam.Enabled = true;
                button_change_diff.Enabled = true;
                button_change_dx.Enabled = true;
                button_change_pres.Enabled = true;
                button_delPres.Enabled = true;
                button_add_pres.Enabled = true;
                button_change_drRmk.Enabled = true;
                button_tmpSave.Enabled = true;
                button_finalSave.Enabled = true;
                button_conLater.Enabled = true;
                button_finish.Enabled = false;
                button_use_previous.Enabled = true;
                checkBox_pat_isPregnant.Enabled = true;
            }
            else if (isFinished == "1")
            {
                groupBox_sickLeaveCert.Enabled = true;
                button_consCert.Enabled = true;
                groupBox_pregCert.Enabled = true;
                checkBox_preg_edc.Enabled = checkBox_pat_isPregnant.Checked;
                dateTimePicker_edc.Enabled = checkBox_pat_isPregnant.Checked;
                button_change_exam.Enabled = true;
                button_change_diff.Enabled = true;
                button_change_dx.Enabled = true;
                button_change_pres.Enabled = true;
                button_delPres.Enabled = true;
                button_add_pres.Enabled = true;
                button_change_drRmk.Enabled = true;
                button_tmpSave.Enabled = false;
                button_finalSave.Enabled = true;
                button_conLater.Enabled = false;
                button_finish.Enabled = true;
                button_use_previous.Enabled = true;
                checkBox_pat_isPregnant.Enabled = true;
            }
            else
            {
                MessageBox.Show("資料狀態錯誤!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button_change_exam_Click(object sender, EventArgs e)
        {
            ersf.reset();
            ersf.ShowDialog();
            textBox_exam.Text = permissibleValueObjListNameToString(examination);
        }

        private void button_change_diff_Click(object sender, EventArgs e)
        {
            drsf.reset();
            drsf.ShowDialog();
            textBox_diff.Text = permissibleValueObjListNameToString(differentiation);
        }

        private void button_dx_Click(object sender, EventArgs e)
        {
            dxrsf.reset();
            dxrsf.ShowDialog();
            textBox_dx.Text = permissibleValueObjListNameToString(diagnosis);
        }

        private void button_change_drRmk_Click(object sender, EventArgs e)
        {
            dref.ShowDialog();
            textBox_drRmk.Text = drRmk[0].Value;
        }

        private void button_delPres_Click(object sender, EventArgs e)
        {
            if (comboBox_presId.SelectedIndex == -1)
                return;
            comboBox_presId.Items.RemoveAt(comboBox_presId.SelectedIndex);
        }

        private void button_add_pres_Click(object sender, EventArgs e)
        {
            PrescriptionForm pf = new PrescriptionForm();
            PermissibleValueObj presId = new PermissibleValueObj("","");
            pf.setPresId(ref presId);
            pf.setIsG6pd(checkBox_pat_isG6PD.Checked);
            pf.setIsPreg(checkBox_pat_isPregnant.Checked);
            pf.ShowDialog();
            comboBox_presId.Items.Add(presId);
            if (comboBox_presId.Items.Count > 0)
            {
                comboBox_presId.SelectedIndex = comboBox_presId.Items.Count - 1;
            }
        }

        private void button_change_pres_Click(object sender, EventArgs e)
        {
            if (comboBox_presId.SelectedIndex == -1)
                return;
            PrescriptionForm pf = new PrescriptionForm();
            PermissibleValueObj presId = new PermissibleValueObj(comboBox_presId.SelectedItem.ToString(),comboBox_presId.SelectedItem.ToString());
            pf.setPresId(ref presId);
            pf.setIsG6pd(checkBox_pat_isG6PD.Checked);
            pf.setIsPreg(checkBox_pat_isPregnant.Checked);
            pf.ShowDialog();
        }

        private void button_tmpSave_Click(object sender, EventArgs e)
        {
            String statusMsg="";
            bool isSuccess;

            String presIds="";
            foreach(PermissibleValueObj o in comboBox_presId.Items)
            {
                presIds+="||"+o.Value;
            }
            if (presIds.Length>0)
            {
                presIds=presIds.Substring(2);
            }
            isSuccess = consMgr.saveConsultation(consId, textBox_patId.Text, permissibleValueObjListValueToString(examination), permissibleValueObjListNameToString(examination), permissibleValueObjListValueToString(differentiation), permissibleValueObjListNameToString(differentiation), permissibleValueObjListValueToString(diagnosis), permissibleValueObjListNameToString(diagnosis), presIds, drRmk[0].Value, ref statusMsg);
            MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (isSuccess)
            {
                refresh_consultation_data(false);
            }
        }

        private void button_conLater_Click(object sender, EventArgs e)
        {
            String statusMsg = "";
            bool isSuccess;

            String presIds = "";
            foreach (PermissibleValueObj o in comboBox_presId.Items)
            {
                presIds += "||" + o.Value;
            }
            if (presIds.Length > 0)
            {
                presIds = presIds.Substring(2);
            }
            isSuccess = consMgr.consLater(consId, textBox_patId.Text, permissibleValueObjListValueToString(examination), permissibleValueObjListNameToString(examination), permissibleValueObjListValueToString(differentiation), permissibleValueObjListNameToString(differentiation), permissibleValueObjListValueToString(diagnosis), permissibleValueObjListNameToString(diagnosis), presIds, drRmk[0].Value, ref statusMsg);
            MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (isSuccess)
            {
                this.Close();
            }
        }

        private void button_finalSave_Click(object sender, EventArgs e)
        {
            String statusMsg = "";
            bool isSuccess = false;

            String presIds = "";
            foreach (PermissibleValueObj o in comboBox_presId.Items)
            {
                presIds += "||" + o.Value;
            }
            if (presIds.Length > 0)
            {
                presIds = presIds.Substring(2);
            }

            int saveConStatus = consMgr.saveConsultation(consId, textBox_patId.Text, permissibleValueObjListValueToString(examination), permissibleValueObjListNameToString(examination), permissibleValueObjListValueToString(differentiation), permissibleValueObjListNameToString(differentiation), permissibleValueObjListValueToString(diagnosis), permissibleValueObjListNameToString(diagnosis), presIds, drRmk[0].Value, ref statusMsg);

            if (saveConStatus == 0)
            {
                isSuccess = true;
            }
            else
            {
                if (saveConStatus == 19)
                {
                    DialogResult needChange = MessageBox.Show(statusMsg, "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (needChange == System.Windows.Forms.DialogResult.Yes)
                    {
                        return;
                    }
                    else
                    {
                        isSuccess = true;
                    }
                }
                else
                {
                    isSuccess = false;
                }
            }

            if (isSuccess)
            {
                refresh_consultation_data(false);
                isSuccess = consMgr.confirmedConsultation(consId, ref statusMsg);
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (isSuccess)
                {
                    refresh_consultation_data(false);
                    DialogResult isPrint = MessageBox.Show("列印處方?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (isPrint == System.Windows.Forms.DialogResult.Yes)
                    {
                        ReportViewer rptViewer = new ReportViewer();
                        rptViewer.preparePrescription(consId);
                        rptViewer.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkBox_pat_isPregnant_CheckedChanged(object sender, EventArgs e)
        {
            consMgr.updatePtPregFlag(int.Parse(textBox_patId.Text), checkBox_pat_isPregnant.Checked);
            if (isFinished == "1")
            {
                refresh_consultation_data(false);
            }
        }

        private void ConsultationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isFinished == "0")
            {
                String statusMsg = "";

                String presIds = "";
                foreach (PermissibleValueObj o in comboBox_presId.Items)
                {
                    presIds += "||" + o.Value;
                }
                if (presIds.Length > 0)
                {
                    presIds = presIds.Substring(2);
                }
                consMgr.consLater(consId, textBox_patId.Text, permissibleValueObjListValueToString(examination), permissibleValueObjListNameToString(examination), permissibleValueObjListValueToString(differentiation), permissibleValueObjListNameToString(differentiation), permissibleValueObjListValueToString(diagnosis), permissibleValueObjListNameToString(diagnosis), presIds, drRmk[0].Value, ref statusMsg);
            }
        }

        private void button_finish_Click(object sender, EventArgs e)
        {
            String statusMsg = "";
            bool isSuccess;
            isSuccess = consMgr.finishConsultation(consId, ref statusMsg);
            if (!isSuccess)
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.Close();
            }
        }

        private void button_use_previous_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            String statusMsg ="";
            if (consMgr.usePreviousConsultationAsTemplate(int.Parse(consId), int.Parse((listView1.SelectedItems[0].Text).ToString()), ref statusMsg))
            {
                refresh_consultation_data(false);
            }
            else
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dateTimePicker_sickLeaveEnd_ValueChanged(object sender, EventArgs e)
        {
            textBox_sickLeaveNDays.Text = ((dateTimePicker_sickLeaveEnd.Value - dateTimePicker_sickLeaveStart.Value).Days+1).ToString();
        }

        private void button_issueSickLeaveCert_Click(object sender, EventArgs e)
        {
            ReportViewer rptViewer = new ReportViewer();
            rptViewer.prepareSickLeaveCert(consMgr.issue_sick_leave_cert(int.Parse(consId), dateTimePicker_sickLeaveStart.Value.ToString("dd/MM/yyyy"), dateTimePicker_sickLeaveEnd.Value.ToString("dd/MM/yyyy"), int.Parse(textBox_sickLeaveNDays.Text)));
            rptViewer.ShowDialog();
        }

        private void dateTimePicker_sickLeaveStart_ValueChanged(object sender, EventArgs e)
        {
            textBox_sickLeaveNDays.Text = ((dateTimePicker_sickLeaveEnd.Value - dateTimePicker_sickLeaveStart.Value).Days + 1).ToString();
        }

        private void button_consCert_Click(object sender, EventArgs e)
        {
            ReportViewer rptViewer = new ReportViewer();
            rptViewer.prepareConsultationCert(int.Parse(consId));
            rptViewer.ShowDialog();
        }

        private void button_pregCert_Click(object sender, EventArgs e)
        {
            ReportViewer rptViewer = new ReportViewer();
            rptViewer.preparePregCert(consMgr.issue_preg_cert(int.Parse(consId), checkBox_pat_isPregnant.Checked, dateTimePicker_edc.Value.ToString("dd/MM/yyyy")));
            rptViewer.ShowDialog();
        }      
    }
}
