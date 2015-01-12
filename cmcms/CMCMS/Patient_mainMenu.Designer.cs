namespace CMCMS
{
    partial class Patient_mainMenu
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
            this.button_newPatient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_amdPatientData = new System.Windows.Forms.Button();
            this.button_reg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_newPatient
            // 
            this.button_newPatient.Location = new System.Drawing.Point(18, 102);
            this.button_newPatient.Name = "button_newPatient";
            this.button_newPatient.Size = new System.Drawing.Size(236, 58);
            this.button_newPatient.TabIndex = 0;
            this.button_newPatient.Text = "新登記";
            this.button_newPatient.UseVisualStyleBackColor = true;
            this.button_newPatient.Click += new System.EventHandler(this.button_newPatient_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "病人系統 - 主目錄";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "請選擇服務";
            // 
            // button_amdPatientData
            // 
            this.button_amdPatientData.Location = new System.Drawing.Point(18, 166);
            this.button_amdPatientData.Name = "button_amdPatientData";
            this.button_amdPatientData.Size = new System.Drawing.Size(236, 58);
            this.button_amdPatientData.TabIndex = 3;
            this.button_amdPatientData.Text = "更改資料";
            this.button_amdPatientData.UseVisualStyleBackColor = true;
            this.button_amdPatientData.Click += new System.EventHandler(this.button_amdPatientData_Click);
            // 
            // button_reg
            // 
            this.button_reg.Location = new System.Drawing.Point(18, 230);
            this.button_reg.Name = "button_reg";
            this.button_reg.Size = new System.Drawing.Size(236, 58);
            this.button_reg.TabIndex = 4;
            this.button_reg.Text = "掛號 / 查詢輪候狀況";
            this.button_reg.UseVisualStyleBackColor = true;
            // 
            // Patient_mainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 310);
            this.Controls.Add(this.button_reg);
            this.Controls.Add(this.button_amdPatientData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_newPatient);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Patient_mainMenu";
            this.Text = "主目錄";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_newPatient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_amdPatientData;
        private System.Windows.Forms.Button button_reg;
    }
}