﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMCMS
{
    public partial class ExaminationResultSelectionForm : Form
    {
        ConsultationMgr consMgr = new ConsultationMgr();
        List<PermissibleValueObj> selectedExamResult = null;

        public ExaminationResultSelectionForm()
        {
            InitializeComponent();
        }

        public void setSelectedExamResult(ref List<PermissibleValueObj> selectedExamResult)
        {
            this.selectedExamResult = selectedExamResult;
            listBox_selectedExamResult.Items.Clear();
            listBox_selectedExamResult.Items.AddRange(selectedExamResult.ToArray());
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            textBox_search_keywords.Clear();
            textBox_freeText.Clear();
            listBox_lv4.Items.Clear();
            listBox_lv3.Items.Clear();
            listBox_lv2.Items.Clear();
            consMgr.setExamLv1(listBox_lv1);
        }

        private void ExaminationResultSelectionForm_Shown(object sender, EventArgs e)
        {
            consMgr.setExamLv1(listBox_lv1);
        }

        private void listBox_lv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_lv1.SelectedIndex != -1)
            {
                consMgr.setExamLv2(listBox_lv2, int.Parse(((PermissibleValueObj)(listBox_lv1.SelectedItem)).Value));
            }
        }

        private void listBox_lv2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_lv1.SelectedIndex != -1 && listBox_lv2.SelectedIndex != -1)
            {
                consMgr.setExamLv3(listBox_lv3, int.Parse(((PermissibleValueObj)(listBox_lv1.SelectedItem)).Value), int.Parse(((PermissibleValueObj)(listBox_lv2.SelectedItem)).Value));
            }
        }

        private void listBox_lv3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_lv1.SelectedIndex != -1 && listBox_lv2.SelectedIndex != -1 && listBox_lv3.SelectedIndex != -1)
            {
                consMgr.setExamLv4(listBox_lv4, int.Parse(((PermissibleValueObj)(listBox_lv1.SelectedItem)).Value), int.Parse(((PermissibleValueObj)(listBox_lv2.SelectedItem)).Value), int.Parse(((PermissibleValueObj)(listBox_lv3.SelectedItem)).Value));
            }
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            listBox_lv4.Items.Clear();
            listBox_lv3.Items.Clear();
            listBox_lv2.Items.Clear();
            listBox_lv1.ClearSelected();
            consMgr.setExamLv4BySearch(listBox_lv4, textBox_search_keywords.Text.Trim().Replace(" ", "").Replace("　","").Replace("，",","));
        }

        private void button_clearSelectedLV_Click(object sender, EventArgs e)
        {
            listBox_selectedExamResult.Items.Clear();
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            selectedExamResult.Clear();
            foreach (PermissibleValueObj o in listBox_selectedExamResult.Items)
            {
                selectedExamResult.Add(o);
            }
            this.Hide();
        }

        private void button_remoceSelected_Click(object sender, EventArgs e)
        {
            if (listBox_selectedExamResult.SelectedIndex != -1)
            {
                listBox_selectedExamResult.Items.RemoveAt(listBox_selectedExamResult.SelectedIndex);
            }
        }

        private void button_addFromListBox_Click(object sender, EventArgs e)
        {
            if (listBox_lv4.SelectedIndex != -1)
            {
                listBox_selectedExamResult.Items.Add(listBox_lv4.SelectedItem);
            }
        }

        private void button_addFromFreeText_Click(object sender, EventArgs e)
        {
            textBox_freeText.Text = textBox_freeText.Text.Trim().Replace(" ", "").Replace("　", "").Replace("；", ";");
            String[] freeTextEx = textBox_freeText.Text.Split(new String[] { ";" }, StringSplitOptions.None);
            foreach (String s in freeTextEx)
            {
                listBox_selectedExamResult.Items.Add(new PermissibleValueObj(s, "FreeText"));
            }
        }
    }
}
