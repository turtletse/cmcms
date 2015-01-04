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
            DSP_addSubDrug.setSubDrugEnabled(true);
            DSP_addSubDrug.setSubDrugSelectionEnabled(false);
            DSP_addSubDrug.setSubDrugInclNotSpecified(false);
            DSP_addSubDrug.setShowDeletedItemCB(false);
            DSP_addSubDrug.setShowDeletedItem(false);

            DSP_amdDrug.setDSPform(this);
            DSP_amdDrug.setSubDrugEnabled(true);
            DSP_amdDrug.setSubDrugSelectionEnabled(true);
            DSP_amdDrug.setSubDrugInclNotSpecified(true);
            DSP_amdDrug.setShowDeletedItemCB(true);
            DSP_amdDrug.setShowDeletedItem(false);
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            textBox_addDrug_drugName.Clear();
            textBox_addDrug_minDose.Clear();
            drugMgr.setDosageUnitCombo(comboBox_addDrug_minDoseUnit);
            comboBox_addDrug_minDoseUnit.SelectedIndex = 0;
            textBox_addDrug_maxDose.Clear();
            drugMgr.setDosageUnitCombo(comboBox_addDrug_maxDoseUnit);
            comboBox_addDrug_maxDoseUnit.SelectedIndex = 0;
            drugMgr.setPrimaryDrugTypeCombo(comboBox_addDrug_pri_type);
            comboBox_addDrug_pri_type.SelectedIndex = 0;
            checkBox_addDrug_q1.Checked = false;
            checkBox_addDrug_q2.Checked = false;
            checkBox_addDrug_q3.Checked = false;
            checkBox_addDrug_q4.Checked = false;
            checkBox_addDrug_w1.Checked = false;
            checkBox_addDrug_w2.Checked = false;
            checkBox_addDrug_w3.Checked = false;
            checkBox_addDrug_w4.Checked = false;
            checkBox_addDrug_w5.Checked = false;
            checkBox_addDrug_w6.Checked = false;
            drugMgr.setContraindicationLevelCombo(comboBox_addDrug_preg_contra);
            comboBox_addDrug_preg_contra.SelectedIndex = 0;
            drugMgr.setContraindicationLevelCombo(comboBox_addDrug_g6pd_contra);
            comboBox_addDrug_g6pd_contra.SelectedIndex = 0;
            DSP_addSubDrug.refresh();
            textBox_addDrug_subDrugName.Clear();
        }

        private void comboBox_pri_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            drugMgr.setSecondaryDrugTypeCombo(comboBox_addDrug_sec_type, (comboBox_addDrug_pri_type.SelectedItem as PermissibleValueObj).getValue());
            comboBox_addDrug_sec_type.SelectedIndex = 0;
        }

        private void button_addDrug_Click(object sender, EventArgs e)
        {
            String statusMsg = "";
            bool isSuccess;
            isSuccess = drugMgr.insertDrugRecord(textBox_addDrug_drugName.Text.Trim(), int.Parse(textBox_addDrug_minDose.Text.Trim()), int.Parse(((PermissibleValueObj)(comboBox_addDrug_minDoseUnit.SelectedItem)).getValue()), int.Parse(textBox_addDrug_maxDose.Text.Trim()), int.Parse(((PermissibleValueObj)(comboBox_addDrug_maxDoseUnit.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(comboBox_addDrug_pri_type.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(comboBox_addDrug_sec_type.SelectedItem)).getValue()), checkBox_addDrug_q1.Checked, checkBox_addDrug_q2.Checked, checkBox_addDrug_q3.Checked, checkBox_addDrug_q4.Checked, checkBox_addDrug_w1.Checked, checkBox_addDrug_w2.Checked, checkBox_addDrug_w3.Checked, checkBox_addDrug_w4.Checked, checkBox_addDrug_w5.Checked, checkBox_addDrug_w6.Checked, int.Parse(((PermissibleValueObj)(comboBox_addDrug_preg_contra.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(comboBox_addDrug_g6pd_contra.SelectedItem)).getValue()), ref statusMsg);
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
            selectedDrug = drug;
            if (selectedTabIdx == 0)
            {
                textBox_addDrug_selectedDrugName.Text = drug.getName();
            }
            else if (selectedTabIdx == 1)
            {
                
            }
        }

        private void button_addSubDrug_Click(object sender, EventArgs e)
        {
            String statusMsg = "";
            bool isSuccess;
            isSuccess = drugMgr.insertSubDrugRecord(int.Parse(selectedDrug.getValue()),textBox_addDrug_subDrugName.Text.Trim(), ref statusMsg);
            if (isSuccess)
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DSP_addSubDrug.refresh();
                textBox_addDrug_subDrugName.Clear();
            }
            else
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
