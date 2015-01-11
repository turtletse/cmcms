namespace CMCMS
{
    partial class Patient_amdPatientData
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
            this.searchPatientInputPanel1 = new CMCMS.searchPatientInputPanel();
            this.patientRegistration1 = new CMCMS.PatientRegistration();
            this.button_selectPatient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchPatientInputPanel1
            // 
            this.searchPatientInputPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchPatientInputPanel1.Location = new System.Drawing.Point(13, 51);
            this.searchPatientInputPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchPatientInputPanel1.Name = "searchPatientInputPanel1";
            this.searchPatientInputPanel1.Size = new System.Drawing.Size(300, 385);
            this.searchPatientInputPanel1.TabIndex = 0;
            // 
            // patientRegistration1
            // 
            this.patientRegistration1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientRegistration1.Location = new System.Drawing.Point(321, 51);
            this.patientRegistration1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.patientRegistration1.Name = "patientRegistration1";
            this.patientRegistration1.Size = new System.Drawing.Size(1081, 608);
            this.patientRegistration1.TabIndex = 1;
            // 
            // button_selectPatient
            // 
            this.button_selectPatient.Location = new System.Drawing.Point(23, 444);
            this.button_selectPatient.Name = "button_selectPatient";
            this.button_selectPatient.Size = new System.Drawing.Size(75, 37);
            this.button_selectPatient.TabIndex = 2;
            this.button_selectPatient.Text = "選擇";
            this.button_selectPatient.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "更改資料";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(521, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "修改以下資料, 然後按確定儲存。若不更改密碼, 請空密碼及確認密碼欄。";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(324, 667);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 37);
            this.button1.TabIndex = 5;
            this.button1.Text = "重設資料";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1255, 667);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 37);
            this.button2.TabIndex = 6;
            this.button2.Text = "確定";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Patient_amdPatientData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 714);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_selectPatient);
            this.Controls.Add(this.patientRegistration1);
            this.Controls.Add(this.searchPatientInputPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Patient_amdPatientData";
            this.Text = "Patient_amdPatientData";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private searchPatientInputPanel searchPatientInputPanel1;
        private PatientRegistration patientRegistration1;
        private System.Windows.Forms.Button button_selectPatient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;

    }
}