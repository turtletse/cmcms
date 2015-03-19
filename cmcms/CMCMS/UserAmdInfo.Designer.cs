namespace CMCMS
{
    partial class UserAmdInfo
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
            this.label2 = new System.Windows.Forms.Label();
            this.button_amdUser = new System.Windows.Forms.Button();
            this.button_amdUser_reset = new System.Windows.Forms.Button();
            this.userRegistration1 = new CMCMS.UserRegistration();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "查詢 / 更改用戶資料";
            // 
            // button_amdUser
            // 
            this.button_amdUser.Location = new System.Drawing.Point(611, 195);
            this.button_amdUser.Name = "button_amdUser";
            this.button_amdUser.Size = new System.Drawing.Size(97, 42);
            this.button_amdUser.TabIndex = 8;
            this.button_amdUser.Text = "確定";
            this.button_amdUser.UseVisualStyleBackColor = true;
            this.button_amdUser.Click += new System.EventHandler(this.button_amdUser_Click);
            // 
            // button_amdUser_reset
            // 
            this.button_amdUser_reset.Location = new System.Drawing.Point(17, 195);
            this.button_amdUser_reset.Name = "button_amdUser_reset";
            this.button_amdUser_reset.Size = new System.Drawing.Size(97, 42);
            this.button_amdUser_reset.TabIndex = 7;
            this.button_amdUser_reset.Text = "重置";
            this.button_amdUser_reset.UseVisualStyleBackColor = true;
            this.button_amdUser_reset.Click += new System.EventHandler(this.button_amdUser_reset_Click);
            // 
            // userRegistration1
            // 
            this.userRegistration1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userRegistration1.Location = new System.Drawing.Point(17, 43);
            this.userRegistration1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userRegistration1.Name = "userRegistration1";
            this.userRegistration1.Size = new System.Drawing.Size(701, 144);
            this.userRegistration1.TabIndex = 9;
            // 
            // UserAmdInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 251);
            this.Controls.Add(this.userRegistration1);
            this.Controls.Add(this.button_amdUser);
            this.Controls.Add(this.button_amdUser_reset);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "UserAmdInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "查詢 / 更改用戶資料";
            this.Shown += new System.EventHandler(this.UserAmdInfo_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_amdUser;
        private System.Windows.Forms.Button button_amdUser_reset;
        private UserRegistration userRegistration1;
    }
}