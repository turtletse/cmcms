namespace CMCMS
{
    partial class UpdateFormulaForm
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
            this.button_updatePredefPres_reset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_updatePredefPres = new System.Windows.Forms.Button();
            this.prescriptionPanel1 = new CMCMS.PrescriptionPanel();
            this.checkBox_isInclDeleted = new System.Windows.Forms.CheckBox();
            this.comboBox_predefPresName = new System.Windows.Forms.ComboBox();
            this.checkBox_rename = new System.Windows.Forms.CheckBox();
            this.textBox_rename = new System.Windows.Forms.TextBox();
            this.checkBox_isDelete = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button_updatePredefPres_reset
            // 
            this.button_updatePredefPres_reset.Location = new System.Drawing.Point(1151, 627);
            this.button_updatePredefPres_reset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_updatePredefPres_reset.Name = "button_updatePredefPres_reset";
            this.button_updatePredefPres_reset.Size = new System.Drawing.Size(120, 50);
            this.button_updatePredefPres_reset.TabIndex = 11;
            this.button_updatePredefPres_reset.Text = "重置";
            this.button_updatePredefPres_reset.UseVisualStyleBackColor = true;
            this.button_updatePredefPres_reset.Click += new System.EventHandler(this.button_updatePredefPres_reset_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "方劑名稱: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "查詢 / 更改方劑";
            // 
            // button_updatePredefPres
            // 
            this.button_updatePredefPres.Location = new System.Drawing.Point(1275, 627);
            this.button_updatePredefPres.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_updatePredefPres.Name = "button_updatePredefPres";
            this.button_updatePredefPres.Size = new System.Drawing.Size(120, 50);
            this.button_updatePredefPres.TabIndex = 7;
            this.button_updatePredefPres.Text = "更改方劑";
            this.button_updatePredefPres.UseVisualStyleBackColor = true;
            this.button_updatePredefPres.Click += new System.EventHandler(this.button_updatePredefPres_Click);
            // 
            // prescriptionPanel1
            // 
            this.prescriptionPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prescriptionPanel1.Location = new System.Drawing.Point(8, 94);
            this.prescriptionPanel1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.prescriptionPanel1.Name = "prescriptionPanel1";
            this.prescriptionPanel1.Size = new System.Drawing.Size(1397, 596);
            this.prescriptionPanel1.TabIndex = 6;
            // 
            // checkBox_isInclDeleted
            // 
            this.checkBox_isInclDeleted.AutoSize = true;
            this.checkBox_isInclDeleted.Location = new System.Drawing.Point(396, 59);
            this.checkBox_isInclDeleted.Name = "checkBox_isInclDeleted";
            this.checkBox_isInclDeleted.Size = new System.Drawing.Size(140, 24);
            this.checkBox_isInclDeleted.TabIndex = 12;
            this.checkBox_isInclDeleted.Text = "包括已刪除方劑";
            this.checkBox_isInclDeleted.UseVisualStyleBackColor = true;
            this.checkBox_isInclDeleted.CheckedChanged += new System.EventHandler(this.checkBox_isInclDeleted_CheckedChanged);
            // 
            // comboBox_predefPresName
            // 
            this.comboBox_predefPresName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_predefPresName.FormattingEnabled = true;
            this.comboBox_predefPresName.Location = new System.Drawing.Point(100, 57);
            this.comboBox_predefPresName.Name = "comboBox_predefPresName";
            this.comboBox_predefPresName.Size = new System.Drawing.Size(290, 28);
            this.comboBox_predefPresName.TabIndex = 13;
            this.comboBox_predefPresName.SelectedIndexChanged += new System.EventHandler(this.comboBox_predefPresName_SelectedIndexChanged);
            // 
            // checkBox_rename
            // 
            this.checkBox_rename.AutoSize = true;
            this.checkBox_rename.Location = new System.Drawing.Point(594, 59);
            this.checkBox_rename.Name = "checkBox_rename";
            this.checkBox_rename.Size = new System.Drawing.Size(92, 24);
            this.checkBox_rename.TabIndex = 15;
            this.checkBox_rename.Text = "更改名稱";
            this.checkBox_rename.UseVisualStyleBackColor = true;
            this.checkBox_rename.CheckedChanged += new System.EventHandler(this.checkBox_rename_CheckedChanged);
            // 
            // textBox_rename
            // 
            this.textBox_rename.Location = new System.Drawing.Point(692, 57);
            this.textBox_rename.Name = "textBox_rename";
            this.textBox_rename.Size = new System.Drawing.Size(317, 26);
            this.textBox_rename.TabIndex = 16;
            // 
            // checkBox_isDelete
            // 
            this.checkBox_isDelete.AutoSize = true;
            this.checkBox_isDelete.Location = new System.Drawing.Point(1151, 59);
            this.checkBox_isDelete.Name = "checkBox_isDelete";
            this.checkBox_isDelete.Size = new System.Drawing.Size(60, 24);
            this.checkBox_isDelete.TabIndex = 17;
            this.checkBox_isDelete.Text = "刪除";
            this.checkBox_isDelete.UseVisualStyleBackColor = true;
            // 
            // UpdateFormulaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1414, 707);
            this.Controls.Add(this.checkBox_isDelete);
            this.Controls.Add(this.textBox_rename);
            this.Controls.Add(this.checkBox_rename);
            this.Controls.Add(this.comboBox_predefPresName);
            this.Controls.Add(this.checkBox_isInclDeleted);
            this.Controls.Add(this.button_updatePredefPres_reset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_updatePredefPres);
            this.Controls.Add(this.prescriptionPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "UpdateFormulaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "查詢 / 更改方劑";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_updatePredefPres_reset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_updatePredefPres;
        private PrescriptionPanel prescriptionPanel1;
        private System.Windows.Forms.CheckBox checkBox_isInclDeleted;
        private System.Windows.Forms.ComboBox comboBox_predefPresName;
        private System.Windows.Forms.CheckBox checkBox_rename;
        private System.Windows.Forms.TextBox textBox_rename;
        private System.Windows.Forms.CheckBox checkBox_isDelete;
    }
}