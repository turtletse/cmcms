namespace CMCMS
{
    partial class AddPredefInstructionForm
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
            this.button_add = new System.Windows.Forms.Button();
            this.textBox_newPredefInstruction = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_del = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_predefInstruction = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "新增 / 刪除預設處方服用方法";
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(455, 109);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 28);
            this.button_add.TabIndex = 4;
            this.button_add.Text = "新増";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // textBox_newPredefInstruction
            // 
            this.textBox_newPredefInstruction.Location = new System.Drawing.Point(100, 110);
            this.textBox_newPredefInstruction.Name = "textBox_newPredefInstruction";
            this.textBox_newPredefInstruction.Size = new System.Drawing.Size(337, 26);
            this.textBox_newPredefInstruction.TabIndex = 3;
            this.textBox_newPredefInstruction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_newPredefInstruction_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "新增方法: ";
            // 
            // button_del
            // 
            this.button_del.Location = new System.Drawing.Point(455, 55);
            this.button_del.Name = "button_del";
            this.button_del.Size = new System.Drawing.Size(75, 28);
            this.button_del.TabIndex = 2;
            this.button_del.Text = "刪除";
            this.button_del.UseVisualStyleBackColor = true;
            this.button_del.Click += new System.EventHandler(this.button_del_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "現有方法: ";
            // 
            // comboBox_predefInstruction
            // 
            this.comboBox_predefInstruction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_predefInstruction.FormattingEnabled = true;
            this.comboBox_predefInstruction.Location = new System.Drawing.Point(100, 55);
            this.comboBox_predefInstruction.Name = "comboBox_predefInstruction";
            this.comboBox_predefInstruction.Size = new System.Drawing.Size(337, 28);
            this.comboBox_predefInstruction.TabIndex = 1;
            // 
            // AddPredefInstructionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 173);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.textBox_newPredefInstruction);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_del);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_predefInstruction);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "AddPredefInstructionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增 / 刪除預設處方服用方法";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.TextBox textBox_newPredefInstruction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_del;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_predefInstruction;
    }
}