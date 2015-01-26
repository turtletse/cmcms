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

        List<PermissibleValueObj> examination = new List<PermissibleValueObj>();
        List<PermissibleValueObj> differentiation = new List<PermissibleValueObj>();
        List<PermissibleValueObj> diagnosis = new List<PermissibleValueObj>();
        String drRmk = "";
        List<String> prescription = new List<string>();

        ExaminationResultSelectionForm ersf = new ExaminationResultSelectionForm();
        DifferentiationResultSelectionForm drsf = new DifferentiationResultSelectionForm();
        DxResultSelectionForm dxrsf = new DxResultSelectionForm();
        DrRmkEditForm dref = new DrRmkEditForm();

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
            textBox_drRmk.Text = drRmk;
        }

        
    }
}
