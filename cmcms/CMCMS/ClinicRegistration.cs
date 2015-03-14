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
    public partial class ClinicRegistration : UserControl
    {
        public ClinicRegistration()
        {
            InitializeComponent();
            setSuspendedCBVisibility();
        }

        public void reset()
        {
            textBox_clinicId.ReadOnly = false;
            textBox_clinicId.Clear();
            textBox_chiName.Clear();
            textBox_engName.Clear();
            textBox_addr.Clear();
            textBox_phoneNo.Clear();
            checkBox_isSuspended.Checked = false;
        }

        public bool input_validation()
        {
            if (textBox_clinicId.Text.Length == 0)
            {
                MessageBox.Show("請輸入診所代號", "診所代號錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_clinicId.Focus();
                return false;
            }
            if (!Utilities.isAlphaOnly(textBox_clinicId.Text))
            {
                MessageBox.Show("診所代號只限英文字母\n請重新輸入", "診所代號錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_clinicId.Focus();
                return false;
            }

            if (textBox_chiName.Text.Length == 0)
            {
                MessageBox.Show("請輸入診所中文名稱", "診所中文名稱錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_chiName.Focus();
                return false;
            }

            if (textBox_engName.Text.Length == 0)
            {
                MessageBox.Show("請輸入診所英文名稱", "診所英文名稱錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_engName.Focus();
                return false;
            }
            if (!Utilities.isAlphaNumericCommonPunctuation(textBox_engName.Text))
            {
                MessageBox.Show("診所代號只限英文(含半形空格)及以下標點符號:\n. ' ( ) &\n請重新輸入", "診所英文名稱錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_engName.Focus();
                return false;
            }

            if (textBox_addr.Text.Length == 0)
            {
                MessageBox.Show("請輸入診所地址", "診所地址錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_engName.Focus();
                return false;
            }

            if (textBox_phoneNo.Text.Length == 0)
            {
                MessageBox.Show("請輸入診所電話", "診所電話錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_phoneNo.Focus();
                return false;
            }
            if (!Utilities.isAlphaNumericCommonPunctuation(textBox_phoneNo.Text))
            {
                MessageBox.Show("診所電話錯誤只限8位半形數字\n如多於一組, 請以半形空格逗號分隔\n請重新輸入", "診所電話錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_phoneNo.Focus();
                return false;
            }

            return true;
        }

        public void setSuspendedCBVisibility()
        {
            if (Login.user!=null && Login.user.CurrentLoginRole == 40)
                checkBox_isSuspended.Show();
            else
                checkBox_isSuspended.Hide();
        }

        public String getClinicId()
        {
            return textBox_clinicId.Text.Trim();
        }

        public String getChineseName()
        {
            return textBox_chiName.Text.Trim();
        }

        public String getEnglishName()
        {
            return textBox_engName.Text.Trim();
        }

        public String getAddr()
        {
            return textBox_addr.Text.Trim();
        }

        public String getPhoneNo()
        {
            return textBox_phoneNo.Text.Trim().Replace(" ", "").Replace(",", ", ");
        }

        public bool getIsSuspended()
        {
            return checkBox_isSuspended.Checked;
        }

        public void setClinic(ClinicObj clinic)
        {
            textBox_clinicId.Text = clinic.ClinicId;
            textBox_clinicId.ReadOnly = true;
            textBox_chiName.Text = clinic.ChineseName;
            textBox_engName.Text = clinic.EnglishName;
            textBox_addr.Text = clinic.Addr;
            textBox_phoneNo.Text = clinic.PhoneNo;
            checkBox_isSuspended.Checked = clinic.IsSuspended;
        }
    }
}
