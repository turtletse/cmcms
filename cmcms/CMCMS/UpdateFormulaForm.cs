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
    public partial class UpdateFormulaForm : Form
    {
        DrugMgr drugMgr = new DrugMgr();
        public UpdateFormulaForm()
        {
            InitializeComponent();
            reset();
        }

        private void comboBox_predefPresName_SelectedIndexChanged(object sender, EventArgs e)
        {
            prescriptionPanel1.setPredefPres(int.Parse(((PermissibleValueObj)(comboBox_predefPresName.SelectedItem)).getValue()));
            textBox_rename.Text = comboBox_predefPresName.SelectedItem.ToString();
            textBox_rename.ReadOnly = !checkBox_rename.Checked;
            checkBox_isDelete.Checked = ((PermissibleValueObjWithDelFlag)(comboBox_predefPresName.SelectedItem)).Deleted;
        }

        private void reset()
        {
            prescriptionPanel1.reset();
            checkBox_isInclDeleted.Checked = false;
            drugMgr.setPredefPresCB(comboBox_predefPresName, checkBox_isInclDeleted.Checked);
            comboBox_predefPresName.SelectedIndex = 0;
            checkBox_rename.Checked = false;
            textBox_rename.Text = comboBox_predefPresName.SelectedItem.ToString();
            textBox_rename.ReadOnly = !checkBox_rename.Checked;
            checkBox_isDelete.Checked = ((PermissibleValueObjWithDelFlag)(comboBox_predefPresName.SelectedItem)).Deleted;
        }

        private void checkBox_isInclDeleted_CheckedChanged(object sender, EventArgs e)
        {
            drugMgr.setPredefPresCB(comboBox_predefPresName, checkBox_isInclDeleted.Checked);
            comboBox_predefPresName.SelectedIndex = 0;
        }

        private void button_addPredefPres_reset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void checkBox_rename_CheckedChanged(object sender, EventArgs e)
        {
            textBox_rename.ReadOnly = !(checkBox_rename.Checked);
        }

        private void button_addPredefPres_Click(object sender, EventArgs e)
        {
            String statusMsg = "";
            bool isSuccess;
            isSuccess = drugMgr.UpdatePredefinedPrescription(int.Parse(((PermissibleValueObj)(comboBox_predefPresName.SelectedItem)).getValue()), textBox_rename.Text.Trim(), prescriptionPanel1.getPrescriptionDataString(), checkBox_isDelete.Checked, ref statusMsg);
            if (isSuccess)
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset();
            }
            else
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
