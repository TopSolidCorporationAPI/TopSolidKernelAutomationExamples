namespace RevisionManager
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.revisionTreeView = new System.Windows.Forms.TreeView();
            this.previewPicture = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btOpen = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btObsolete = new System.Windows.Forms.Button();
            this.btValidate = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.currentStateImage = new System.Windows.Forms.PictureBox();
            this.projectTreeView = new TopSolidAutomationControls.PDMTreeView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPicture)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentStateImage)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.projectTreeView);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 383);
            this.splitContainer1.SplitterDistance = 308;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.revisionTreeView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.previewPicture, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(488, 383);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // revisionTreeView
            // 
            this.revisionTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.revisionTreeView.FullRowSelect = true;
            this.revisionTreeView.Location = new System.Drawing.Point(13, 13);
            this.revisionTreeView.Name = "revisionTreeView";
            this.tableLayoutPanel1.SetRowSpan(this.revisionTreeView, 2);
            this.revisionTreeView.Size = new System.Drawing.Size(228, 357);
            this.revisionTreeView.TabIndex = 0;
            this.revisionTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.revisionTreeView_AfterSelect);
            // 
            // previewPicture
            // 
            this.previewPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPicture.Location = new System.Drawing.Point(247, 13);
            this.previewPicture.Name = "previewPicture";
            this.previewPicture.Size = new System.Drawing.Size(228, 175);
            this.previewPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewPicture.TabIndex = 1;
            this.previewPicture.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btOpen, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.currentStateImage, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(247, 194);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.18792F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.81208F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(228, 176);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // btOpen
            // 
            this.btOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.btOpen, 2);
            this.btOpen.Location = new System.Drawing.Point(10, 8);
            this.btOpen.Margin = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(208, 33);
            this.btOpen.TabIndex = 0;
            this.btOpen.Text = "Open";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btObsolete);
            this.flowLayoutPanel1.Controls.Add(this.btValidate);
            this.flowLayoutPanel1.Controls.Add(this.btDelete);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(119, 62);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(106, 100);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btObsolete
            // 
            this.btObsolete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btObsolete.Location = new System.Drawing.Point(0, 0);
            this.btObsolete.Margin = new System.Windows.Forms.Padding(0);
            this.btObsolete.Name = "btObsolete";
            this.btObsolete.Size = new System.Drawing.Size(106, 33);
            this.btObsolete.TabIndex = 0;
            this.btObsolete.Text = "Obsolete";
            this.btObsolete.UseVisualStyleBackColor = true;
            this.btObsolete.Click += new System.EventHandler(this.btObsolete_Click);
            // 
            // btValidate
            // 
            this.btValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btValidate.Location = new System.Drawing.Point(0, 33);
            this.btValidate.Margin = new System.Windows.Forms.Padding(0);
            this.btValidate.Name = "btValidate";
            this.btValidate.Size = new System.Drawing.Size(106, 33);
            this.btValidate.TabIndex = 0;
            this.btValidate.Text = "Validate";
            this.btValidate.UseVisualStyleBackColor = true;
            this.btValidate.Click += new System.EventHandler(this.btValidate_Click);
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.Location = new System.Drawing.Point(0, 66);
            this.btDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(106, 33);
            this.btDelete.TabIndex = 0;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // currentStateImage
            // 
            this.currentStateImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentStateImage.Location = new System.Drawing.Point(30, 79);
            this.currentStateImage.Margin = new System.Windows.Forms.Padding(30);
            this.currentStateImage.Name = "currentStateImage";
            this.currentStateImage.Size = new System.Drawing.Size(54, 67);
            this.currentStateImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.currentStateImage.TabIndex = 2;
            this.currentStateImage.TabStop = false;
            // 
            // projectTreeView
            // 
            this.projectTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectTreeView.DocumentTypes = new string[0];
            this.projectTreeView.HideSelection = false;
            this.projectTreeView.ImageIndex = 0;
            this.projectTreeView.Location = new System.Drawing.Point(10, 10);
            this.projectTreeView.Name = "projectTreeView";
            this.projectTreeView.SelectedImageIndex = 0;
            this.projectTreeView.Size = new System.Drawing.Size(288, 363);
            this.projectTreeView.TabIndex = 0;
            this.projectTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.projectTreeView_AfterSelect);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 383);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "RevisionManager";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previewPicture)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.currentStateImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TopSolidAutomationControls.PDMTreeView projectTreeView;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView revisionTreeView;
        private System.Windows.Forms.PictureBox previewPicture;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btObsolete;
        private System.Windows.Forms.Button btValidate;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.PictureBox currentStateImage;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

