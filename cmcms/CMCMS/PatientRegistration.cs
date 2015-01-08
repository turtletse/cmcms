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
            dateTimePicker_DOB.Value = DateTime.Now;
            radioButton_male.Select();
            DSP_allergic.refresh();
            textBox_patReg_chiName.Select();
        }

        public void reset()
        {
            textBox_patReg_chiName.Clear();
            textBox_patReg_engName.Clear();
            radioButton_IDNo.Select();
            textBox_patReg_HKID.Clear();
            textBox_patReg_phoneNo.Clear();
            dateTimePicker_DOB.Value = DateTime.Now;
            radioButton_male.Select();
            checkBox_g6pd.Checked = false;
            textBox_patReg_addr.Clear();
            DSP_allergic.refresh();
            listBox_selectedAllergicDrug.Items.Clear();
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

        public String getChiName()
        {
            return textBox_patReg_chiName.Text.Trim();
        }

        public String getEngName()
        {
            return textBox_patReg_engName.Text.Trim();
        }

        public String getPIDDocType()
        {
            if (radioButton_IDNo.Checked)
                return "HKID";
            if (radioButton_passportNo.Checked)
                return "PASSPORT";
            return "";
        }

        public String getPIDDocNo()
        {
            return textBox_patReg_HKID.Text.Trim();
        }

        public String getPhoneNo()
        {
            return textBox_patReg_phoneNo.Text.Trim();
        }

        public String getDOB()
        {
            return dateTimePicker_DOB.Value.ToString("dd/MM/yyyy");
        }

        public String getSex()
        {
            if (radioButton_male.Checked)
                return "M";
            if (radioButton_female.Checked)
                return "F";
            return "";
        }

        public bool getIsG6PD()
        {
            return checkBox_g6pd.Checked;
        }

        public String getAddr()
        {
            return textBox_patReg_addr.Text.Trim();
        }

        public String getAllergicDrugsIdString()
        {
            String dataStr = "";
            foreach (DrugObj drug in listBox_selectedAllergicDrug.Items)
            {
                dataStr += "||" + drug.getValue();
            }
            if (dataStr.Length > 2)
                dataStr = dataStr.Substring(2);
            return dataStr;
        }

        private bool passwordMatch()
        {
            return textBox_patReg_password.Text == textBox_patReg_confirmPassword.Text;
        }

        public String getHashedPassword()
        {
            return PasswordHash.getHashedPw(textBox_patReg_password.Text);
        }

    }
}
