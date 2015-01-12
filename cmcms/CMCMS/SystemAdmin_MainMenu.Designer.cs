namespace CMCMS
{
    partial class SystemAdmin_MainMenu
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
            this.button_NewPatient = new System.Windows.Forms.Button();
            this.button_amdPatData = new System.Windows.Forms.Button();
            this.button_drugAdm = new System.Windows.Forms.Button();
            this.button_newClinic = new System.Windows.Forms.Button();
            this.button_amdClinic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "系統管理 - 主目錄";
            // 
            // button_NewPatient
            // 
            this.button_NewPatient.Location = new System.Drawing.Point(19, 64);
            this.button_NewPatient.Name = "button_NewPatient";
            this.button_NewPatient.Size = new System.Drawing.Size(221, 51);
            this.button_NewPatient.TabIndex = 4;
            this.button_NewPatient.Text = "新增病人";
            this.button_NewPatient.UseVisualStyleBackColor = true;
            this.button_NewPatient.Click += new System.EventHandler(this.button_NewPatient_Click);
            // 
            // button_amdPatData
            // 
            this.button_amdPatData.Location = new System.Drawing.Point(19, 121);
            this.button_amdPatData.Name = "button_amdPatData";
            this.button_amdPatData.Size = new System.Drawing.Size(221, 51);
            this.button_amdPatData.TabIndex = 5;
            this.button_amdPatData.Text = "更改病人資料";
            this.button_amdPatData.UseVisualStyleBackColor = true;
            this.button_amdPatData.Click += new System.EventHandler(this.button_amdPatData_Click);
            // 
            // button_drugAdm
            // 
            this.button_drugAdm.Location = new System.Drawing.Point(19, 178);
            this.button_drugAdm.Name = "button_drugAdm";
            this.button_drugAdm.Size = new System.Drawing.Size(221, 51);
            this.button_drugAdm.TabIndex = 6;
            this.button_drugAdm.Text = "藥物管理";
            this.button_drugAdm.UseVisualStyleBackColor = true;
            this.button_drugAdm.Click += new System.EventHandler(this.button_drugAdm_Click);
            // 
            // button_newClinic
            // 
            this.button_newClinic.Location = new System.Drawing.Point(19, 235);
            this.button_newClinic.Name = "button_newClinic";
            this.button_newClinic.Size = new System.Drawing.Size(221, 51);
            this.button_newClinic.TabIndex = 7;
            this.button_newClinic.Text = "新増診所";
            this.button_newClinic.UseVisualStyleBackColor = true;
            this.button_newClinic.Click += new System.EventHandler(this.button_newClinic_Click);
            // 
            // button_amdClinic
            // 
            this.button_amdClinic.Location = new System.Drawing.Point(19, 292);
            this.button_amdClinic.Name = "button_amdClinic";
            this.button_amdClinic.Size = new System.Drawing.Size(221, 51);
            this.button_amdClinic.TabIndex = 8;
            this.button_amdClinic.Text = "更改診所資料";
            this.button_amdClinic.UseVisualStyleBackColor = true;
            this.button_amdClinic.Click += new System.EventHandler(this.button_amdClinic_Click);
            // 
            // SystemAdmin_MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 548);
            this.Controls.Add(this.button_amdClinic);
            this.Controls.Add(this.button_newClinic);
            this.Controls.Add(this.button_drugAdm);
            this.Controls.Add(this.button_amdPatData);
            this.Controls.Add(this.button_NewPatient);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SystemAdmin_MainMenu";
            this.Text = "主目錄";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_NewPatient;
        private System.Windows.Forms.Button button_amdPatData;
        private System.Windows.Forms.Button button_drugAdm;
        private System.Windows.Forms.Button button_newClinic;
        private System.Windows.Forms.Button button_amdClinic;

    }
}