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
        PermissibleValueObj drRmk = new PermissibleValueObj("","");

        ExaminationResultSelectionForm ersf = new ExaminationResultSelectionForm();
        DifferentiationResultSelectionForm drsf = new DifferentiationResultSelectionForm();
        DxResultSelectionForm dxrsf = new DxResultSelectionForm();
        DrRmkEditForm dref = new DrRmkEditForm();

        String consId = "";

        public ConsultationForm()
        {
            InitializeComponent();
            ersf.setSelectedExamResult(ref examination);
            drsf.setSelectedDiffResult(ref differentiation);
            dxrsf.setSelectedDxResult(ref diagnosis);
            dref.setRmk(ref drRmk);
        }

        private String permissibleValueObjListToString(List<PermissibleValueObj> list)
        {
            String s = "";
            foreach (PermissibleValueObj o in list)
            {
                s += o.Name + "; ";
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

            Dictionary<String, String> consData = consMgr.startConsultation(int.Parse(textBox_patId.Text));

            consId = consData["cons_id"];
            textBox_startDtm.Text = consData["first_record_dtm"];
            textBox_lastUpdateDtm.Text = consData["last_update_dtm"];

            String[] code;
            String[] desc;

            examination.Clear();
            code = consData["ex_code"].Split(new String[] { "||" }, StringSplitOptions.None);
            desc = consData["ex_desc"].Split(new String[] { "||" }, StringSplitOptions.None);
            for (int i = 0; i < code.Length; i++)
            {
                examination.Add(new PermissibleValueObj(code[i], desc[i]));
            }

            differentiation.Clear();
            code = consData["diff_code"].Split(new String[] { "||" }, StringSplitOptions.None);
            desc = consData["diff_desc"].Split(new String[] { "||" }, StringSplitOptions.None);
            for (int i = 0; i < code.Length; i++)
            {
                differentiation.Add(new PermissibleValueObj(code[i], desc[i]));
            }

            diagnosis.Clear();
            code = consData["dx_code"].Split(new String[] { "||" }, StringSplitOptions.None);
            desc = consData["dx_desc"].Split(new String[] { "||" }, StringSplitOptions.None);
            for (int i = 0; i < code.Length; i++)
            {
                diagnosis.Add(new PermissibleValueObj(code[i], desc[i]));
            }


            comboBox_presId.Items.Clear();
            code = consData["pres_id"].Split(new String[] { "||" }, StringSplitOptions.None);
            for (int i = 0; i < code.Length; i++)
            {
                comboBox_presId.Items.Add(new PermissibleValueObj(code[i], code[i]));
            }

            drRmk = new PermissibleValueObj(consData["dr_rmk"], consData["dr_rmk"]);
        }

        private void button_change_exam_Click(object sender, EventArgs e)
        {
            ersf.ShowDialog();
            textBox_exam.Text = permissibleValueObjListToString(examination);
        }

        private void button_change_diff_Click(object sender, EventArgs e)
        {
            drsf.ShowDialog();
            textBox_diff.Text = permissibleValueObjListToString(differentiation);
        }

        private void button_dx_Click(object sender, EventArgs e)
        {
            dxrsf.ShowDialog();
            textBox_dx.Text = permissibleValueObjListToString(diagnosis);
        }

        private void button_change_drRmk_Click(object sender, EventArgs e)
        {
            dref.ShowDialog();
            textBox_drRmk.Text = drRmk.Value;
        }

        private void button_delPres_Click(object sender, EventArgs e)
        {
            comboBox_presId.Items.RemoveAt(comboBox_presId.SelectedIndex);
        }

        private void button_add_pres_Click(object sender, EventArgs e)
        {
            PrescriptionForm pf = new PrescriptionForm();
            PermissibleValueObj presId = new PermissibleValueObj("","");
            pf.setPresId(ref presId);
            pf.ShowDialog();
            comboBox_presId.Items.Add(presId);
            if (comboBox_presId.Items.Count > 0)
            {
                comboBox_presId.SelectedIndex = comboBox_presId.Items.Count - 1;
            }
        }

        private void button_change_pres_Click(object sender, EventArgs e)
        {
            PrescriptionForm pf = new PrescriptionForm();
            PermissibleValueObj presId = new PermissibleValueObj(comboBox_presId.SelectedItem.ToString(),comboBox_presId.SelectedItem.ToString());
            pf.setPresId(ref presId);
            pf.ShowDialog();
        }        
    }
}
