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
    public partial class AddDrRmkForm : Form
    {
        ConsultationMgr consMgr = new ConsultationMgr();
        public AddDrRmkForm()
        {
            InitializeComponent();
            reset();
        }

        private void reset()
        {
            consMgr.setDrRmkPredefined(comboBox_predefPhrase);
            textBox_newPredefDrRmk.Clear();
        }

        private void button_del_Click(object sender, EventArgs e)
        {
            if (del_input_validation())
            {
                String statusMsg = "";
                bool isSuccess;
                isSuccess = consMgr.delDrRmk(int.Parse(((PermissibleValueObj)comboBox_predefPhrase.SelectedItem).Value), ref statusMsg);
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
            if (comboBox_predefPhrase.SelectedIndex == -1)
            {
                MessageBox.Show("請選擇現有醫囑", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox_predefPhrase.Focus();
                return false;
            }
            return true;
        }

        private bool add_input_validation()
        {
            if (textBox_newPredefDrRmk.Text.Trim().Length == 0)
            {
                MessageBox.Show("請輸入醫囑", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_newPredefDrRmk.Focus();
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
                isSuccess = consMgr.newDrRmk(textBox_newPredefDrRmk.Text.Trim(), ref statusMsg);
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

        private void textBox_newPredefDrRmk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                button_add_Click(sender, e);
            }
        }

    }
}
