namespace Projekt_Auftragsverwaltung.Gui
{
    partial class TreeViewClass
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
            this.treeView = new System.Windows.Forms.TreeView();
            this.CmdTreeViewShow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(77, 50);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(670, 456);
            this.treeView.TabIndex = 0;
            // 
            // CmdTreeViewShow
            // 
            this.CmdTreeViewShow.Location = new System.Drawing.Point(784, 50);
            this.CmdTreeViewShow.Name = "CmdTreeViewShow";
            this.CmdTreeViewShow.Size = new System.Drawing.Size(157, 56);
            this.CmdTreeViewShow.TabIndex = 1;
            this.CmdTreeViewShow.Text = "TreeViewZeigen";
            this.CmdTreeViewShow.UseVisualStyleBackColor = true;
            this.CmdTreeViewShow.Click += new System.EventHandler(this.CmdTreeViewShow_Click);
            // 
            // TreeViewClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 583);
            this.Controls.Add(this.CmdTreeViewShow);
            this.Controls.Add(this.treeView);
            this.Name = "TreeViewClass";
            this.Text = "TreeView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private Button CmdTreeViewShow;
    }
}