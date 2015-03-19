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
        DrugObj selectedDrug;
        PermissibleValueObjWithDelFlag selectedSubDrug;
       
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

            DSP_incompatibleWith.setDSPform(this);
            DSP_incompatibleWith.setSubDrugEnabled(false);
            DSP_incompatibleWith.setSubDrugSelectionEnabled(false);
            DSP_incompatibleWith.setSubDrugInclNotSpecified(false);
            DSP_incompatibleWith.setShowDeletedItemCB(false);
            DSP_incompatibleWith.setShowDeletedItem(false);
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
            textBox_addDrug_subDrugName.Clear();
            DSP_addSubDrug.refresh();
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            textBox_amdDrug_drugName.Clear();
            textBox_amdDrug_minDoseVal.Clear();
            drugMgr.setDosageUnitCombo(comboBox_amdDrug_minDoseUnit);
            comboBox_amdDrug_minDoseUnit.SelectedIndex = 0;
            textBox_amdDrug_maxDoseVal.Clear();
            drugMgr.setDosageUnitCombo(comboBox_amdDrug_maxDoseUnit);
            comboBox_amdDrug_maxDoseUnit.SelectedIndex = 0;
            drugMgr.setPrimaryDrugTypeCombo(comboBox_amdDrug_pri_type);
            comboBox_amdDrug_pri_type.SelectedIndex = 0;
            checkBox_amdDrug_q1.Checked = false;
            checkBox_amdDrug_q2.Checked = false;
            checkBox_amdDrug_q3.Checked = false;
            checkBox_amdDrug_q4.Checked = false;
            checkBox_amdDrug_w1.Checked = false;
            checkBox_amdDrug_w2.Checked = false;
            checkBox_amdDrug_w3.Checked = false;
            checkBox_amdDrug_w4.Checked = false;
            checkBox_amdDrug_w5.Checked = false;
            checkBox_amdDrug_w6.Checked = false;
            drugMgr.setContraindicationLevelCombo(comboBox_amdDrug_preg_contra);
            comboBox_amdDrug_preg_contra.SelectedIndex = 0;
            drugMgr.setContraindicationLevelCombo(comboBox_amdDrug_g6pd_contra);
            comboBox_amdDrug_g6pd_contra.SelectedIndex = 0;
            textBox_amdDrug_subDrugName.Clear();
            checkBox_amdDrug_deleteItem.Checked = false;
            DSP_amdDrug.refresh();
            
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            textBox_incompatible_drugName.Clear();
            DSP_incompatibleWith.refresh();
            listBox_selectedIncompatibleDrug.Items.Clear();
            selectedDrug = null;
        }

        private void comboBox_pri_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            drugMgr.setSecondaryDrugTypeCombo(comboBox_addDrug_sec_type, (comboBox_addDrug_pri_type.SelectedItem as PermissibleValueObj).getValue());
            comboBox_addDrug_sec_type.SelectedIndex = 0;
        }

        private void button_addDrug_Click(object sender, EventArgs e)
        {
            if (input_validation_add_drug())
            {
                String statusMsg = "";
                bool isSuccess;
                isSuccess = drugMgr.insertDrugRecord(textBox_addDrug_drugName.Text.Trim(), decimal.Parse(textBox_addDrug_minDose.Text.Trim()), int.Parse(((PermissibleValueObj)(comboBox_addDrug_minDoseUnit.SelectedItem)).getValue()), decimal.Parse(textBox_addDrug_maxDose.Text.Trim()), int.Parse(((PermissibleValueObj)(comboBox_addDrug_maxDoseUnit.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(comboBox_addDrug_pri_type.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(comboBox_addDrug_sec_type.SelectedItem)).getValue()), checkBox_addDrug_q1.Checked, checkBox_addDrug_q2.Checked, checkBox_addDrug_q3.Checked, checkBox_addDrug_q4.Checked, checkBox_addDrug_w1.Checked, checkBox_addDrug_w2.Checked, checkBox_addDrug_w3.Checked, checkBox_addDrug_w4.Checked, checkBox_addDrug_w5.Checked, checkBox_addDrug_w6.Checked, int.Parse(((PermissibleValueObj)(comboBox_addDrug_preg_contra.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(comboBox_addDrug_g6pd_contra.SelectedItem)).getValue()), ref statusMsg);
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
        }

        private bool input_validation_add_drug()
        {
            if (textBox_addDrug_drugName.Text.Length == 0)
            {
                MessageBox.Show("請輸入藥名", "藥名錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_addDrug_drugName.Focus();
                return false;
            }

            if (textBox_addDrug_minDose.Text.Length == 0)
            {
                MessageBox.Show("請輸入劑量下限", "劑量下限錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_addDrug_minDose.Focus();
                return false;
            }
            if (!Utilities.isDecimal(textBox_addDrug_minDose.Text))
            {
                MessageBox.Show("劑量下限只限數值\n有效範圍[0.0000 - 9999.9999]", "劑量下限錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_addDrug_minDose.Focus();
                return false;
            }

            if (textBox_addDrug_maxDose.Text.Length == 0)
            {
                MessageBox.Show("請輸入劑量上限", "劑量上限錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_addDrug_maxDose.Focus();
                return false;
            }
            if (!Utilities.isDecimal(textBox_addDrug_maxDose.Text))
            {
                MessageBox.Show("劑量上限只限數值\n有效範圍[0.0000 - 9999.9999]", "劑量上限錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_addDrug_maxDose.Focus();
                return false;
            }
            

            return true;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            tabPage1_Enter(sender, e);
        }


        public void DSPselectedDrugChanged(DrugObj drug)
        {
            int selectedTabIdx = tabControl1.SelectedIndex;
            selectedDrug = drug;
            selectedSubDrug = null;
            if (selectedTabIdx == 0)
            {
                textBox_addDrug_selectedDrugName.Text = drug.getName();
                textBox_addDrug_selectedDrugName.ReadOnly = true;
            }
            else if (selectedTabIdx == 1)
            {
                textBox_amdDrug_drugName.ReadOnly = false;
                textBox_amdDrug_subDrugName.ReadOnly = true;
                textBox_amdDrug_minDoseVal.ReadOnly = false;
                comboBox_amdDrug_minDoseUnit.Enabled = true;
                textBox_amdDrug_maxDoseVal.ReadOnly = false;
                comboBox_amdDrug_maxDoseUnit.Enabled = true;
                comboBox_amdDrug_pri_type.Enabled = true;
                comboBox_amdDrug_sec_type.Enabled = true;
                groupBox_amdDrug4q5w.Enabled = true;
                groupBox_amdDrug_contraindication.Enabled = true;
                textBox_amdDrug_drugName.Text = drug.getName();
                textBox_amdDrug_subDrugName.Clear();
                textBox_amdDrug_minDoseVal.Text = drug.MinDoseVal.ToString();
                Utilities.SelectItemByValue(comboBox_amdDrug_minDoseUnit, drug.MinDoseUnit.ToString());
                textBox_amdDrug_maxDoseVal.Text = drug.MaxDoseVal.ToString();
                Utilities.SelectItemByValue(comboBox_amdDrug_maxDoseUnit, drug.MaxDoseUnit.ToString());
                Utilities.SelectItemByValue(comboBox_amdDrug_pri_type, drug.PriType.ToString());
                Utilities.SelectItemByValue(comboBox_amdDrug_sec_type, drug.SecType.ToString());
                checkBox_amdDrug_q1.Checked = drug.Q1;
                checkBox_amdDrug_q2.Checked = drug.Q2;
                checkBox_amdDrug_q3.Checked = drug.Q3;
                checkBox_amdDrug_q4.Checked = drug.Q4;
                checkBox_amdDrug_w1.Checked = drug.W1;
                checkBox_amdDrug_w2.Checked = drug.W2;
                checkBox_amdDrug_w3.Checked = drug.W3;
                checkBox_amdDrug_w4.Checked = drug.W4;
                checkBox_amdDrug_w5.Checked = drug.W5;
                checkBox_amdDrug_w6.Checked = drug.W6;
                Utilities.SelectItemByValue(comboBox_amdDrug_preg_contra, drug.PregContra.ToString());
                Utilities.SelectItemByValue(comboBox_amdDrug_g6pd_contra, drug.G6pdContra.ToString());
                checkBox_amdDrug_deleteItem.Checked = drug.Deleted;

            }
        }

        public void setSelectedDrug(DrugObj drug)
        {
            selectedDrug = drug;
        }

        public void DSPselectedSubDrugChanged(PermissibleValueObjWithDelFlag subDrug)
        {
            int selectedTabIdx = tabControl1.SelectedIndex;
            selectedSubDrug = subDrug;
            if (selectedTabIdx == 1)
            {
                textBox_amdDrug_subDrugName.Text = subDrug.getName();
                if (textBox_amdDrug_subDrugName.Text.Length > 0 && textBox_amdDrug_subDrugName.Text != "-")
                {
                    textBox_amdDrug_drugName.ReadOnly = true;
                    textBox_amdDrug_subDrugName.ReadOnly = false;
                    textBox_amdDrug_minDoseVal.ReadOnly = true;
                    comboBox_amdDrug_minDoseUnit.Enabled = false;
                    textBox_amdDrug_maxDoseVal.ReadOnly = true;
                    comboBox_amdDrug_maxDoseUnit.Enabled = false;
                    comboBox_amdDrug_pri_type.Enabled = false;
                    comboBox_amdDrug_sec_type.Enabled = false;
                    groupBox_amdDrug4q5w.Enabled = false;
                    groupBox_amdDrug_contraindication.Enabled = false;

                }
                else
                {
                    textBox_amdDrug_drugName.ReadOnly = false;
                    textBox_amdDrug_subDrugName.ReadOnly = true;
                    textBox_amdDrug_minDoseVal.ReadOnly = false;
                    comboBox_amdDrug_minDoseUnit.Enabled = true;
                    textBox_amdDrug_maxDoseVal.ReadOnly = false;
                    comboBox_amdDrug_maxDoseUnit.Enabled = true;
                    comboBox_amdDrug_pri_type.Enabled = true;
                    comboBox_amdDrug_sec_type.Enabled = true;
                    groupBox_amdDrug4q5w.Enabled = true;
                    groupBox_amdDrug_contraindication.Enabled = true;
                }
                if (selectedSubDrug!=null && selectedSubDrug.getValue().Split(new String[] { "||" }, System.StringSplitOptions.None)[1].Equals("0"))
                    checkBox_amdDrug_deleteItem.Checked = selectedDrug.Deleted;
                else
                    checkBox_amdDrug_deleteItem.Checked = subDrug.Deleted;
            }
        }

        private void button_addSubDrug_Click(object sender, EventArgs e)
        {
            if (input_validation_add_sub_drug())
            {
                String statusMsg = "";
                bool isSuccess;
                isSuccess = drugMgr.insertSubDrugRecord(int.Parse(selectedDrug.getValue()), textBox_addDrug_subDrugName.Text.Trim(), ref statusMsg);
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

        private bool input_validation_add_sub_drug()
        {
            if (selectedDrug == null)
            {
                MessageBox.Show("請選擇藥項", "藥項錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBox_addDrug_subDrugName.Text.Length == 0)
            {
                MessageBox.Show("請輸入子藥項名稱", "子藥項名稱錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_addDrug_subDrugName.Focus();
                return false;
            }

            return true;
        }

        private void button_cancelAmdDrug_Click(object sender, EventArgs e)
        {
            tabPage2_Enter(sender, e);
        }

        private void button_amdDrug_Click(object sender, EventArgs e)
        {
            if (input_validation_amdDrug())
            {
                String statusMsg = "";
                bool isSuccess;
                if (selectedSubDrug == null || selectedSubDrug.getValue().Split(new String[] { "||" }, System.StringSplitOptions.None)[1].Equals("0"))
                {
                    isSuccess = drugMgr.updateDrugRecord(selectedDrug.getValue(), textBox_amdDrug_drugName.Text.Trim(), decimal.Parse(textBox_amdDrug_minDoseVal.Text.Trim()), int.Parse(((PermissibleValueObj)(comboBox_amdDrug_minDoseUnit.SelectedItem)).getValue()), decimal.Parse(textBox_amdDrug_maxDoseVal.Text.Trim()), int.Parse(((PermissibleValueObj)(comboBox_amdDrug_maxDoseUnit.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(comboBox_amdDrug_pri_type.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(comboBox_amdDrug_sec_type.SelectedItem)).getValue()), checkBox_amdDrug_q1.Checked, checkBox_amdDrug_q2.Checked, checkBox_amdDrug_q3.Checked, checkBox_amdDrug_q4.Checked, checkBox_amdDrug_w1.Checked, checkBox_amdDrug_w2.Checked, checkBox_amdDrug_w3.Checked, checkBox_amdDrug_w4.Checked, checkBox_amdDrug_w5.Checked, checkBox_amdDrug_w6.Checked, int.Parse(((PermissibleValueObj)(comboBox_amdDrug_preg_contra.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(comboBox_amdDrug_g6pd_contra.SelectedItem)).getValue()), checkBox_amdDrug_deleteItem.Checked, ref statusMsg);
                    if (isSuccess)
                    {
                        MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tabPage2_Enter(sender, e);
                    }
                    else
                    {
                        MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (selectedSubDrug.getValue().Split(new String[] { "||" }, System.StringSplitOptions.None)[1].Equals("0") == false)
                {
                    isSuccess = drugMgr.updateSubDrugRecord(selectedSubDrug.getValue(), textBox_amdDrug_subDrugName.Text.Trim(), checkBox_amdDrug_deleteItem.Checked, ref statusMsg);
                    if (isSuccess)
                    {
                        MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tabPage2_Enter(sender, e);
                    }
                    else
                    {
                        MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool input_validation_amdDrug()
        {
            if (textBox_amdDrug_drugName.Text.Length == 0)
            {
                MessageBox.Show("請輸入藥名", "藥名錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_amdDrug_drugName.Focus();
                return false;
            }

            if (selectedSubDrug.getValue().Split(new String[] { "||" }, System.StringSplitOptions.None)[1].Equals("0") == false && textBox_amdDrug_subDrugName.Text.Length == 0)
            {
                MessageBox.Show("請輸入子藥項名稱", "子藥項名稱錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_amdDrug_subDrugName.Focus();
                return false;
            }

            return true;
        }

        private void comboBox_amdDrug_pri_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            drugMgr.setSecondaryDrugTypeCombo(comboBox_amdDrug_sec_type, (comboBox_amdDrug_pri_type.SelectedItem as PermissibleValueObj).getValue());
            comboBox_amdDrug_sec_type.SelectedIndex = 0;
        }

        private void button_selectIncompatibleDrug_Click(object sender, EventArgs e)
        {
            PermissibleValueObj DSPselectedDrug = DSP_incompatibleWith.getSelectedDrug();
            if (DSPselectedDrug != null)
            {
                if (DSPselectedDrug.Value == selectedDrug.Value)
                {
                    MessageBox.Show("同一藥物必能配伍", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                foreach (PermissibleValueObj drug in listBox_selectedIncompatibleDrug.Items)
                {
                    if (DSPselectedDrug.Value == drug.Value)
                    {
                        MessageBox.Show("此項目已被選擇", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                listBox_selectedIncompatibleDrug.Items.Add(DSPselectedDrug);
                //DSP_allergic.refresh();
            }
        }

        private void button_removeIncompatibleDrug_Click(object sender, EventArgs e)
        {
            if (listBox_selectedIncompatibleDrug.SelectedItems.Count > 0)
                listBox_selectedIncompatibleDrug.Items.Remove((listBox_selectedIncompatibleDrug.SelectedItems[0]));
        }

        private void button_Incompatible_drug_select_Click(object sender, EventArgs e)
        {
            DrugIncompatibleSelection DIS = new DrugIncompatibleSelection();
            DIS.setParentForm(this);
            DIS.ShowDialog();
            if (selectedDrug != null)
            {
                textBox_incompatible_drugName.Text = selectedDrug.Name;
                drugMgr.setSelectedIncompatibleListbox(listBox_selectedIncompatibleDrug, int.Parse(selectedDrug.Value));
            }
        }

        private void button_cancelIncompatible_Click(object sender, EventArgs e)
        {
            tabPage3_Enter(sender, e);
        }

        private void button_updateIncompatible_Click(object sender, EventArgs e)
        {
            String incompatibleWith = "";
            foreach (PermissibleValueObj o in listBox_selectedIncompatibleDrug.Items)
            {
                incompatibleWith += "||" + o.Value;
            }
            if (incompatibleWith.Length>0)
                incompatibleWith = incompatibleWith.Substring(2);

            String statusMsg = "";
            bool isSuccess;
            isSuccess = drugMgr.updateIncompatibleDrug(int.Parse(selectedDrug.Value), incompatibleWith, ref statusMsg);
            if (isSuccess)
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                drugMgr.setSelectedIncompatibleListbox(listBox_selectedIncompatibleDrug, int.Parse(selectedDrug.Value));
            }
            else
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox_addDrug_subDrugName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                button_addSubDrug_Click(sender, e);
            }
        }

    }
}
