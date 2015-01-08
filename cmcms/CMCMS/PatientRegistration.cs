using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMCMS
{
    public partial class PatientRegistration : UserControl
    {
        public PatientRegistration()
        {
            InitializeComponent();
            DSP_allergic.setShowDeletedItemCB(false);
            DSP_allergic.setShowDeletedItem(true);
            DSP_allergic.setSubDrugEnabled(false);
        }

        private void PatientRegistration_Load(object sender, EventArgs e)
        {
            radioButton_IDNo.Select();
            radioButton_male.Select();
            DSP_allergic.refresh();
            textBox_patReg_chiName.Select();
        }

        private void button_selectAllergicDrug_Click(object sender, EventArgs e)
        {
            DrugObj selectedDrug = DSP_allergic.getSelectedDrug();
            if (selectedDrug != null)
            {
                foreach (DrugObj drug in listBox_selectedAllergicDrug.Items)
                {
                    if (selectedDrug.Equals(drug))
                    {
                        MessageBox.Show("此項目已被選擇", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                listBox_selectedAllergicDrug.Items.Add(selectedDrug);
                //DSP_allergic.refresh();
            }
        }

        private void button_removeSelectedDrug_Click(object sender, EventArgs e)
        {
            if (listBox_selectedAllergicDrug.SelectedItems.Count>0)
                listBox_selectedAllergicDrug.Items.Remove((listBox_selectedAllergicDrug.SelectedItems[0]));
        }
    }
}
