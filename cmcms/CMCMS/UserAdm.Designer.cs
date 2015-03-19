namespace CMCMS
{
    partial class UserAdm
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
            this.button_newUser_reset = new System.Windows.Forms.Button();
            this.button_newUser = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_newUser = new System.Windows.Forms.TabPage();
            this.userRegistration_newUser = new CMCMS.UserRegistration();
            this.tabPage_amdUserData = new System.Windows.Forms.TabPage();
            this.userRegistration_amdUser = new CMCMS.UserRegistration();
            this.button_amdUser = new System.Windows.Forms.Button();
            this.button_amdUser_reset = new System.Windows.Forms.Button();
            this.comboBox_amdUser_userId = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage_amdRole = new System.Windows.Forms.TabPage();
            this.button_amdRole_reset = new System.Windows.Forms.Button();
            this.button_amdRole_delete = new System.Windows.Forms.Button();
            this.button_amdRole_add = new System.Windows.Forms.Button();
            this.comboBox_amdRole_role = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox_amdRole_clinic = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.listBox_amdRole_grantedClinicRole = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_amdRole_userId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_amdRole_user = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage_newUser.SuspendLayout();
            this.tabPage_amdUserData.SuspendLayout();
            this.tabPage_amdRole.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "新增用戶";
            // 
            // button_newUser_reset
            // 
            this.button_newUser_reset.Location = new System.Drawing.Point(11, 189);
            this.button_newUser_reset.Name = "button_newUser_reset";
            this.button_newUser_reset.Size = new System.Drawing.Size(97, 42);
            this.button_newUser_reset.TabIndex = 2;
            this.button_newUser_reset.Text = "重置";
            this.button_newUser_reset.UseVisualStyleBackColor = true;
            this.button_newUser_reset.Click += new System.EventHandler(this.button_newUser_reset_Click);
            // 
            // button_newUser
            // 
            this.button_newUser.Location = new System.Drawing.Point(605, 189);
            this.button_newUser.Name = "button_newUser";
            this.button_newUser.Size = new System.Drawing.Size(97, 42);
            this.button_newUser.TabIndex = 3;
            this.button_newUser.Text = "確定";
            this.button_newUser.UseVisualStyleBackColor = true;
            this.button_newUser.Click += new System.EventHandler(this.button_newUser_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_newUser);
            this.tabControl1.Controls.Add(this.tabPage_amdUserData);
            this.tabControl1.Controls.Add(this.tabPage_amdRole);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(741, 327);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage_newUser
            // 
            this.tabPage_newUser.Controls.Add(this.userRegistration_newUser);
            this.tabPage_newUser.Controls.Add(this.label1);
            this.tabPage_newUser.Controls.Add(this.button_newUser);
            this.tabPage_newUser.Controls.Add(this.button_newUser_reset);
            this.tabPage_newUser.Location = new System.Drawing.Point(4, 29);
            this.tabPage_newUser.Name = "tabPage_newUser";
            this.tabPage_newUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_newUser.Size = new System.Drawing.Size(733, 294);
            this.tabPage_newUser.TabIndex = 0;
            this.tabPage_newUser.Text = "新增用戶";
            this.tabPage_newUser.UseVisualStyleBackColor = true;
            this.tabPage_newUser.Enter += new System.EventHandler(this.tabPage_newUser_Enter);
            // 
            // userRegistration_newUser
            // 
            this.userRegistration_newUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userRegistration_newUser.Location = new System.Drawing.Point(11, 37);
            this.userRegistration_newUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userRegistration_newUser.Name = "userRegistration_newUser";
            this.userRegistration_newUser.Size = new System.Drawing.Size(701, 144);
            this.userRegistration_newUser.TabIndex = 4;
            // 
            // tabPage_amdUserData
            // 
            this.tabPage_amdUserData.Controls.Add(this.userRegistration_amdUser);
            this.tabPage_amdUserData.Controls.Add(this.button_amdUser);
            this.tabPage_amdUserData.Controls.Add(this.button_amdUser_reset);
            this.tabPage_amdUserData.Controls.Add(this.comboBox_amdUser_userId);
            this.tabPage_amdUserData.Controls.Add(this.label3);
            this.tabPage_amdUserData.Controls.Add(this.label2);
            this.tabPage_amdUserData.Location = new System.Drawing.Point(4, 29);
            this.tabPage_amdUserData.Name = "tabPage_amdUserData";
            this.tabPage_amdUserData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_amdUserData.Size = new System.Drawing.Size(733, 294);
            this.tabPage_amdUserData.TabIndex = 1;
            this.tabPage_amdUserData.Text = "查詢 / 更改用戶資料";
            this.tabPage_amdUserData.UseVisualStyleBackColor = true;
            this.tabPage_amdUserData.Enter += new System.EventHandler(this.tabPage_amdUserData_Enter);
            // 
            // userRegistration_amdUser
            // 
            this.userRegistration_amdUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userRegistration_amdUser.Location = new System.Drawing.Point(14, 77);
            this.userRegistration_amdUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userRegistration_amdUser.Name = "userRegistration_amdUser";
            this.userRegistration_amdUser.Size = new System.Drawing.Size(701, 144);
            this.userRegistration_amdUser.TabIndex = 7;
            // 
            // button_amdUser
            // 
            this.button_amdUser.Location = new System.Drawing.Point(608, 229);
            this.button_amdUser.Name = "button_amdUser";
            this.button_amdUser.Size = new System.Drawing.Size(97, 42);
            this.button_amdUser.TabIndex = 6;
            this.button_amdUser.Text = "確定";
            this.button_amdUser.UseVisualStyleBackColor = true;
            this.button_amdUser.Click += new System.EventHandler(this.button_amdUser_Click);
            // 
            // button_amdUser_reset
            // 
            this.button_amdUser_reset.Location = new System.Drawing.Point(14, 229);
            this.button_amdUser_reset.Name = "button_amdUser_reset";
            this.button_amdUser_reset.Size = new System.Drawing.Size(97, 42);
            this.button_amdUser_reset.TabIndex = 5;
            this.button_amdUser_reset.Text = "重置";
            this.button_amdUser_reset.UseVisualStyleBackColor = true;
            this.button_amdUser_reset.Click += new System.EventHandler(this.button_amdUser_reset_Click);
            // 
            // comboBox_amdUser_userId
            // 
            this.comboBox_amdUser_userId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_amdUser_userId.FormattingEnabled = true;
            this.comboBox_amdUser_userId.Location = new System.Drawing.Point(90, 41);
            this.comboBox_amdUser_userId.Name = "comboBox_amdUser_userId";
            this.comboBox_amdUser_userId.Size = new System.Drawing.Size(396, 28);
            this.comboBox_amdUser_userId.TabIndex = 2;
            this.comboBox_amdUser_userId.SelectedIndexChanged += new System.EventHandler(this.comboBox_amdUser_userId_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "用戶名稱:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "查詢 / 更改用戶資料";
            // 
            // tabPage_amdRole
            // 
            this.tabPage_amdRole.Controls.Add(this.button_amdRole_reset);
            this.tabPage_amdRole.Controls.Add(this.button_amdRole_delete);
            this.tabPage_amdRole.Controls.Add(this.button_amdRole_add);
            this.tabPage_amdRole.Controls.Add(this.comboBox_amdRole_role);
            this.tabPage_amdRole.Controls.Add(this.label9);
            this.tabPage_amdRole.Controls.Add(this.comboBox_amdRole_clinic);
            this.tabPage_amdRole.Controls.Add(this.label8);
            this.tabPage_amdRole.Controls.Add(this.listBox_amdRole_grantedClinicRole);
            this.tabPage_amdRole.Controls.Add(this.label7);
            this.tabPage_amdRole.Controls.Add(this.textBox_amdRole_userId);
            this.tabPage_amdRole.Controls.Add(this.label6);
            this.tabPage_amdRole.Controls.Add(this.comboBox_amdRole_user);
            this.tabPage_amdRole.Controls.Add(this.label4);
            this.tabPage_amdRole.Controls.Add(this.label5);
            this.tabPage_amdRole.Location = new System.Drawing.Point(4, 29);
            this.tabPage_amdRole.Name = "tabPage_amdRole";
            this.tabPage_amdRole.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_amdRole.Size = new System.Drawing.Size(733, 294);
            this.tabPage_amdRole.TabIndex = 2;
            this.tabPage_amdRole.Text = "查詢 / 更改用戶身份";
            this.tabPage_amdRole.UseVisualStyleBackColor = true;
            this.tabPage_amdRole.Enter += new System.EventHandler(this.tabPage_amdRole_Enter);
            // 
            // button_amdRole_reset
            // 
            this.button_amdRole_reset.Location = new System.Drawing.Point(604, 229);
            this.button_amdRole_reset.Name = "button_amdRole_reset";
            this.button_amdRole_reset.Size = new System.Drawing.Size(85, 41);
            this.button_amdRole_reset.TabIndex = 18;
            this.button_amdRole_reset.Text = "重置";
            this.button_amdRole_reset.UseVisualStyleBackColor = true;
            this.button_amdRole_reset.Click += new System.EventHandler(this.button_amdRole_reset_Click);
            // 
            // button_amdRole_delete
            // 
            this.button_amdRole_delete.Location = new System.Drawing.Point(270, 126);
            this.button_amdRole_delete.Name = "button_amdRole_delete";
            this.button_amdRole_delete.Size = new System.Drawing.Size(85, 41);
            this.button_amdRole_delete.TabIndex = 17;
            this.button_amdRole_delete.Text = "移除";
            this.button_amdRole_delete.UseVisualStyleBackColor = true;
            this.button_amdRole_delete.Click += new System.EventHandler(this.button_amdRole_delete_Click);
            // 
            // button_amdRole_add
            // 
            this.button_amdRole_add.Location = new System.Drawing.Point(503, 147);
            this.button_amdRole_add.Name = "button_amdRole_add";
            this.button_amdRole_add.Size = new System.Drawing.Size(85, 41);
            this.button_amdRole_add.TabIndex = 16;
            this.button_amdRole_add.Text = "增加";
            this.button_amdRole_add.UseVisualStyleBackColor = true;
            this.button_amdRole_add.Click += new System.EventHandler(this.button_amdRole_add_Click);
            // 
            // comboBox_amdRole_role
            // 
            this.comboBox_amdRole_role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_amdRole_role.FormattingEnabled = true;
            this.comboBox_amdRole_role.Location = new System.Drawing.Point(503, 113);
            this.comboBox_amdRole_role.Name = "comboBox_amdRole_role";
            this.comboBox_amdRole_role.Size = new System.Drawing.Size(186, 28);
            this.comboBox_amdRole_role.TabIndex = 15;
            this.comboBox_amdRole_role.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox_amdRole_role_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(416, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "身份: ";
            // 
            // comboBox_amdRole_clinic
            // 
            this.comboBox_amdRole_clinic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_amdRole_clinic.FormattingEnabled = true;
            this.comboBox_amdRole_clinic.Location = new System.Drawing.Point(503, 82);
            this.comboBox_amdRole_clinic.Name = "comboBox_amdRole_clinic";
            this.comboBox_amdRole_clinic.Size = new System.Drawing.Size(186, 28);
            this.comboBox_amdRole_clinic.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(416, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "診所代號: ";
            // 
            // listBox_amdRole_grantedClinicRole
            // 
            this.listBox_amdRole_grantedClinicRole.FormattingEnabled = true;
            this.listBox_amdRole_grantedClinicRole.ItemHeight = 20;
            this.listBox_amdRole_grantedClinicRole.Location = new System.Drawing.Point(98, 126);
            this.listBox_amdRole_grantedClinicRole.Name = "listBox_amdRole_grantedClinicRole";
            this.listBox_amdRole_grantedClinicRole.Size = new System.Drawing.Size(166, 144);
            this.listBox_amdRole_grantedClinicRole.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "診所/身份: ";
            // 
            // textBox_amdRole_userId
            // 
            this.textBox_amdRole_userId.Location = new System.Drawing.Point(94, 82);
            this.textBox_amdRole_userId.Name = "textBox_amdRole_userId";
            this.textBox_amdRole_userId.ReadOnly = true;
            this.textBox_amdRole_userId.Size = new System.Drawing.Size(170, 26);
            this.textBox_amdRole_userId.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "用戶名稱: ";
            // 
            // comboBox_amdRole_user
            // 
            this.comboBox_amdRole_user.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_amdRole_user.FormattingEnabled = true;
            this.comboBox_amdRole_user.Location = new System.Drawing.Point(90, 41);
            this.comboBox_amdRole_user.Name = "comboBox_amdRole_user";
            this.comboBox_amdRole_user.Size = new System.Drawing.Size(396, 28);
            this.comboBox_amdRole_user.TabIndex = 6;
            this.comboBox_amdRole_user.SelectedIndexChanged += new System.EventHandler(this.comboBox_amdRole_user_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "用戶名稱:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(235, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "查詢 / 更改用戶身份";
            // 
            // UserAdm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 353);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "UserAdm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用戶管理";
            this.tabControl1.ResumeLayout(false);
            this.tabPage_newUser.ResumeLayout(false);
            this.tabPage_newUser.PerformLayout();
            this.tabPage_amdUserData.ResumeLayout(false);
            this.tabPage_amdUserData.PerformLayout();
            this.tabPage_amdRole.ResumeLayout(false);
            this.tabPage_amdRole.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_newUser_reset;
        private System.Windows.Forms.Button button_newUser;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_newUser;
        private System.Windows.Forms.TabPage tabPage_amdUserData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_amdUser;
        private System.Windows.Forms.Button button_amdUser_reset;
        private System.Windows.Forms.ComboBox comboBox_amdUser_userId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage_amdRole;
        private UserRegistration userRegistration_newUser;
        private UserRegistration userRegistration_amdUser;
        private System.Windows.Forms.ComboBox comboBox_amdRole_user;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_amdRole_delete;
        private System.Windows.Forms.Button button_amdRole_add;
        private System.Windows.Forms.ComboBox comboBox_amdRole_role;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox_amdRole_clinic;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listBox_amdRole_grantedClinicRole;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_amdRole_userId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_amdRole_reset;
    }
}