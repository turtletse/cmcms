namespace CMCMS
{
    partial class PrintMedicalReportForm
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
            this.button_prnWholeRec = new System.Windows.Forms.Button();
            this.button_search = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader_consId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_firstRecDtm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_dx = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_exam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_diff = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_pres = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_acupuncture = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_prnSelected = new System.Windows.Forms.Button();
            this.searchPatientInputPanel1 = new CMCMS.SearchPatientInputPanel();
            this.SuspendLayout();
            // 
            // button_prnWholeRec
            // 
            this.button_prnWholeRec.Location = new System.Drawing.Point(20, 402);
            this.button_prnWholeRec.Name = "button_prnWholeRec";
            this.button_prnWholeRec.Size = new System.Drawing.Size(133, 39);
            this.button_prnWholeRec.TabIndex = 1;
            this.button_prnWholeRec.Text = "列印完整紀錄";
            this.button_prnWholeRec.UseVisualStyleBackColor = true;
            this.button_prnWholeRec.Click += new System.EventHandler(this.button_prnWholeRec_Click);
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(159, 402);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(133, 39);
            this.button_search.TabIndex = 2;
            this.button_search.Text = "檢索紀錄";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_consId,
            this.columnHeader_firstRecDtm,
            this.columnHeader_dx,
            this.columnHeader_exam,
            this.columnHeader_diff,
            this.columnHeader_pres,
            this.columnHeader_acupuncture});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(309, 14);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(845, 380);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_consId
            // 
            this.columnHeader_consId.Text = "#";
            // 
            // columnHeader_firstRecDtm
            // 
            this.columnHeader_firstRecDtm.Text = "日期 / 時間";
            this.columnHeader_firstRecDtm.Width = 136;
            // 
            // columnHeader_dx
            // 
            this.columnHeader_dx.Text = "診斷";
            this.columnHeader_dx.Width = 92;
            // 
            // columnHeader_exam
            // 
            this.columnHeader_exam.Text = "病徵";
            this.columnHeader_exam.Width = 82;
            // 
            // columnHeader_diff
            // 
            this.columnHeader_diff.Text = "辨症";
            this.columnHeader_diff.Width = 88;
            // 
            // columnHeader_pres
            // 
            this.columnHeader_pres.Text = "處方簡要";
            this.columnHeader_pres.Width = 230;
            // 
            // columnHeader_acupuncture
            // 
            this.columnHeader_acupuncture.Text = "針灸";
            this.columnHeader_acupuncture.Width = 211;
            // 
            // button_prnSelected
            // 
            this.button_prnSelected.Location = new System.Drawing.Point(1021, 402);
            this.button_prnSelected.Name = "button_prnSelected";
            this.button_prnSelected.Size = new System.Drawing.Size(133, 39);
            this.button_prnSelected.TabIndex = 4;
            this.button_prnSelected.Text = "列印已選紀錄";
            this.button_prnSelected.UseVisualStyleBackColor = true;
            this.button_prnSelected.Click += new System.EventHandler(this.button_prnSelected_Click);
            // 
            // searchPatientInputPanel1
            // 
            this.searchPatientInputPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchPatientInputPanel1.Location = new System.Drawing.Point(13, 14);
            this.searchPatientInputPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchPatientInputPanel1.Name = "searchPatientInputPanel1";
            this.searchPatientInputPanel1.Size = new System.Drawing.Size(289, 380);
            this.searchPatientInputPanel1.TabIndex = 0;
            // 
            // PrintMedicalReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 463);
            this.Controls.Add(this.button_prnSelected);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.button_prnWholeRec);
            this.Controls.Add(this.searchPatientInputPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "PrintMedicalReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "醫療紀錄";
            this.ResumeLayout(false);

        }

        #endregion

        private SearchPatientInputPanel searchPatientInputPanel1;
        private System.Windows.Forms.Button button_prnWholeRec;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader_consId;
        private System.Windows.Forms.ColumnHeader columnHeader_firstRecDtm;
        private System.Windows.Forms.ColumnHeader columnHeader_dx;
        private System.Windows.Forms.ColumnHeader columnHeader_exam;
        private System.Windows.Forms.ColumnHeader columnHeader_diff;
        private System.Windows.Forms.ColumnHeader columnHeader_pres;
        private System.Windows.Forms.ColumnHeader columnHeader_acupuncture;
        private System.Windows.Forms.Button button_prnSelected;
    }
}