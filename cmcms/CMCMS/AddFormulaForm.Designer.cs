﻿namespace CMCMS
{
    partial class AddFormulaForm
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
            this.prescriptionPanel1 = new CMCMS.PrescriptionPanel();
            this.SuspendLayout();
            // 
            // prescriptionPanel1
            // 
            this.prescriptionPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prescriptionPanel1.Location = new System.Drawing.Point(13, 14);
            this.prescriptionPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.prescriptionPanel1.Name = "prescriptionPanel1";
            this.prescriptionPanel1.Size = new System.Drawing.Size(1390, 748);
            this.prescriptionPanel1.TabIndex = 0;
            // 
            // AddFormulaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 643);
            this.Controls.Add(this.prescriptionPanel1);
            this.Name = "AddFormulaForm";
            this.Text = "AddFormulaForm";
            this.ResumeLayout(false);

        }

        #endregion

        private PrescriptionPanel prescriptionPanel1;
    }
}