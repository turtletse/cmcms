﻿namespace CMCMS
{
    partial class Staff_MainMenu
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
            this.button_queuingMgt = new System.Windows.Forms.Button();
            this.button_amdPatData = new System.Windows.Forms.Button();
            this.button_NewPatient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_userAmdInfo = new System.Windows.Forms.Button();
            this.button_reporting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_queuingMgt
            // 
            this.button_queuingMgt.Location = new System.Drawing.Point(21, 169);
            this.button_queuingMgt.Name = "button_queuingMgt";
            this.button_queuingMgt.Size = new System.Drawing.Size(221, 51);
            this.button_queuingMgt.TabIndex = 3;
            this.button_queuingMgt.Text = "掛號 / 候診病人";
            this.button_queuingMgt.UseVisualStyleBackColor = true;
            this.button_queuingMgt.Click += new System.EventHandler(this.button_queuingMgt_Click);
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
            this.label1.TabIndex = 20;
            this.label1.Text = "診所運作 - 主目錄";
            // 
            // button_userAmdInfo
            // 
            this.button_userAmdInfo.Location = new System.Drawing.Point(21, 226);
            this.button_userAmdInfo.Name = "button_userAmdInfo";
            this.button_userAmdInfo.Size = new System.Drawing.Size(221, 51);
            this.button_userAmdInfo.TabIndex = 4;
            this.button_userAmdInfo.Text = "查詢 / 更改用戶資料";
            this.button_userAmdInfo.UseVisualStyleBackColor = true;
            this.button_userAmdInfo.Click += new System.EventHandler(this.button_userAmdInfo_Click);
            // 
            // button_reporting
            // 
            this.button_reporting.Location = new System.Drawing.Point(21, 283);
            this.button_reporting.Name = "button_reporting";
            this.button_reporting.Size = new System.Drawing.Size(221, 51);
            this.button_reporting.TabIndex = 5;
            this.button_reporting.Text = "列印報告/紀錄";
            this.button_reporting.UseVisualStyleBackColor = true;
            this.button_reporting.Click += new System.EventHandler(this.button_reporting_Click);
            // 
            // Staff_MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 355);
            this.Controls.Add(this.button_reporting);
            this.Controls.Add(this.button_userAmdInfo);
            this.Controls.Add(this.button_queuingMgt);
            this.Controls.Add(this.button_amdPatData);
            this.Controls.Add(this.button_NewPatient);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Staff_MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "主目錄";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Staff_MainMenu_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_queuingMgt;
        private System.Windows.Forms.Button button_amdPatData;
        private System.Windows.Forms.Button button_NewPatient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_userAmdInfo;
        private System.Windows.Forms.Button button_reporting;
    }
}