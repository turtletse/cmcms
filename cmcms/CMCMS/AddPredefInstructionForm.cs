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
    public partial class AddPredefInstructionForm : Form
    {
        ConsultationMgr consMgr = new ConsultationMgr();
        public AddPredefInstructionForm()
        {
            InitializeComponent();
            reset();
        }

        private void reset()
        {
            consMgr.setPredefInstructionCB(comboBox_predefInstruction);
            textBox_newPredefInstruction.Clear();
        }

        private void button_del_Click(object sender, EventArgs e)
        {
            if (del_input_validation())
            {
                String statusMsg = "";
                bool isSuccess;
                isSuccess = consMgr.delInstruction(int.Parse(((PermissibleValueObj)comboBox_predefInstruction.SelectedItem).Value), ref statusMsg);
                if (isSuccess)
                {
                    MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                reset();
            }
        }

        private bool del_input_validation()
        {
            if (comboBox_predefInstruction.SelectedIndex == -1)
            {
                MessageBox.Show("請選擇現有方法", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox_predefInstruction.Focus();
                return false;
            }
            return true;
        }

        private bool add_input_validation()
        {
            if (textBox_newPredefInstruction.Text.Trim().Length == 0)
            {
                MessageBox.Show("請輸入方法", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_newPredefInstruction.Focus();
                return false;
            }
            return true;
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (add_input_validation())
            {
                String statusMsg = "";
                bool isSuccess;
                isSuccess = consMgr.newInstruction(textBox_newPredefInstruction.Text.Trim(), ref statusMsg);
                if (isSuccess)
                {
                    MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                reset();
            }
        }

        private void textBox_newPredefInstruction_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                button_add_Click(sender, e);
            }
        }
    }
}
