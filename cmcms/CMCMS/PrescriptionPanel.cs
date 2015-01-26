using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMCMS
{
    public partial class PrescriptionPanel : UserControl
    {
        Dictionary<String, String> units;
        Dictionary<String, String> methods;
        bool isInclDeletedPredefPres = false;
        DrugMgr drugMgr = new DrugMgr();
        public PrescriptionPanel()
        {
            InitializeComponent();
            DSP.setSubDrugEnabled(true);
            DSP.setShowDeletedItemCB(false);
            DSP.setShowDeletedItem(false);
            DSP.setSubDrugInclNotSpecified(true);
            DSP.setSubDrugSelectionEnabled(true);
            DSP.refresh();
            units = drugMgr.getDosageUnitForDrug();
            methods = drugMgr.getPrepMethod();
            drugMgr.setPredefPresCB(comboBox_existingPredefPres, isInclDeletedPredefPres);
            if (comboBox_existingPredefPres.Items.Count > 0)
                comboBox_existingPredefPres.SelectedIndex = 0;
        }

        public void setIsInclDeletedPredefPres(bool isInclDeletedPredefPres){
            if (this.isInclDeletedPredefPres != isInclDeletedPredefPres)
            {
                drugMgr.setPredefPresCB(comboBox_existingPredefPres, isInclDeletedPredefPres);
                if (comboBox_existingPredefPres.Items.Count > 0)
                    comboBox_existingPredefPres.SelectedIndex = 0;
                this.isInclDeletedPredefPres = isInclDeletedPredefPres;
            }
        }

        public void reset()
        {
            DSP.refresh();
            textBox_drugInput.Clear();
            DGV_selected.Rows.Clear();
            drugMgr.setPredefPresCB(comboBox_existingPredefPres, isInclDeletedPredefPres);
            if (comboBox_existingPredefPres.Items.Count > 0)
                comboBox_existingPredefPres.SelectedIndex = 0;
        }

        private void button_addFromDSP_Click(object sender, EventArgs e)
        {
            //DGV 0=BUTTON, 1=DRUG_ID, 2=DRUG_NAME, 3=DOSAGE, 4=UNIT
            PermissibleValueObjWithDelFlag subDrug = DSP.getSelectedSubDrug();
            DrugObj drug = DSP.getSelectedDrug();

            if (subDrug == null || subDrug.getValue().Split(new String[] { "||" }, StringSplitOptions.None)[1] == "0")
            {
                addDrugToDGV(drug);
            }
            else
            {
                addDrugToDGV(subDrug);
            }
            
        }

        private void addDrugToDGV(PermissibleValueObj drug)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(DGV_selected);
            /*foreach (DataGridViewRow r in DGV_selected.Rows)
            {
                if (((String)r.Cells[1].Value) == drug.getValue())
                {
                    MessageBox.Show("此藥已在藥單上", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }*/
            if (isExistInDGV_selected(drug.getValue(), drug.getName()))
                return;
            row.Cells[1].Value = drug.getValue();
            row.Cells[2].Value = drug.getName();
            List<PermissibleValueObj> units = drugMgr.getPermissibleUnitForDrug(drug.getValue().Split(new String[] { "||" }, StringSplitOptions.None)[0]);
            foreach (PermissibleValueObj o in units)
                ((DataGridViewComboBoxCell)row.Cells[4]).Items.Add(o.getName());
            if (((DataGridViewComboBoxCell)row.Cells[4]) != null)
            {
                ((DataGridViewComboBoxCell)row.Cells[4]).Value = ((DataGridViewComboBoxCell)row.Cells[4]).Items[0];
            }

            List<String> methodDesc = methods.Keys.ToList();
            foreach (String m in methodDesc)
                ((DataGridViewComboBoxCell)row.Cells[5]).Items.Add(m);
            if (((DataGridViewComboBoxCell)row.Cells[5]) != null)
            {
                ((DataGridViewComboBoxCell)row.Cells[5]).Value = ((DataGridViewComboBoxCell)row.Cells[5]).Items[(((DataGridViewComboBoxCell)row.Cells[5]).Items.Count>1?1:0)];
            }

            DGV_selected.Rows.Add(row);
        }

        private void DGV_selected_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGV_selected.Columns[0].Index)
            {
                DGV_selected.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            DGV_selected.Rows.Clear();
        }

        public String getPrescriptionDataString()
        {
            //FORMAT: drugId||subDrugId^^dosage^^unit^^method##
            String prescription = "";
            foreach (DataGridViewRow row in DGV_selected.Rows)
            {
                prescription += "##" + row.Cells[1].Value + "^^" + row.Cells[3].Value + "^^" + units[((DataGridViewComboBoxCell)row.Cells[4]).EditedFormattedValue.ToString()] + "^^" + methods[((DataGridViewComboBoxCell)row.Cells[5]).EditedFormattedValue.ToString()];
            }
            return prescription.Substring(2);
        }

        public String getConsultationPrescriptionDataString()
        {
            //FORMAT: drugId||subDrugId^^drug_name^^dosage^^unit^^method##
            String prescription = "";
            foreach (DataGridViewRow row in DGV_selected.Rows)
            {
                prescription += "##" + row.Cells[1].Value + "^^" + row.Cells[2].Value + "^^" + row.Cells[3].Value + "^^" + units[((DataGridViewComboBoxCell)row.Cells[4]).EditedFormattedValue.ToString()] + "^^" + methods[((DataGridViewComboBoxCell)row.Cells[5]).EditedFormattedValue.ToString()];
            }
            return prescription.Substring(2);
        }

        private void button_addFromFreeText_Click(object sender, EventArgs e)
        {
            String notFoundDrugs = "";
            List<PermissibleValueObj> drugs = drugMgr.getDrugIdByNames(textBox_drugInput.Text.Trim().Replace(" ", "").Replace("，", ",").Replace("　",""), ref notFoundDrugs);
            foreach (PermissibleValueObj o in drugs)
            {
                addDrugToDGV(o);
            }
            if (notFoundDrugs.Length > 0)
            {
                MessageBox.Show("以下藥物名稱不存在:\n" + notFoundDrugs, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            textBox_drugInput.Text = notFoundDrugs;
        }

        private bool isExistInDGV_selected(String drugId, String drugName)
        {
            foreach (DataGridViewRow r in DGV_selected.Rows)
            {
                if (((String)r.Cells[1].Value) == drugId)
                {
                    MessageBox.Show("此藥已在藥單上: " + drugName, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            return false;
        }

        private void button_addFromExistingPres_Click(object sender, EventArgs e)
        {
            List<List<String>> pres = drugMgr.getPredefPrescriptionById(int.Parse(((PermissibleValueObj)(comboBox_existingPredefPres.SelectedItem)).getValue()));
            foreach (List<String> drugRow in pres)
            {
                if (isExistInDGV_selected(drugRow[0], drugRow[1]))
                    continue;
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(DGV_selected);

                row.Cells[1].Value = drugRow[0];
                row.Cells[2].Value = drugRow[1];
                row.Cells[3].Value = drugRow[2];
                List<PermissibleValueObj> units = drugMgr.getPermissibleUnitForDrug(drugRow[0].Split(new String[] { "||" }, StringSplitOptions.None)[0]);
                foreach (PermissibleValueObj o in units)
                    ((DataGridViewComboBoxCell)row.Cells[4]).Items.Add(o.getName());
                if (((DataGridViewComboBoxCell)row.Cells[4]) != null)
                {
                    ((DataGridViewComboBoxCell)row.Cells[4]).Value = ((DataGridViewComboBoxCell)row.Cells[4]).Items[((DataGridViewComboBoxCell)row.Cells[4]).Items.IndexOf(drugRow[3])];
                }

                List<String> methodDesc = methods.Keys.ToList();
                foreach (String m in methodDesc)
                    ((DataGridViewComboBoxCell)row.Cells[5]).Items.Add(m);
                if (((DataGridViewComboBoxCell)row.Cells[5]) != null)
                {
                    ((DataGridViewComboBoxCell)row.Cells[5]).Value = ((DataGridViewComboBoxCell)row.Cells[5]).Items[((DataGridViewComboBoxCell)row.Cells[5]).Items.IndexOf(drugRow[4])];
                }

                DGV_selected.Rows.Add(row);
            }
        }

        public void setPredefPres(int predefPresId)
        {
            DGV_selected.Rows.Clear();
            List<List<String>> pres = drugMgr.getPredefPrescriptionById(predefPresId);
            foreach (List<String> drugRow in pres)
            {
                if (isExistInDGV_selected(drugRow[0], drugRow[1]))
                    continue;
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(DGV_selected);

                row.Cells[1].Value = drugRow[0];
                row.Cells[2].Value = drugRow[1];
                row.Cells[3].Value = drugRow[2];
                List<PermissibleValueObj> units = drugMgr.getPermissibleUnitForDrug(drugRow[0].Split(new String[] { "||" }, StringSplitOptions.None)[0]);
                foreach (PermissibleValueObj o in units)
                    ((DataGridViewComboBoxCell)row.Cells[4]).Items.Add(o.getName());
                if (((DataGridViewComboBoxCell)row.Cells[4]) != null)
                {
                    ((DataGridViewComboBoxCell)row.Cells[4]).Value = ((DataGridViewComboBoxCell)row.Cells[4]).Items[((DataGridViewComboBoxCell)row.Cells[4]).Items.IndexOf(drugRow[3])];
                }

                List<String> methodDesc = methods.Keys.ToList();
                foreach (String m in methodDesc)
                    ((DataGridViewComboBoxCell)row.Cells[5]).Items.Add(m);
                if (((DataGridViewComboBoxCell)row.Cells[5]) != null)
                {
                    ((DataGridViewComboBoxCell)row.Cells[5]).Value = ((DataGridViewComboBoxCell)row.Cells[5]).Items[((DataGridViewComboBoxCell)row.Cells[5]).Items.IndexOf(drugRow[4])];
                }

                DGV_selected.Rows.Add(row);
            }
        }
    }
}
