
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rdbWorkingProjects = new System.Windows.Forms.RadioButton();
            this.rdbLibrairies = new System.Windows.Forms.RadioButton();
            this.rdbImportPackage = new System.Windows.Forms.RadioButton();
            this.cmbProjectsList = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btBrowse = new System.Windows.Forms.Button();
            this.txtPackagePath = new System.Windows.Forms.TextBox();
            this.btManage = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.treeViewContent = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPreview)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBoxPreview
            // 
            this.picBoxPreview.Location = new System.Drawing.Point(3, 3);
            this.picBoxPreview.Name = "picBoxPreview";
            this.picBoxPreview.Size = new System.Drawing.Size(85, 117);
            this.picBoxPreview.TabIndex = 0;
            this.picBoxPreview.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.07335F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.92665F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(627, 478);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.rdbWorkingProjects, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.rdbLibrairies, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.rdbImportPackage, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.cmbProjectsList, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.btManage, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(621, 137);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // rdbWorkingProjects
            // 
            this.rdbWorkingProjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbWorkingProjects.AutoSize = true;
            this.rdbWorkingProjects.Location = new System.Drawing.Point(23, 3);
            this.rdbWorkingProjects.Name = "rdbWorkingProjects";
            this.rdbWorkingProjects.Size = new System.Drawing.Size(106, 39);
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
            this.rdbLibrairies.Location = new System.Drawing.Point(23, 48);
            this.rdbLibrairies.Name = "rdbLibrairies";
            this.rdbLibrairies.Size = new System.Drawing.Size(66, 39);
            this.rdbLibrairies.TabIndex = 0;
            this.rdbLibrairies.TabStop = true;
            this.rdbLibrairies.Text = "Librairies";
            this.rdbLibrairies.UseVisualStyleBackColor = true;
            this.rdbLibrairies.CheckedChanged += new System.EventHandler(this.rdbLibrairies_CheckedChanged);
            // 
            // rdbImportPackage
            // 
            this.rdbImportPackage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbImportPackage.AutoSize = true;
            this.rdbImportPackage.Location = new System.Drawing.Point(23, 93);
            this.rdbImportPackage.Name = "rdbImportPackage";
            this.rdbImportPackage.Size = new System.Drawing.Size(112, 41);
            this.rdbImportPackage.TabIndex = 0;
            this.rdbImportPackage.TabStop = true;
            this.rdbImportPackage.Text = "Imported Package";
            this.rdbImportPackage.UseVisualStyleBackColor = true;
            this.rdbImportPackage.CheckedChanged += new System.EventHandler(this.rdbImportPackage_CheckedChanged);
            // 
            // cmbProjectsList
            // 
            this.cmbProjectsList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProjectsList.DisplayMember = "Name";
            this.cmbProjectsList.FormattingEnabled = true;
            this.cmbProjectsList.Location = new System.Drawing.Point(230, 57);
            this.cmbProjectsList.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.cmbProjectsList.Name = "cmbProjectsList";
            this.cmbProjectsList.Size = new System.Drawing.Size(180, 21);
            this.cmbProjectsList.TabIndex = 1;
            this.cmbProjectsList.SelectedIndexChanged += new System.EventHandler(this.cmbProjectsList_SelectedIndexChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.btBrowse, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtPackagePath, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(223, 93);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(194, 41);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // btBrowse
            // 
            this.btBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowse.Location = new System.Drawing.Point(158, 9);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(33, 23);
            this.btBrowse.TabIndex = 0;
            this.btBrowse.Text = "...";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // txtPackagePath
            // 
            this.txtPackagePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPackagePath.Enabled = false;
            this.txtPackagePath.Location = new System.Drawing.Point(3, 10);
            this.txtPackagePath.Name = "txtPackagePath";
            this.txtPackagePath.Size = new System.Drawing.Size(149, 20);
            this.txtPackagePath.TabIndex = 1;
            // 
            // btManage
            // 
            this.btManage.Dock = System.Windows.Forms.DockStyle.Right;
            this.btManage.Location = new System.Drawing.Point(488, 20);
            this.btManage.Margin = new System.Windows.Forms.Padding(20);
            this.btManage.Name = "btManage";
            this.tableLayoutPanel2.SetRowSpan(this.btManage, 3);
            this.btManage.Size = new System.Drawing.Size(113, 97);
            this.btManage.TabIndex = 3;
            this.btManage.Text = "Manage Documents";
            this.btManage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 146);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(611, 319);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.treeViewContent, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(299, 300);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // treeViewContent
            // 
            this.treeViewContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewContent.CheckBoxes = true;
            this.treeViewContent.ImageIndex = 0;
            this.treeViewContent.ImageList = this.imageList1;
            this.treeViewContent.Location = new System.Drawing.Point(3, 3);
            this.treeViewContent.Name = "treeViewContent";
            this.treeViewContent.SelectedImageIndex = 0;
            this.treeViewContent.Size = new System.Drawing.Size(293, 243);
            this.treeViewContent.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Controls.Add(this.picBoxPreview, 0, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(308, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(274, 300);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            this.imageList1.Images.SetKeyName(1, "file.png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 502);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Document Manager";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPreview)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
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
        private System.Windows.Forms.Button btManage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TreeView treeViewContent;
        private System.Windows.Forms.ImageList imageList1;
    }
}

