namespace CMCMS
{
    partial class ClinicRegistration
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
            this.textBox_clinicId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_chiName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_engName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_addr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_phoneNo = new System.Windows.Forms.TextBox();
            this.checkBox_isSuspended = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_isSuspended);
            this.groupBox1.Controls.Add(this.textBox_phoneNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_addr);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_engName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_chiName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_clinicId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(680, 195);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "診所基本資料";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "診所代號: ";
            // 
            // textBox_clinicId
            // 
            this.textBox_clinicId.Location = new System.Drawing.Point(94, 33);
            this.textBox_clinicId.Name = "textBox_clinicId";
            this.textBox_clinicId.Size = new System.Drawing.Size(108, 26);
            this.textBox_clinicId.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "診所中文名稱: ";
            // 
            // textBox_chiName
            // 
            this.textBox_chiName.Location = new System.Drawing.Point(347, 33);
            this.textBox_chiName.Name = "textBox_chiName";
            this.textBox_chiName.Size = new System.Drawing.Size(319, 26);
            this.textBox_chiName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "診所英文名稱: ";
            // 
            // textBox_engName
            // 
            this.textBox_engName.Location = new System.Drawing.Point(126, 68);
            this.textBox_engName.Name = "textBox_engName";
            this.textBox_engName.Size = new System.Drawing.Size(540, 26);
            this.textBox_engName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "地址: ";
            // 
            // textBox_addr
            // 
            this.textBox_addr.Location = new System.Drawing.Point(62, 101);
            this.textBox_addr.Name = "textBox_addr";
            this.textBox_addr.Size = new System.Drawing.Size(604, 26);
            this.textBox_addr.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "電話(最多3組, 逗號分隔): ";
            // 
            // textBox_phoneNo
            // 
            this.textBox_phoneNo.Location = new System.Drawing.Point(201, 133);
            this.textBox_phoneNo.Name = "textBox_phoneNo";
            this.textBox_phoneNo.Size = new System.Drawing.Size(465, 26);
            this.textBox_phoneNo.TabIndex = 9;
            // 
            // checkBox_isSuspended
            // 
            this.checkBox_isSuspended.AutoSize = true;
            this.checkBox_isSuspended.Location = new System.Drawing.Point(11, 165);
            this.checkBox_isSuspended.Name = "checkBox_isSuspended";
            this.checkBox_isSuspended.Size = new System.Drawing.Size(60, 24);
            this.checkBox_isSuspended.TabIndex = 10;
            this.checkBox_isSuspended.Text = "停用";
            this.checkBox_isSuspended.UseVisualStyleBackColor = true;
            // 
            // ClinicRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ClinicRegistration";
            this.Size = new System.Drawing.Size(689, 204);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_isSuspended;
        private System.Windows.Forms.TextBox textBox_phoneNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_addr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_engName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_chiName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_clinicId;
    }
}
