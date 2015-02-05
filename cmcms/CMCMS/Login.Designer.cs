namespace CMCMS
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_userName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_clinicId = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.button_reset = new System.Windows.Forms.Button();
            this.button_login = new System.Windows.Forms.Button();
            this.button_patSys = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_role = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "登入名稱:";
            // 
            // textBox_userName
            // 
            this.textBox_userName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_userName.Location = new System.Drawing.Point(95, 6);
            this.textBox_userName.Name = "textBox_userName";
            this.textBox_userName.Size = new System.Drawing.Size(99, 26);
            this.textBox_userName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "@";
            // 
            // comboBox_clinicId
            // 
            this.comboBox_clinicId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_clinicId.FormattingEnabled = true;
            this.comboBox_clinicId.Location = new System.Drawing.Point(231, 6);
            this.comboBox_clinicId.Name = "comboBox_clinicId";
            this.comboBox_clinicId.Size = new System.Drawing.Size(112, 28);
            this.comboBox_clinicId.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "密碼: ";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(95, 76);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(248, 26);
            this.textBox_password.TabIndex = 4;
            this.textBox_password.UseSystemPasswordChar = true;
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(16, 108);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(75, 33);
            this.button_reset.TabIndex = 5;
            this.button_reset.Text = "重置";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(268, 108);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(75, 33);
            this.button_login.TabIndex = 7;
            this.button_login.Text = "登入";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // button_patSys
            // 
            this.button_patSys.Location = new System.Drawing.Point(131, 108);
            this.button_patSys.Name = "button_patSys";
            this.button_patSys.Size = new System.Drawing.Size(94, 33);
            this.button_patSys.TabIndex = 6;
            this.button_patSys.Text = "病人系統";
            this.button_patSys.UseVisualStyleBackColor = true;
            this.button_patSys.Click += new System.EventHandler(this.button_patSys_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "身份: ";
            // 
            // comboBox_role
            // 
            this.comboBox_role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_role.FormattingEnabled = true;
            this.comboBox_role.Location = new System.Drawing.Point(95, 40);
            this.comboBox_role.Name = "comboBox_role";
            this.comboBox_role.Size = new System.Drawing.Size(248, 28);
            this.comboBox_role.TabIndex = 3;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 154);
            this.Controls.Add(this.comboBox_role);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_patSys);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_clinicId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_userName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_userName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_clinicId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Button button_patSys;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_role;
    }
}