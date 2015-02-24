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
    public partial class DrugIncompatibleSelection : Form
    {
        DrugAdmin parentForm;
        public DrugIncompatibleSelection()
        {
            InitializeComponent();
            drugSelectionPanel1.setSubDrugEnabled(false);
            drugSelectionPanel1.setSubDrugSelectionEnabled(false);
            drugSelectionPanel1.setSubDrugInclNotSpecified(false);
            drugSelectionPanel1.setShowDeletedItemCB(false);
            drugSelectionPanel1.setShowDeletedItem(false);
        }

        public void setParentForm(DrugAdmin parentForm)
        {
            this.parentForm = parentForm;
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            parentForm.setSelectedDrug(drugSelectionPanel1.getSelectedDrug());
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DrugIncompatibleSelection_Shown(object sender, EventArgs e)
        {
            drugSelectionPanel1.refresh();
        }
    }
}
