namespace CMCMS
{
    partial class Doctor_MainMenu
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
            this.button_amdPatData = new System.Windows.Forms.Button();
            this.button_NewPatient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_updatePredefPres = new System.Windows.Forms.Button();
            this.button_newPredefPres = new System.Windows.Forms.Button();
            this.button_consultation = new System.Windows.Forms.Button();
            this.button_userAmdInfo = new System.Windows.Forms.Button();
            this.button_recordCert = new System.Windows.Forms.Button();
            this.button_drugListing = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_amdPatData
            // 
            this.button_amdPatData.Location = new System.Drawing.Point(21, 112);
            this.button_amdPatData.Name = "button_amdPatData";
            this.button_amdPatData.Size = new System.Drawing.Size(221, 51);
            this.button_amdPatData.TabIndex = 2;
            this.button_amdPatData.Text = "查詢 / 更改病人資料";
            this.button_amdPatData.UseVisualStyleBackColor = true;
            this.button_amdPatData.Click += new System.EventHandler(this.button_amdPatData_Click);
            // 
            // button_NewPatient
            // 
            this.button_NewPatient.Location = new System.Drawing.Point(21, 55);
            this.button_NewPatient.Name = "button_NewPatient";
            this.button_NewPatient.Size = new System.Drawing.Size(221, 51);
            this.button_NewPatient.TabIndex = 1;
            this.button_NewPatient.Text = "新增病人";
            this.button_NewPatient.UseVisualStyleBackColor = true;
            this.button_NewPatient.Click += new System.EventHandler(this.button_NewPatient_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 31);
            this.label1.TabIndex = 23;
            this.label1.Text = "診所診症 - 主目錄";
            // 
            // button_updatePredefPres
            // 
            this.button_updatePredefPres.Location = new System.Drawing.Point(21, 283);
            this.button_updatePredefPres.Name = "button_updatePredefPres";
            this.button_updatePredefPres.Size = new System.Drawing.Size(221, 51);
            this.button_updatePredefPres.TabIndex = 5;
            this.button_updatePredefPres.Text = "查詢 / 更改方劑";
            this.button_updatePredefPres.UseVisualStyleBackColor = true;
            this.button_updatePredefPres.Click += new System.EventHandler(this.button_updatePredefPres_Click);
            // 
            // button_newPredefPres
            // 
            this.button_newPredefPres.Location = new System.Drawing.Point(21, 226);
            this.button_newPredefPres.Name = "button_newPredefPres";
            this.button_newPredefPres.Size = new System.Drawing.Size(221, 51);
            this.button_newPredefPres.TabIndex = 4;
            this.button_newPredefPres.Text = "新增方劑";
            this.button_newPredefPres.UseVisualStyleBackColor = true;
            this.button_newPredefPres.Click += new System.EventHandler(this.button_newPredefPres_Click);
            // 
            // button_consultation
            // 
            this.button_consultation.Location = new System.Drawing.Point(21, 169);
            this.button_consultation.Name = "button_consultation";
            this.button_consultation.Size = new System.Drawing.Size(221, 51);
            this.button_consultation.TabIndex = 3;
            this.button_consultation.Text = "診症";
            this.button_consultation.UseVisualStyleBackColor = true;
            this.button_consultation.Click += new System.EventHandler(this.button_consultation_Click);
            // 
            // button_userAmdInfo
            // 
            this.button_userAmdInfo.Location = new System.Drawing.Point(21, 340);
            this.button_userAmdInfo.Name = "button_userAmdInfo";
            this.button_userAmdInfo.Size = new System.Drawing.Size(221, 51);
            this.button_userAmdInfo.TabIndex = 6;
            this.button_userAmdInfo.Text = "查詢 / 更改用戶資料";
            this.button_userAmdInfo.UseVisualStyleBackColor = true;
            this.button_userAmdInfo.Click += new System.EventHandler(this.button_userAmdInfo_Click);
            // 
            // button_recordCert
            // 
            this.button_recordCert.Location = new System.Drawing.Point(21, 397);
            this.button_recordCert.Name = "button_recordCert";
            this.button_recordCert.Size = new System.Drawing.Size(221, 51);
            this.button_recordCert.TabIndex = 7;
            this.button_recordCert.Text = "列印紀錄 / 證明";
            this.button_recordCert.UseVisualStyleBackColor = true;
            this.button_recordCert.Click += new System.EventHandler(this.button_recordCert_Click);
            // 
            // button_drugListing
            // 
            this.button_drugListing.Location = new System.Drawing.Point(21, 454);
            this.button_drugListing.Name = "button_drugListing";
            this.button_drugListing.Size = new System.Drawing.Size(221, 51);
            this.button_drugListing.TabIndex = 8;
            this.button_drugListing.Text = "可選用藥物列表";
            this.button_drugListing.UseVisualStyleBackColor = true;
            this.button_drugListing.Click += new System.EventHandler(this.button_drugListing_Click);
            // 
            // Doctor_MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 524);
            this.Controls.Add(this.button_drugListing);
            this.Controls.Add(this.button_recordCert);
            this.Controls.Add(this.button_userAmdInfo);
            this.Controls.Add(this.button_consultation);
            this.Controls.Add(this.button_updatePredefPres);
            this.Controls.Add(this.button_newPredefPres);
            this.Controls.Add(this.button_amdPatData);
            this.Controls.Add(this.button_NewPatient);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Doctor_MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "診症目錄";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Doctor_MainMenu_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_amdPatData;
        private System.Windows.Forms.Button button_NewPatient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_updatePredefPres;
        private System.Windows.Forms.Button button_newPredefPres;
        private System.Windows.Forms.Button button_consultation;
        private System.Windows.Forms.Button button_userAmdInfo;
        private System.Windows.Forms.Button button_recordCert;
        private System.Windows.Forms.Button button_drugListing;
    }
}