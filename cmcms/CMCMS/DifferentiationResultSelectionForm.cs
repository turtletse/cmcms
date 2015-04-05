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
    public partial class DifferentiationResultSelectionForm : Form
    {
        ConsultationMgr consMgr = new ConsultationMgr();
        List<PermissibleValueObj> selectedDiffResult = null;

        public DifferentiationResultSelectionForm()
        {
            InitializeComponent();
        }

        public void setSelectedDiffResult(ref List<PermissibleValueObj> selectedDiffResult)
        {
            this.selectedDiffResult = selectedDiffResult;
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            reset();
        }

        public void reset()
        {
            textBox_search_keywords.Clear();
            textBox_freeText.Clear();
            listBox_lv3.Items.Clear();
            listBox_lv2.Items.Clear();
            consMgr.setDiffLv1(listBox_lv1);
            listBox_selectedDiffResult.Items.Clear();
            foreach (PermissibleValueObj o in selectedDiffResult)
            {
                listBox_selectedDiffResult.Items.Add(o);
            }
        }

        private void listBox_lv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_lv1.SelectedIndex != -1)
            {
                consMgr.setDiffLv2(listBox_lv2, int.Parse(((PermissibleValueObj)(listBox_lv1.SelectedItem)).Value));
                if (listBox_lv2.Items.Count > 0)
                {
                    listBox_lv2.SelectedIndex = 0;
                }
            }
        }

        private void listBox_lv2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_lv1.SelectedIndex != -1 && listBox_lv2.SelectedIndex != -1)
            {
                consMgr.setDiffLv3(listBox_lv3, int.Parse(((PermissibleValueObj)(listBox_lv1.SelectedItem)).Value), int.Parse(((PermissibleValueObj)(listBox_lv2.SelectedItem)).Value));
            }
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            listBox_lv3.Items.Clear();
            listBox_lv2.Items.Clear();
            listBox_lv1.ClearSelected();
            consMgr.setDiffLv3BySearch(listBox_lv3, textBox_search_keywords.Text.Trim().Replace(" ", "").Replace("　", "").Replace("，", ","));
        }

        private void button_addFromListBox_Click(object sender, EventArgs e)
        {
            if (listBox_lv3.SelectedIndex != -1)
            {
                PermissibleValueObj objToBeAdded = ((PermissibleValueObj)(listBox_lv3.SelectedItem));
                if (checkDuplication(objToBeAdded))
                {
                    MessageBox.Show("項目已經存在", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                listBox_selectedDiffResult.Items.Add(listBox_lv3.SelectedItem);
            }
        }

        private bool checkDuplication(PermissibleValueObj objToBeAdded)
        {
            foreach (PermissibleValueObj o in listBox_selectedDiffResult.Items)
            {
                if (o.Name == objToBeAdded.Name)
                {
                    return true;
                }
            }
            return false;
        }

        private void button_addFromFreeText_Click(object sender, EventArgs e)
        {
            textBox_freeText.Text = textBox_freeText.Text.Trim().Replace(" ", "").Replace("　", "").Replace("；", ";");
            String[] freeTextEx = textBox_freeText.Text.Split(new String[] { ";" }, StringSplitOptions.None);
            foreach (String s in freeTextEx)
            {
                PermissibleValueObj objToBeAdded = new PermissibleValueObj(s, "FreeText");
                if (!checkDuplication(objToBeAdded))
                    listBox_selectedDiffResult.Items.Add(objToBeAdded);
            }
            textBox_freeText.Clear();
        }

        private void button_clearSelectedLV_Click(object sender, EventArgs e)
        {
            listBox_selectedDiffResult.Items.Clear();
        }

        private void button_removeSelected_Click(object sender, EventArgs e)
        {
            if (listBox_selectedDiffResult.SelectedIndex != -1)
            {
                listBox_selectedDiffResult.Items.RemoveAt(listBox_selectedDiffResult.SelectedIndex);
            }
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            selectedDiffResult.Clear();
            foreach (PermissibleValueObj o in listBox_selectedDiffResult.Items)
            {
                selectedDiffResult.Add(o);
            }
            this.Hide();
        }

        private void DifferentiationResultSelectionForm_Shown(object sender, EventArgs e)
        {
            consMgr.setDiffLv1(listBox_lv1);
        }

        private void textBox_search_keywords_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                button_search_Click(sender, e);
            }
        }

        private void textBox_freeText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                button_addFromFreeText_Click(sender, e);
            }
        }
    }
}
