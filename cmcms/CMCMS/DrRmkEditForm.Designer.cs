namespace CMCMS
{
    partial class DrRmkEditForm
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
            this.comboBox_predefPhrase = new System.Windows.Forms.ComboBox();
            this.button_select = new System.Windows.Forms.Button();
            this.textBox_drRmk = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_confirm = new System.Windows.Forms.Button();
            this.button_reset = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "預設字詞: ";
            // 
            // comboBox_predefPhrase
            // 
            this.comboBox_predefPhrase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_predefPhrase.FormattingEnabled = true;
            this.comboBox_predefPhrase.Location = new System.Drawing.Point(99, 19);
            this.comboBox_predefPhrase.Name = "comboBox_predefPhrase";
            this.comboBox_predefPhrase.Size = new System.Drawing.Size(337, 28);
            this.comboBox_predefPhrase.TabIndex = 1;
            // 
            // button_select
            // 
            this.button_select.Location = new System.Drawing.Point(442, 14);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(102, 37);
            this.button_select.TabIndex = 2;
            this.button_select.Text = "選擇";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // textBox_drRmk
            // 
            this.textBox_drRmk.Location = new System.Drawing.Point(16, 82);
            this.textBox_drRmk.Multiline = true;
            this.textBox_drRmk.Name = "textBox_drRmk";
            this.textBox_drRmk.Size = new System.Drawing.Size(420, 309);
            this.textBox_drRmk.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "醫囑: ";
            // 
            // button_confirm
            // 
            this.button_confirm.Location = new System.Drawing.Point(442, 354);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(102, 37);
            this.button_confirm.TabIndex = 5;
            this.button_confirm.Text = "確定";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(442, 311);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(102, 37);
            this.button_reset.TabIndex = 6;
            this.button_reset.Text = "還原";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(442, 268);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(102, 37);
            this.button_clear.TabIndex = 7;
            this.button_clear.Text = "清空";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // DrRmkEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 403);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_drRmk);
            this.Controls.Add(this.button_select);
            this.Controls.Add(this.comboBox_predefPhrase);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "DrRmkEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "醫囑";
            this.Shown += new System.EventHandler(this.DrRmkEditForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_predefPhrase;
        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.TextBox textBox_drRmk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_confirm;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.Button button_clear;
    }
}