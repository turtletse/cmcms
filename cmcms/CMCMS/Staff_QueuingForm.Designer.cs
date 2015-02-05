namespace CMCMS
{
    partial class Staff_QueuingForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_seaechPanel_leaveQ = new System.Windows.Forms.Button();
            this.button_enterQueue = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchPatientInputPanel1 = new CMCMS.SearchPatientInputPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_changeMOIC_reset = new System.Windows.Forms.Button();
            this.button_changeMOIC = new System.Windows.Forms.Button();
            this.button_NextPat_reset = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox_changeMOIC_MOIC = new System.Windows.Forms.ComboBox();
            this.textBox_changeMOIC_patId = new System.Windows.Forms.TextBox();
            this.textBox_piorityCons_patId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_piorityCons = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_NextPat_MOIC = new System.Windows.Forms.ComboBox();
            this.button_callNext = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.waitingList1 = new CMCMS.WaitingList();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_seaechPanel_leaveQ
            // 
            this.button_seaechPanel_leaveQ.Location = new System.Drawing.Point(150, 435);
            this.button_seaechPanel_leaveQ.Name = "button_seaechPanel_leaveQ";
            this.button_seaechPanel_leaveQ.Size = new System.Drawing.Size(133, 36);
            this.button_seaechPanel_leaveQ.TabIndex = 8;
            this.button_seaechPanel_leaveQ.Text = "取消掛號";
            this.button_seaechPanel_leaveQ.UseVisualStyleBackColor = true;
            this.button_seaechPanel_leaveQ.Click += new System.EventHandler(this.button_seaechPanel_leaveQ_Click);
            // 
            // button_enterQueue
            // 
            this.button_enterQueue.Location = new System.Drawing.Point(11, 435);
            this.button_enterQueue.Name = "button_enterQueue";
            this.button_enterQueue.Size = new System.Drawing.Size(133, 36);
            this.button_enterQueue.TabIndex = 6;
            this.button_enterQueue.Text = "掛號 / 查詢輪候";
            this.button_enterQueue.UseVisualStyleBackColor = true;
            this.button_enterQueue.Click += new System.EventHandler(this.button_enterQueue_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button_seaechPanel_leaveQ);
            this.groupBox1.Controls.Add(this.button_enterQueue);
            this.groupBox1.Controls.Add(this.searchPatientInputPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 486);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "掛號";
            // 
            // searchPatientInputPanel1
            // 
            this.searchPatientInputPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchPatientInputPanel1.Location = new System.Drawing.Point(4, 47);
            this.searchPatientInputPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchPatientInputPanel1.Name = "searchPatientInputPanel1";
            this.searchPatientInputPanel1.Size = new System.Drawing.Size(289, 380);
            this.searchPatientInputPanel1.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_changeMOIC_reset);
            this.groupBox2.Controls.Add(this.button_changeMOIC);
            this.groupBox2.Controls.Add(this.button_NextPat_reset);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.comboBox_changeMOIC_MOIC);
            this.groupBox2.Controls.Add(this.textBox_changeMOIC_patId);
            this.groupBox2.Controls.Add(this.textBox_piorityCons_patId);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.button_piorityCons);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBox_NextPat_MOIC);
            this.groupBox2.Controls.Add(this.button_callNext);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(317, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 486);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // button_changeMOIC_reset
            // 
            this.button_changeMOIC_reset.Location = new System.Drawing.Point(155, 428);
            this.button_changeMOIC_reset.Name = "button_changeMOIC_reset";
            this.button_changeMOIC_reset.Size = new System.Drawing.Size(138, 43);
            this.button_changeMOIC_reset.TabIndex = 27;
            this.button_changeMOIC_reset.Text = "重置";
            this.button_changeMOIC_reset.UseVisualStyleBackColor = true;
            this.button_changeMOIC_reset.Click += new System.EventHandler(this.button_changeMOIC_reset_Click);
            // 
            // button_changeMOIC
            // 
            this.button_changeMOIC.Location = new System.Drawing.Point(11, 428);
            this.button_changeMOIC.Name = "button_changeMOIC";
            this.button_changeMOIC.Size = new System.Drawing.Size(138, 43);
            this.button_changeMOIC.TabIndex = 26;
            this.button_changeMOIC.Text = "確定";
            this.button_changeMOIC.UseVisualStyleBackColor = true;
            this.button_changeMOIC.Click += new System.EventHandler(this.button_changeMOIC_Click);
            // 
            // button_NextPat_reset
            // 
            this.button_NextPat_reset.Location = new System.Drawing.Point(155, 234);
            this.button_NextPat_reset.Name = "button_NextPat_reset";
            this.button_NextPat_reset.Size = new System.Drawing.Size(138, 43);
            this.button_NextPat_reset.TabIndex = 25;
            this.button_NextPat_reset.Text = "重置";
            this.button_NextPat_reset.UseVisualStyleBackColor = true;
            this.button_NextPat_reset.Click += new System.EventHandler(this.button_NextPat_reset_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 383);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 23;
            this.label8.Text = "醫生: ";
            // 
            // comboBox_changeMOIC_MOIC
            // 
            this.comboBox_changeMOIC_MOIC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_changeMOIC_MOIC.FormattingEnabled = true;
            this.comboBox_changeMOIC_MOIC.Location = new System.Drawing.Point(62, 380);
            this.comboBox_changeMOIC_MOIC.Name = "comboBox_changeMOIC_MOIC";
            this.comboBox_changeMOIC_MOIC.Size = new System.Drawing.Size(231, 28);
            this.comboBox_changeMOIC_MOIC.TabIndex = 22;
            // 
            // textBox_changeMOIC_patId
            // 
            this.textBox_changeMOIC_patId.Location = new System.Drawing.Point(94, 339);
            this.textBox_changeMOIC_patId.Name = "textBox_changeMOIC_patId";
            this.textBox_changeMOIC_patId.Size = new System.Drawing.Size(199, 26);
            this.textBox_changeMOIC_patId.TabIndex = 21;
            // 
            // textBox_piorityCons_patId
            // 
            this.textBox_piorityCons_patId.Location = new System.Drawing.Point(94, 202);
            this.textBox_piorityCons_patId.Name = "textBox_piorityCons_patId";
            this.textBox_piorityCons_patId.Size = new System.Drawing.Size(199, 26);
            this.textBox_piorityCons_patId.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 342);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "病人編號: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 29);
            this.label6.TabIndex = 17;
            this.label6.Text = "更改主診醫生";
            // 
            // button_piorityCons
            // 
            this.button_piorityCons.Location = new System.Drawing.Point(11, 234);
            this.button_piorityCons.Name = "button_piorityCons";
            this.button_piorityCons.Size = new System.Drawing.Size(138, 43);
            this.button_piorityCons.TabIndex = 16;
            this.button_piorityCons.Text = "確定";
            this.button_piorityCons.UseVisualStyleBackColor = true;
            this.button_piorityCons.Click += new System.EventHandler(this.button_piorityCons_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "病人編號: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(249, 60);
            this.label4.TabIndex = 13;
            this.label4.Text = "按「下一位」以根據登記順序叫名\r\n或\r\n輸入病人編號作優先診治";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "醫生: ";
            // 
            // comboBox_NextPat_MOIC
            // 
            this.comboBox_NextPat_MOIC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_NextPat_MOIC.FormattingEnabled = true;
            this.comboBox_NextPat_MOIC.Location = new System.Drawing.Point(62, 47);
            this.comboBox_NextPat_MOIC.Name = "comboBox_NextPat_MOIC";
            this.comboBox_NextPat_MOIC.Size = new System.Drawing.Size(231, 28);
            this.comboBox_NextPat_MOIC.TabIndex = 11;
            // 
            // button_callNext
            // 
            this.button_callNext.Location = new System.Drawing.Point(11, 150);
            this.button_callNext.Name = "button_callNext";
            this.button_callNext.Size = new System.Drawing.Size(282, 43);
            this.button_callNext.TabIndex = 10;
            this.button_callNext.Text = "下一位";
            this.button_callNext.UseVisualStyleBackColor = true;
            this.button_callNext.Click += new System.EventHandler(this.button_callNext_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "叫名";
            // 
            // waitingList1
            // 
            this.waitingList1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitingList1.Location = new System.Drawing.Point(628, 12);
            this.waitingList1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.waitingList1.Name = "waitingList1";
            this.waitingList1.Size = new System.Drawing.Size(605, 486);
            this.waitingList1.TabIndex = 11;
            // 
            // Staff_QueuingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 514);
            this.Controls.Add(this.waitingList1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Staff_QueuingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Staff_QueuingForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_seaechPanel_leaveQ;
        private SearchPatientInputPanel searchPatientInputPanel1;
        private System.Windows.Forms.Button button_enterQueue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_NextPat_MOIC;
        private System.Windows.Forms.Button button_callNext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_changeMOIC_patId;
        private System.Windows.Forms.TextBox textBox_piorityCons_patId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_piorityCons;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_changeMOIC_reset;
        private System.Windows.Forms.Button button_changeMOIC;
        private System.Windows.Forms.Button button_NextPat_reset;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox_changeMOIC_MOIC;
        private WaitingList waitingList1;
    }
}