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

        public void setSuspendedCBVisibility()
        {
            if (Login.user!=null && Login.user.CurrentLoginRole == 4)
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
