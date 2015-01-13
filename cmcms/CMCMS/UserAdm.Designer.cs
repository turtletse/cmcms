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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.userRegistration_newUser = new CMCMS.UserRegistration();
            this.tabControl1.SuspendLayout();
            this.tabPage_newUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "新增用戶";
            // 
            // button_newUser_reset
            // 
            this.button_newUser_reset.Location = new System.Drawing.Point(10, 180);
            this.button_newUser_reset.Name = "button_newUser_reset";
            this.button_newUser_reset.Size = new System.Drawing.Size(97, 42);
            this.button_newUser_reset.TabIndex = 2;
            this.button_newUser_reset.Text = "重置";
            this.button_newUser_reset.UseVisualStyleBackColor = true;
            this.button_newUser_reset.Click += new System.EventHandler(this.button_newUser_reset_Click);
            // 
            // button_newUser
            // 
            this.button_newUser.Location = new System.Drawing.Point(604, 180);
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
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1113, 571);
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
            this.tabPage_newUser.Size = new System.Drawing.Size(1105, 538);
            this.tabPage_newUser.TabIndex = 0;
            this.tabPage_newUser.Text = "新增用戶";
            this.tabPage_newUser.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1105, 538);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // userRegistration_newUser
            // 
            this.userRegistration_newUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userRegistration_newUser.Location = new System.Drawing.Point(10, 28);
            this.userRegistration_newUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userRegistration_newUser.Name = "userRegistration_newUser";
            this.userRegistration_newUser.Size = new System.Drawing.Size(701, 144);
            this.userRegistration_newUser.TabIndex = 4;
            // 
            // UserAdm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 595);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "UserAdm";
            this.Text = "用戶管理";
            this.tabControl1.ResumeLayout(false);
            this.tabPage_newUser.ResumeLayout(false);
            this.tabPage_newUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_newUser_reset;
        private System.Windows.Forms.Button button_newUser;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_newUser;
        private System.Windows.Forms.TabPage tabPage2;
        private UserRegistration userRegistration_newUser;
    }
}