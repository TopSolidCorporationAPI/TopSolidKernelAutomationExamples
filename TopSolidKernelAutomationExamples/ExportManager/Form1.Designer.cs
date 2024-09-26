namespace ExportManager
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
            this.pdmTreeView1 = new TopSolidAutomationControls.PDMTreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblExportFormats = new System.Windows.Forms.Label();
            this.lbAvailableExportFormats = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPrinterNames = new System.Windows.Forms.Label();
            this.lblPrinterFormats = new System.Windows.Forms.Label();
            this.btPrint = new System.Windows.Forms.Button();
            this.lblPrintColorMapping = new System.Windows.Forms.Label();
            this.cmbPrinterNames = new System.Windows.Forms.ComboBox();
            this.cmbPrinterFormats = new System.Windows.Forms.ComboBox();
            this.cmbPrintColorMapping = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btExport = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkChooseRepresentation = new System.Windows.Forms.CheckBox();
            this.cmbRepresentation = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btBrowse = new System.Windows.Forms.Button();
            this.txtExportPath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pdmTreeView1
            // 
            this.pdmTreeView1.CheckBoxes = true;
            this.pdmTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdmTreeView1.DocumentTypes = new string[0];
            this.pdmTreeView1.ImageIndex = 0;
            this.pdmTreeView1.Location = new System.Drawing.Point(10, 10);
            this.pdmTreeView1.MultipleCheck = true;
            this.pdmTreeView1.Name = "pdmTreeView1";
            this.pdmTreeView1.SelectedImageIndex = 0;
            this.pdmTreeView1.Size = new System.Drawing.Size(312, 349);
            this.pdmTreeView1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pdmTreeView1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(643, 369);
            this.splitContainer1.SplitterDistance = 332;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.90554F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.09446F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.11653F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.88347F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(307, 369);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblExportFormats);
            this.flowLayoutPanel1.Controls.Add(this.lbAvailableExportFormats);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 10);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 10, 10, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(131, 186);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lblExportFormats
            // 
            this.lblExportFormats.AutoSize = true;
            this.lblExportFormats.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblExportFormats.Location = new System.Drawing.Point(3, 5);
            this.lblExportFormats.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.lblExportFormats.Name = "lblExportFormats";
            this.lblExportFormats.Size = new System.Drawing.Size(123, 13);
            this.lblExportFormats.TabIndex = 0;
            this.lblExportFormats.Text = "Available Export Formats";
            // 
            // lbAvailableExportFormats
            // 
            this.lbAvailableExportFormats.DisplayMember = "Key";
            this.lbAvailableExportFormats.FormattingEnabled = true;
            this.lbAvailableExportFormats.Location = new System.Drawing.Point(3, 24);
            this.lbAvailableExportFormats.Name = "lbAvailableExportFormats";
            this.lbAvailableExportFormats.Size = new System.Drawing.Size(123, 160);
            this.lbAvailableExportFormats.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.98485F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.01515F));
            this.tableLayoutPanel2.Controls.Add(this.lblPrinterNames, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblPrinterFormats, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btPrint, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblPrintColorMapping, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cmbPrinterNames, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbPrinterFormats, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.cmbPrintColorMapping, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 206);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(287, 153);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblPrinterNames
            // 
            this.lblPrinterNames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrinterNames.AutoSize = true;
            this.lblPrinterNames.Location = new System.Drawing.Point(3, 12);
            this.lblPrinterNames.Name = "lblPrinterNames";
            this.lblPrinterNames.Size = new System.Drawing.Size(97, 13);
            this.lblPrinterNames.TabIndex = 0;
            this.lblPrinterNames.Text = "Printer Names";
            // 
            // lblPrinterFormats
            // 
            this.lblPrinterFormats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrinterFormats.AutoSize = true;
            this.lblPrinterFormats.Location = new System.Drawing.Point(3, 50);
            this.lblPrinterFormats.Name = "lblPrinterFormats";
            this.lblPrinterFormats.Size = new System.Drawing.Size(97, 13);
            this.lblPrinterFormats.TabIndex = 0;
            this.lblPrinterFormats.Text = "Printer Formats";
            // 
            // btPrint
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.btPrint, 2);
            this.btPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btPrint.Location = new System.Drawing.Point(50, 117);
            this.btPrint.Margin = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(187, 33);
            this.btPrint.TabIndex = 2;
            this.btPrint.Text = "Print";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // lblPrintColorMapping
            // 
            this.lblPrintColorMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrintColorMapping.AutoSize = true;
            this.lblPrintColorMapping.Location = new System.Drawing.Point(3, 82);
            this.lblPrintColorMapping.Name = "lblPrintColorMapping";
            this.lblPrintColorMapping.Size = new System.Drawing.Size(97, 26);
            this.lblPrintColorMapping.TabIndex = 0;
            this.lblPrintColorMapping.Text = "Print Color Mapping";
            // 
            // cmbPrinterNames
            // 
            this.cmbPrinterNames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPrinterNames.FormattingEnabled = true;
            this.cmbPrinterNames.Location = new System.Drawing.Point(106, 8);
            this.cmbPrinterNames.Name = "cmbPrinterNames";
            this.cmbPrinterNames.Size = new System.Drawing.Size(178, 21);
            this.cmbPrinterNames.TabIndex = 1;
            // 
            // cmbPrinterFormats
            // 
            this.cmbPrinterFormats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPrinterFormats.FormattingEnabled = true;
            this.cmbPrinterFormats.Location = new System.Drawing.Point(106, 46);
            this.cmbPrinterFormats.Name = "cmbPrinterFormats";
            this.cmbPrinterFormats.Size = new System.Drawing.Size(178, 21);
            this.cmbPrinterFormats.TabIndex = 1;
            // 
            // cmbPrintColorMapping
            // 
            this.cmbPrintColorMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPrintColorMapping.FormattingEnabled = true;
            this.cmbPrintColorMapping.Items.AddRange(new object[] {
            "Color",
            "GreyLevels",
            "BlackAndWhite"});
            this.cmbPrintColorMapping.Location = new System.Drawing.Point(106, 84);
            this.cmbPrintColorMapping.Name = "cmbPrintColorMapping";
            this.cmbPrintColorMapping.Size = new System.Drawing.Size(178, 21);
            this.cmbPrintColorMapping.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.btExport, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(147, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.35947F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.64052F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(157, 190);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // btExport
            // 
            this.btExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btExport.Image = global::ExportManager.Properties.Resources.Export;
            this.btExport.Location = new System.Drawing.Point(97, 134);
            this.btExport.Margin = new System.Windows.Forms.Padding(10);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(50, 46);
            this.btExport.TabIndex = 3;
            this.btExport.UseVisualStyleBackColor = true;
            this.btExport.Click += new System.EventHandler(this.btExport_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.chkChooseRepresentation);
            this.flowLayoutPanel2.Controls.Add(this.cmbRepresentation);
            this.flowLayoutPanel2.Controls.Add(this.tableLayoutPanel4);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(151, 118);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // chkChooseRepresentation
            // 
            this.chkChooseRepresentation.AutoSize = true;
            this.chkChooseRepresentation.Location = new System.Drawing.Point(3, 3);
            this.chkChooseRepresentation.Name = "chkChooseRepresentation";
            this.chkChooseRepresentation.Size = new System.Drawing.Size(132, 17);
            this.chkChooseRepresentation.TabIndex = 2;
            this.chkChooseRepresentation.Text = "Choose representation";
            this.chkChooseRepresentation.UseVisualStyleBackColor = true;
            // 
            // cmbRepresentation
            // 
            this.cmbRepresentation.FormattingEnabled = true;
            this.cmbRepresentation.Items.AddRange(new object[] {
            "Simplified",
            "Design",
            "Detailed"});
            this.cmbRepresentation.Location = new System.Drawing.Point(3, 26);
            this.cmbRepresentation.Name = "cmbRepresentation";
            this.cmbRepresentation.Size = new System.Drawing.Size(141, 21);
            this.cmbRepresentation.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.51908F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.48092F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.btBrowse, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtExportPath, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 53);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(142, 33);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // btBrowse
            // 
            this.btBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowse.Location = new System.Drawing.Point(105, 5);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(34, 23);
            this.btBrowse.TabIndex = 2;
            this.btBrowse.Text = "...";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // txtExportPath
            // 
            this.txtExportPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExportPath.Location = new System.Drawing.Point(3, 6);
            this.txtExportPath.Name = "txtExportPath";
            this.txtExportPath.Size = new System.Drawing.Size(96, 20);
            this.txtExportPath.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 369);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ExportManager";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TopSolidAutomationControls.PDMTreeView pdmTreeView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblExportFormats;
        private System.Windows.Forms.ListBox lbAvailableExportFormats;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtExportPath;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.Button btExport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblPrinterNames;
        private System.Windows.Forms.Label lblPrinterFormats;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Label lblPrintColorMapping;
        private System.Windows.Forms.ComboBox cmbPrinterNames;
        private System.Windows.Forms.ComboBox cmbPrinterFormats;
        private System.Windows.Forms.ComboBox cmbPrintColorMapping;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.ComboBox cmbRepresentation;
        private System.Windows.Forms.CheckBox chkChooseRepresentation;
    }
}

