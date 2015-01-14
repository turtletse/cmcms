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
        public PrescriptionPanel()
        {
            InitializeComponent();
            DSP.setSubDrugEnabled(true);
            DSP.setShowDeletedItemCB(false);
            DSP.setShowDeletedItem(false);
            DSP.setSubDrugInclNotSpecified(true);
            DSP.setSubDrugSelectionEnabled(true);
            DSP.refresh();
        }

        private void button_addFromDSP_Click(object sender, EventArgs e)
        {
            //DGV 0=BUTTON, 1=DRUG_ID, 2=DRUG_NAME, 3=DOSAGE, 4=UNIT
            SubDrugObj subDrug = DSP.getSelectedSubDrug();
            DrugObj drug = DSP.getSelectedDrug();

            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(DGV_selected);

            if (subDrug == null || subDrug.getValue().Split(new String[] { "||" }, StringSplitOptions.None)[1] == "0")
            {
                DrugMgr drugMgr = new DrugMgr();
                row.Cells[1].Value = drug.getValue();
                row.Cells[2].Value = drug.getName();
                List<PermissibleValueObj> units = drugMgr.getPermissibleUnitForDrug(drug.getValue());
                foreach(PermissibleValueObj o in units)
                    ((DataGridViewComboBoxCell)row.Cells[4]).Items.Add(o);
            }
            else
            {
                row.Cells[1].Value = subDrug.getValue();
                row.Cells[2].Value = subDrug.getName();
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
    }
}
