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
    public partial class PrescriptionForm : Form
    {
        PermissibleValueObj presId;

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
                if (!consMgr.newPrescription(textBox_instruction.Text.Trim(), int.Parse(textBox_nDose.Text), textBox_methodOfTreatment.Text.Trim(), prescriptionPanel1.getConsultationPrescriptionDataString(), ref tmp, ref statusMsg))
                {
                    MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    presId.Value = tmp;
                    presId.Name = tmp;
                    this.Hide();
                }
            }
            else
            {
                if (consMgr.updatePrescription(int.Parse(presId.Value), textBox_instruction.Text.Trim(), int.Parse(textBox_nDose.Text), textBox_methodOfTreatment.Text.Trim(), prescriptionPanel1.getConsultationPrescriptionDataString(), ref statusMsg))
                {
                    MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Hide();
                }
            }
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
    }
}