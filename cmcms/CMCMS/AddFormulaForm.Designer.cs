namespace CMCMS
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
            this.button_addPredefPres = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_presName = new System.Windows.Forms.TextBox();
            this.prescriptionPanel1 = new CMCMS.PrescriptionPanel();
            this.button_addPredefPres_reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_addPredefPres
            // 
            this.button_addPredefPres.Location = new System.Drawing.Point(1275, 627);
            this.button_addPredefPres.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_addPredefPres.Name = "button_addPredefPres";
            this.button_addPredefPres.Size = new System.Drawing.Size(120, 50);
            this.button_addPredefPres.TabIndex = 1;
            this.button_addPredefPres.Text = "新增方劑";
            this.button_addPredefPres.UseVisualStyleBackColor = true;
            this.button_addPredefPres.Click += new System.EventHandler(this.button_addPredefPres_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "新增方劑";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "方劑名稱: ";
            // 
            // textBox_presName
            // 
            this.textBox_presName.Location = new System.Drawing.Point(100, 57);
            this.textBox_presName.Name = "textBox_presName";
            this.textBox_presName.Size = new System.Drawing.Size(256, 26);
            this.textBox_presName.TabIndex = 4;
            // 
            // prescriptionPanel1
            // 
            this.prescriptionPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prescriptionPanel1.Location = new System.Drawing.Point(8, 94);
            this.prescriptionPanel1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.prescriptionPanel1.Name = "prescriptionPanel1";
            this.prescriptionPanel1.Size = new System.Drawing.Size(1397, 596);
            this.prescriptionPanel1.TabIndex = 0;
            // 
            // button_addPredefPres_reset
            // 
            this.button_addPredefPres_reset.Location = new System.Drawing.Point(1151, 627);
            this.button_addPredefPres_reset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_addPredefPres_reset.Name = "button_addPredefPres_reset";
            this.button_addPredefPres_reset.Size = new System.Drawing.Size(120, 50);
            this.button_addPredefPres_reset.TabIndex = 5;
            this.button_addPredefPres_reset.Text = "重置";
            this.button_addPredefPres_reset.UseVisualStyleBackColor = true;
            this.button_addPredefPres_reset.Click += new System.EventHandler(this.button_addPredefPres_reset_Click);
            // 
            // AddFormulaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1414, 707);
            this.Controls.Add(this.button_addPredefPres_reset);
            this.Controls.Add(this.textBox_presName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_addPredefPres);
            this.Controls.Add(this.prescriptionPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "AddFormulaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增方劑";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PrescriptionPanel prescriptionPanel1;
        private System.Windows.Forms.Button button_addPredefPres;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_presName;
        private System.Windows.Forms.Button button_addPredefPres_reset;
    }
}