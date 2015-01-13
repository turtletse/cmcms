namespace CMCMS
{
    partial class UserRegistration
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_userId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_chiName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_engName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_regNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_cmfPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_clinic = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox_role = new System.Windows.Forms.ComboBox();
            this.checkBox_isSuspended = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_isSuspended);
            this.groupBox1.Controls.Add(this.comboBox_role);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.comboBox_clinic);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox_cmfPassword);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_password);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_regNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_engName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_chiName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_userId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(691, 136);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用戶資料";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "用戶名稱: ";
            // 
            // textBox_userId
            // 
            this.textBox_userId.Location = new System.Drawing.Point(93, 29);
            this.textBox_userId.Name = "textBox_userId";
            this.textBox_userId.Size = new System.Drawing.Size(100, 26);
            this.textBox_userId.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "中文姓名: ";
            // 
            // textBox_chiName
            // 
            this.textBox_chiName.Location = new System.Drawing.Point(286, 29);
            this.textBox_chiName.Name = "textBox_chiName";
            this.textBox_chiName.Size = new System.Drawing.Size(100, 26);
            this.textBox_chiName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(392, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "英文姓名: ";
            // 
            // textBox_engName
            // 
            this.textBox_engName.Location = new System.Drawing.Point(479, 29);
            this.textBox_engName.Name = "textBox_engName";
            this.textBox_engName.Size = new System.Drawing.Size(198, 26);
            this.textBox_engName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "中醫註冊編號: ";
            // 
            // textBox_regNo
            // 
            this.textBox_regNo.Location = new System.Drawing.Point(125, 60);
            this.textBox_regNo.Name = "textBox_regNo";
            this.textBox_regNo.Size = new System.Drawing.Size(100, 26);
            this.textBox_regNo.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(231, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "密碼: ";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(286, 60);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(149, 26);
            this.textBox_password.TabIndex = 9;
            this.textBox_password.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(441, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "確認密碼: ";
            // 
            // textBox_cmfPassword
            // 
            this.textBox_cmfPassword.Location = new System.Drawing.Point(528, 60);
            this.textBox_cmfPassword.Name = "textBox_cmfPassword";
            this.textBox_cmfPassword.Size = new System.Drawing.Size(149, 26);
            this.textBox_cmfPassword.TabIndex = 11;
            this.textBox_cmfPassword.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "診所代號: ";
            // 
            // comboBox_clinic
            // 
            this.comboBox_clinic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_clinic.FormattingEnabled = true;
            this.comboBox_clinic.Location = new System.Drawing.Point(93, 95);
            this.comboBox_clinic.Name = "comboBox_clinic";
            this.comboBox_clinic.Size = new System.Drawing.Size(132, 28);
            this.comboBox_clinic.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(231, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "身份: ";
            // 
            // comboBox_role
            // 
            this.comboBox_role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_role.FormattingEnabled = true;
            this.comboBox_role.Location = new System.Drawing.Point(286, 95);
            this.comboBox_role.Name = "comboBox_role";
            this.comboBox_role.Size = new System.Drawing.Size(149, 28);
            this.comboBox_role.TabIndex = 15;
            // 
            // checkBox_isSuspended
            // 
            this.checkBox_isSuspended.AutoSize = true;
            this.checkBox_isSuspended.Location = new System.Drawing.Point(445, 97);
            this.checkBox_isSuspended.Name = "checkBox_isSuspended";
            this.checkBox_isSuspended.Size = new System.Drawing.Size(60, 24);
            this.checkBox_isSuspended.TabIndex = 16;
            this.checkBox_isSuspended.Text = "停用";
            this.checkBox_isSuspended.UseVisualStyleBackColor = true;
            // 
            // UserRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserRegistration";
            this.Size = new System.Drawing.Size(701, 144);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_cmfPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_regNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_engName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_chiName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_userId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_role;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox_clinic;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox_isSuspended;
    }
}
