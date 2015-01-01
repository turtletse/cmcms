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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_cancelAddSubDrug = new System.Windows.Forms.Button();
            this.button_addSubDrug = new System.Windows.Forms.Button();
            this.textBox_subDrugName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_selectedDrugName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DSP_addSubDrug = new CMCMS.DrugSelectionPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_cancelAddDrug = new System.Windows.Forms.Button();
            this.comboBox_pri_type = new System.Windows.Forms.ComboBox();
            this.button_addDrug = new System.Windows.Forms.Button();
            this.textBox_drugName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_g6pd_contra = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_preg_contra = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.textBox_minDose = new System.Windows.Forms.TextBox();
            this.comboBox_sec_type = new System.Windows.Forms.ComboBox();
            this.comboBox_minDoseUnit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_maxDose = new System.Windows.Forms.TextBox();
            this.comboBox_maxDoseUnit = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1392, 745);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "新增藥物";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Enter += new System.EventHandler(this.tabPage1_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button_cancelAddSubDrug);
            this.groupBox4.Controls.Add(this.button_addSubDrug);
            this.groupBox4.Controls.Add(this.textBox_subDrugName);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.textBox_selectedDrugName);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.DSP_addSubDrug);
            this.groupBox4.Location = new System.Drawing.Point(346, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1040, 733);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "加入子藥項";
            // 
            // button_cancelAddSubDrug
            // 
            this.button_cancelAddSubDrug.Location = new System.Drawing.Point(148, 439);
            this.button_cancelAddSubDrug.Name = "button_cancelAddSubDrug";
            this.button_cancelAddSubDrug.Size = new System.Drawing.Size(116, 40);
            this.button_cancelAddSubDrug.TabIndex = 22;
            this.button_cancelAddSubDrug.Text = "取消";
            this.button_cancelAddSubDrug.UseVisualStyleBackColor = true;
            // 
            // button_addSubDrug
            // 
            this.button_addSubDrug.Location = new System.Drawing.Point(10, 439);
            this.button_addSubDrug.Name = "button_addSubDrug";
            this.button_addSubDrug.Size = new System.Drawing.Size(116, 40);
            this.button_addSubDrug.TabIndex = 21;
            this.button_addSubDrug.Text = "加入子項目";
            this.button_addSubDrug.UseVisualStyleBackColor = true;
            // 
            // textBox_subDrugName
            // 
            this.textBox_subDrugName.Location = new System.Drawing.Point(109, 406);
            this.textBox_subDrugName.Name = "textBox_subDrugName";
            this.textBox_subDrugName.Size = new System.Drawing.Size(137, 26);
            this.textBox_subDrugName.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 409);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "子藥項名稱: ";
            // 
            // textBox_selectedDrugName
            // 
            this.textBox_selectedDrugName.Location = new System.Drawing.Point(109, 370);
            this.textBox_selectedDrugName.Name = "textBox_selectedDrugName";
            this.textBox_selectedDrugName.Size = new System.Drawing.Size(137, 26);
            this.textBox_selectedDrugName.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 373);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "藥項名稱: ";
            // 
            // DSP_addSubDrug
            // 
            this.DSP_addSubDrug.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DSP_addSubDrug.Location = new System.Drawing.Point(7, 27);
            this.DSP_addSubDrug.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DSP_addSubDrug.Name = "DSP_addSubDrug";
            this.DSP_addSubDrug.Size = new System.Drawing.Size(826, 326);
            this.DSP_addSubDrug.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.button_cancelAddDrug);
            this.groupBox3.Controls.Add(this.comboBox_pri_type);
            this.groupBox3.Controls.Add(this.button_addDrug);
            this.groupBox3.Controls.Add(this.textBox_drugName);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.textBox_minDose);
            this.groupBox3.Controls.Add(this.comboBox_sec_type);
            this.groupBox3.Controls.Add(this.comboBox_minDoseUnit);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBox_maxDose);
            this.groupBox3.Controls.Add(this.comboBox_maxDoseUnit);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(334, 733);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "加入藥項";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "藥名: ";
            // 
            // button_cancelAddDrug
            // 
            this.button_cancelAddDrug.Location = new System.Drawing.Point(199, 502);
            this.button_cancelAddDrug.Name = "button_cancelAddDrug";
            this.button_cancelAddDrug.Size = new System.Drawing.Size(116, 40);
            this.button_cancelAddDrug.TabIndex = 21;
            this.button_cancelAddDrug.Text = "取消";
            this.button_cancelAddDrug.UseVisualStyleBackColor = true;
            this.button_cancelAddDrug.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // comboBox_pri_type
            // 
            this.comboBox_pri_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_pri_type.FormattingEnabled = true;
            this.comboBox_pri_type.Location = new System.Drawing.Point(61, 159);
            this.comboBox_pri_type.Name = "comboBox_pri_type";
            this.comboBox_pri_type.Size = new System.Drawing.Size(198, 28);
            this.comboBox_pri_type.TabIndex = 6;
            this.comboBox_pri_type.SelectedIndexChanged += new System.EventHandler(this.comboBox_pri_type_SelectedIndexChanged);
            // 
            // button_addDrug
            // 
            this.button_addDrug.Location = new System.Drawing.Point(10, 502);
            this.button_addDrug.Name = "button_addDrug";
            this.button_addDrug.Size = new System.Drawing.Size(116, 40);
            this.button_addDrug.TabIndex = 20;
            this.button_addDrug.Text = "加入項目";
            this.button_addDrug.UseVisualStyleBackColor = true;
            this.button_addDrug.Click += new System.EventHandler(this.button_addDrug_Click);
            // 
            // textBox_drugName
            // 
            this.textBox_drugName.Location = new System.Drawing.Point(61, 36);
            this.textBox_drugName.Name = "textBox_drugName";
            this.textBox_drugName.Size = new System.Drawing.Size(198, 26);
            this.textBox_drugName.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_g6pd_contra);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.comboBox_preg_contra);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(10, 373);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 123);
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
            this.comboBox_g6pd_contra.Size = new System.Drawing.Size(182, 28);
            this.comboBox_g6pd_contra.TabIndex = 19;
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
            this.comboBox_preg_contra.Size = new System.Drawing.Size(191, 28);
            this.comboBox_preg_contra.TabIndex = 18;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "劑量下限: ";
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
            this.groupBox1.Location = new System.Drawing.Point(10, 244);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 123);
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
            this.checkBox_w6.TabIndex = 17;
            this.checkBox_w6.Text = "淡";
            this.checkBox_w6.UseVisualStyleBackColor = true;
            // 
            // checkBox_w5
            // 
            this.checkBox_w5.AutoSize = true;
            this.checkBox_w5.Location = new System.Drawing.Point(205, 80);
            this.checkBox_w5.Name = "checkBox_w5";
            this.checkBox_w5.Size = new System.Drawing.Size(44, 24);
            this.checkBox_w5.TabIndex = 16;
            this.checkBox_w5.Text = "鹹";
            this.checkBox_w5.UseVisualStyleBackColor = true;
            // 
            // checkBox_w4
            // 
            this.checkBox_w4.AutoSize = true;
            this.checkBox_w4.Location = new System.Drawing.Point(156, 80);
            this.checkBox_w4.Name = "checkBox_w4";
            this.checkBox_w4.Size = new System.Drawing.Size(44, 24);
            this.checkBox_w4.TabIndex = 15;
            this.checkBox_w4.Text = "苦";
            this.checkBox_w4.UseVisualStyleBackColor = true;
            // 
            // checkBox_w3
            // 
            this.checkBox_w3.AutoSize = true;
            this.checkBox_w3.Location = new System.Drawing.Point(106, 80);
            this.checkBox_w3.Name = "checkBox_w3";
            this.checkBox_w3.Size = new System.Drawing.Size(44, 24);
            this.checkBox_w3.TabIndex = 14;
            this.checkBox_w3.Text = "酸";
            this.checkBox_w3.UseVisualStyleBackColor = true;
            // 
            // checkBox_w2
            // 
            this.checkBox_w2.AutoSize = true;
            this.checkBox_w2.Location = new System.Drawing.Point(56, 80);
            this.checkBox_w2.Name = "checkBox_w2";
            this.checkBox_w2.Size = new System.Drawing.Size(44, 24);
            this.checkBox_w2.TabIndex = 13;
            this.checkBox_w2.Text = "甘";
            this.checkBox_w2.UseVisualStyleBackColor = true;
            // 
            // checkBox_w1
            // 
            this.checkBox_w1.AutoSize = true;
            this.checkBox_w1.Location = new System.Drawing.Point(6, 80);
            this.checkBox_w1.Name = "checkBox_w1";
            this.checkBox_w1.Size = new System.Drawing.Size(44, 24);
            this.checkBox_w1.TabIndex = 12;
            this.checkBox_w1.Text = "辛";
            this.checkBox_w1.UseVisualStyleBackColor = true;
            // 
            // checkBox_q4
            // 
            this.checkBox_q4.AutoSize = true;
            this.checkBox_q4.Location = new System.Drawing.Point(252, 25);
            this.checkBox_q4.Name = "checkBox_q4";
            this.checkBox_q4.Size = new System.Drawing.Size(44, 24);
            this.checkBox_q4.TabIndex = 11;
            this.checkBox_q4.Text = "涼";
            this.checkBox_q4.UseVisualStyleBackColor = true;
            // 
            // checkBox_q3
            // 
            this.checkBox_q3.AutoSize = true;
            this.checkBox_q3.Location = new System.Drawing.Point(168, 25);
            this.checkBox_q3.Name = "checkBox_q3";
            this.checkBox_q3.Size = new System.Drawing.Size(44, 24);
            this.checkBox_q3.TabIndex = 10;
            this.checkBox_q3.Text = "溫";
            this.checkBox_q3.UseVisualStyleBackColor = true;
            // 
            // checkBox_q2
            // 
            this.checkBox_q2.AutoSize = true;
            this.checkBox_q2.Location = new System.Drawing.Point(83, 25);
            this.checkBox_q2.Name = "checkBox_q2";
            this.checkBox_q2.Size = new System.Drawing.Size(44, 24);
            this.checkBox_q2.TabIndex = 9;
            this.checkBox_q2.Text = "熱";
            this.checkBox_q2.UseVisualStyleBackColor = true;
            // 
            // checkBox_q1
            // 
            this.checkBox_q1.AutoSize = true;
            this.checkBox_q1.Location = new System.Drawing.Point(6, 25);
            this.checkBox_q1.Name = "checkBox_q1";
            this.checkBox_q1.Size = new System.Drawing.Size(44, 24);
            this.checkBox_q1.TabIndex = 8;
            this.checkBox_q1.Text = "寒";
            this.checkBox_q1.UseVisualStyleBackColor = true;
            // 
            // textBox_minDose
            // 
            this.textBox_minDose.Location = new System.Drawing.Point(93, 78);
            this.textBox_minDose.Name = "textBox_minDose";
            this.textBox_minDose.Size = new System.Drawing.Size(79, 26);
            this.textBox_minDose.TabIndex = 2;
            // 
            // comboBox_sec_type
            // 
            this.comboBox_sec_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_sec_type.FormattingEnabled = true;
            this.comboBox_sec_type.Location = new System.Drawing.Point(77, 200);
            this.comboBox_sec_type.Name = "comboBox_sec_type";
            this.comboBox_sec_type.Size = new System.Drawing.Size(182, 28);
            this.comboBox_sec_type.TabIndex = 7;
            // 
            // comboBox_minDoseUnit
            // 
            this.comboBox_minDoseUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_minDoseUnit.FormattingEnabled = true;
            this.comboBox_minDoseUnit.Location = new System.Drawing.Point(178, 78);
            this.comboBox_minDoseUnit.Name = "comboBox_minDoseUnit";
            this.comboBox_minDoseUnit.Size = new System.Drawing.Size(81, 28);
            this.comboBox_minDoseUnit.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "子藥類: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "劑量上限: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "藥類: ";
            // 
            // textBox_maxDose
            // 
            this.textBox_maxDose.Location = new System.Drawing.Point(93, 118);
            this.textBox_maxDose.Name = "textBox_maxDose";
            this.textBox_maxDose.Size = new System.Drawing.Size(79, 26);
            this.textBox_maxDose.TabIndex = 4;
            // 
            // comboBox_maxDoseUnit
            // 
            this.comboBox_maxDoseUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_maxDoseUnit.FormattingEnabled = true;
            this.comboBox_maxDoseUnit.Location = new System.Drawing.Point(178, 118);
            this.comboBox_maxDoseUnit.Name = "comboBox_maxDoseUnit";
            this.comboBox_maxDoseUnit.Size = new System.Drawing.Size(81, 28);
            this.comboBox_maxDoseUnit.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1392, 745);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "修改藥物資料";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DrugAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 802);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DrugAdmin";
            this.Text = "藥物管理";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.Button button_cancelAddDrug;
        private System.Windows.Forms.Button button_addDrug;
        private System.Windows.Forms.ComboBox comboBox_g6pd_contra;
        private System.Windows.Forms.GroupBox groupBox4;
        private DrugSelectionPanel DSP_addSubDrug;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_selectedDrugName;
        private System.Windows.Forms.Button button_cancelAddSubDrug;
        private System.Windows.Forms.Button button_addSubDrug;
        private System.Windows.Forms.TextBox textBox_subDrugName;
        private System.Windows.Forms.Label label9;

    }
}

