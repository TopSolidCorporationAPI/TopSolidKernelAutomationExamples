namespace FamilyManager
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btCreateExplicitFamily = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFamilyName = new System.Windows.Forms.TextBox();
            this.btGetFirstFileName = new System.Windows.Forms.Button();
            this.chkPurgeOriginalFiles = new System.Windows.Forms.CheckBox();
            this.chkRemoveRedundantName = new System.Windows.Forms.CheckBox();
            this.chkUseRedundantName = new System.Windows.Forms.CheckBox();
            this.pdmTreeView1 = new TopSolidAutomationControls.PDMTreeView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.rdbForSelection = new System.Windows.Forms.RadioButton();
            this.rdbForAll = new System.Windows.Forms.RadioButton();
            this.btSetFamilyGenericDocument = new System.Windows.Forms.Button();
            this.picBoxPreview = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // btCreateExplicitFamily
            // 
            this.btCreateExplicitFamily.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btCreateExplicitFamily.Location = new System.Drawing.Point(286, 85);
            this.btCreateExplicitFamily.Name = "btCreateExplicitFamily";
            this.btCreateExplicitFamily.Size = new System.Drawing.Size(166, 35);
            this.btCreateExplicitFamily.TabIndex = 1;
            this.btCreateExplicitFamily.Text = "Create Explicit Family";
            this.btCreateExplicitFamily.UseVisualStyleBackColor = true;
            this.btCreateExplicitFamily.Click += new System.EventHandler(this.btCreateExplicitFamily_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.47312F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.52688F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pdmTreeView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.41758F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.58242F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkPurgeOriginalFiles, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.chkRemoveRedundantName, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.chkUseRedundantName, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btCreateExplicitFamily, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(342, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(455, 207);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.tbFamilyName);
            this.flowLayoutPanel1.Controls.Add(this.btGetFirstFileName);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(449, 28);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Family Name";
            // 
            // tbFamilyName
            // 
            this.tbFamilyName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFamilyName.Location = new System.Drawing.Point(76, 4);
            this.tbFamilyName.Name = "tbFamilyName";
            this.tbFamilyName.Size = new System.Drawing.Size(289, 20);
            this.tbFamilyName.TabIndex = 0;
            // 
            // btGetFirstFileName
            // 
            this.btGetFirstFileName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btGetFirstFileName.Location = new System.Drawing.Point(371, 3);
            this.btGetFirstFileName.Name = "btGetFirstFileName";
            this.btGetFirstFileName.Size = new System.Drawing.Size(36, 23);
            this.btGetFirstFileName.TabIndex = 1;
            this.btGetFirstFileName.Text = "Get";
            this.btGetFirstFileName.UseVisualStyleBackColor = true;
            this.btGetFirstFileName.Click += new System.EventHandler(this.btGetFirstFileName_Click);
            // 
            // chkPurgeOriginalFiles
            // 
            this.chkPurgeOriginalFiles.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkPurgeOriginalFiles.AutoSize = true;
            this.chkPurgeOriginalFiles.Location = new System.Drawing.Point(3, 135);
            this.chkPurgeOriginalFiles.Name = "chkPurgeOriginalFiles";
            this.chkPurgeOriginalFiles.Size = new System.Drawing.Size(111, 17);
            this.chkPurgeOriginalFiles.TabIndex = 3;
            this.chkPurgeOriginalFiles.Text = "Purge original files";
            this.chkPurgeOriginalFiles.UseVisualStyleBackColor = true;
            // 
            // chkRemoveRedundantName
            // 
            this.chkRemoveRedundantName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkRemoveRedundantName.AutoSize = true;
            this.chkRemoveRedundantName.Location = new System.Drawing.Point(3, 94);
            this.chkRemoveRedundantName.Name = "chkRemoveRedundantName";
            this.chkRemoveRedundantName.Size = new System.Drawing.Size(146, 17);
            this.chkRemoveRedundantName.TabIndex = 2;
            this.chkRemoveRedundantName.Text = "Remove redundant name";
            this.chkRemoveRedundantName.UseVisualStyleBackColor = true;
            // 
            // chkUseRedundantName
            // 
            this.chkUseRedundantName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkUseRedundantName.AutoSize = true;
            this.chkUseRedundantName.Location = new System.Drawing.Point(3, 53);
            this.chkUseRedundantName.Name = "chkUseRedundantName";
            this.chkUseRedundantName.Size = new System.Drawing.Size(197, 17);
            this.chkUseRedundantName.TabIndex = 2;
            this.chkUseRedundantName.Text = "Use redundant name as family name";
            this.chkUseRedundantName.UseVisualStyleBackColor = true;
            this.chkUseRedundantName.CheckedChanged += new System.EventHandler(this.chkUseRedundantName_CheckedChanged);
            // 
            // pdmTreeView1
            // 
            this.pdmTreeView1.CheckBoxes = true;
            this.pdmTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdmTreeView1.DocumentTypes = new string[] {
        ".TopPrt",
        ".TopFam"};
            this.pdmTreeView1.ImageIndex = 0;
            this.pdmTreeView1.Location = new System.Drawing.Point(10, 10);
            this.pdmTreeView1.Margin = new System.Windows.Forms.Padding(10);
            this.pdmTreeView1.MultipleCheck = true;
            this.pdmTreeView1.Name = "pdmTreeView1";
            this.tableLayoutPanel1.SetRowSpan(this.pdmTreeView1, 2);
            this.pdmTreeView1.SelectedImageIndex = 0;
            this.pdmTreeView1.Size = new System.Drawing.Size(319, 430);
            this.pdmTreeView1.TabIndex = 3;
            this.pdmTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.pdmTreeView1_AfterSelect);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.96703F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.75824F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel3.Controls.Add(this.rdbForSelection, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.rdbForAll, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.btSetFamilyGenericDocument, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.picBoxPreview, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(342, 228);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(455, 219);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // rdbForSelection
            // 
            this.rdbForSelection.AutoSize = true;
            this.rdbForSelection.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdbForSelection.Checked = true;
            this.rdbForSelection.Dock = System.Windows.Forms.DockStyle.Right;
            this.rdbForSelection.Location = new System.Drawing.Point(159, 38);
            this.rdbForSelection.Name = "rdbForSelection";
            this.rdbForSelection.Size = new System.Drawing.Size(87, 66);
            this.rdbForSelection.TabIndex = 0;
            this.rdbForSelection.TabStop = true;
            this.rdbForSelection.Text = "For Selection";
            this.rdbForSelection.UseVisualStyleBackColor = true;
            // 
            // rdbForAll
            // 
            this.rdbForAll.AutoSize = true;
            this.rdbForAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdbForAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.rdbForAll.Location = new System.Drawing.Point(192, 110);
            this.rdbForAll.Name = "rdbForAll";
            this.rdbForAll.Size = new System.Drawing.Size(54, 62);
            this.rdbForAll.TabIndex = 0;
            this.rdbForAll.Text = "For All";
            this.rdbForAll.UseVisualStyleBackColor = true;
            // 
            // btSetFamilyGenericDocument
            // 
            this.btSetFamilyGenericDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btSetFamilyGenericDocument.Location = new System.Drawing.Point(269, 86);
            this.btSetFamilyGenericDocument.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.btSetFamilyGenericDocument.Name = "btSetFamilyGenericDocument";
            this.tableLayoutPanel3.SetRowSpan(this.btSetFamilyGenericDocument, 2);
            this.btSetFamilyGenericDocument.Size = new System.Drawing.Size(166, 38);
            this.btSetFamilyGenericDocument.TabIndex = 1;
            this.btSetFamilyGenericDocument.Text = "Set Generic Document";
            this.btSetFamilyGenericDocument.UseVisualStyleBackColor = true;
            this.btSetFamilyGenericDocument.Click += new System.EventHandler(this.btSetFamilyGenericDocument_Click);
            // 
            // picBoxPreview
            // 
            this.picBoxPreview.Location = new System.Drawing.Point(3, 38);
            this.picBoxPreview.Name = "picBoxPreview";
            this.tableLayoutPanel3.SetRowSpan(this.picBoxPreview, 2);
            this.picBoxPreview.Size = new System.Drawing.Size(144, 134);
            this.picBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxPreview.TabIndex = 2;
            this.picBoxPreview.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Family Manager";
            this.TopMost = true;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btCreateExplicitFamily;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFamilyName;
        private System.Windows.Forms.Button btGetFirstFileName;
        private System.Windows.Forms.CheckBox chkPurgeOriginalFiles;
        private System.Windows.Forms.CheckBox chkRemoveRedundantName;
        private TopSolidAutomationControls.PDMTreeView pdmTreeView1;
        private System.Windows.Forms.CheckBox chkUseRedundantName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.RadioButton rdbForSelection;
        private System.Windows.Forms.RadioButton rdbForAll;
        private System.Windows.Forms.Button btSetFamilyGenericDocument;
        private System.Windows.Forms.PictureBox picBoxPreview;
    }
}

