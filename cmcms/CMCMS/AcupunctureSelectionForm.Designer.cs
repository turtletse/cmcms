namespace CMCMS
{
    partial class AcupunctureSelectionForm
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
            this.button_addFromListBox = new System.Windows.Forms.Button();
            this.listBox_selectedAcupuncturePoint = new System.Windows.Forms.ListBox();
            this.button_keyword_search = new System.Windows.Forms.Button();
            this.textBox_search_keywords = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox_lv3 = new System.Windows.Forms.ListBox();
            this.listBox_lv2 = new System.Windows.Forms.ListBox();
            this.listBox_lv1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_code_search = new System.Windows.Forms.Button();
            this.textBox_search_code = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(560, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 58;
            this.label6.Text = "已選穴位";
            // 
            // button_removeSelected
            // 
            this.button_removeSelected.Location = new System.Drawing.Point(655, 375);
            this.button_removeSelected.Name = "button_removeSelected";
            this.button_removeSelected.Size = new System.Drawing.Size(85, 40);
            this.button_removeSelected.TabIndex = 57;
            this.button_removeSelected.Text = "刪除";
            this.button_removeSelected.UseVisualStyleBackColor = true;
            this.button_removeSelected.Click += new System.EventHandler(this.button_removeSelected_Click);
            // 
            // button_confirm
            // 
            this.button_confirm.Location = new System.Drawing.Point(746, 375);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(85, 40);
            this.button_confirm.TabIndex = 56;
            this.button_confirm.Text = "確認";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // button_clearSelectedLV
            // 
            this.button_clearSelectedLV.Location = new System.Drawing.Point(564, 375);
            this.button_clearSelectedLV.Name = "button_clearSelectedLV";
            this.button_clearSelectedLV.Size = new System.Drawing.Size(85, 40);
            this.button_clearSelectedLV.TabIndex = 55;
            this.button_clearSelectedLV.Text = "清空";
            this.button_clearSelectedLV.UseVisualStyleBackColor = true;
            this.button_clearSelectedLV.Click += new System.EventHandler(this.button_clearSelectedLV_Click);
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(18, 375);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(85, 40);
            this.button_reset.TabIndex = 54;
            this.button_reset.Text = "重置";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // button_addFromListBox
            // 
            this.button_addFromListBox.Location = new System.Drawing.Point(518, 172);
            this.button_addFromListBox.Name = "button_addFromListBox";
            this.button_addFromListBox.Size = new System.Drawing.Size(40, 77);
            this.button_addFromListBox.TabIndex = 52;
            this.button_addFromListBox.Text = ">>";
            this.button_addFromListBox.UseVisualStyleBackColor = true;
            this.button_addFromListBox.Click += new System.EventHandler(this.button_addFromListBox_Click);
            // 
            // listBox_selectedAcupuncturePoint
            // 
            this.listBox_selectedAcupuncturePoint.FormattingEnabled = true;
            this.listBox_selectedAcupuncturePoint.ItemHeight = 20;
            this.listBox_selectedAcupuncturePoint.Location = new System.Drawing.Point(564, 65);
            this.listBox_selectedAcupuncturePoint.Name = "listBox_selectedAcupuncturePoint";
            this.listBox_selectedAcupuncturePoint.Size = new System.Drawing.Size(267, 304);
            this.listBox_selectedAcupuncturePoint.TabIndex = 51;
            // 
            // button_keyword_search
            // 
            this.button_keyword_search.Location = new System.Drawing.Point(250, 271);
            this.button_keyword_search.Name = "button_keyword_search";
            this.button_keyword_search.Size = new System.Drawing.Size(94, 37);
            this.button_keyword_search.TabIndex = 48;
            this.button_keyword_search.Text = "檢索";
            this.button_keyword_search.UseVisualStyleBackColor = true;
            this.button_keyword_search.Click += new System.EventHandler(this.button_keyword_search_Click);
            // 
            // textBox_search_keywords
            // 
            this.textBox_search_keywords.Location = new System.Drawing.Point(18, 276);
            this.textBox_search_keywords.Name = "textBox_search_keywords";
            this.textBox_search_keywords.Size = new System.Drawing.Size(226, 26);
            this.textBox_search_keywords.TabIndex = 47;
            this.textBox_search_keywords.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_search_keywords_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 20);
            this.label4.TabIndex = 46;
            this.label4.Text = "輸入名稱檢索(分號分隔):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 45;
            this.label3.Text = "可選穴位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "經絡";
            // 
            // listBox_lv3
            // 
            this.listBox_lv3.FormattingEnabled = true;
            this.listBox_lv3.ItemHeight = 20;
            this.listBox_lv3.Location = new System.Drawing.Point(350, 65);
            this.listBox_lv3.Name = "listBox_lv3";
            this.listBox_lv3.Size = new System.Drawing.Size(162, 304);
            this.listBox_lv3.TabIndex = 43;
            // 
            // listBox_lv2
            // 
            this.listBox_lv2.FormattingEnabled = true;
            this.listBox_lv2.ItemHeight = 20;
            this.listBox_lv2.Location = new System.Drawing.Point(182, 65);
            this.listBox_lv2.Name = "listBox_lv2";
            this.listBox_lv2.Size = new System.Drawing.Size(162, 184);
            this.listBox_lv2.TabIndex = 42;
            this.listBox_lv2.SelectedIndexChanged += new System.EventHandler(this.listBox_lv2_SelectedIndexChanged);
            // 
            // listBox_lv1
            // 
            this.listBox_lv1.FormattingEnabled = true;
            this.listBox_lv1.ItemHeight = 20;
            this.listBox_lv1.Location = new System.Drawing.Point(14, 65);
            this.listBox_lv1.Name = "listBox_lv1";
            this.listBox_lv1.Size = new System.Drawing.Size(162, 184);
            this.listBox_lv1.TabIndex = 41;
            this.listBox_lv1.SelectedIndexChanged += new System.EventHandler(this.listBox_lv1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "從左至右揀選項目:";
            // 
            // button_code_search
            // 
            this.button_code_search.Location = new System.Drawing.Point(250, 332);
            this.button_code_search.Name = "button_code_search";
            this.button_code_search.Size = new System.Drawing.Size(94, 37);
            this.button_code_search.TabIndex = 61;
            this.button_code_search.Text = "檢索";
            this.button_code_search.UseVisualStyleBackColor = true;
            this.button_code_search.Click += new System.EventHandler(this.button_code_search_Click);
            // 
            // textBox_search_code
            // 
            this.textBox_search_code.Location = new System.Drawing.Point(18, 337);
            this.textBox_search_code.Name = "textBox_search_code";
            this.textBox_search_code.Size = new System.Drawing.Size(226, 26);
            this.textBox_search_code.TabIndex = 60;
            this.textBox_search_code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_search_code_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 20);
            this.label5.TabIndex = 59;
            this.label5.Text = "輸入國際代碼檢索(分號分隔):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(178, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 62;
            this.label7.Text = "身體部位";
            // 
            // AcupunctureSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 427);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button_code_search);
            this.Controls.Add(this.textBox_search_code);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_removeSelected);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.button_clearSelectedLV);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.button_addFromListBox);
            this.Controls.Add(this.listBox_selectedAcupuncturePoint);
            this.Controls.Add(this.button_keyword_search);
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
            this.Name = "AcupunctureSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "針灸穴位選擇";
            this.Shown += new System.EventHandler(this.AcupunctureSelectionForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_removeSelected;
        private System.Windows.Forms.Button button_confirm;
        private System.Windows.Forms.Button button_clearSelectedLV;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.Button button_addFromListBox;
        private System.Windows.Forms.ListBox listBox_selectedAcupuncturePoint;
        private System.Windows.Forms.Button button_keyword_search;
        private System.Windows.Forms.TextBox textBox_search_keywords;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox_lv3;
        private System.Windows.Forms.ListBox listBox_lv2;
        private System.Windows.Forms.ListBox listBox_lv1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_code_search;
        private System.Windows.Forms.TextBox textBox_search_code;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
    }
}