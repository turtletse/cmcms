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
        }

        private void button_addFromDSP_Click(object sender, EventArgs e)
        {
            //DGV 0=BUTTON, 1=DRUG_ID, 2=DRUG_NAME, 3=DOSAGE, 4=UNIT
            SubDrugObj subDrug = DSP.getSelectedSubDrug();
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
            foreach (DataGridViewRow r in DGV_selected.Rows)
            {
                if (((String)r.Cells[1].Value) == drug.getValue())
                {
                    MessageBox.Show("此藥已在藥單上", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            row.Cells[1].Value = drug.getValue();
            row.Cells[2].Value = drug.getName();
            List<PermissibleValueObj> units = drugMgr.getPermissibleUnitForDrug(drug.getValue().Split(new String[] { "||" }, StringSplitOptions.None)[0]);
            foreach (PermissibleValueObj o in units)
                ((DataGridViewComboBoxCell)row.Cells[4]).Items.Add(o.getName());
            if (((DataGridViewComboBoxCell)row.Cells[4]) != null)
            {
                ((DataGridViewComboBoxCell)row.Cells[4]).Value = ((DataGridViewComboBoxCell)row.Cells[4]).Items[0];
            }

            DGV_selected.Rows.Add(row);
        }

        private void DGV_selected_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGV_selected.Columns[0].Index)
            {
                DGV_selected.Rows.RemoveAt(e.ColumnIndex);
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            DGV_selected.Rows.Clear();
        }

        public String getPrescriptionDataString()
        {
            //FORMAT: drugId||subDrugId^^dosage^^unit##
            String prescription = "";
            foreach (DataGridViewRow row in DGV_selected.Rows)
            {
                prescription += "##" + row.Cells[1].Value + "^^" + row.Cells[3].Value + "^^" + units[((DataGridViewComboBoxCell)row.Cells[4]).EditedFormattedValue.ToString()];
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
    }
}
