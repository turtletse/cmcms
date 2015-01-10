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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button_submit = new System.Windows.Forms.Button();
            this.button_reset = new System.Windows.Forms.Button();
            this.patientRegistration1 = new CMCMS.PatientRegistration();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "新登記";
            // 
            // button_submit
            // 
            this.button_submit.Location = new System.Drawing.Point(942, 665);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(129, 44);
            this.button_submit.TabIndex = 3;
            this.button_submit.Text = "登記";
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(23, 665);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(129, 44);
            this.button_reset.TabIndex = 4;
            this.button_reset.Text = "重置";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // patientRegistration1
            // 
            this.patientRegistration1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientRegistration1.Location = new System.Drawing.Point(15, 47);
            this.patientRegistration1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.patientRegistration1.Name = "patientRegistration1";
            this.patientRegistration1.Size = new System.Drawing.Size(1073, 607);
            this.patientRegistration1.TabIndex = 0;
            // 
            // NewPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.button_submit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.patientRegistration1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "NewPatient";
            this.Size = new System.Drawing.Size(1104, 711);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PatientRegistration patientRegistration1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.Button button_reset;
    }
}