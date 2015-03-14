namespace CMCMS
{
    partial class AmdClinicDataForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_clinic = new System.Windows.Forms.ComboBox();
            this.button_select = new System.Windows.Forms.Button();
            this.clinicRegistration1 = new CMCMS.ClinicRegistration();
            this.button_reset = new System.Windows.Forms.Button();
            this.button_updateClinic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "更改診所資料";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "診所代號: ";
            // 
            // comboBox_clinic
            // 
            this.comboBox_clinic.FormattingEnabled = true;
            this.comboBox_clinic.Location = new System.Drawing.Point(100, 55);
            this.comboBox_clinic.Name = "comboBox_clinic";
            this.comboBox_clinic.Size = new System.Drawing.Size(121, 28);
            this.comboBox_clinic.TabIndex = 6;
            // 
            // button_select
            // 
            this.button_select.Location = new System.Drawing.Point(227, 55);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(75, 28);
            this.button_select.TabIndex = 7;
            this.button_select.Text = "選擇";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // clinicRegistration1
            // 
            this.clinicRegistration1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clinicRegistration1.Location = new System.Drawing.Point(17, 91);
            this.clinicRegistration1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clinicRegistration1.Name = "clinicRegistration1";
            this.clinicRegistration1.Size = new System.Drawing.Size(689, 204);
            this.clinicRegistration1.TabIndex = 8;
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(17, 303);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(107, 39);
            this.button_reset.TabIndex = 9;
            this.button_reset.Text = "重置";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // button_updateClinic
            // 
            this.button_updateClinic.Location = new System.Drawing.Point(595, 303);
            this.button_updateClinic.Name = "button_updateClinic";
            this.button_updateClinic.Size = new System.Drawing.Size(107, 39);
            this.button_updateClinic.TabIndex = 10;
            this.button_updateClinic.Text = "確定";
            this.button_updateClinic.UseVisualStyleBackColor = true;
            this.button_updateClinic.Click += new System.EventHandler(this.button_updateClinic_Click);
            // 
            // AmdClinicDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 354);
            this.Controls.Add(this.button_updateClinic);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.clinicRegistration1);
            this.Controls.Add(this.button_select);
            this.Controls.Add(this.comboBox_clinic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "AmdClinicDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "更改診所資料";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_clinic;
        private System.Windows.Forms.Button button_select;
        private ClinicRegistration clinicRegistration1;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.Button button_updateClinic;
    }
}