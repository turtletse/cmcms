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
    public partial class DxResultSelectionForm : Form
    {
        ConsultationMgr consMgr = new ConsultationMgr();
        List<PermissibleValueObj> selectedDxResult = null;

        public DxResultSelectionForm()
        {
            InitializeComponent();
        }

        public void setSelectedDxResult(ref List<PermissibleValueObj> selectedDxResult)
        {
            this.selectedDxResult = selectedDxResult;
            listBox_selectedDxResult.Items.Clear();
            listBox_selectedDxResult.Items.AddRange(selectedDxResult.ToArray());
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            textBox_search_keywords.Clear();
            textBox_freeText.Clear();
            listBox_lv2.Items.Clear();
            consMgr.setDxLv1(listBox_lv1);
        }

        private void ExaminationResultSelectionForm_Shown(object sender, EventArgs e)
        {
            consMgr.setDxLv1(listBox_lv1);
        }

        private void listBox_lv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_lv1.SelectedIndex != -1)
            {
                consMgr.setDxLv2(listBox_lv2, int.Parse(((PermissibleValueObj)(listBox_lv1.SelectedItem)).Value));
            }
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            listBox_lv2.Items.Clear();
            listBox_lv1.ClearSelected();
            consMgr.setExamLv4BySearch(listBox_lv2, textBox_search_keywords.Text.Trim().Replace(" ", "").Replace("　", "").Replace("，", ","));
        }

        private void button_clearSelectedLV_Click(object sender, EventArgs e)
        {
            listBox_selectedDxResult.Items.Clear();
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            selectedDxResult.Clear();
            foreach (PermissibleValueObj o in listBox_selectedDxResult.Items)
            {
                selectedDxResult.Add(o);
            }
            this.Hide();
        }

        private void button_removeSelected_Click(object sender, EventArgs e)
        {
            if (listBox_selectedDxResult.SelectedIndex != -1)
            {
                listBox_selectedDxResult.Items.RemoveAt(listBox_selectedDxResult.SelectedIndex);
            }
        }

        private bool checkDuplication(PermissibleValueObj objToBeAdded)
        {
            foreach (PermissibleValueObj o in listBox_selectedDxResult.Items)
            {
                if (o.Name == objToBeAdded.Name)
                {
                    return true;
                }
            }
            return false;
        }

        private void button_addFromListBox_Click(object sender, EventArgs e)
        {
            if (listBox_lv2.SelectedIndex != -1)
            {
                PermissibleValueObj objToBeAdded = ((PermissibleValueObj)(listBox_lv2.SelectedItem));
                if (checkDuplication(objToBeAdded))
                {
                    MessageBox.Show("項目已經存在", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                listBox_selectedDxResult.Items.Add(objToBeAdded);
            }
        }

        private void button_addFromFreeText_Click(object sender, EventArgs e)
        {
            textBox_freeText.Text = textBox_freeText.Text.Trim().Replace(" ", "").Replace("　", "").Replace("；", ";");
            String[] freeTextEx = textBox_freeText.Text.Split(new String[] { ";" }, StringSplitOptions.None);
            foreach (String s in freeTextEx)
            {
                PermissibleValueObj objToBeAdded = new PermissibleValueObj(s, "FreeText");
                if (!checkDuplication(objToBeAdded))
                    listBox_selectedDxResult.Items.Add(objToBeAdded);
            }
        }
        
    }
}