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
        bool showDeceasedCtrl = false;
        public PatientRegistration()
        {
            InitializeComponent();
            DSP_allergic.setShowDeletedItemCB(false);
            DSP_allergic.setShowDeletedItem(true);
            DSP_allergic.setSubDrugEnabled(false);
            setShowDeceasedCtrl(false);
        }

        public void setShowDeceasedCtrl(bool showDeceasedCtrl)
        {
            this.showDeceasedCtrl = showDeceasedCtrl;
            if (showDeceasedCtrl)
            {
                checkBox_isDeceased.Show();
                label_deceasedRptDate.Show();
            }
            else
            {
                checkBox_isDeceased.Hide();
                label_deceasedRptDate.Hide();
            }
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
            checkBox_isRecordShared.Checked = false;
            DSP_allergic.refresh();
            listBox_selectedAllergicDrug.Items.Clear();
            textBox_patReg_password.Clear();
            textBox_patReg_confirmPassword.Clear();
            checkBox_isDeceased.Checked = false;
            label_deceasedRptDate.Text = "";
        }

        public bool input_validation()
        {
            if (textBox_patReg_chiName.Text.Length > 7)
            {
                MessageBox.Show("中文姓名只限最多7個中文字符\n請重新輸入", "中文姓名錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_patReg_engName.Focus();
                return false;
            }
            if (!Utilities.isCJKCharacters(textBox_patReg_chiName.Text))
            {
                MessageBox.Show("中文姓名只限中文字符\n請重新輸入", "中文姓名錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_patReg_chiName.Focus();
                return false;
            }

            if (textBox_patReg_engName.Text.Length == 0)
            {
                MessageBox.Show("請輸入英文姓名", "英文姓名錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_patReg_engName.Focus();
                return false;
            }
            if (textBox_patReg_chiName.Text.Length > 70)
            {
                MessageBox.Show("英文姓名只限最多70個半形英文字母及空格\n請重新輸入", "英文姓名錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_patReg_engName.Focus();
                return false;
            }
            if (!Utilities.isAlphaSpace(textBox_patReg_engName.Text))
            {
                MessageBox.Show("英文姓名只限半形英文字母及空格\n請重新輸入", "英文姓名錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_patReg_engName.Focus();
                return false;
            }

            if (radioButton_IDNo.Checked)
            {
                if (!Utilities.isValidHKID(textBox_patReg_HKID.Text))
                {
                    MessageBox.Show("身份證號碼錯誤\n請重新輸入", "身份證號碼錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_patReg_HKID.Focus();
                    return false;
                }
            }
            else
            {
                if (textBox_patReg_HKID.Text.Length == 0)
                {
                    MessageBox.Show("請輸入護照號碼", "護照號碼錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_patReg_HKID.Focus();
                    return false;
                }
                if (!Utilities.isAlphaNumericParentheses(textBox_patReg_HKID.Text))
                {
                    MessageBox.Show("護照號碼只限半形英文字母,數字及小括號\"()\"\n請重新輸入", "護照號碼錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_patReg_HKID.Focus();
                    return false;
                }
            }

            if (!Utilities.isphoneNo(textBox_patReg_phoneNo.Text))
            {
                MessageBox.Show("電話號碼只限8位半形數字\n請重新輸入", "電話號碼錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_patReg_phoneNo.Focus();
                return false;
            }

            if (textBox_patReg_addr.Text.Length == 0)
            {
                MessageBox.Show("請輸入地址", "地址錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_patReg_addr.Focus();
                return false;
            }

            if (!isPasswordMatch())
            {
                MessageBox.Show("確認密碼錯誤", "確認密碼錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_patReg_confirmPassword.Focus();
                return false;
            }

            return true;
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

        private bool isPasswordMatch()
        {
            return textBox_patReg_password.Text == textBox_patReg_confirmPassword.Text;
        }

        public String getHashedPassword()
        {
            return PasswordHash.getHashedPw(textBox_patReg_password.Text);
        }

        public String getPlainTextPassword()
        {
            return textBox_patReg_password.Text;
        }

        public bool getIsDeceased()
        {
            return checkBox_isDeceased.Checked;
        }

        public bool getIsPregnant()
        {
            return checkBox_isPregnant.Checked;
        }

        public bool getIsRecordShared()
        {
            return checkBox_isRecordShared.Checked;
        }

        public void setSelectedDrugList(String drugIds)
        {
            DrugMgr drugMgr = new DrugMgr();
            listBox_selectedAllergicDrug.Enabled = false;
            drugMgr.setDrugListBoxItemsByDrugIds(listBox_selectedAllergicDrug, drugIds);
            listBox_selectedAllergicDrug.Enabled = true;
        }

        public void setPatientData(PatientObj pat)
        {
            DrugMgr drugMgr = new DrugMgr();
            textBox_patReg_chiName.Text = pat.ChineseName;
            textBox_patReg_engName.Text = pat.EnglishName;
            if (pat.IdDocType == "HKID")
                radioButton_IDNo.Checked = true;
            else if (pat.IdDocType == "PASSPORT")
                radioButton_passportNo.Checked = true;
            textBox_patReg_HKID.Text = pat.IdDocNo;
            textBox_patReg_phoneNo.Text = pat.PhoneNo;
            dateTimePicker_DOB.Value = DateTime.ParseExact(pat.Dob, "dd/MM/yyyy", null);
            if (pat.Sex == "M")
                radioButton_male.Checked = true;
            else if (pat.Sex == "F")
                radioButton_female.Checked = true;
            checkBox_g6pd.Checked = pat.IsG6PD;
            textBox_patReg_addr.Text = pat.Addr;
            textBox_patReg_password.Clear();
            textBox_patReg_confirmPassword.Clear();
            drugMgr.setDrugListBoxItemsByDrugIds(listBox_selectedAllergicDrug, pat.AllergicDrugIds);
            checkBox_isDeceased.Checked = pat.IsDeceased;
            if (pat.IsDeceased)
                label_deceasedRptDate.Text = "紀錄於" + pat.DeceasedRecordDtm;
            else
                label_deceasedRptDate.Text = "";
            checkBox_isPregnant.Checked = pat.IsPregnant;
            checkBox_isRecordShared.Checked = pat.IsRecordShared;
        }

        private void radioButton_female_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_female.Checked)
            {
                checkBox_isPregnant.Enabled = true;
            }
            else
            {
                checkBox_isPregnant.Enabled = false;
                checkBox_isPregnant.Checked = false;
            }
        }

        private void radioButton_male_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_male.Checked)
            {
                checkBox_isPregnant.Enabled = false;
                checkBox_isPregnant.Checked = false;
            }
            else
            {
                checkBox_isPregnant.Enabled = true;
            }
        }
    }
}
