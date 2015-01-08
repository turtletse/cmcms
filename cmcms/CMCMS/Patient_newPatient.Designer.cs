namespace CMCMS
{
    partial class Patient_newPatient
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
            this.newPatient1 = new CMCMS.NewPatient();
            this.SuspendLayout();
            // 
            // newPatient1
            // 
            this.newPatient1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPatient1.Location = new System.Drawing.Point(0, 0);
            this.newPatient1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.newPatient1.Name = "newPatient1";
            this.newPatient1.Size = new System.Drawing.Size(1104, 711);
            this.newPatient1.TabIndex = 0;
            // 
            // Patient_newPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 726);
            this.Controls.Add(this.newPatient1);
            this.Name = "Patient_newPatient";
            this.Text = "Patient_newPatient";
            this.ResumeLayout(false);

        }

        #endregion

        private NewPatient newPatient1;
    }
}