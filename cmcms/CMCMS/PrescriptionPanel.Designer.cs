﻿namespace CMCMS
{
    partial class PrescriptionPanel
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
            this.DGV_selected = new System.Windows.Forms.DataGridView();
            this.button_addFromDSP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_drugInput = new System.Windows.Forms.TextBox();
            this.button_addFromFreeText = new System.Windows.Forms.Button();
            this.Column_Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column_drugId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_drugName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_dosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_unit = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DSP = new CMCMS.DrugSelectionPanel();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_selected)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_selected
            // 
            this.DGV_selected.AllowUserToAddRows = false;
            this.DGV_selected.AllowUserToResizeColumns = false;
            this.DGV_selected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_selected.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Delete,
            this.Column_drugId,
            this.Column_drugName,
            this.Column_dosage,
            this.Column_unit});
            this.DGV_selected.Location = new System.Drawing.Point(1018, 23);
            this.DGV_selected.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DGV_selected.Name = "DGV_selected";
            this.DGV_selected.ShowRowErrors = false;
            this.DGV_selected.Size = new System.Drawing.Size(368, 584);
            this.DGV_selected.TabIndex = 1;
            this.DGV_selected.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_selected_CellClick);
            // 
            // button_addFromDSP
            // 
            this.button_addFromDSP.Location = new System.Drawing.Point(970, 189);
            this.button_addFromDSP.Name = "button_addFromDSP";
            this.button_addFromDSP.Size = new System.Drawing.Size(45, 65);
            this.button_addFromDSP.TabIndex = 2;
            this.button_addFromDSP.Text = ">>";
            this.button_addFromDSP.UseVisualStyleBackColor = true;
            this.button_addFromDSP.Click += new System.EventHandler(this.button_addFromDSP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "輸入檢索 (逗號分隔): ";
            // 
            // textBox_drugInput
            // 
            this.textBox_drugInput.Location = new System.Drawing.Point(177, 405);
            this.textBox_drugInput.Name = "textBox_drugInput";
            this.textBox_drugInput.Size = new System.Drawing.Size(753, 26);
            this.textBox_drugInput.TabIndex = 4;
            // 
            // button_addFromFreeText
            // 
            this.button_addFromFreeText.Location = new System.Drawing.Point(936, 402);
            this.button_addFromFreeText.Name = "button_addFromFreeText";
            this.button_addFromFreeText.Size = new System.Drawing.Size(75, 29);
            this.button_addFromFreeText.TabIndex = 5;
            this.button_addFromFreeText.Text = ">>";
            this.button_addFromFreeText.UseVisualStyleBackColor = true;
            // 
            // Column_Delete
            // 
            this.Column_Delete.HeaderText = "刪除";
            this.Column_Delete.Name = "Column_Delete";
            this.Column_Delete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column_Delete.Text = "X";
            this.Column_Delete.UseColumnTextForButtonValue = true;
            this.Column_Delete.Width = 35;
            // 
            // Column_drugId
            // 
            this.Column_drugId.HeaderText = "藥物編號";
            this.Column_drugId.Name = "Column_drugId";
            this.Column_drugId.ReadOnly = true;
            this.Column_drugId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_drugId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_drugId.Visible = false;
            // 
            // Column_drugName
            // 
            this.Column_drugName.HeaderText = "藥名";
            this.Column_drugName.Name = "Column_drugName";
            this.Column_drugName.ReadOnly = true;
            this.Column_drugName.Width = 150;
            // 
            // Column_dosage
            // 
            this.Column_dosage.HeaderText = "劑量";
            this.Column_dosage.Name = "Column_dosage";
            this.Column_dosage.Width = 70;
            // 
            // Column_unit
            // 
            this.Column_unit.HeaderText = "單位";
            this.Column_unit.MaxDropDownItems = 20;
            this.Column_unit.Name = "Column_unit";
            this.Column_unit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column_unit.Width = 70;
            // 
            // DSP
            // 
            this.DSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DSP.Location = new System.Drawing.Point(6, 14);
            this.DSP.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.DSP.Name = "DSP";
            this.DSP.Size = new System.Drawing.Size(963, 377);
            this.DSP.TabIndex = 0;
            // 
            // PrescriptionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_addFromFreeText);
            this.Controls.Add(this.textBox_drugInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_addFromDSP);
            this.Controls.Add(this.DGV_selected);
            this.Controls.Add(this.DSP);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PrescriptionPanel";
            this.Size = new System.Drawing.Size(1390, 748);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_selected)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DrugSelectionPanel DSP;
        private System.Windows.Forms.DataGridView DGV_selected;
        private System.Windows.Forms.Button button_addFromDSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_drugInput;
        private System.Windows.Forms.Button button_addFromFreeText;
        private System.Windows.Forms.DataGridViewButtonColumn Column_Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_drugId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_drugName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_dosage;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_unit;
    }
}