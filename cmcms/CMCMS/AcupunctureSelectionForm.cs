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
    public partial class AcupunctureSelectionForm : Form
    {
        ConsultationMgr consMgr = new ConsultationMgr();
        List<PermissibleValueObj> selectedAcupuncturePt = null;
        public AcupunctureSelectionForm()
        {
            InitializeComponent();
        }

        public void setSelectedAcupuncturePt(ref List<PermissibleValueObj> selectedAcupuncturePt)
        {
            this.selectedAcupuncturePt = selectedAcupuncturePt;
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            reset();
        }

        public void reset()
        {
            textBox_search_keywords.Clear();
            textBox_search_code.Clear();
            listBox_lv3.Items.Clear();
            listBox_lv2.Items.Clear();
            consMgr.setAPLv1(listBox_lv1);
            listBox_selectedAcupuncturePoint.Items.Clear();
            foreach (PermissibleValueObj o in selectedAcupuncturePt)
            {
                listBox_selectedAcupuncturePoint.Items.Add(o);
            }
        }

        private void listBox_lv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_lv1.SelectedIndex != -1)
            {
                consMgr.setAPLv2(listBox_lv2, int.Parse(((PermissibleValueObj)(listBox_lv1.SelectedItem)).Value));
                if (listBox_lv2.Items.Count == 1)
                {
                    listBox_lv2.SelectedIndex = 0;
                }
            }
        }

        private void listBox_lv2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_lv1.SelectedIndex != -1 && listBox_lv2.SelectedIndex != -1)
            {
                consMgr.setAPLv3(listBox_lv3, int.Parse(((PermissibleValueObj)(listBox_lv1.SelectedItem)).Value), int.Parse(((PermissibleValueObj)(listBox_lv2.SelectedItem)).Value));
            }
        }

        private void button_keyword_search_Click(object sender, EventArgs e)
        {
            listBox_lv3.Items.Clear();
            listBox_lv2.Items.Clear();
            listBox_lv1.ClearSelected();
            textBox_search_code.Clear();
            consMgr.setAPLv3ByKeywordsSearch(listBox_lv3, textBox_search_keywords.Text.Trim().Replace(" ", "").Replace("　", "").Replace("，", ","));
        }

        private void button_code_search_Click(object sender, EventArgs e)
        {
            listBox_lv3.Items.Clear();
            listBox_lv2.Items.Clear();
            listBox_lv1.ClearSelected();
            textBox_search_keywords.Clear();
            consMgr.setAPLv3ByCodeSearch(listBox_lv3, textBox_search_code.Text.Trim().Replace(" ", "").Replace("　", "").Replace("，", ","));
        }

        private bool checkDuplication(PermissibleValueObj objToBeAdded)
        {
            foreach (PermissibleValueObj o in listBox_selectedAcupuncturePoint.Items)
            {
                if (o.Name == objToBeAdded.Name)
                {
                    return true;
                }
            }
            return false;
        }

        private void button_clearSelectedLV_Click(object sender, EventArgs e)
        {
            listBox_selectedAcupuncturePoint.Items.Clear();
        }

        private void button_removeSelected_Click(object sender, EventArgs e)
        {
            if (listBox_selectedAcupuncturePoint.SelectedIndex != -1)
            {
                listBox_selectedAcupuncturePoint.Items.RemoveAt(listBox_selectedAcupuncturePoint.SelectedIndex);
            }
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            selectedAcupuncturePt.Clear();
            foreach (PermissibleValueObj o in listBox_selectedAcupuncturePoint.Items)
            {
                selectedAcupuncturePt.Add(o);
            }
            this.Hide();
        }

        private void AcupunctureSelectionForm_Shown(object sender, EventArgs e)
        {
            consMgr.setAPLv1(listBox_lv1);
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
                listBox_selectedAcupuncturePoint.Items.Add(listBox_lv3.SelectedItem);
            }
        }

        private void textBox_search_keywords_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                button_keyword_search_Click(sender, e);
            }
        }

        private void textBox_search_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                button_code_search_Click(sender, e);
            }
        }
    }
}
