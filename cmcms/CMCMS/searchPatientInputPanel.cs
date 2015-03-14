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
    public partial class SearchPatientInputPanel : UserControl
    {
        bool showInclDeceasedCB = false;
        bool inclDeceased = false;
        public SearchPatientInputPanel()
        {
            InitializeComponent();
            checkBox_search_inclDeceased.Checked = inclDeceased;
            setInclDeceased(false);
            setShowInclDeceasedCB(false);
        }

        public void setShowInclDeceasedCB(bool showInclDeceasedCB)
        {
            this.showInclDeceasedCB = showInclDeceasedCB;
            if (showInclDeceasedCB)
                checkBox_search_inclDeceased.Show();
            else
                checkBox_search_inclDeceased.Hide();
        }

        public void setInclDeceased(bool inclDeceased)
        {
            checkBox_search_inclDeceased.Checked = inclDeceased;
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            if (input_validation())
            {
                PatientMgr patMgr = new PatientMgr();
                listBox_search_result.Enabled = false;
                patMgr.setSearchPatientResultListbox(listBox_search_result, textBox_search_patientID.Text.Trim(), textBox_search_IDNo.Text.Trim(), textBox_search_phoneNo.Text.Trim(), inclDeceased);
                if (listBox_search_result.Items.Count > 0)
                    listBox_search_result.SelectedIndex = 0;
                listBox_search_result.Enabled = true;
            }
        }

        private void checkBox_search_inclDeceased_CheckedChanged(object sender, EventArgs e)
        {
            inclDeceased = checkBox_search_inclDeceased.Checked;
        }

        private void button_search_reset_Click(object sender, EventArgs e)
        {
            reset();
        }

        public PatientObj getSelectedPatient()
        {
            return (PatientObj)(listBox_search_result.SelectedItem);
        }

        public void reset()
        {
            textBox_search_patientID.Clear();
            textBox_search_IDNo.Clear();
            textBox_search_phoneNo.Clear();
            checkBox_search_inclDeceased.Checked = false;
            listBox_search_result.Items.Clear();
        }

        public bool input_validation()
        {
            if (textBox_search_patientID.Text.Length == 0 && textBox_search_IDNo.Text.Length == 0 && textBox_search_phoneNo.Text.Length == 0)
            {
                MessageBox.Show("請輸入最少一項檢索條例", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_search_patientID.Focus();
                return false;
            }

            if (!Utilities.isInteger(textBox_search_patientID.Text))
            {
                MessageBox.Show("病人編號只限數字\n請重新輸入", "病人編號錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_search_patientID.Focus();
                return false;
            }

            if (!Utilities.isAlphaNumericParentheses(textBox_search_patientID.Text))
            {
                MessageBox.Show("身份證/護照號碼只限半形英文字母,數字及小括號\"()\"\n請重新輸入", "身份證/護照號碼錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_search_patientID.Focus();
                return false;
            }

            if (textBox_search_phoneNo.Text.Length != 0 && !Utilities.isphoneNo(textBox_search_phoneNo.Text))
            {
                MessageBox.Show("電話號碼只限8位半形數字\n請重新輸入", "電話號碼錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_search_patientID.Focus();
                return false;
            }

            return true;
        }
    }
}
