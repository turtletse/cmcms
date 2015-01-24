﻿namespace CMCMS
{
    partial class ConsultationForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_pat_isG6PD = new System.Windows.Forms.CheckBox();
            this.textBox_pat_drugAllergy = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox_pat_isPregnant = new System.Windows.Forms.CheckBox();
            this.textBox_pat_IDNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_pat_age = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_pat_DOB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_pat_sex = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_pat_engName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_pat_chiName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_patId = new System.Windows.Forms.TextBox();
            this.button_finish = new System.Windows.Forms.Button();
            this.button_conLater = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_exam = new System.Windows.Forms.TextBox();
            this.button_finalSave = new System.Windows.Forms.Button();
            this.button_tmpSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader_firstRecDtm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_dx = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_exam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_diff = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_pres = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_change_exam = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_diff = new System.Windows.Forms.TextBox();
            this.button_change_diff = new System.Windows.Forms.Button();
            this.textBox_dx = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button_dx = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox_presId = new System.Windows.Forms.ComboBox();
            this.button_change_pres = new System.Windows.Forms.Button();
            this.button_add_pres = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_drRmk = new System.Windows.Forms.TextBox();
            this.button_add_drRmk = new System.Windows.Forms.Button();
            this.button_use_previous = new System.Windows.Forms.Button();
            this.groupBox_sickLeaveCert = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_sickLeaveNDays = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dateTimePicker_sickLeaveStart = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.dateTimePicker_sickLeaveEnd = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_consCert = new System.Windows.Forms.Button();
            this.button_pregCert = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox_sickLeaveCert.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_patId);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.checkBox_pat_isG6PD);
            this.groupBox1.Controls.Add(this.textBox_pat_drugAllergy);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.checkBox_pat_isPregnant);
            this.groupBox1.Controls.Add(this.textBox_pat_IDNo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_pat_age);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_pat_DOB);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_pat_sex);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_pat_engName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_pat_chiName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 226);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "病人資料";
            // 
            // checkBox_pat_isG6PD
            // 
            this.checkBox_pat_isG6PD.AutoSize = true;
            this.checkBox_pat_isG6PD.Enabled = false;
            this.checkBox_pat_isG6PD.Location = new System.Drawing.Point(357, 147);
            this.checkBox_pat_isG6PD.Name = "checkBox_pat_isG6PD";
            this.checkBox_pat_isG6PD.Size = new System.Drawing.Size(124, 24);
            this.checkBox_pat_isG6PD.TabIndex = 15;
            this.checkBox_pat_isG6PD.Text = "G6PD/蠶豆症";
            this.checkBox_pat_isG6PD.UseVisualStyleBackColor = true;
            // 
            // textBox_pat_drugAllergy
            // 
            this.textBox_pat_drugAllergy.Location = new System.Drawing.Point(93, 183);
            this.textBox_pat_drugAllergy.Name = "textBox_pat_drugAllergy";
            this.textBox_pat_drugAllergy.ReadOnly = true;
            this.textBox_pat_drugAllergy.Size = new System.Drawing.Size(425, 26);
            this.textBox_pat_drugAllergy.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "藥物敏感: ";
            // 
            // checkBox_pat_isPregnant
            // 
            this.checkBox_pat_isPregnant.AutoSize = true;
            this.checkBox_pat_isPregnant.Location = new System.Drawing.Point(458, 107);
            this.checkBox_pat_isPregnant.Name = "checkBox_pat_isPregnant";
            this.checkBox_pat_isPregnant.Size = new System.Drawing.Size(60, 24);
            this.checkBox_pat_isPregnant.TabIndex = 12;
            this.checkBox_pat_isPregnant.Text = "懷孕";
            this.checkBox_pat_isPregnant.UseVisualStyleBackColor = true;
            // 
            // textBox_pat_IDNo
            // 
            this.textBox_pat_IDNo.Location = new System.Drawing.Point(145, 108);
            this.textBox_pat_IDNo.Name = "textBox_pat_IDNo";
            this.textBox_pat_IDNo.ReadOnly = true;
            this.textBox_pat_IDNo.Size = new System.Drawing.Size(141, 26);
            this.textBox_pat_IDNo.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "身份證/護照號碼: ";
            // 
            // textBox_pat_age
            // 
            this.textBox_pat_age.Location = new System.Drawing.Point(296, 145);
            this.textBox_pat_age.Name = "textBox_pat_age";
            this.textBox_pat_age.ReadOnly = true;
            this.textBox_pat_age.Size = new System.Drawing.Size(47, 26);
            this.textBox_pat_age.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(241, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "年齡: ";
            // 
            // textBox_pat_DOB
            // 
            this.textBox_pat_DOB.Location = new System.Drawing.Point(93, 145);
            this.textBox_pat_DOB.Name = "textBox_pat_DOB";
            this.textBox_pat_DOB.ReadOnly = true;
            this.textBox_pat_DOB.Size = new System.Drawing.Size(142, 26);
            this.textBox_pat_DOB.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "出生日期: ";
            // 
            // textBox_pat_sex
            // 
            this.textBox_pat_sex.Location = new System.Drawing.Point(357, 108);
            this.textBox_pat_sex.Name = "textBox_pat_sex";
            this.textBox_pat_sex.ReadOnly = true;
            this.textBox_pat_sex.Size = new System.Drawing.Size(36, 26);
            this.textBox_pat_sex.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "性別: ";
            // 
            // textBox_pat_engName
            // 
            this.textBox_pat_engName.Location = new System.Drawing.Point(306, 73);
            this.textBox_pat_engName.Name = "textBox_pat_engName";
            this.textBox_pat_engName.ReadOnly = true;
            this.textBox_pat_engName.Size = new System.Drawing.Size(212, 26);
            this.textBox_pat_engName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "(英文): ";
            // 
            // textBox_pat_chiName
            // 
            this.textBox_pat_chiName.Location = new System.Drawing.Point(103, 73);
            this.textBox_pat_chiName.Name = "textBox_pat_chiName";
            this.textBox_pat_chiName.ReadOnly = true;
            this.textBox_pat_chiName.Size = new System.Drawing.Size(132, 26);
            this.textBox_pat_chiName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名(中文): ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "病人編號: ";
            // 
            // textBox_patId
            // 
            this.textBox_patId.Location = new System.Drawing.Point(103, 35);
            this.textBox_patId.Name = "textBox_patId";
            this.textBox_patId.ReadOnly = true;
            this.textBox_patId.Size = new System.Drawing.Size(132, 26);
            this.textBox_patId.TabIndex = 17;
            // 
            // button_finish
            // 
            this.button_finish.Location = new System.Drawing.Point(1270, 735);
            this.button_finish.Name = "button_finish";
            this.button_finish.Size = new System.Drawing.Size(142, 49);
            this.button_finish.TabIndex = 1;
            this.button_finish.Text = "完成診症";
            this.button_finish.UseVisualStyleBackColor = true;
            // 
            // button_conLater
            // 
            this.button_conLater.Location = new System.Drawing.Point(904, 491);
            this.button_conLater.Name = "button_conLater";
            this.button_conLater.Size = new System.Drawing.Size(142, 49);
            this.button_conLater.TabIndex = 2;
            this.button_conLater.Text = "稍後再診";
            this.button_conLater.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "病徵: ";
            // 
            // textBox_exam
            // 
            this.textBox_exam.Location = new System.Drawing.Point(93, 30);
            this.textBox_exam.Multiline = true;
            this.textBox_exam.Name = "textBox_exam";
            this.textBox_exam.ReadOnly = true;
            this.textBox_exam.Size = new System.Drawing.Size(258, 126);
            this.textBox_exam.TabIndex = 4;
            // 
            // button_finalSave
            // 
            this.button_finalSave.Location = new System.Drawing.Point(756, 491);
            this.button_finalSave.Name = "button_finalSave";
            this.button_finalSave.Size = new System.Drawing.Size(142, 49);
            this.button_finalSave.TabIndex = 5;
            this.button_finalSave.Text = "確定無誤並儲存";
            this.button_finalSave.UseVisualStyleBackColor = true;
            // 
            // button_tmpSave
            // 
            this.button_tmpSave.Location = new System.Drawing.Point(608, 491);
            this.button_tmpSave.Name = "button_tmpSave";
            this.button_tmpSave.Size = new System.Drawing.Size(142, 49);
            this.button_tmpSave.TabIndex = 6;
            this.button_tmpSave.Text = "暫存";
            this.button_tmpSave.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_use_previous);
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Location = new System.Drawing.Point(555, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(857, 226);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "病歷";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_firstRecDtm,
            this.columnHeader_dx,
            this.columnHeader_exam,
            this.columnHeader_diff,
            this.columnHeader_pres});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(6, 25);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(845, 160);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_firstRecDtm
            // 
            this.columnHeader_firstRecDtm.Text = "日期 / 時間";
            this.columnHeader_firstRecDtm.Width = 136;
            // 
            // columnHeader_dx
            // 
            this.columnHeader_dx.Text = "診斷";
            this.columnHeader_dx.Width = 92;
            // 
            // columnHeader_exam
            // 
            this.columnHeader_exam.Text = "病徵";
            this.columnHeader_exam.Width = 82;
            // 
            // columnHeader_diff
            // 
            this.columnHeader_diff.Text = "辨症";
            this.columnHeader_diff.Width = 88;
            // 
            // columnHeader_pres
            // 
            this.columnHeader_pres.Text = "處方簡要";
            this.columnHeader_pres.Width = 441;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_add_drRmk);
            this.groupBox3.Controls.Add(this.textBox_drRmk);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.button_conLater);
            this.groupBox3.Controls.Add(this.button_tmpSave);
            this.groupBox3.Controls.Add(this.button_finalSave);
            this.groupBox3.Controls.Add(this.button_add_pres);
            this.groupBox3.Controls.Add(this.button_change_pres);
            this.groupBox3.Controls.Add(this.comboBox_presId);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.button_dx);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.textBox_dx);
            this.groupBox3.Controls.Add(this.button_change_diff);
            this.groupBox3.Controls.Add(this.textBox_diff);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.button_change_exam);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.textBox_exam);
            this.groupBox3.Location = new System.Drawing.Point(12, 244);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1052, 546);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "是次診症紀錄";
            // 
            // button_change_exam
            // 
            this.button_change_exam.Location = new System.Drawing.Point(357, 33);
            this.button_change_exam.Name = "button_change_exam";
            this.button_change_exam.Size = new System.Drawing.Size(142, 49);
            this.button_change_exam.TabIndex = 7;
            this.button_change_exam.Text = "修改";
            this.button_change_exam.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 174);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "辨症: ";
            // 
            // textBox_diff
            // 
            this.textBox_diff.Location = new System.Drawing.Point(93, 171);
            this.textBox_diff.Multiline = true;
            this.textBox_diff.Name = "textBox_diff";
            this.textBox_diff.ReadOnly = true;
            this.textBox_diff.Size = new System.Drawing.Size(258, 126);
            this.textBox_diff.TabIndex = 9;
            // 
            // button_change_diff
            // 
            this.button_change_diff.Location = new System.Drawing.Point(357, 174);
            this.button_change_diff.Name = "button_change_diff";
            this.button_change_diff.Size = new System.Drawing.Size(142, 49);
            this.button_change_diff.TabIndex = 10;
            this.button_change_diff.Text = "修改";
            this.button_change_diff.UseVisualStyleBackColor = true;
            // 
            // textBox_dx
            // 
            this.textBox_dx.Location = new System.Drawing.Point(93, 320);
            this.textBox_dx.Multiline = true;
            this.textBox_dx.Name = "textBox_dx";
            this.textBox_dx.ReadOnly = true;
            this.textBox_dx.Size = new System.Drawing.Size(258, 126);
            this.textBox_dx.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 323);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 20);
            this.label11.TabIndex = 12;
            this.label11.Text = "診斷: ";
            // 
            // button_dx
            // 
            this.button_dx.Location = new System.Drawing.Point(357, 323);
            this.button_dx.Name = "button_dx";
            this.button_dx.Size = new System.Drawing.Size(142, 49);
            this.button_dx.TabIndex = 13;
            this.button_dx.Text = "修改";
            this.button_dx.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(545, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 20);
            this.label12.TabIndex = 14;
            this.label12.Text = "處方: ";
            // 
            // comboBox_presId
            // 
            this.comboBox_presId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_presId.FormattingEnabled = true;
            this.comboBox_presId.Location = new System.Drawing.Point(600, 30);
            this.comboBox_presId.Name = "comboBox_presId";
            this.comboBox_presId.Size = new System.Drawing.Size(217, 28);
            this.comboBox_presId.TabIndex = 15;
            // 
            // button_change_pres
            // 
            this.button_change_pres.Location = new System.Drawing.Point(823, 29);
            this.button_change_pres.Name = "button_change_pres";
            this.button_change_pres.Size = new System.Drawing.Size(75, 28);
            this.button_change_pres.TabIndex = 16;
            this.button_change_pres.Text = "修改";
            this.button_change_pres.UseVisualStyleBackColor = true;
            // 
            // button_add_pres
            // 
            this.button_add_pres.Location = new System.Drawing.Point(904, 29);
            this.button_add_pres.Name = "button_add_pres";
            this.button_add_pres.Size = new System.Drawing.Size(75, 28);
            this.button_add_pres.TabIndex = 17;
            this.button_add_pres.Text = "新增";
            this.button_add_pres.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(545, 171);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 20);
            this.label13.TabIndex = 18;
            this.label13.Text = "醫囑: ";
            // 
            // textBox_drRmk
            // 
            this.textBox_drRmk.Location = new System.Drawing.Point(600, 171);
            this.textBox_drRmk.Multiline = true;
            this.textBox_drRmk.Name = "textBox_drRmk";
            this.textBox_drRmk.Size = new System.Drawing.Size(298, 126);
            this.textBox_drRmk.TabIndex = 19;
            // 
            // button_add_drRmk
            // 
            this.button_add_drRmk.Location = new System.Drawing.Point(904, 174);
            this.button_add_drRmk.Name = "button_add_drRmk";
            this.button_add_drRmk.Size = new System.Drawing.Size(142, 49);
            this.button_add_drRmk.TabIndex = 20;
            this.button_add_drRmk.Text = "加入預設項目";
            this.button_add_drRmk.UseVisualStyleBackColor = true;
            // 
            // button_use_previous
            // 
            this.button_use_previous.Location = new System.Drawing.Point(6, 191);
            this.button_use_previous.Name = "button_use_previous";
            this.button_use_previous.Size = new System.Drawing.Size(245, 29);
            this.button_use_previous.TabIndex = 1;
            this.button_use_previous.Text = "使用已選紀錄作藍本";
            this.button_use_previous.UseVisualStyleBackColor = true;
            // 
            // groupBox_sickLeaveCert
            // 
            this.groupBox_sickLeaveCert.Controls.Add(this.button1);
            this.groupBox_sickLeaveCert.Controls.Add(this.label18);
            this.groupBox_sickLeaveCert.Controls.Add(this.dateTimePicker_sickLeaveEnd);
            this.groupBox_sickLeaveCert.Controls.Add(this.label17);
            this.groupBox_sickLeaveCert.Controls.Add(this.dateTimePicker_sickLeaveStart);
            this.groupBox_sickLeaveCert.Controls.Add(this.label16);
            this.groupBox_sickLeaveCert.Controls.Add(this.label15);
            this.groupBox_sickLeaveCert.Controls.Add(this.textBox_sickLeaveNDays);
            this.groupBox_sickLeaveCert.Controls.Add(this.label14);
            this.groupBox_sickLeaveCert.Location = new System.Drawing.Point(1070, 244);
            this.groupBox_sickLeaveCert.Name = "groupBox_sickLeaveCert";
            this.groupBox_sickLeaveCert.Size = new System.Drawing.Size(342, 242);
            this.groupBox_sickLeaveCert.TabIndex = 9;
            this.groupBox_sickLeaveCert.TabStop = false;
            this.groupBox_sickLeaveCert.Text = "病假";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "日數: ";
            // 
            // textBox_sickLeaveNDays
            // 
            this.textBox_sickLeaveNDays.Location = new System.Drawing.Point(61, 35);
            this.textBox_sickLeaveNDays.Name = "textBox_sickLeaveNDays";
            this.textBox_sickLeaveNDays.Size = new System.Drawing.Size(64, 26);
            this.textBox_sickLeaveNDays.TabIndex = 1;
            this.textBox_sickLeaveNDays.Text = "1";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 73);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 20);
            this.label15.TabIndex = 2;
            this.label15.Text = "日期: ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(61, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 20);
            this.label16.TabIndex = 3;
            this.label16.Text = "由(即日)";
            // 
            // dateTimePicker_sickLeaveStart
            // 
            this.dateTimePicker_sickLeaveStart.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker_sickLeaveStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_sickLeaveStart.Location = new System.Drawing.Point(134, 73);
            this.dateTimePicker_sickLeaveStart.Name = "dateTimePicker_sickLeaveStart";
            this.dateTimePicker_sickLeaveStart.Size = new System.Drawing.Size(157, 26);
            this.dateTimePicker_sickLeaveStart.TabIndex = 4;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(61, 111);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 20);
            this.label17.TabIndex = 5;
            this.label17.Text = "至";
            // 
            // dateTimePicker_sickLeaveEnd
            // 
            this.dateTimePicker_sickLeaveEnd.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker_sickLeaveEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_sickLeaveEnd.Location = new System.Drawing.Point(134, 106);
            this.dateTimePicker_sickLeaveEnd.Name = "dateTimePicker_sickLeaveEnd";
            this.dateTimePicker_sickLeaveEnd.Size = new System.Drawing.Size(157, 26);
            this.dateTimePicker_sickLeaveEnd.TabIndex = 6;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(61, 145);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(115, 20);
            this.label18.TabIndex = 7;
            this.label18.Text = "(包括首尾兩天)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(330, 49);
            this.button1.TabIndex = 8;
            this.button1.Text = "確認並發出證明書";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button_consCert
            // 
            this.button_consCert.Location = new System.Drawing.Point(1076, 515);
            this.button_consCert.Name = "button_consCert";
            this.button_consCert.Size = new System.Drawing.Size(330, 49);
            this.button_consCert.TabIndex = 9;
            this.button_consCert.Text = "到診紀錄證明書";
            this.button_consCert.UseVisualStyleBackColor = true;
            // 
            // button_pregCert
            // 
            this.button_pregCert.Location = new System.Drawing.Point(1076, 603);
            this.button_pregCert.Name = "button_pregCert";
            this.button_pregCert.Size = new System.Drawing.Size(330, 49);
            this.button_pregCert.TabIndex = 10;
            this.button_pregCert.Text = "懷孕證明書";
            this.button_pregCert.UseVisualStyleBackColor = true;
            // 
            // ConsultationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 802);
            this.Controls.Add(this.button_pregCert);
            this.Controls.Add(this.button_consCert);
            this.Controls.Add(this.groupBox_sickLeaveCert);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_finish);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "ConsultationForm";
            this.Text = "診症";
            this.Shown += new System.EventHandler(this.ConsultationForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox_sickLeaveCert.ResumeLayout(false);
            this.groupBox_sickLeaveCert.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_pat_isG6PD;
        private System.Windows.Forms.TextBox textBox_pat_drugAllergy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox_pat_isPregnant;
        private System.Windows.Forms.TextBox textBox_pat_IDNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_pat_age;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_pat_DOB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_pat_sex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_pat_engName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_pat_chiName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_patId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_finish;
        private System.Windows.Forms.Button button_conLater;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_exam;
        private System.Windows.Forms.Button button_finalSave;
        private System.Windows.Forms.Button button_tmpSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader_firstRecDtm;
        private System.Windows.Forms.ColumnHeader columnHeader_dx;
        private System.Windows.Forms.ColumnHeader columnHeader_exam;
        private System.Windows.Forms.ColumnHeader columnHeader_diff;
        private System.Windows.Forms.ColumnHeader columnHeader_pres;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_change_exam;
        private System.Windows.Forms.Button button_use_previous;
        private System.Windows.Forms.Button button_add_drRmk;
        private System.Windows.Forms.TextBox textBox_drRmk;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button_add_pres;
        private System.Windows.Forms.Button button_change_pres;
        private System.Windows.Forms.ComboBox comboBox_presId;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button_dx;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_dx;
        private System.Windows.Forms.Button button_change_diff;
        private System.Windows.Forms.TextBox textBox_diff;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox_sickLeaveCert;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dateTimePicker_sickLeaveEnd;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dateTimePicker_sickLeaveStart;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox_sickLeaveNDays;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button_consCert;
        private System.Windows.Forms.Button button_pregCert;
    }
}