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
            DrugMgr drugMgr = new DrugMgr();
            String statusMsg = "";
            bool isSuccess;
            isSuccess = drugMgr.insertPredifinedPrescription(textBox_presName.Text.Trim(), prescriptionPanel1.getPrescriptionDataString(), ref statusMsg);
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

        private void button_addPredefPres_reset_Click(object sender, EventArgs e)
        {
            textBox_presName.Clear();
            prescriptionPanel1.reset();
        }
    }
}
