namespace CMCMS
{
    partial class DrugIncompatibleSelection
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
            this.drugSelectionPanel1 = new CMCMS.DrugSelectionPanel();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // drugSelectionPanel1
            // 
            this.drugSelectionPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drugSelectionPanel1.Location = new System.Drawing.Point(13, 14);
            this.drugSelectionPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.drugSelectionPanel1.Name = "drugSelectionPanel1";
            this.drugSelectionPanel1.Size = new System.Drawing.Size(827, 371);
            this.drugSelectionPanel1.TabIndex = 0;
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(602, 393);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(116, 40);
            this.button_cancel.TabIndex = 41;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_confirm
            // 
            this.button_confirm.Location = new System.Drawing.Point(724, 393);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(116, 40);
            this.button_confirm.TabIndex = 40;
            this.button_confirm.Text = "確定";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // DrugIncompatibleSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 451);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.drugSelectionPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DrugIncompatibleSelection";
            this.Text = "DrugIncompatibleSelection";
            this.Shown += new System.EventHandler(this.DrugIncompatibleSelection_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private DrugSelectionPanel drugSelectionPanel1;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_confirm;

    }
}