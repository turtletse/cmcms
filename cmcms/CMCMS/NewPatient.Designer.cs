namespace CMCMS
{
    partial class NewPatient
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
            this.patientRegistration1 = new CMCMS.PatientRegistration();
            this.SuspendLayout();
            // 
            // patientRegistration1
            // 
            this.patientRegistration1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientRegistration1.Location = new System.Drawing.Point(13, 14);
            this.patientRegistration1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.patientRegistration1.Name = "patientRegistration1";
            this.patientRegistration1.Size = new System.Drawing.Size(1086, 654);
            this.patientRegistration1.TabIndex = 0;
            // 
            // NewPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 683);
            this.Controls.Add(this.patientRegistration1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewPatient";
            this.ShowIcon = false;
            this.Text = "NewPatient";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private PatientRegistration patientRegistration1;
    }
}