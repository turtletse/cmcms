namespace CMCMS
{
    partial class AddDrRmkForm
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
            this.comboBox_predefPhrase = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_del = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_newPredefDrRmk = new System.Windows.Forms.TextBox();
            this.button_add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_predefPhrase
            // 
            this.comboBox_predefPhrase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_predefPhrase.FormattingEnabled = true;
            this.comboBox_predefPhrase.Location = new System.Drawing.Point(100, 59);
            this.comboBox_predefPhrase.Name = "comboBox_predefPhrase";
            this.comboBox_predefPhrase.Size = new System.Drawing.Size(337, 28);
            this.comboBox_predefPhrase.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "新增 / 刪除預設醫囑";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "現有醫囑: ";
            // 
            // button_del
            // 
            this.button_del.Location = new System.Drawing.Point(455, 59);
            this.button_del.Name = "button_del";
            this.button_del.Size = new System.Drawing.Size(75, 28);
            this.button_del.TabIndex = 2;
            this.button_del.Text = "刪除";
            this.button_del.UseVisualStyleBackColor = true;
            this.button_del.Click += new System.EventHandler(this.button_del_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "新增醫囑: ";
            // 
            // textBox_newPredefDrRmk
            // 
            this.textBox_newPredefDrRmk.Location = new System.Drawing.Point(100, 114);
            this.textBox_newPredefDrRmk.Name = "textBox_newPredefDrRmk";
            this.textBox_newPredefDrRmk.Size = new System.Drawing.Size(337, 26);
            this.textBox_newPredefDrRmk.TabIndex = 3;
            this.textBox_newPredefDrRmk.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_newPredefDrRmk_KeyPress);
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(455, 113);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 28);
            this.button_add.TabIndex = 4;
            this.button_add.Text = "新増";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // AddDrRmkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 179);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.textBox_newPredefDrRmk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_del);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_predefPhrase);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "AddDrRmkForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增 / 刪除預設醫囑";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_predefPhrase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_del;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_newPredefDrRmk;
        private System.Windows.Forms.Button button_add;
    }
}