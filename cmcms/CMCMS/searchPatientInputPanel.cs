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
    public partial class searchPatientInputPanel : UserControl
    {
        bool showInclDeceasedCB = false;
        bool inclDeceased = false;
        public searchPatientInputPanel()
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
            PatientMgr patMgr = new PatientMgr();
            listBox_search_result.Enabled = false;
            patMgr.setSearchPatientResultListbox(listBox_search_result, textBox_search_patientID.Text.Trim(), textBox_search_IDNo.Text.Trim(), textBox_search_phoneNo.Text.Trim(), false);
            listBox_search_result.Enabled = true;
        }

        private void checkBox_search_inclDeceased_CheckedChanged(object sender, EventArgs e)
        {
            inclDeceased = checkBox_search_inclDeceased.Checked;
        }

        private void button_search_reset_Click(object sender, EventArgs e)
        {
            textBox_search_patientID.Clear();
            textBox_search_IDNo.Clear();
            textBox_search_phoneNo.Clear();
            checkBox_search_inclDeceased.Checked = false;
            listBox_search_result.Items.Clear();
        }

        public PatientObj getSelectedPatient()
        {
            return (PatientObj)(listBox_search_result.SelectedItem);
        }

    }
}
