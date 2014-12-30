﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMCMS
{
    public partial class DrugSelectionPanel : UserControl
    {
        DrugMgr drugMgr = new DrugMgr();

        public DrugSelectionPanel()
        {
            InitializeComponent();
        }

        private void DrugSelectionPanel_VisibleChanged(object sender, System.EventArgs e)
        {
            //MessageBox.Show("LAYOUT", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (this.Visible)
            {
                listBox_priDrugType.Enabled = false;
                drugMgr.setDSPPrimaryDrugTypeListBox(listBox_priDrugType);
                listBox_priDrugType.Enabled = true;
            }
        }

        private void listBox_priDrugType_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_secDrugType.Enabled = false;
            drugMgr.setDSPSecondaryDrugTypeListBox(listBox_secDrugType, int.Parse(((permissibleValueObj)(listBox_priDrugType.SelectedItem)).getValue()));
            listBox_secDrugType.Enabled = true;
        }

        private void listBox_secDrugType_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_nStrokes.Enabled = false;
            drugMgr.setDSPnStrokesListBox(listBox_nStrokes, int.Parse(((permissibleValueObj)(listBox_priDrugType.SelectedItem)).getValue()), int.Parse(((permissibleValueObj)(listBox_secDrugType.SelectedItem)).getValue()));
            listBox_nStrokes.Enabled = true;
        }

        private void listBox_nStrokes_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_length.Enabled = false;
            drugMgr.setDSPLengthListBox(listBox_length, int.Parse(((permissibleValueObj)(listBox_priDrugType.SelectedItem)).getValue()), int.Parse(((permissibleValueObj)(listBox_secDrugType.SelectedItem)).getValue()), int.Parse(((permissibleValueObj)(listBox_nStrokes.SelectedItem)).getValue()));
            listBox_length.Enabled = true;
        }
        

        private void listBox_length_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_length.Enabled = false;
            drugMgr.setDSP4q5wListBox(checkedListBox_4q5w, int.Parse(((permissibleValueObj)(listBox_priDrugType.SelectedItem)).getValue()), int.Parse(((permissibleValueObj)(listBox_secDrugType.SelectedItem)).getValue()), int.Parse(((permissibleValueObj)(listBox_nStrokes.SelectedItem)).getValue()), int.Parse(((permissibleValueObj)(listBox_length.SelectedItem)).getValue()));
            listBox_length.Enabled = true;
            updateDrugList();
        }

        private void checkedListBox_4q5w_SelectedValueChanged(object sender, EventArgs e)
        {
            updateDrugList();
        }

        private void updateDrugList()
        {
            String selected4q5w = "";
            foreach (Object o in checkedListBox_4q5w.CheckedItems)
            {
                selected4q5w += ((permissibleValueObj)o).getValue().Trim() + "||";
            }
            if (selected4q5w.Length > 0)
                selected4q5w = selected4q5w.Substring(0, selected4q5w.Length - 2);
            listBox_drugList.Enabled = false;
            drugMgr.setDSPDrugListBox(listBox_drugList, int.Parse(((permissibleValueObj)(listBox_priDrugType.SelectedItem)).getValue()), int.Parse(((permissibleValueObj)(listBox_secDrugType.SelectedItem)).getValue()), int.Parse(((permissibleValueObj)(listBox_nStrokes.SelectedItem)).getValue()), int.Parse(((permissibleValueObj)(listBox_length.SelectedItem)).getValue()), selected4q5w);
            listBox_drugList.Enabled = true;
        }

    }
}
