namespace Projekt_Auftragsverwaltung
{
    partial class MainEditPosition
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
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.CmdCreatePositionCancel = new System.Windows.Forms.Button();
            this.CmdCreatePositionSave = new System.Windows.Forms.Button();
            this.DGWChooseOrder = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.NumOrderPositionQuantity = new System.Windows.Forms.NumericUpDown();
            this.DGWChooseArticles = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGWChooseOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumOrderPositionQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGWChooseArticles)).BeginInit();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(54, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 15);
            this.label14.TabIndex = 91;
            this.label14.Text = "Anzahl";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(54, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 28);
            this.label10.TabIndex = 88;
            this.label10.Text = "Positionen";
            // 
            // CmdCreatePositionCancel
            // 
            this.CmdCreatePositionCancel.Location = new System.Drawing.Point(665, 68);
            this.CmdCreatePositionCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CmdCreatePositionCancel.Name = "CmdCreatePositionCancel";
            this.CmdCreatePositionCancel.Size = new System.Drawing.Size(116, 60);
            this.CmdCreatePositionCancel.TabIndex = 96;
            this.CmdCreatePositionCancel.Text = "Abbrechen";
            this.CmdCreatePositionCancel.UseVisualStyleBackColor = true;
            this.CmdCreatePositionCancel.Click += new System.EventHandler(this.CmdCreatePositionCancel_Click);
            // 
            // CmdCreatePositionSave
            // 
            this.CmdCreatePositionSave.Location = new System.Drawing.Point(465, 68);
            this.CmdCreatePositionSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CmdCreatePositionSave.Name = "CmdCreatePositionSave";
            this.CmdCreatePositionSave.Size = new System.Drawing.Size(116, 60);
            this.CmdCreatePositionSave.TabIndex = 95;
            this.CmdCreatePositionSave.Text = "Speichern";
            this.CmdCreatePositionSave.UseVisualStyleBackColor = true;
            this.CmdCreatePositionSave.Click += new System.EventHandler(this.CmdCreatePositionSave_Click);
            // 
            // DGWChooseOrder
            // 
            this.DGWChooseOrder.AllowUserToAddRows = false;
            this.DGWChooseOrder.AllowUserToDeleteRows = false;
            this.DGWChooseOrder.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DGWChooseOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGWChooseOrder.Location = new System.Drawing.Point(54, 199);
            this.DGWChooseOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DGWChooseOrder.Name = "DGWChooseOrder";
            this.DGWChooseOrder.RowHeadersWidth = 51;
            this.DGWChooseOrder.RowTemplate.Height = 29;
            this.DGWChooseOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGWChooseOrder.Size = new System.Drawing.Size(583, 354);
            this.DGWChooseOrder.TabIndex = 97;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 15);
            this.label1.TabIndex = 98;
            this.label1.Text = "Auftrag Auswählen:";
            // 
            // NumOrderPositionQuantity
            // 
            this.NumOrderPositionQuantity.Location = new System.Drawing.Point(228, 83);
            this.NumOrderPositionQuantity.Name = "NumOrderPositionQuantity";
            this.NumOrderPositionQuantity.Size = new System.Drawing.Size(120, 23);
            this.NumOrderPositionQuantity.TabIndex = 99;
            // 
            // DGWChooseArticles
            // 
            this.DGWChooseArticles.AllowUserToAddRows = false;
            this.DGWChooseArticles.AllowUserToDeleteRows = false;
            this.DGWChooseArticles.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DGWChooseArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGWChooseArticles.Location = new System.Drawing.Point(660, 199);
            this.DGWChooseArticles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DGWChooseArticles.Name = "DGWChooseArticles";
            this.DGWChooseArticles.RowHeadersWidth = 51;
            this.DGWChooseArticles.RowTemplate.Height = 29;
            this.DGWChooseArticles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGWChooseArticles.Size = new System.Drawing.Size(583, 354);
            this.DGWChooseArticles.TabIndex = 100;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(665, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 101;
            this.label2.Text = "Artikel Auswählen";
            // 
            // MainEditPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 662);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DGWChooseArticles);
            this.Controls.Add(this.NumOrderPositionQuantity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGWChooseOrder);
            this.Controls.Add(this.CmdCreatePositionCancel);
            this.Controls.Add(this.CmdCreatePositionSave);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label10);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainEditPosition";
            this.Text = "Position speichern / bearbeiten";
            this.VisibleChanged += new System.EventHandler(this.UpdateLists);
            ((System.ComponentModel.ISupportInitialize)(this.DGWChooseOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumOrderPositionQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGWChooseArticles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label14;
        private Label label10;
        private Button CmdCreatePositionCancel;
        private Button CmdCreatePositionSave;
        private DataGridView DGWChooseOrder;
        private Label label1;
        private NumericUpDown NumOrderPositionQuantity;
        private DataGridView DGWChooseArticles;
        private Label label2;
    }
}