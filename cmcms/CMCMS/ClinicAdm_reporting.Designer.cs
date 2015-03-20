namespace CMCMS
{
    partial class ClinicAdm_reporting
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
            this.label1 = new System.Windows.Forms.Label();
            this.button_clinicConsStatByDay30 = new System.Windows.Forms.Button();
            this.button_recordCert = new System.Windows.Forms.Button();
            this.button_dxStat = new System.Windows.Forms.Button();
            this.button_suspiciousPresList = new System.Windows.Forms.Button();
            this.button_userListing = new System.Windows.Forms.Button();
            this.button_clinicListing = new System.Windows.Forms.Button();
            this.button_drugListing = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 31);
            this.label1.TabIndex = 28;
            this.label1.Text = "列印報告/紀錄目錄";
            // 
            // button_clinicConsStatByDay30
            // 
            this.button_clinicConsStatByDay30.Location = new System.Drawing.Point(12, 110);
            this.button_clinicConsStatByDay30.Name = "button_clinicConsStatByDay30";
            this.button_clinicConsStatByDay30.Size = new System.Drawing.Size(255, 51);
            this.button_clinicConsStatByDay30.TabIndex = 2;
            this.button_clinicConsStatByDay30.Text = "過去30日按日診症數";
            this.button_clinicConsStatByDay30.UseVisualStyleBackColor = true;
            this.button_clinicConsStatByDay30.Click += new System.EventHandler(this.button_clinicConsStatByDay30_Click);
            // 
            // button_recordCert
            // 
            this.button_recordCert.Location = new System.Drawing.Point(12, 53);
            this.button_recordCert.Name = "button_recordCert";
            this.button_recordCert.Size = new System.Drawing.Size(255, 51);
            this.button_recordCert.TabIndex = 1;
            this.button_recordCert.Text = "紀錄 / 證明";
            this.button_recordCert.UseVisualStyleBackColor = true;
            this.button_recordCert.Click += new System.EventHandler(this.button_recordCert_Click);
            // 
            // button_dxStat
            // 
            this.button_dxStat.Location = new System.Drawing.Point(12, 167);
            this.button_dxStat.Name = "button_dxStat";
            this.button_dxStat.Size = new System.Drawing.Size(255, 51);
            this.button_dxStat.TabIndex = 3;
            this.button_dxStat.Text = "過去30日之診斷統計";
            this.button_dxStat.UseVisualStyleBackColor = true;
            this.button_dxStat.Click += new System.EventHandler(this.button_dxStat_Click);
            // 
            // button_suspiciousPresList
            // 
            this.button_suspiciousPresList.Location = new System.Drawing.Point(12, 224);
            this.button_suspiciousPresList.Name = "button_suspiciousPresList";
            this.button_suspiciousPresList.Size = new System.Drawing.Size(255, 51);
            this.button_suspiciousPresList.TabIndex = 4;
            this.button_suspiciousPresList.Text = "懷疑問題處方列表";
            this.button_suspiciousPresList.UseVisualStyleBackColor = true;
            this.button_suspiciousPresList.Click += new System.EventHandler(this.button_suspiciousPresList_Click);
            // 
            // button_userListing
            // 
            this.button_userListing.Location = new System.Drawing.Point(12, 281);
            this.button_userListing.Name = "button_userListing";
            this.button_userListing.Size = new System.Drawing.Size(255, 51);
            this.button_userListing.TabIndex = 5;
            this.button_userListing.Text = "用戶名單";
            this.button_userListing.UseVisualStyleBackColor = true;
            this.button_userListing.Click += new System.EventHandler(this.button_userListing_Click);
            // 
            // button_clinicListing
            // 
            this.button_clinicListing.Location = new System.Drawing.Point(12, 338);
            this.button_clinicListing.Name = "button_clinicListing";
            this.button_clinicListing.Size = new System.Drawing.Size(255, 51);
            this.button_clinicListing.TabIndex = 6;
            this.button_clinicListing.Text = "診所列表";
            this.button_clinicListing.UseVisualStyleBackColor = true;
            this.button_clinicListing.Click += new System.EventHandler(this.button_clinicListing_Click);
            // 
            // button_drugListing
            // 
            this.button_drugListing.Location = new System.Drawing.Point(12, 395);
            this.button_drugListing.Name = "button_drugListing";
            this.button_drugListing.Size = new System.Drawing.Size(255, 51);
            this.button_drugListing.TabIndex = 7;
            this.button_drugListing.Text = "可選用藥物列表";
            this.button_drugListing.UseVisualStyleBackColor = true;
            this.button_drugListing.Click += new System.EventHandler(this.button_drugListing_Click);
            // 
            // ClinicAdm_reporting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 462);
            this.Controls.Add(this.button_drugListing);
            this.Controls.Add(this.button_clinicListing);
            this.Controls.Add(this.button_userListing);
            this.Controls.Add(this.button_suspiciousPresList);
            this.Controls.Add(this.button_dxStat);
            this.Controls.Add(this.button_clinicConsStatByDay30);
            this.Controls.Add(this.button_recordCert);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "ClinicAdm_reporting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "列印報告/紀錄目錄";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_clinicConsStatByDay30;
        private System.Windows.Forms.Button button_recordCert;
        private System.Windows.Forms.Button button_dxStat;
        private System.Windows.Forms.Button button_suspiciousPresList;
        private System.Windows.Forms.Button button_userListing;
        private System.Windows.Forms.Button button_clinicListing;
        private System.Windows.Forms.Button button_drugListing;
    }
}