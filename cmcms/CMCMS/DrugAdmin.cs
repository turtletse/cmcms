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
    public partial class DrugAdmin : Form
    {
        DrugMgr drugMgr;
        public DrugAdmin()
        {
            drugMgr = new DrugMgr();
            InitializeComponent();
        }


        private void tabPage1_Enter(object sender, EventArgs e)
        {
            drugMgr.setDosageUnitCombo(comboBox_minDoseUnit);
            drugMgr.setDosageUnitCombo(comboBox_maxDoseUnit);
            drugMgr.setPrimaryDrugTypeCombo(comboBox_pri_type);
            //drugMgr.setSecondaryDrugTypeCombo(comboBox_sec_type, (comboBox_pri_type.SelectedItem as permissibleValueObj).getValue());
            drugMgr.setContraindicationLevelCombo(comboBox_preg_contra);
            drugMgr.setContraindicationLevelCombo(comboBox_g6pd_contra);
        }

        private void comboBox_pri_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            drugMgr.setSecondaryDrugTypeCombo(comboBox_sec_type, (comboBox_pri_type.SelectedItem as permissibleValueObj).getValue());
        }


    }
}
