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
        String presId = "";

        ConsultationMgr consMgr = new ConsultationMgr();

        public PrescriptionForm()
        {
            InitializeComponent();
        }

        public void setPresId(ref String presId)
        {
            this.presId = presId;
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
            if (presId == "")
            {
                consMgr.newPrescription(textBox_instruction.Text.Trim(), int.Parse(textBox_nDose.Text), textBox_methodOfTreatment.Text.Trim(), prescriptionPanel1.getConsultationPrescriptionDataString(), ref presId);
            }
            else
            {
            }
        }
    }
}
