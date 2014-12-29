namespace CMCMS
{
    partial class DrugSelectionPanel
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
            this.listBox_priDrugType = new System.Windows.Forms.ListBox();
            this.listBox_secDrugType = new System.Windows.Forms.ListBox();
            this.checkedListBox_4q5w = new System.Windows.Forms.CheckedListBox();
            this.listBox_drugList = new System.Windows.Forms.ListBox();
            this.listBox_nStrokes = new System.Windows.Forms.ListBox();
            this.listBox_length = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox_priDrugType
            // 
            this.listBox_priDrugType.FormattingEnabled = true;
            this.listBox_priDrugType.ItemHeight = 20;
            this.listBox_priDrugType.Location = new System.Drawing.Point(4, 0);
            this.listBox_priDrugType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBox_priDrugType.Name = "listBox_priDrugType";
            this.listBox_priDrugType.Size = new System.Drawing.Size(130, 324);
            this.listBox_priDrugType.TabIndex = 1;
            this.listBox_priDrugType.SelectedIndexChanged += new System.EventHandler(this.listBox_priDrugType_SelectedIndexChanged);
            // 
            // listBox_secDrugType
            // 
            this.listBox_secDrugType.FormattingEnabled = true;
            this.listBox_secDrugType.ItemHeight = 20;
            this.listBox_secDrugType.Location = new System.Drawing.Point(142, 0);
            this.listBox_secDrugType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBox_secDrugType.Name = "listBox_secDrugType";
            this.listBox_secDrugType.Size = new System.Drawing.Size(130, 324);
            this.listBox_secDrugType.TabIndex = 2;
            this.listBox_secDrugType.SelectedIndexChanged += new System.EventHandler(this.listBox_secDrugType_SelectedIndexChanged);
            // 
            // checkedListBox_4q5w
            // 
            this.checkedListBox_4q5w.FormattingEnabled = true;
            this.checkedListBox_4q5w.Location = new System.Drawing.Point(555, 0);
            this.checkedListBox_4q5w.Name = "checkedListBox_4q5w";
            this.checkedListBox_4q5w.Size = new System.Drawing.Size(130, 319);
            this.checkedListBox_4q5w.TabIndex = 3;
            // 
            // listBox_drugList
            // 
            this.listBox_drugList.FormattingEnabled = true;
            this.listBox_drugList.ItemHeight = 20;
            this.listBox_drugList.Location = new System.Drawing.Point(692, 0);
            this.listBox_drugList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBox_drugList.Name = "listBox_drugList";
            this.listBox_drugList.Size = new System.Drawing.Size(130, 324);
            this.listBox_drugList.TabIndex = 4;
            // 
            // listBox_nStrokes
            // 
            this.listBox_nStrokes.FormattingEnabled = true;
            this.listBox_nStrokes.ItemHeight = 20;
            this.listBox_nStrokes.Location = new System.Drawing.Point(280, 0);
            this.listBox_nStrokes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBox_nStrokes.Name = "listBox_nStrokes";
            this.listBox_nStrokes.Size = new System.Drawing.Size(130, 324);
            this.listBox_nStrokes.TabIndex = 5;
            this.listBox_nStrokes.SelectedIndexChanged += new System.EventHandler(this.listBox_nStrokes_SelectedIndexChanged);
            // 
            // listBox_length
            // 
            this.listBox_length.FormattingEnabled = true;
            this.listBox_length.ItemHeight = 20;
            this.listBox_length.Location = new System.Drawing.Point(418, 0);
            this.listBox_length.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBox_length.Name = "listBox_length";
            this.listBox_length.Size = new System.Drawing.Size(130, 324);
            this.listBox_length.TabIndex = 6;
            this.listBox_length.SelectedIndexChanged += new System.EventHandler(this.listBox_length_SelectedIndexChanged);
            // 
            // DrugSelectionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBox_length);
            this.Controls.Add(this.listBox_nStrokes);
            this.Controls.Add(this.listBox_drugList);
            this.Controls.Add(this.checkedListBox_4q5w);
            this.Controls.Add(this.listBox_secDrugType);
            this.Controls.Add(this.listBox_priDrugType);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DrugSelectionPanel";
            this.Size = new System.Drawing.Size(826, 326);
            this.VisibleChanged += new System.EventHandler(this.DrugSelectionPanel_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_priDrugType;
        private System.Windows.Forms.ListBox listBox_secDrugType;
        private System.Windows.Forms.CheckedListBox checkedListBox_4q5w;
        private System.Windows.Forms.ListBox listBox_drugList;
        private System.Windows.Forms.ListBox listBox_nStrokes;
        private System.Windows.Forms.ListBox listBox_length;

    }
}
