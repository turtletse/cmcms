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
    public partial class AddFormulaForm : Form
    {
        public AddFormulaForm()
        {
            InitializeComponent();
            prescriptionPanel1.setIsInclDeletedPredefPres(false);
        }

        private void button_addPredefPres_Click(object sender, EventArgs e)
        {
            if (input_validation())
            {
                DrugMgr drugMgr = new DrugMgr();
                String statusMsg = "";
                bool isSuccess;
                isSuccess = drugMgr.insertPredefinedPrescription(textBox_presName.Text.Trim(), prescriptionPanel1.getPrescriptionDataString(), ref statusMsg);
                if (isSuccess)
                {
                    MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button_addPredefPres_reset_Click(sender, e);
                }
                else
                {
                    MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_addPredefPres_reset_Click(object sender, EventArgs e)
        {
            textBox_presName.Clear();
            prescriptionPanel1.reset();
        }

        private bool input_validation()
        {
            if (textBox_presName.Text.Length == 0)
            {
                MessageBox.Show("請輸入方劑名稱", "方劑名稱錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_presName.Focus();
                return false;
            }

            if (!prescriptionPanel1.input_validation())
            {
                MessageBox.Show("方劑資料有誤", "方劑資料錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_presName.Focus();
                return false;
            }

            return true;
        }
    }
}
