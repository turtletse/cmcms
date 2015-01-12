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
            this.button1 = new System.Windows.Forms.Button();
            this.button_drugAdm = new System.Windows.Forms.Button();
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
            this.label1.Text = "病人系統 - 主目錄";
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(221, 51);
            this.button1.TabIndex = 5;
            this.button1.Text = "更改病人資料";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // SystemAdmin_MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 548);
            this.Controls.Add(this.button_drugAdm);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_drugAdm;

    }
}