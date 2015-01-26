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
    public partial class DrRmkEditForm : Form
    {
        ConsultationMgr consMgr = new ConsultationMgr();
        String drRmk = "";

        public DrRmkEditForm()
        {
            InitializeComponent();
        }

        public void setRmk(ref String drRmk)
        {
            this.drRmk = drRmk;
            textBox_drRmk.Text = drRmk;
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_drRmk.Clear();
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            textBox_drRmk.Text = drRmk;
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            drRmk = textBox_drRmk.Text.Trim();
        }

        private void button_select_Click(object sender, EventArgs e)
        {
            textBox_drRmk.Text += comboBox_predefPhrase.SelectedItem.ToString();
        }

        private void DrRmkEditForm_Shown(object sender, EventArgs e)
        {
            consMgr.setDrRmkPredefined(comboBox_predefPhrase);
            if (comboBox_predefPhrase.Items.Count > 0)
            {
                comboBox_predefPhrase.SelectedIndex = 0;
            }
        }
    }
}
