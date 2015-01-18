namespace CMCMS
{
    partial class EnterQueue
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
            this.button_enterQueue = new System.Windows.Forms.Button();
            this.searchPatientInputPanel1 = new CMCMS.SearchPatientInputPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "掛號";
            // 
            // button_enterQueue
            // 
            this.button_enterQueue.Location = new System.Drawing.Point(17, 431);
            this.button_enterQueue.Name = "button_enterQueue";
            this.button_enterQueue.Size = new System.Drawing.Size(273, 36);
            this.button_enterQueue.TabIndex = 2;
            this.button_enterQueue.Text = "掛號";
            this.button_enterQueue.UseVisualStyleBackColor = true;
            this.button_enterQueue.Click += new System.EventHandler(this.button_enterQueue_Click);
            // 
            // searchPatientInputPanel1
            // 
            this.searchPatientInputPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchPatientInputPanel1.Location = new System.Drawing.Point(10, 43);
            this.searchPatientInputPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchPatientInputPanel1.Name = "searchPatientInputPanel1";
            this.searchPatientInputPanel1.Size = new System.Drawing.Size(289, 380);
            this.searchPatientInputPanel1.TabIndex = 3;
            // 
            // EnterQueue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 485);
            this.Controls.Add(this.searchPatientInputPanel1);
            this.Controls.Add(this.button_enterQueue);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "EnterQueue";
            this.Text = "EnterQueue";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_enterQueue;
        private SearchPatientInputPanel searchPatientInputPanel1;
    }
}