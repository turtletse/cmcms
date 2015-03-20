namespace CMCMS
{
    partial class WaitingList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listView_waitingList = new System.Windows.Forms.ListView();
            this.columnHeader_queueSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_patId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_chiName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_engName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_sex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_DOB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_queueDtm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_MOIC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_waitingList_refresh = new System.Windows.Forms.Button();
            this.textBox_waitingList_refreshDtm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listView_waitingList);
            this.groupBox3.Controls.Add(this.button_waitingList_refresh);
            this.groupBox3.Controls.Add(this.textBox_waitingList_refreshDtm);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(605, 486);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            // 
            // listView_waitingList
            // 
            this.listView_waitingList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_queueSeq,
            this.columnHeader_patId,
            this.columnHeader_chiName,
            this.columnHeader_engName,
            this.columnHeader_sex,
            this.columnHeader_DOB,
            this.columnHeader_queueDtm,
            this.columnHeader_status,
            this.columnHeader_MOIC});
            this.listView_waitingList.FullRowSelect = true;
            this.listView_waitingList.GridLines = true;
            this.listView_waitingList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_waitingList.Location = new System.Drawing.Point(6, 85);
            this.listView_waitingList.MultiSelect = false;
            this.listView_waitingList.Name = "listView_waitingList";
            this.listView_waitingList.Size = new System.Drawing.Size(595, 395);
            this.listView_waitingList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView_waitingList.TabIndex = 3;
            this.listView_waitingList.UseCompatibleStateImageBehavior = false;
            this.listView_waitingList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_queueSeq
            // 
            this.columnHeader_queueSeq.Text = "#";
            this.columnHeader_queueSeq.Width = 31;
            // 
            // columnHeader_patId
            // 
            this.columnHeader_patId.Text = "病人編號";
            this.columnHeader_patId.Width = 79;
            // 
            // columnHeader_chiName
            // 
            this.columnHeader_chiName.Text = "中文姓名";
            this.columnHeader_chiName.Width = 78;
            // 
            // columnHeader_engName
            // 
            this.columnHeader_engName.Text = "英文姓名";
            this.columnHeader_engName.Width = 77;
            // 
            // columnHeader_sex
            // 
            this.columnHeader_sex.Text = "性別";
            this.columnHeader_sex.Width = 44;
            // 
            // columnHeader_DOB
            // 
            this.columnHeader_DOB.Text = "出生日期";
            this.columnHeader_DOB.Width = 82;
            // 
            // columnHeader_queueDtm
            // 
            this.columnHeader_queueDtm.Text = "輪候時間";
            this.columnHeader_queueDtm.Width = 76;
            // 
            // columnHeader_status
            // 
            this.columnHeader_status.Text = "狀況";
            this.columnHeader_status.Width = 55;
            // 
            // columnHeader_MOIC
            // 
            this.columnHeader_MOIC.Text = "醫生";
            // 
            // button_waitingList_refresh
            // 
            this.button_waitingList_refresh.Location = new System.Drawing.Point(327, 51);
            this.button_waitingList_refresh.Name = "button_waitingList_refresh";
            this.button_waitingList_refresh.Size = new System.Drawing.Size(75, 28);
            this.button_waitingList_refresh.TabIndex = 2;
            this.button_waitingList_refresh.Text = "更新";
            this.button_waitingList_refresh.UseVisualStyleBackColor = true;
            this.button_waitingList_refresh.Click += new System.EventHandler(this.button_waitingList_refresh_Click);
            // 
            // textBox_waitingList_refreshDtm
            // 
            this.textBox_waitingList_refreshDtm.Location = new System.Drawing.Point(130, 52);
            this.textBox_waitingList_refreshDtm.Name = "textBox_waitingList_refreshDtm";
            this.textBox_waitingList_refreshDtm.ReadOnly = true;
            this.textBox_waitingList_refreshDtm.Size = new System.Drawing.Size(191, 26);
            this.textBox_waitingList_refreshDtm.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "更新日期/時間: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 29);
            this.label9.TabIndex = 0;
            this.label9.Text = "輪候名單";
            // 
            // WaitingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Name = "WaitingList";
            this.Size = new System.Drawing.Size(607, 486);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView listView_waitingList;
        private System.Windows.Forms.ColumnHeader columnHeader_queueSeq;
        private System.Windows.Forms.ColumnHeader columnHeader_patId;
        private System.Windows.Forms.ColumnHeader columnHeader_chiName;
        private System.Windows.Forms.ColumnHeader columnHeader_engName;
        private System.Windows.Forms.ColumnHeader columnHeader_sex;
        private System.Windows.Forms.ColumnHeader columnHeader_DOB;
        private System.Windows.Forms.ColumnHeader columnHeader_queueDtm;
        private System.Windows.Forms.ColumnHeader columnHeader_status;
        private System.Windows.Forms.ColumnHeader columnHeader_MOIC;
        private System.Windows.Forms.Button button_waitingList_refresh;
        private System.Windows.Forms.TextBox textBox_waitingList_refreshDtm;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}
