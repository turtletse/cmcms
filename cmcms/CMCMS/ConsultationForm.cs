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
    public partial class ConsultationForm : Form
    {
        PatientMgr patMgr = new PatientMgr();

        List<List<String>> examination = new List<List<string>>();
        List<List<String>> differentiation = new List<List<string>>();
        List<List<String>> diagnosis = new List<List<string>>();
        List<String> prescription = new List<string>();

        public ConsultationForm()
        {
            InitializeComponent();
        }

        private void ConsultationForm_Shown(object sender, EventArgs e)
        {
            String statusMsg="";
            bool isSuccess;
            isSuccess = patMgr.setPatientInfoForConsultation(textBox_patId, textBox_pat_chiName, textBox_pat_engName, textBox_pat_IDNo, textBox_pat_sex, checkBox_pat_isPregnant, textBox_pat_DOB, textBox_pat_age, checkBox_pat_isG6PD, textBox_pat_drugAllergy, ref statusMsg);
            if (!isSuccess)
            {
                MessageBox.Show(statusMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
