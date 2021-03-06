﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMCMS
{
    public partial class WaitingList : UserControl
    {
        public WaitingList()
        {
            InitializeComponent();
        }

        private void button_waitingList_refresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        public void refresh()
        {
            PatientMgr patMgr = new PatientMgr();
            listView_waitingList.Enabled = false;
            textBox_waitingList_refreshDtm.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            patMgr.refreshWaitingList(listView_waitingList);
            listView_waitingList.Enabled = true;
        }
    }
}
