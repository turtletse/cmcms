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
        DBMgr dbmgr = new DBMgr();
        public DrugAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string stm = "SELECT a FROM testing";
            textBox1.Text=dbmgr.testReadData(stm);
        }

    }
}
