
namespace DocumentManager
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
            this.picBoxPreview = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rdbWorkingProjects = new System.Windows.Forms.RadioButton();
            this.rdbLibrairies = new System.Windows.Forms.RadioButton();
            this.rdbImportPackage = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btBrowse = new System.Windows.Forms.Button();
            this.txtPackagePath = new System.Windows.Forms.TextBox();
            this.cmbProjectsList = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.btOpen = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btCheckIn = new System.Windows.Forms.Button();
            this.btCheckOut = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btUndo = new System.Windows.Forms.Button();
            this.treeViewContent = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabDocDetails = new System.Windows.Forms.TableLayoutPanel();
            this.propertiesPanel = new System.Windows.Forms.SplitContainer();
            this.listViewParams = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.listEnumValues = new System.Windows.Forms.ListBox();
            this.txtParameterValue = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btModify = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPreview)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tabDocDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.propertiesPanel)).BeginInit();
            this.propertiesPanel.Panel1.SuspendLayout();
            this.propertiesPanel.Panel2.SuspendLayout();
            this.propertiesPanel.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBoxPreview
            // 
            this.picBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxPreview.Location = new System.Drawing.Point(23, 303);
            this.picBoxPreview.Name = "picBoxPreview";
            this.picBoxPreview.Size = new System.Drawing.Size(179, 199);
            this.picBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxPreview.TabIndex = 0;
            this.picBoxPreview.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1005, 523);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.12112F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.63063F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.24825F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.tabDocDetails, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(999, 517);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.picBoxPreview, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.rdbWorkingProjects, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.rdbLibrairies, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.rdbImportPackage, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.cmbProjectsList, 1, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(205, 505);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // rdbWorkingProjects
            // 
            this.rdbWorkingProjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbWorkingProjects.AutoSize = true;
            this.rdbWorkingProjects.Checked = true;
            this.rdbWorkingProjects.Location = new System.Drawing.Point(23, 3);
            this.rdbWorkingProjects.Name = "rdbWorkingProjects";
            this.rdbWorkingProjects.Size = new System.Drawing.Size(106, 44);
            this.rdbWorkingProjects.TabIndex = 0;
            this.rdbWorkingProjects.TabStop = true;
            this.rdbWorkingProjects.Text = "Working Projects";
            this.rdbWorkingProjects.UseVisualStyleBackColor = true;
            this.rdbWorkingProjects.CheckedChanged += new System.EventHandler(this.rdbWorkingProjects_CheckedChanged);
            // 
            // rdbLibrairies
            // 
            this.rdbLibrairies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbLibrairies.AutoSize = true;
            this.rdbLibrairies.Location = new System.Drawing.Point(23, 53);
            this.rdbLibrairies.Name = "rdbLibrairies";
            this.rdbLibrairies.Size = new System.Drawing.Size(66, 44);
            this.rdbLibrairies.TabIndex = 0;
            this.rdbLibrairies.Text = "Librairies";
            this.rdbLibrairies.UseVisualStyleBackColor = true;
            this.rdbLibrairies.CheckedChanged += new System.EventHandler(this.rdbLibrairies_CheckedChanged);
            // 
            // rdbImportPackage
            // 
            this.rdbImportPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbImportPackage.AutoSize = true;
            this.rdbImportPackage.Location = new System.Drawing.Point(23, 120);
            this.rdbImportPackage.Name = "rdbImportPackage";
            this.rdbImportPackage.Size = new System.Drawing.Size(112, 17);
            this.rdbImportPackage.TabIndex = 0;
            this.rdbImportPackage.Text = "Imported Package";
            this.rdbImportPackage.UseVisualStyleBackColor = true;
            this.rdbImportPackage.CheckedChanged += new System.EventHandler(this.rdbImportPackage_CheckedChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.74302F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.25698F));
            this.tableLayoutPanel3.Controls.Add(this.btBrowse, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtPackagePath, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(23, 143);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(179, 54);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // btBrowse
            // 
            this.btBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btBrowse.Image = global::DocumentManager.Properties.Resources.Import;
            this.btBrowse.Location = new System.Drawing.Point(135, 3);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(41, 48);
            this.btBrowse.TabIndex = 0;
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // txtPackagePath
            // 
            this.txtPackagePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPackagePath.Enabled = false;
            this.txtPackagePath.Location = new System.Drawing.Point(3, 17);
            this.txtPackagePath.Name = "txtPackagePath";
            this.txtPackagePath.Size = new System.Drawing.Size(126, 20);
            this.txtPackagePath.TabIndex = 1;
            // 
            // cmbProjectsList
            // 
            this.cmbProjectsList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbProjectsList.DisplayMember = "Name";
            this.cmbProjectsList.FormattingEnabled = true;
            this.cmbProjectsList.Location = new System.Drawing.Point(43, 214);
            this.cmbProjectsList.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.cmbProjectsList.Name = "cmbProjectsList";
            this.cmbProjectsList.Size = new System.Drawing.Size(138, 21);
            this.cmbProjectsList.TabIndex = 1;
            this.cmbProjectsList.SelectedIndexChanged += new System.EventHandler(this.cmbProjectsList_SelectedIndexChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel8, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.treeViewContent, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(214, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.24859F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.75141F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(300, 511);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel8.Controls.Add(this.btOpen, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.btSave, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.btCheckIn, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.btCheckOut, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.btDelete, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.btUndo, 2, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 402);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(294, 106);
            this.tableLayoutPanel8.TabIndex = 1;
            // 
            // btOpen
            // 
            this.btOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btOpen.Image = global::DocumentManager.Properties.Resources.OpenDocumentCommand;
            this.btOpen.Location = new System.Drawing.Point(3, 3);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(91, 47);
            this.btOpen.TabIndex = 0;
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // btSave
            // 
            this.btSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btSave.Image = global::DocumentManager.Properties.Resources.SaveCommand;
            this.btSave.Location = new System.Drawing.Point(100, 3);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(92, 47);
            this.btSave.TabIndex = 0;
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btCheckIn
            // 
            this.btCheckIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btCheckIn.Image = global::DocumentManager.Properties.Resources.CheckInCommand;
            this.btCheckIn.Location = new System.Drawing.Point(3, 56);
            this.btCheckIn.Name = "btCheckIn";
            this.btCheckIn.Size = new System.Drawing.Size(91, 47);
            this.btCheckIn.TabIndex = 0;
            this.btCheckIn.UseVisualStyleBackColor = true;
            this.btCheckIn.Click += new System.EventHandler(this.btCheckIn_Click);
            // 
            // btCheckOut
            // 
            this.btCheckOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btCheckOut.Image = global::DocumentManager.Properties.Resources.CheckOutCommand;
            this.btCheckOut.Location = new System.Drawing.Point(100, 56);
            this.btCheckOut.Name = "btCheckOut";
            this.btCheckOut.Size = new System.Drawing.Size(92, 47);
            this.btCheckOut.TabIndex = 0;
            this.btCheckOut.UseVisualStyleBackColor = true;
            this.btCheckOut.Click += new System.EventHandler(this.btCheckOut_Click);
            // 
            // btDelete
            // 
            this.btDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btDelete.Image = global::DocumentManager.Properties.Resources.DeleteCommand;
            this.btDelete.Location = new System.Drawing.Point(198, 3);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(93, 47);
            this.btDelete.TabIndex = 0;
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btUndo
            // 
            this.btUndo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btUndo.Image = global::DocumentManager.Properties.Resources.UndoCheckOutCommand;
            this.btUndo.Location = new System.Drawing.Point(198, 56);
            this.btUndo.Name = "btUndo";
            this.btUndo.Size = new System.Drawing.Size(93, 47);
            this.btUndo.TabIndex = 0;
            this.btUndo.UseVisualStyleBackColor = true;
            this.btUndo.Click += new System.EventHandler(this.btUndo_Click);
            // 
            // treeViewContent
            // 
            this.treeViewContent.CheckBoxes = true;
            this.treeViewContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewContent.HideSelection = false;
            this.treeViewContent.ImageIndex = 0;
            this.treeViewContent.ImageList = this.imageList1;
            this.treeViewContent.Location = new System.Drawing.Point(3, 3);
            this.treeViewContent.Name = "treeViewContent";
            this.treeViewContent.SelectedImageIndex = 0;
            this.treeViewContent.Size = new System.Drawing.Size(294, 393);
            this.treeViewContent.TabIndex = 0;
            this.treeViewContent.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewContent_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder");
            this.imageList1.Images.SetKeyName(1, "file");
            // 
            // tabDocDetails
            // 
            this.tabDocDetails.ColumnCount = 1;
            this.tabDocDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tabDocDetails.Controls.Add(this.propertiesPanel, 0, 1);
            this.tabDocDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDocDetails.Location = new System.Drawing.Point(520, 3);
            this.tabDocDetails.Name = "tabDocDetails";
            this.tabDocDetails.RowCount = 3;
            this.tabDocDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabDocDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tabDocDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabDocDetails.Size = new System.Drawing.Size(476, 511);
            this.tabDocDetails.TabIndex = 0;
            // 
            // propertiesPanel
            // 
            this.propertiesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertiesPanel.Location = new System.Drawing.Point(3, 23);
            this.propertiesPanel.Name = "propertiesPanel";
            // 
            // propertiesPanel.Panel1
            // 
            this.propertiesPanel.Panel1.Controls.Add(this.listViewParams);
            // 
            // propertiesPanel.Panel2
            // 
            this.propertiesPanel.Panel2.Controls.Add(this.tableLayoutPanel6);
            this.propertiesPanel.Size = new System.Drawing.Size(470, 465);
            this.propertiesPanel.SplitterDistance = 210;
            this.propertiesPanel.TabIndex = 2;
            // 
            // listViewParams
            // 
            this.listViewParams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewParams.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewParams.HideSelection = false;
            this.listViewParams.Location = new System.Drawing.Point(0, 0);
            this.listViewParams.MultiSelect = false;
            this.listViewParams.Name = "listViewParams";
            this.listViewParams.Size = new System.Drawing.Size(210, 465);
            this.listViewParams.TabIndex = 0;
            this.listViewParams.UseCompatibleStateImageBehavior = false;
            this.listViewParams.View = System.Windows.Forms.View.Details;
            this.listViewParams.SelectedIndexChanged += new System.EventHandler(this.listViewParams_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Properties";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.04196F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.95804F));
            this.tableLayoutPanel6.Controls.Add(this.listEnumValues, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.txtParameterValue, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.81871F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.18129F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(256, 465);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // listEnumValues
            // 
            this.listEnumValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listEnumValues.FormattingEnabled = true;
            this.listEnumValues.Location = new System.Drawing.Point(10, 151);
            this.listEnumValues.Margin = new System.Windows.Forms.Padding(10);
            this.listEnumValues.Name = "listEnumValues";
            this.listEnumValues.Size = new System.Drawing.Size(128, 121);
            this.listEnumValues.TabIndex = 0;
            // 
            // txtParameterValue
            // 
            this.txtParameterValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParameterValue.Location = new System.Drawing.Point(10, 285);
            this.txtParameterValue.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.txtParameterValue.Name = "txtParameterValue";
            this.txtParameterValue.Size = new System.Drawing.Size(128, 20);
            this.txtParameterValue.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btModify);
            this.flowLayoutPanel1.Controls.Add(this.btClear);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(151, 285);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(102, 177);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btModify
            // 
            this.btModify.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btModify.Location = new System.Drawing.Point(3, 3);
            this.btModify.Name = "btModify";
            this.btModify.Size = new System.Drawing.Size(77, 23);
            this.btModify.TabIndex = 2;
            this.btModify.Text = "Modify";
            this.btModify.UseVisualStyleBackColor = true;
            this.btModify.Click += new System.EventHandler(this.btModify_Click);
            // 
            // btClear
            // 
            this.btClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btClear.Location = new System.Drawing.Point(3, 32);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(77, 23);
            this.btClear.TabIndex = 2;
            this.btClear.Text = "Clear";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 523);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Document Manager";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPreview)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tabDocDetails.ResumeLayout(false);
            this.propertiesPanel.Panel1.ResumeLayout(false);
            this.propertiesPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.propertiesPanel)).EndInit();
            this.propertiesPanel.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxPreview;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton rdbWorkingProjects;
        private System.Windows.Forms.RadioButton rdbLibrairies;
        private System.Windows.Forms.RadioButton rdbImportPackage;
        private System.Windows.Forms.ComboBox cmbProjectsList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.TextBox txtPackagePath;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView treeViewContent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCheckIn;
        private System.Windows.Forms.Button btCheckOut;
        private System.Windows.Forms.Button btUndo;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.TableLayoutPanel tabDocDetails;
        private System.Windows.Forms.SplitContainer propertiesPanel;
        private System.Windows.Forms.ListView listViewParams;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.ListBox listEnumValues;
        private System.Windows.Forms.TextBox txtParameterValue;
        private System.Windows.Forms.Button btModify;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btClear;
    }
}

