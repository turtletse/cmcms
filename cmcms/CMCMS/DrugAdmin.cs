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
    public partial class DrugAdmin : Form, IDSPSelectedDrugChange
    {
        DrugMgr drugMgr;
        PermissibleValueObj selectedDrug;
       
        public DrugAdmin()
        {
            drugMgr = new DrugMgr();
            InitializeComponent();
            DSP_addSubDrug.setDSPform(this);            
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            textBox_drugName.Clear();
            textBox_minDose.Clear();
            drugMgr.setDosageUnitCombo(comboBox_minDoseUnit);
            textBox_maxDose.Clear();
            drugMgr.setDosageUnitCombo(comboBox_maxDoseUnit);
            drugMgr.setPrimaryDrugTypeCombo(comboBox_pri_type);
            //drugMgr.setSecondaryDrugTypeCombo(comboBox_sec_type, (comboBox_pri_type.SelectedItem as permissibleValueObj).getValue());
            checkBox_q1.Checked = false;
            checkBox_q2.Checked = false;
            checkBox_q3.Checked = false;
            checkBox_q4.Checked = false;
            checkBox_w1.Checked = false;
            checkBox_w2.Checked = false;
            checkBox_w3.Checked = false;
            checkBox_w4.Checked = false;
            checkBox_w5.Checked = false;
            checkBox_w6.Checked = false;
            drugMgr.setContraindicationLevelCombo(comboBox_preg_contra);
            drugMgr.setContraindicationLevelCombo(comboBox_g6pd_contra);
        }

        private void comboBox_pri_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            drugMgr.setSecondaryDrugTypeCombo(comboBox_sec_type, (comboBox_pri_type.SelectedItem as PermissibleValueObj).getValue());
        }

        private void button_addDrug_Click(object sender, EventArgs e)
        {
            String statusMsg = "";
            bool isSuccess;
            isSuccess = drugMgr.insertDrugRecord(textBox_drugName.Text.Trim(), int.Parse(textBox_minDose.Text.Trim()), int.Parse(((PermissibleValueObj)(comboBox_minDoseUnit.SelectedItem)).getValue()), int.Parse(textBox_maxDose.Text.Trim()), int.Parse(((PermissibleValueObj)(comboBox_maxDoseUnit.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(comboBox_pri_type.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(comboBox_sec_type.SelectedItem)).getValue()), checkBox_q1.Checked, checkBox_q2.Checked, checkBox_q3.Checked, checkBox_q4.Checked, checkBox_w1.Checked, checkBox_w2.Checked, checkBox_w3.Checked, checkBox_w4.Checked, checkBox_w5.Checked, checkBox_w6.Checked, int.Parse(((PermissibleValueObj)(comboBox_preg_contra.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(comboBox_g6pd_contra.SelectedItem)).getValue()), ref statusMsg);
            if (isSuccess)
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabPage1_Enter(sender, e);
            }
            else
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            tabPage1_Enter(sender, e);
        }


        public void DSPselectedDrugChanged(PermissibleValueObj drug)
        {
            int selectedTabIdx = tabControl1.SelectedIndex;
            if (selectedTabIdx == 0)
            {
                selectedDrug = drug;
                textBox_selectedDrugName.Text = drug.getName();
            }
        }

    }
}
