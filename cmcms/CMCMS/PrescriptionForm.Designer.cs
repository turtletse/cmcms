namespace CMCMS
{
    partial class PrescriptionForm
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
            this.button_confirm = new System.Windows.Forms.Button();
            this.prescriptionPanel1 = new CMCMS.PrescriptionPanel();
            this.button_reset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_instruction = new System.Windows.Forms.TextBox();
            this.textBox_nDose = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_methodOfTreatment = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_selectInstruction = new System.Windows.Forms.Button();
            this.comboBox_predefInstruction = new System.Windows.Forms.ComboBox();
            this.comboBox_predefMOT = new System.Windows.Forms.ComboBox();
            this.button_selectMOT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_confirm
            // 
            this.button_confirm.Location = new System.Drawing.Point(1271, 637);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(120, 51);
            this.button_confirm.TabIndex = 9;
            this.button_confirm.Text = "確定";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // prescriptionPanel1
            // 
            this.prescriptionPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prescriptionPanel1.Location = new System.Drawing.Point(4, 106);
            this.prescriptionPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.prescriptionPanel1.Name = "prescriptionPanel1";
            this.prescriptionPanel1.Size = new System.Drawing.Size(1390, 582);
            this.prescriptionPanel1.TabIndex = 8;
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(1147, 637);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(120, 51);
            this.button_reset.TabIndex = 10;
            this.button_reset.Text = "還原";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "服用方法: ";
            // 
            // textBox_instruction
            // 
            this.textBox_instruction.Location = new System.Drawing.Point(99, 6);
            this.textBox_instruction.Name = "textBox_instruction";
            this.textBox_instruction.Size = new System.Drawing.Size(660, 26);
            this.textBox_instruction.TabIndex = 1;
            // 
            // textBox_nDose
            // 
            this.textBox_nDose.Location = new System.Drawing.Point(99, 38);
            this.textBox_nDose.Name = "textBox_nDose";
            this.textBox_nDose.Size = new System.Drawing.Size(48, 26);
            this.textBox_nDose.TabIndex = 4;
            this.textBox_nDose.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "劑數: ";
            // 
            // textBox_methodOfTreatment
            // 
            this.textBox_methodOfTreatment.Location = new System.Drawing.Point(99, 70);
            this.textBox_methodOfTreatment.Name = "textBox_methodOfTreatment";
            this.textBox_methodOfTreatment.Size = new System.Drawing.Size(660, 26);
            this.textBox_methodOfTreatment.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "治法: ";
            // 
            // button_selectInstruction
            // 
            this.button_selectInstruction.Location = new System.Drawing.Point(765, 6);
            this.button_selectInstruction.Name = "button_selectInstruction";
            this.button_selectInstruction.Size = new System.Drawing.Size(66, 26);
            this.button_selectInstruction.TabIndex = 3;
            this.button_selectInstruction.Text = "<<";
            this.button_selectInstruction.UseVisualStyleBackColor = true;
            this.button_selectInstruction.Click += new System.EventHandler(this.button_selectInstruction_Click);
            // 
            // comboBox_predefInstruction
            // 
            this.comboBox_predefInstruction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_predefInstruction.FormattingEnabled = true;
            this.comboBox_predefInstruction.Location = new System.Drawing.Point(837, 6);
            this.comboBox_predefInstruction.Name = "comboBox_predefInstruction";
            this.comboBox_predefInstruction.Size = new System.Drawing.Size(259, 28);
            this.comboBox_predefInstruction.TabIndex = 2;
            // 
            // comboBox_predefMOT
            // 
            this.comboBox_predefMOT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_predefMOT.FormattingEnabled = true;
            this.comboBox_predefMOT.Location = new System.Drawing.Point(837, 70);
            this.comboBox_predefMOT.Name = "comboBox_predefMOT";
            this.comboBox_predefMOT.Size = new System.Drawing.Size(259, 28);
            this.comboBox_predefMOT.TabIndex = 6;
            // 
            // button_selectMOT
            // 
            this.button_selectMOT.Location = new System.Drawing.Point(765, 70);
            this.button_selectMOT.Name = "button_selectMOT";
            this.button_selectMOT.Size = new System.Drawing.Size(66, 26);
            this.button_selectMOT.TabIndex = 7;
            this.button_selectMOT.Text = "<<";
            this.button_selectMOT.UseVisualStyleBackColor = true;
            this.button_selectMOT.Click += new System.EventHandler(this.button_selectMOT_Click);
            // 
            // PrescriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 695);
            this.Controls.Add(this.comboBox_predefMOT);
            this.Controls.Add(this.button_selectMOT);
            this.Controls.Add(this.textBox_methodOfTreatment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_nDose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_predefInstruction);
            this.Controls.Add(this.button_selectInstruction);
            this.Controls.Add(this.textBox_instruction);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.prescriptionPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "PrescriptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "處方";
            this.Shown += new System.EventHandler(this.PrescriptionForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PrescriptionPanel prescriptionPanel1;
        private System.Windows.Forms.Button button_confirm;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_instruction;
        private System.Windows.Forms.TextBox textBox_nDose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_methodOfTreatment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_selectInstruction;
        private System.Windows.Forms.ComboBox comboBox_predefInstruction;
        private System.Windows.Forms.ComboBox comboBox_predefMOT;
        private System.Windows.Forms.Button button_selectMOT;
    }
}