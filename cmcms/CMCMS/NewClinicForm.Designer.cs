namespace CMCMS
{
    partial class NewClinicForm
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
            this.clinicRegistration1 = new CMCMS.ClinicRegistration();
            this.button_reset = new System.Windows.Forms.Button();
            this.button_newClinic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clinicRegistration1
            // 
            this.clinicRegistration1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clinicRegistration1.Location = new System.Drawing.Point(13, 14);
            this.clinicRegistration1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clinicRegistration1.Name = "clinicRegistration1";
            this.clinicRegistration1.Size = new System.Drawing.Size(689, 204);
            this.clinicRegistration1.TabIndex = 0;
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(13, 226);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(107, 39);
            this.button_reset.TabIndex = 1;
            this.button_reset.Text = "重置";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // button_newClinic
            // 
            this.button_newClinic.Location = new System.Drawing.Point(591, 226);
            this.button_newClinic.Name = "button_newClinic";
            this.button_newClinic.Size = new System.Drawing.Size(107, 39);
            this.button_newClinic.TabIndex = 2;
            this.button_newClinic.Text = "確定";
            this.button_newClinic.UseVisualStyleBackColor = true;
            this.button_newClinic.Click += new System.EventHandler(this.button_newClinic_Click);
            // 
            // NewClinicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 278);
            this.Controls.Add(this.button_newClinic);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.clinicRegistration1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "NewClinicForm";
            this.Text = "NewClinicForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ClinicRegistration clinicRegistration1;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.Button button_newClinic;
    }
}