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
    public partial class PrescriptionForm : Form
    {
        PermissibleValueObj presId;
        // bool isPreg = false;
        // bool isG6pd = false;
        int patId = 0;


        ConsultationMgr consMgr = new ConsultationMgr();

        public PrescriptionForm()
        {
            InitializeComponent();
        }

        public void setPresId(ref PermissibleValueObj presId)
        {
            this.presId = presId;
            if (presId.Value != "")
            {
                Dictionary<String, String> pres = consMgr.getPrescriptionById(int.Parse(presId.Value));
                textBox_instruction.Text = pres["instruction"];
                textBox_nDose.Text = pres["no_of_dose"];
                textBox_methodOfTreatment.Text = pres["method_of_treatment"];
                prescriptionPanel1.setConsPres(int.Parse(presId.Value));
            }
        }

        /*public void setIsPreg(bool isPreg)
        {
            this.isPreg = isPreg;
        }

        public void setIsG6pd(bool isG6pd)
        {
            this.isG6pd = isPreg;
        }*/

        public void setPatId(int patId)
        {
            this.patId = patId;
        }

        private void button_selectInstruction_Click(object sender, EventArgs e)
        {
            textBox_instruction.Text += comboBox_predefInstruction.SelectedItem.ToString();
        }

        private void button_selectMOT_Click(object sender, EventArgs e)
        {
            textBox_methodOfTreatment.Text += comboBox_predefMOT.SelectedItem.ToString();
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            String statusMsg = "";
            String tmp = presId.Value;
            if (presId.Value == "")
            {
                int status_id = consMgr.newPrescription(textBox_instruction.Text.Trim(), int.Parse(textBox_nDose.Text), textBox_methodOfTreatment.Text.Trim(), prescriptionPanel1.getConsultationPrescriptionDataString(), patId, Login.user.CurrentLoginClinicId, ref tmp, ref statusMsg);
                if (status_id > 0 && status_id != 18)
                {
                    MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    presId.Value = tmp;
                    presId.Name = tmp;
                    if (status_id == 18)
                    {
                        DialogResult result = MessageBox.Show(statusMsg+"\n\n需要修改?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (result == System.Windows.Forms.DialogResult.No)
                        {
                            this.Hide();
                        }
                    }
                    else
                        this.Hide();
                }
            }
            else
            {
                int status_id = consMgr.updatePrescription(int.Parse(presId.Value), textBox_instruction.Text.Trim(), int.Parse(textBox_nDose.Text), textBox_methodOfTreatment.Text.Trim(), prescriptionPanel1.getConsultationPrescriptionDataString(), patId, Login.user.CurrentLoginClinicId, ref statusMsg);
                if (status_id > 0 && status_id != 18)
                {
                    MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    presId.Value = tmp;
                    presId.Name = tmp;
                    if (status_id == 18)
                    {
                        DialogResult result = MessageBox.Show(statusMsg + "\n\n需要修改?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (result == System.Windows.Forms.DialogResult.No)
                        {
                            this.Hide();
                        }
                    }
                    else
                        this.Hide();
                }
            }
        }

        private bool input_validation()
        {
            if (textBox_nDose.Text.Length == 0)
            {
                MessageBox.Show("請輸入劑數", "劑數錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_nDose.Focus();
                return false;
            }
            if (!Utilities.isInteger(textBox_nDose.Text))
            {
                MessageBox.Show("劑數只限半形數字\n請重新輸入", "劑數錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_nDose.Focus();
                return false;
            }

            if (prescriptionPanel1.input_validation())
            {
                MessageBox.Show("方劑資料有誤", "方劑資料錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            if (presId.Value != "")
            {
                Dictionary<String, String> pres = consMgr.getPrescriptionById(int.Parse(presId.Value));
                textBox_instruction.Text = pres["instruction"];
                textBox_nDose.Text = pres["no_of_dose"];
                textBox_methodOfTreatment.Text = pres["method_of_treatment"];
                prescriptionPanel1.setConsPres(int.Parse(presId.Value));
            }
            else
            {
                textBox_instruction.Clear();
                textBox_nDose.Clear();
                textBox_methodOfTreatment.Clear();
                prescriptionPanel1.reset();
            }
        }

        private void PrescriptionForm_Shown(object sender, EventArgs e)
        {
            consMgr.setPredefInstructionCB(comboBox_predefInstruction);
            if (comboBox_predefInstruction.Items.Count > 0)
            {
                comboBox_predefInstruction.SelectedIndex = 0;
            }

            consMgr.setPredefMOTCB(comboBox_predefMOT);
            if (comboBox_predefMOT.Items.Count > 0)
            {
                comboBox_predefMOT.SelectedIndex = 0;
            }
        }
    }
}
