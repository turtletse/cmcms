namespace CMCMS
{
    partial class DrugAdmin
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_addDrug = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_g6pd_contra = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_preg_contra = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_w6 = new System.Windows.Forms.CheckBox();
            this.checkBox_w5 = new System.Windows.Forms.CheckBox();
            this.checkBox_w4 = new System.Windows.Forms.CheckBox();
            this.checkBox_w3 = new System.Windows.Forms.CheckBox();
            this.checkBox_w2 = new System.Windows.Forms.CheckBox();
            this.checkBox_w1 = new System.Windows.Forms.CheckBox();
            this.checkBox_q4 = new System.Windows.Forms.CheckBox();
            this.checkBox_q3 = new System.Windows.Forms.CheckBox();
            this.checkBox_q2 = new System.Windows.Forms.CheckBox();
            this.checkBox_q1 = new System.Windows.Forms.CheckBox();
            this.comboBox_sec_type = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_maxDoseUnit = new System.Windows.Forms.ComboBox();
            this.textBox_maxDose = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_minDoseUnit = new System.Windows.Forms.ComboBox();
            this.textBox_minDose = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_drugName = new System.Windows.Forms.TextBox();
            this.comboBox_pri_type = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1400, 778);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button_cancel);
            this.tabPage1.Controls.Add(this.button_addDrug);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.comboBox_sec_type);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.comboBox_maxDoseUnit);
            this.tabPage1.Controls.Add(this.textBox_maxDose);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.comboBox_minDoseUnit);
            this.tabPage1.Controls.Add(this.textBox_minDose);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox_drugName);
            this.tabPage1.Controls.Add(this.comboBox_pri_type);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1392, 745);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "新增藥物";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Enter += new System.EventHandler(this.tabPage1_Enter);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(221, 490);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(116, 40);
            this.button_cancel.TabIndex = 15;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            // 
            // button_addDrug
            // 
            this.button_addDrug.Location = new System.Drawing.Point(32, 490);
            this.button_addDrug.Name = "button_addDrug";
            this.button_addDrug.Size = new System.Drawing.Size(116, 40);
            this.button_addDrug.TabIndex = 14;
            this.button_addDrug.Text = "加入項目";
            this.button_addDrug.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_g6pd_contra);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.comboBox_preg_contra);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(32, 361);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 123);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "禁忌";
            // 
            // comboBox_g6pd_contra
            // 
            this.comboBox_g6pd_contra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_g6pd_contra.FormattingEnabled = true;
            this.comboBox_g6pd_contra.Location = new System.Drawing.Point(67, 73);
            this.comboBox_g6pd_contra.Name = "comboBox_g6pd_contra";
            this.comboBox_g6pd_contra.Size = new System.Drawing.Size(238, 28);
            this.comboBox_g6pd_contra.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "G6PD: ";
            // 
            // comboBox_preg_contra
            // 
            this.comboBox_preg_contra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_preg_contra.FormattingEnabled = true;
            this.comboBox_preg_contra.Location = new System.Drawing.Point(58, 28);
            this.comboBox_preg_contra.Name = "comboBox_preg_contra";
            this.comboBox_preg_contra.Size = new System.Drawing.Size(238, 28);
            this.comboBox_preg_contra.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "孕婦: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_w6);
            this.groupBox1.Controls.Add(this.checkBox_w5);
            this.groupBox1.Controls.Add(this.checkBox_w4);
            this.groupBox1.Controls.Add(this.checkBox_w3);
            this.groupBox1.Controls.Add(this.checkBox_w2);
            this.groupBox1.Controls.Add(this.checkBox_w1);
            this.groupBox1.Controls.Add(this.checkBox_q4);
            this.groupBox1.Controls.Add(this.checkBox_q3);
            this.groupBox1.Controls.Add(this.checkBox_q2);
            this.groupBox1.Controls.Add(this.checkBox_q1);
            this.groupBox1.Location = new System.Drawing.Point(32, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 123);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "性味";
            // 
            // checkBox_w6
            // 
            this.checkBox_w6.AutoSize = true;
            this.checkBox_w6.Location = new System.Drawing.Point(255, 80);
            this.checkBox_w6.Name = "checkBox_w6";
            this.checkBox_w6.Size = new System.Drawing.Size(44, 24);
            this.checkBox_w6.TabIndex = 9;
            this.checkBox_w6.Text = "淡";
            this.checkBox_w6.UseVisualStyleBackColor = true;
            // 
            // checkBox_w5
            // 
            this.checkBox_w5.AutoSize = true;
            this.checkBox_w5.Location = new System.Drawing.Point(205, 80);
            this.checkBox_w5.Name = "checkBox_w5";
            this.checkBox_w5.Size = new System.Drawing.Size(44, 24);
            this.checkBox_w5.TabIndex = 8;
            this.checkBox_w5.Text = "鹹";
            this.checkBox_w5.UseVisualStyleBackColor = true;
            // 
            // checkBox_w4
            // 
            this.checkBox_w4.AutoSize = true;
            this.checkBox_w4.Location = new System.Drawing.Point(156, 80);
            this.checkBox_w4.Name = "checkBox_w4";
            this.checkBox_w4.Size = new System.Drawing.Size(44, 24);
            this.checkBox_w4.TabIndex = 7;
            this.checkBox_w4.Text = "苦";
            this.checkBox_w4.UseVisualStyleBackColor = true;
            // 
            // checkBox_w3
            // 
            this.checkBox_w3.AutoSize = true;
            this.checkBox_w3.Location = new System.Drawing.Point(106, 80);
            this.checkBox_w3.Name = "checkBox_w3";
            this.checkBox_w3.Size = new System.Drawing.Size(44, 24);
            this.checkBox_w3.TabIndex = 6;
            this.checkBox_w3.Text = "酸";
            this.checkBox_w3.UseVisualStyleBackColor = true;
            // 
            // checkBox_w2
            // 
            this.checkBox_w2.AutoSize = true;
            this.checkBox_w2.Location = new System.Drawing.Point(56, 80);
            this.checkBox_w2.Name = "checkBox_w2";
            this.checkBox_w2.Size = new System.Drawing.Size(44, 24);
            this.checkBox_w2.TabIndex = 5;
            this.checkBox_w2.Text = "甘";
            this.checkBox_w2.UseVisualStyleBackColor = true;
            // 
            // checkBox_w1
            // 
            this.checkBox_w1.AutoSize = true;
            this.checkBox_w1.Location = new System.Drawing.Point(6, 80);
            this.checkBox_w1.Name = "checkBox_w1";
            this.checkBox_w1.Size = new System.Drawing.Size(44, 24);
            this.checkBox_w1.TabIndex = 4;
            this.checkBox_w1.Text = "辛";
            this.checkBox_w1.UseVisualStyleBackColor = true;
            // 
            // checkBox_q4
            // 
            this.checkBox_q4.AutoSize = true;
            this.checkBox_q4.Location = new System.Drawing.Point(252, 25);
            this.checkBox_q4.Name = "checkBox_q4";
            this.checkBox_q4.Size = new System.Drawing.Size(44, 24);
            this.checkBox_q4.TabIndex = 3;
            this.checkBox_q4.Text = "涼";
            this.checkBox_q4.UseVisualStyleBackColor = true;
            // 
            // checkBox_q3
            // 
            this.checkBox_q3.AutoSize = true;
            this.checkBox_q3.Location = new System.Drawing.Point(168, 25);
            this.checkBox_q3.Name = "checkBox_q3";
            this.checkBox_q3.Size = new System.Drawing.Size(44, 24);
            this.checkBox_q3.TabIndex = 2;
            this.checkBox_q3.Text = "溫";
            this.checkBox_q3.UseVisualStyleBackColor = true;
            // 
            // checkBox_q2
            // 
            this.checkBox_q2.AutoSize = true;
            this.checkBox_q2.Location = new System.Drawing.Point(83, 25);
            this.checkBox_q2.Name = "checkBox_q2";
            this.checkBox_q2.Size = new System.Drawing.Size(44, 24);
            this.checkBox_q2.TabIndex = 1;
            this.checkBox_q2.Text = "熱";
            this.checkBox_q2.UseVisualStyleBackColor = true;
            // 
            // checkBox_q1
            // 
            this.checkBox_q1.AutoSize = true;
            this.checkBox_q1.Location = new System.Drawing.Point(6, 25);
            this.checkBox_q1.Name = "checkBox_q1";
            this.checkBox_q1.Size = new System.Drawing.Size(44, 24);
            this.checkBox_q1.TabIndex = 0;
            this.checkBox_q1.Text = "寒";
            this.checkBox_q1.UseVisualStyleBackColor = true;
            // 
            // comboBox_sec_type
            // 
            this.comboBox_sec_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_sec_type.FormattingEnabled = true;
            this.comboBox_sec_type.Location = new System.Drawing.Point(99, 188);
            this.comboBox_sec_type.Name = "comboBox_sec_type";
            this.comboBox_sec_type.Size = new System.Drawing.Size(270, 28);
            this.comboBox_sec_type.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "子藥類: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "藥類: ";
            // 
            // comboBox_maxDoseUnit
            // 
            this.comboBox_maxDoseUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_maxDoseUnit.FormattingEnabled = true;
            this.comboBox_maxDoseUnit.Location = new System.Drawing.Point(200, 106);
            this.comboBox_maxDoseUnit.Name = "comboBox_maxDoseUnit";
            this.comboBox_maxDoseUnit.Size = new System.Drawing.Size(81, 28);
            this.comboBox_maxDoseUnit.TabIndex = 8;
            // 
            // textBox_maxDose
            // 
            this.textBox_maxDose.Location = new System.Drawing.Point(115, 106);
            this.textBox_maxDose.Name = "textBox_maxDose";
            this.textBox_maxDose.Size = new System.Drawing.Size(79, 26);
            this.textBox_maxDose.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "劑量上限: ";
            // 
            // comboBox_minDoseUnit
            // 
            this.comboBox_minDoseUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_minDoseUnit.FormattingEnabled = true;
            this.comboBox_minDoseUnit.Location = new System.Drawing.Point(200, 66);
            this.comboBox_minDoseUnit.Name = "comboBox_minDoseUnit";
            this.comboBox_minDoseUnit.Size = new System.Drawing.Size(81, 28);
            this.comboBox_minDoseUnit.TabIndex = 5;
            // 
            // textBox_minDose
            // 
            this.textBox_minDose.Location = new System.Drawing.Point(115, 66);
            this.textBox_minDose.Name = "textBox_minDose";
            this.textBox_minDose.Size = new System.Drawing.Size(79, 26);
            this.textBox_minDose.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "劑量下限: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "藥名: ";
            // 
            // textBox_drugName
            // 
            this.textBox_drugName.Location = new System.Drawing.Point(83, 24);
            this.textBox_drugName.Name = "textBox_drugName";
            this.textBox_drugName.Size = new System.Drawing.Size(270, 26);
            this.textBox_drugName.TabIndex = 1;
            // 
            // comboBox_pri_type
            // 
            this.comboBox_pri_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_pri_type.FormattingEnabled = true;
            this.comboBox_pri_type.Location = new System.Drawing.Point(83, 147);
            this.comboBox_pri_type.Name = "comboBox_pri_type";
            this.comboBox_pri_type.Size = new System.Drawing.Size(270, 28);
            this.comboBox_pri_type.TabIndex = 0;
            this.comboBox_pri_type.SelectedIndexChanged += new System.EventHandler(this.comboBox_pri_type_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1392, 745);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DrugAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 802);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DrugAdmin";
            this.Text = "藥物管理";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBox_pri_type;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_drugName;
        private System.Windows.Forms.TextBox textBox_minDose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_maxDoseUnit;
        private System.Windows.Forms.TextBox textBox_maxDose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_minDoseUnit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox_preg_contra;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_w6;
        private System.Windows.Forms.CheckBox checkBox_w5;
        private System.Windows.Forms.CheckBox checkBox_w4;
        private System.Windows.Forms.CheckBox checkBox_w3;
        private System.Windows.Forms.CheckBox checkBox_w2;
        private System.Windows.Forms.CheckBox checkBox_w1;
        private System.Windows.Forms.CheckBox checkBox_q4;
        private System.Windows.Forms.CheckBox checkBox_q3;
        private System.Windows.Forms.CheckBox checkBox_q2;
        private System.Windows.Forms.CheckBox checkBox_q1;
        private System.Windows.Forms.ComboBox comboBox_sec_type;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_addDrug;
        private System.Windows.Forms.ComboBox comboBox_g6pd_contra;

    }
}

