namespace InclusionManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btDrop = new System.Windows.Forms.Button();
            this.btSlottedMushrooms = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btCreateInclusion = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btDrop
            // 
            this.btDrop.Location = new System.Drawing.Point(13, 13);
            this.btDrop.Name = "btDrop";
            this.btDrop.Size = new System.Drawing.Size(141, 34);
            this.btDrop.TabIndex = 0;
            this.btDrop.Text = "Create and drop part";
            this.btDrop.UseVisualStyleBackColor = true;
            this.btDrop.Click += new System.EventHandler(this.btDrop_Click);
            // 
            // btSlottedMushrooms
            // 
            this.btSlottedMushrooms.Location = new System.Drawing.Point(13, 93);
            this.btSlottedMushrooms.Name = "btSlottedMushrooms";
            this.btSlottedMushrooms.Size = new System.Drawing.Size(141, 34);
            this.btSlottedMushrooms.TabIndex = 0;
            this.btSlottedMushrooms.Text = "Create slotted mushrooms";
            this.btSlottedMushrooms.UseVisualStyleBackColor = true;
            this.btSlottedMushrooms.Click += new System.EventHandler(this.btSlottedMushrooms_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "This example creates a part document then drop it into a new assembly document.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(391, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "This example shows how to insert whole family codes into an assembly document.";
            // 
            // btCreateInclusion
            // 
            this.btCreateInclusion.Location = new System.Drawing.Point(13, 53);
            this.btCreateInclusion.Name = "btCreateInclusion";
            this.btCreateInclusion.Size = new System.Drawing.Size(141, 34);
            this.btCreateInclusion.TabIndex = 0;
            this.btCreateInclusion.Text = "Create part inclusion";
            this.btCreateInclusion.UseVisualStyleBackColor = true;
            this.btCreateInclusion.Click += new System.EventHandler(this.btCreateInclusion_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "This example creates a basic inclusion.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 384);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btSlottedMushrooms);
            this.Controls.Add(this.btCreateInclusion);
            this.Controls.Add(this.btDrop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "InclusionManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btDrop;
        private System.Windows.Forms.Button btSlottedMushrooms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btCreateInclusion;
        private System.Windows.Forms.Label label3;
    }
}

