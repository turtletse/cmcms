namespace CMCMS
{
    partial class DifferentiationResultSelectionForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.button_removeSelected = new System.Windows.Forms.Button();
            this.button_confirm = new System.Windows.Forms.Button();
            this.button_clearSelectedLV = new System.Windows.Forms.Button();
            this.button_reset = new System.Windows.Forms.Button();
            this.button_addFromFreeText = new System.Windows.Forms.Button();
            this.button_addFromListBox = new System.Windows.Forms.Button();
            this.listBox_selectedDiffResult = new System.Windows.Forms.ListBox();
            this.textBox_freeText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_search = new System.Windows.Forms.Button();
            this.textBox_search_keywords = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox_lv3 = new System.Windows.Forms.ListBox();
            this.listBox_lv2 = new System.Windows.Forms.ListBox();
            this.listBox_lv1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(558, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 39;
            this.label6.Text = "已選辨證";
            // 
            // button_removeSelected
            // 
            this.button_removeSelected.Location = new System.Drawing.Point(653, 373);
            this.button_removeSelected.Name = "button_removeSelected";
            this.button_removeSelected.Size = new System.Drawing.Size(85, 40);
            this.button_removeSelected.TabIndex = 38;
            this.button_removeSelected.Text = "刪除";
            this.button_removeSelected.UseVisualStyleBackColor = true;
            this.button_removeSelected.Click += new System.EventHandler(this.button_removeSelected_Click);
            // 
            // button_confirm
            // 
            this.button_confirm.Location = new System.Drawing.Point(744, 373);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(85, 40);
            this.button_confirm.TabIndex = 37;
            this.button_confirm.Text = "確認";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // button_clearSelectedLV
            // 
            this.button_clearSelectedLV.Location = new System.Drawing.Point(562, 373);
            this.button_clearSelectedLV.Name = "button_clearSelectedLV";
            this.button_clearSelectedLV.Size = new System.Drawing.Size(85, 40);
            this.button_clearSelectedLV.TabIndex = 36;
            this.button_clearSelectedLV.Text = "清空";
            this.button_clearSelectedLV.UseVisualStyleBackColor = true;
            this.button_clearSelectedLV.Click += new System.EventHandler(this.button_clearSelectedLV_Click);
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(16, 373);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(85, 40);
            this.button_reset.TabIndex = 35;
            this.button_reset.Text = "重置";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // button_addFromFreeText
            // 
            this.button_addFromFreeText.Location = new System.Drawing.Point(516, 332);
            this.button_addFromFreeText.Name = "button_addFromFreeText";
            this.button_addFromFreeText.Size = new System.Drawing.Size(40, 26);
            this.button_addFromFreeText.TabIndex = 34;
            this.button_addFromFreeText.Text = ">>";
            this.button_addFromFreeText.UseVisualStyleBackColor = true;
            this.button_addFromFreeText.Click += new System.EventHandler(this.button_addFromFreeText_Click);
            // 
            // button_addFromListBox
            // 
            this.button_addFromListBox.Location = new System.Drawing.Point(516, 140);
            this.button_addFromListBox.Name = "button_addFromListBox";
            this.button_addFromListBox.Size = new System.Drawing.Size(40, 77);
            this.button_addFromListBox.TabIndex = 33;
            this.button_addFromListBox.Text = ">>";
            this.button_addFromListBox.UseVisualStyleBackColor = true;
            this.button_addFromListBox.Click += new System.EventHandler(this.button_addFromListBox_Click);
            // 
            // listBox_selectedDiffResult
            // 
            this.listBox_selectedDiffResult.FormattingEnabled = true;
            this.listBox_selectedDiffResult.ItemHeight = 20;
            this.listBox_selectedDiffResult.Location = new System.Drawing.Point(562, 63);
            this.listBox_selectedDiffResult.Name = "listBox_selectedDiffResult";
            this.listBox_selectedDiffResult.Size = new System.Drawing.Size(267, 304);
            this.listBox_selectedDiffResult.TabIndex = 32;
            // 
            // textBox_freeText
            // 
            this.textBox_freeText.Location = new System.Drawing.Point(16, 332);
            this.textBox_freeText.Name = "textBox_freeText";
            this.textBox_freeText.Size = new System.Drawing.Size(494, 26);
            this.textBox_freeText.TabIndex = 31;
            this.textBox_freeText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_freeText_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "文字輸入(分號分隔):";
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(248, 246);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(94, 37);
            this.button_search.TabIndex = 29;
            this.button_search.Text = "檢索";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // textBox_search_keywords
            // 
            this.textBox_search_keywords.Location = new System.Drawing.Point(16, 251);
            this.textBox_search_keywords.Name = "textBox_search_keywords";
            this.textBox_search_keywords.Size = new System.Drawing.Size(226, 26);
            this.textBox_search_keywords.TabIndex = 28;
            this.textBox_search_keywords.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_search_keywords_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "輸入檢索(分號分隔):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "可選辨證";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "分類";
            // 
            // listBox_lv3
            // 
            this.listBox_lv3.FormattingEnabled = true;
            this.listBox_lv3.ItemHeight = 20;
            this.listBox_lv3.Location = new System.Drawing.Point(348, 63);
            this.listBox_lv3.Name = "listBox_lv3";
            this.listBox_lv3.Size = new System.Drawing.Size(162, 224);
            this.listBox_lv3.TabIndex = 24;
            // 
            // listBox_lv2
            // 
            this.listBox_lv2.FormattingEnabled = true;
            this.listBox_lv2.ItemHeight = 20;
            this.listBox_lv2.Location = new System.Drawing.Point(180, 63);
            this.listBox_lv2.Name = "listBox_lv2";
            this.listBox_lv2.Size = new System.Drawing.Size(162, 144);
            this.listBox_lv2.TabIndex = 22;
            this.listBox_lv2.SelectedIndexChanged += new System.EventHandler(this.listBox_lv2_SelectedIndexChanged);
            // 
            // listBox_lv1
            // 
            this.listBox_lv1.FormattingEnabled = true;
            this.listBox_lv1.ItemHeight = 20;
            this.listBox_lv1.Location = new System.Drawing.Point(12, 63);
            this.listBox_lv1.Name = "listBox_lv1";
            this.listBox_lv1.Size = new System.Drawing.Size(162, 144);
            this.listBox_lv1.TabIndex = 21;
            this.listBox_lv1.SelectedIndexChanged += new System.EventHandler(this.listBox_lv1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "從左至右揀選項目:";
            // 
            // DifferentiationResultSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 427);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_removeSelected);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.button_clearSelectedLV);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.button_addFromFreeText);
            this.Controls.Add(this.button_addFromListBox);
            this.Controls.Add(this.listBox_selectedDiffResult);
            this.Controls.Add(this.textBox_freeText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.textBox_search_keywords);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox_lv3);
            this.Controls.Add(this.listBox_lv2);
            this.Controls.Add(this.listBox_lv1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "DifferentiationResultSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "辨證";
            this.Shown += new System.EventHandler(this.DifferentiationResultSelectionForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_removeSelected;
        private System.Windows.Forms.Button button_confirm;
        private System.Windows.Forms.Button button_clearSelectedLV;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.Button button_addFromFreeText;
        private System.Windows.Forms.Button button_addFromListBox;
        private System.Windows.Forms.ListBox listBox_selectedDiffResult;
        private System.Windows.Forms.TextBox textBox_freeText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.TextBox textBox_search_keywords;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox_lv3;
        private System.Windows.Forms.ListBox listBox_lv2;
        private System.Windows.Forms.ListBox listBox_lv1;
        private System.Windows.Forms.Label label1;
    }
}