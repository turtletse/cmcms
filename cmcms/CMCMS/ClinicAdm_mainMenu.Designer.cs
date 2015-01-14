namespace CMCMS
{
    partial class ClinicAdm_mainMenu
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
            this.button_userAdm = new System.Windows.Forms.Button();
            this.button_amdClinic = new System.Windows.Forms.Button();
            this.button_drugAdm = new System.Windows.Forms.Button();
            this.button_amdPatData = new System.Windows.Forms.Button();
            this.button_NewPatient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 31);
            this.label1.TabIndex = 10;
            this.label1.Text = "診所管理 - 主目錄";
            // 
            // button_userAdm
            // 
            this.button_userAdm.Location = new System.Drawing.Point(26, 288);
            this.button_userAdm.Name = "button_userAdm";
            this.button_userAdm.Size = new System.Drawing.Size(221, 51);
            this.button_userAdm.TabIndex = 16;
            this.button_userAdm.Text = "用戶管理";
            this.button_userAdm.UseVisualStyleBackColor = true;
            this.button_userAdm.Click += new System.EventHandler(this.button_userAdm_Click);
            // 
            // button_amdClinic
            // 
            this.button_amdClinic.Location = new System.Drawing.Point(26, 231);
            this.button_amdClinic.Name = "button_amdClinic";
            this.button_amdClinic.Size = new System.Drawing.Size(221, 51);
            this.button_amdClinic.TabIndex = 15;
            this.button_amdClinic.Text = "更改診所資料";
            this.button_amdClinic.UseVisualStyleBackColor = true;
            this.button_amdClinic.Click += new System.EventHandler(this.button_amdClinic_Click);
            // 
            // button_drugAdm
            // 
            this.button_drugAdm.Location = new System.Drawing.Point(26, 174);
            this.button_drugAdm.Name = "button_drugAdm";
            this.button_drugAdm.Size = new System.Drawing.Size(221, 51);
            this.button_drugAdm.TabIndex = 14;
            this.button_drugAdm.Text = "藥物管理";
            this.button_drugAdm.UseVisualStyleBackColor = true;
            this.button_drugAdm.Click += new System.EventHandler(this.button_drugAdm_Click);
            // 
            // button_amdPatData
            // 
            this.button_amdPatData.Location = new System.Drawing.Point(26, 117);
            this.button_amdPatData.Name = "button_amdPatData";
            this.button_amdPatData.Size = new System.Drawing.Size(221, 51);
            this.button_amdPatData.TabIndex = 13;
            this.button_amdPatData.Text = "更改病人資料";
            this.button_amdPatData.UseVisualStyleBackColor = true;
            this.button_amdPatData.Click += new System.EventHandler(this.button_amdPatData_Click);
            // 
            // button_NewPatient
            // 
            this.button_NewPatient.Location = new System.Drawing.Point(26, 60);
            this.button_NewPatient.Name = "button_NewPatient";
            this.button_NewPatient.Size = new System.Drawing.Size(221, 51);
            this.button_NewPatient.TabIndex = 12;
            this.button_NewPatient.Text = "新增病人";
            this.button_NewPatient.UseVisualStyleBackColor = true;
            this.button_NewPatient.Click += new System.EventHandler(this.button_NewPatient_Click);
            // 
            // ClinicAdm_mainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 458);
            this.Controls.Add(this.button_userAdm);
            this.Controls.Add(this.button_amdClinic);
            this.Controls.Add(this.button_drugAdm);
            this.Controls.Add(this.button_amdPatData);
            this.Controls.Add(this.button_NewPatient);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "ClinicAdm_mainMenu";
            this.Text = "主目錄";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClinicAdm_mainMenu_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_userAdm;
        private System.Windows.Forms.Button button_amdClinic;
        private System.Windows.Forms.Button button_drugAdm;
        private System.Windows.Forms.Button button_amdPatData;
        private System.Windows.Forms.Button button_NewPatient;
    }
}