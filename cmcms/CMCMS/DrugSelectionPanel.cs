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
    public partial class DrugSelectionPanel : UserControl
    {
        DrugMgr drugMgr = new DrugMgr();
        IDSPSelectedDrugChange DSPform;
        bool subDrugEnabled = false;
        bool subDrugSelectionEnabled = false;
        bool subDrugInclNotSpecified = false;

        public DrugSelectionPanel()
        {
            InitializeComponent();
        }

        public void setDSPform(IDSPSelectedDrugChange DSPform)
        {
            this.DSPform = DSPform;
        }

        public void setSubDrugEnabled(bool subDrugEnabled)
        {
            this.subDrugEnabled = subDrugEnabled;
            if (subDrugEnabled)
                listBox_subDrugList.Show();
            else
                listBox_subDrugList.Hide();
        }

        public void setSubDrugSelectionEnabled(bool subDrugSelectionEnabled)
        {
            this.subDrugSelectionEnabled = subDrugSelectionEnabled;
            if (subDrugSelectionEnabled)
            {
                listBox_subDrugList.SelectionMode = SelectionMode.One;
            }
            else
            {
                listBox_subDrugList.SelectionMode = SelectionMode.None;
            }
        }

        public void setSubDrugInclNotSpecified(bool subDrugInclNotSpecified)
        {
            this.subDrugInclNotSpecified = subDrugInclNotSpecified;
        }

        private void DrugSelectionPanel_VisibleChanged(object sender, System.EventArgs e)
        {
            //MessageBox.Show("LAYOUT", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (this.Visible)
            {
                refresh();
            }
        }

        public void refresh()
        {
            listBox_priDrugType.Enabled = false;
            drugMgr.setDSPPrimaryDrugTypeListBox(listBox_priDrugType);
            listBox_priDrugType.SelectedIndex = 0;
            listBox_priDrugType.Enabled = true;
        }

        private void listBox_priDrugType_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_secDrugType.Enabled = false;
            drugMgr.setDSPSecondaryDrugTypeListBox(listBox_secDrugType, int.Parse(((PermissibleValueObj)(listBox_priDrugType.SelectedItem)).getValue()));
            listBox_secDrugType.SelectedIndex = 0;
            listBox_secDrugType.Enabled = true;
        }

        private void listBox_secDrugType_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_nStrokes.Enabled = false;
            drugMgr.setDSPnStrokesListBox(listBox_nStrokes, int.Parse(((PermissibleValueObj)(listBox_priDrugType.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(listBox_secDrugType.SelectedItem)).getValue()));
            listBox_nStrokes.SelectedIndex = 0;
            listBox_nStrokes.Enabled = true;
        }

        private void listBox_nStrokes_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_length.Enabled = false;
            drugMgr.setDSPLengthListBox(listBox_length, int.Parse(((PermissibleValueObj)(listBox_priDrugType.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(listBox_secDrugType.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(listBox_nStrokes.SelectedItem)).getValue()));
            listBox_length.SelectedIndex = 0;
            listBox_length.Enabled = true;
        }
        

        private void listBox_length_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_length.Enabled = false;
            drugMgr.setDSP4q5wListBox(checkedListBox_4q5w, int.Parse(((PermissibleValueObj)(listBox_priDrugType.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(listBox_secDrugType.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(listBox_nStrokes.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(listBox_length.SelectedItem)).getValue()));
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
                selected4q5w += ((PermissibleValueObj)o).getValue().Trim() + "||";
            }
            if (selected4q5w.Length > 0)
                selected4q5w = selected4q5w.Substring(0, selected4q5w.Length - 2);
            listBox_drugList.Enabled = false;
            drugMgr.setDSPDrugListBox(listBox_drugList, int.Parse(((PermissibleValueObj)(listBox_priDrugType.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(listBox_secDrugType.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(listBox_nStrokes.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(listBox_length.SelectedItem)).getValue()), selected4q5w);
            listBox_drugList.SelectedIndex = 0;
            listBox_drugList.Enabled = true;
        }

        public PermissibleValueObj getSelectedDrug()
        {
            return (PermissibleValueObj)listBox_drugList.SelectedItem;
        }

        public System.Windows.Forms.ListBox getDrugListBox()
        {
            return this.listBox_drugList;
        }

        private void listBox_drugList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DSPform != null)
                DSPform.DSPselectedDrugChanged(getSelectedDrug());
            if (subDrugEnabled)
            {
                listBox_subDrugList.Enabled = false;
                drugMgr.setDSPSubDrugListBox(listBox_subDrugList, int.Parse(getSelectedDrug().getValue()), subDrugInclNotSpecified?1:0);
                listBox_subDrugList.ClearSelected();
                listBox_subDrugList.Enabled = true;
            }
            
        }

        private void listBox_subDrugList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

    }
}
