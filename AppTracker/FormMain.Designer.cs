
namespace AppTracker
{
    partial class FormMain
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
            this.btnAddPeriod = new System.Windows.Forms.Button();
            this.treeViewPeriod = new System.Windows.Forms.TreeView();
            this.btnPosition = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddPeriod
            // 
            this.btnAddPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPeriod.Location = new System.Drawing.Point(437, 518);
            this.btnAddPeriod.Name = "btnAddPeriod";
            this.btnAddPeriod.Size = new System.Drawing.Size(75, 23);
            this.btnAddPeriod.TabIndex = 0;
            this.btnAddPeriod.Text = "Add Period";
            this.btnAddPeriod.UseVisualStyleBackColor = true;
            this.btnAddPeriod.Click += new System.EventHandler(this.btnAddPeriod_Click);
            // 
            // treeViewPeriod
            // 
            this.treeViewPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewPeriod.Location = new System.Drawing.Point(12, 12);
            this.treeViewPeriod.Name = "treeViewPeriod";
            this.treeViewPeriod.Size = new System.Drawing.Size(414, 528);
            this.treeViewPeriod.TabIndex = 1;
            this.treeViewPeriod.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewPeriod_NodeMouseClick);
            this.treeViewPeriod.DoubleClick += new System.EventHandler(this.treeViewPeriod_DoubleClick);
            // 
            // btnPosition
            // 
            this.btnPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPosition.Location = new System.Drawing.Point(437, 489);
            this.btnPosition.Name = "btnPosition";
            this.btnPosition.Size = new System.Drawing.Size(75, 23);
            this.btnPosition.TabIndex = 2;
            this.btnPosition.Text = "Add Position";
            this.btnPosition.UseVisualStyleBackColor = true;
            this.btnPosition.Click += new System.EventHandler(this.btnPosition_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 553);
            this.Controls.Add(this.btnPosition);
            this.Controls.Add(this.treeViewPeriod);
            this.Controls.Add(this.btnAddPeriod);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddPeriod;
        private System.Windows.Forms.TreeView treeViewPeriod;
        private System.Windows.Forms.Button btnPosition;
    }
}

