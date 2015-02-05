namespace CMCMS
{
    partial class Doctor_QueuingForm
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
            this.button_NextPat_reset = new System.Windows.Forms.Button();
            this.button_seaechPanel_leaveQ = new System.Windows.Forms.Button();
            this.textBox_piorityCons_patId = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_calledPat = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button_piorityCons = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button_callNext = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button_enterQueue = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchPatientInputPanel1 = new CMCMS.SearchPatientInputPanel();
            this.waitingList1 = new CMCMS.WaitingList();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_NextPat_reset
            // 
            this.button_NextPat_reset.Location = new System.Drawing.Point(155, 280);
            this.button_NextPat_reset.Name = "button_NextPat_reset";
            this.button_NextPat_reset.Size = new System.Drawing.Size(138, 43);
            this.button_NextPat_reset.TabIndex = 25;
            this.button_NextPat_reset.Text = "重置";
            this.button_NextPat_reset.UseVisualStyleBackColor = true;
            this.button_NextPat_reset.Click += new System.EventHandler(this.button_NextPat_reset_Click);
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
            // textBox_piorityCons_patId
            // 
            this.textBox_piorityCons_patId.Location = new System.Drawing.Point(94, 248);
            this.textBox_piorityCons_patId.Name = "textBox_piorityCons_patId";
            this.textBox_piorityCons_patId.Size = new System.Drawing.Size(199, 26);
            this.textBox_piorityCons_patId.TabIndex = 20;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_calledPat);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.button_NextPat_reset);
            this.groupBox2.Controls.Add(this.textBox_piorityCons_patId);
            this.groupBox2.Controls.Add(this.button_piorityCons);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button_callNext);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(318, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 486);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // button_calledPat
            // 
            this.button_calledPat.Location = new System.Drawing.Point(11, 73);
            this.button_calledPat.Name = "button_calledPat";
            this.button_calledPat.Size = new System.Drawing.Size(282, 43);
            this.button_calledPat.TabIndex = 27;
            this.button_calledPat.Text = "已叫名 / 診症中 病人";
            this.button_calledPat.UseVisualStyleBackColor = true;
            this.button_calledPat.Click += new System.EventHandler(this.button_calledPat_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "輸入病人編號作診治";
            // 
            // button_piorityCons
            // 
            this.button_piorityCons.Location = new System.Drawing.Point(11, 280);
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
            this.label5.Location = new System.Drawing.Point(7, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "病人編號: ";
            // 
            // button_callNext
            // 
            this.button_callNext.Location = new System.Drawing.Point(11, 147);
            this.button_callNext.Name = "button_callNext";
            this.button_callNext.Size = new System.Drawing.Size(282, 43);
            this.button_callNext.TabIndex = 10;
            this.button_callNext.Text = "據登記順序叫名";
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
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 486);
            this.groupBox1.TabIndex = 12;
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
            // waitingList1
            // 
            this.waitingList1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitingList1.Location = new System.Drawing.Point(629, 14);
            this.waitingList1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.waitingList1.Name = "waitingList1";
            this.waitingList1.Size = new System.Drawing.Size(605, 486);
            this.waitingList1.TabIndex = 14;
            // 
            // Doctor_QueuingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 514);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.waitingList1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Doctor_QueuingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Doctor_QueuingForm";
            this.Shown += new System.EventHandler(this.Doctor_QueuingForm_Shown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_NextPat_reset;
        private System.Windows.Forms.Button button_seaechPanel_leaveQ;
        private System.Windows.Forms.TextBox textBox_piorityCons_patId;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_piorityCons;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_callNext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_enterQueue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private SearchPatientInputPanel searchPatientInputPanel1;
        private WaitingList waitingList1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_calledPat;
    }
}