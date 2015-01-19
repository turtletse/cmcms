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
        bool showDeletedItemCB = false;
        bool showDeletedItem = false;

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
            {
                listBox_subDrugList.Hide();
                subDrugSelectionEnabled = false;
                subDrugInclNotSpecified = false;
            }
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

        public void setShowDeletedItemCB(bool showDeletedItemCB)
        {
            this.showDeletedItemCB = showDeletedItemCB;
            if (showDeletedItemCB)
            {
                checkBox_showDeletedItem.Show();
            }
            else
            {
                checkBox_showDeletedItem.Hide();
            }
        }

        public void setShowDeletedItem(bool showDeletedItem)
        {
            this.showDeletedItem = showDeletedItem;
            checkBox_showDeletedItem.Checked = showDeletedItem;
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
            drugMgr.setDSPPrimaryDrugTypeListBox(listBox_priDrugType, showDeletedItem?1:0);
            listBox_priDrugType.SelectedIndex = 0;
            listBox_priDrugType.Enabled = true;
        }

        private void listBox_priDrugType_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_secDrugType.Enabled = false;
            drugMgr.setDSPSecondaryDrugTypeListBox(listBox_secDrugType, int.Parse(((PermissibleValueObj)(listBox_priDrugType.SelectedItem)).getValue()), showDeletedItem ? 1 : 0);
            listBox_secDrugType.SelectedIndex = 0;
            listBox_secDrugType.Enabled = true;
        }

        private void listBox_secDrugType_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_nStrokes.Enabled = false;
            drugMgr.setDSPnStrokesListBox(listBox_nStrokes, int.Parse(((PermissibleValueObj)(listBox_priDrugType.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(listBox_secDrugType.SelectedItem)).getValue()), showDeletedItem ? 1 : 0);
            listBox_nStrokes.SelectedIndex = 0;
            listBox_nStrokes.Enabled = true;
        }

        private void listBox_nStrokes_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_length.Enabled = false;
            drugMgr.setDSPLengthListBox(listBox_length, int.Parse(((PermissibleValueObj)(listBox_priDrugType.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(listBox_secDrugType.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(listBox_nStrokes.SelectedItem)).getValue()), showDeletedItem ? 1 : 0);
            listBox_length.SelectedIndex = 0;
            listBox_length.Enabled = true;
        }
        

        private void listBox_length_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_length.Enabled = false;
            drugMgr.setDSP4q5wListBox(checkedListBox_4q5w, int.Parse(((PermissibleValueObj)(listBox_priDrugType.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(listBox_secDrugType.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(listBox_nStrokes.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(listBox_length.SelectedItem)).getValue()), showDeletedItem ? 1 : 0);
            updateDrugList();
            listBox_length.Enabled = true;
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
            if (selected4q5w.Length >= 2)
                selected4q5w = selected4q5w.Substring(0, selected4q5w.Length - 2);
            listBox_drugList.Enabled = false;
            drugMgr.setDSPDrugListBox(listBox_drugList, int.Parse(((PermissibleValueObj)(listBox_priDrugType.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(listBox_secDrugType.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(listBox_nStrokes.SelectedItem)).getValue()), int.Parse(((PermissibleValueObj)(listBox_length.SelectedItem)).getValue()), selected4q5w, showDeletedItem ? 1 : 0);
            listBox_drugList.SelectedIndex = 0;
            listBox_drugList.Enabled = true;
        }

        public DrugObj getSelectedDrug()
        {
            return (DrugObj)listBox_drugList.SelectedItem;
        }

        public PermissibleValueObjWithDelFlag getSelectedSubDrug()
        {
            return (PermissibleValueObjWithDelFlag)listBox_subDrugList.SelectedItem;
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
                drugMgr.setDSPSubDrugListBox(listBox_subDrugList, int.Parse(getSelectedDrug().getValue()), subDrugInclNotSpecified ? 1 : 0, showDeletedItem ? 1 : 0);
                if (subDrugInclNotSpecified)
                    listBox_subDrugList.SelectedIndex = 0;
                else
                    listBox_subDrugList.ClearSelected();
                listBox_subDrugList.Enabled = true;
            }
            
        }

        private void listBox_subDrugList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DSPform != null)
                DSPform.DSPselectedSubDrugChanged(getSelectedSubDrug());
        }

        private void checkBox_showDeletedItem_CheckedChanged(object sender, EventArgs e)
        {
            setShowDeletedItem(checkBox_showDeletedItem.Checked);
            refresh();
        }

    }
}
