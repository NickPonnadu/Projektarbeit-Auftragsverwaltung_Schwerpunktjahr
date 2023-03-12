namespace Projekt_Auftragsverwaltung
{
    partial class MainEditArticle
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
            this.TxtArticleDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblArticle = new System.Windows.Forms.Label();
            this.CmdCreateArticleancel = new System.Windows.Forms.Button();
            this.CmdCreateArticleSave = new System.Windows.Forms.Button();
            this.NumArticlePrice = new System.Windows.Forms.NumericUpDown();
            this.DGWChooseArticleGroup = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.NumArticlePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGWChooseArticleGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtArticleDescription
            // 
            this.TxtArticleDescription.Location = new System.Drawing.Point(205, 83);
            this.TxtArticleDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtArticleDescription.Name = "TxtArticleDescription";
            this.TxtArticleDescription.Size = new System.Drawing.Size(110, 23);
            this.TxtArticleDescription.TabIndex = 69;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 66;
            this.label4.Text = "Bezeichnung";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 15);
            this.label3.TabIndex = 65;
            this.label3.Text = "Preis";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 15);
            this.label2.TabIndex = 64;
            this.label2.Text = "Artikelgruppe auswählen:";
            // 
            // LblArticle
            // 
            this.LblArticle.AutoSize = true;
            this.LblArticle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblArticle.Location = new System.Drawing.Point(40, 23);
            this.LblArticle.Name = "LblArticle";
            this.LblArticle.Size = new System.Drawing.Size(69, 28);
            this.LblArticle.TabIndex = 62;
            this.LblArticle.Text = "Artikel";
            // 
            // CmdCreateArticleancel
            // 
            this.CmdCreateArticleancel.Location = new System.Drawing.Point(416, 132);
            this.CmdCreateArticleancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CmdCreateArticleancel.Name = "CmdCreateArticleancel";
            this.CmdCreateArticleancel.Size = new System.Drawing.Size(116, 60);
            this.CmdCreateArticleancel.TabIndex = 72;
            this.CmdCreateArticleancel.Text = "Abbrechen";
            this.CmdCreateArticleancel.UseVisualStyleBackColor = true;
            this.CmdCreateArticleancel.Click += new System.EventHandler(this.CmdCreateArticleancel_Click);
            // 
            // CmdCreateArticleSave
            // 
            this.CmdCreateArticleSave.Location = new System.Drawing.Point(416, 53);
            this.CmdCreateArticleSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CmdCreateArticleSave.Name = "CmdCreateArticleSave";
            this.CmdCreateArticleSave.Size = new System.Drawing.Size(116, 60);
            this.CmdCreateArticleSave.TabIndex = 71;
            this.CmdCreateArticleSave.Text = "Speichern";
            this.CmdCreateArticleSave.UseVisualStyleBackColor = true;
            this.CmdCreateArticleSave.Click += new System.EventHandler(this.CmdCreateArticleSave_Click);
            // 
            // NumArticlePrice
            // 
            this.NumArticlePrice.DecimalPlaces = 2;
            this.NumArticlePrice.Location = new System.Drawing.Point(205, 118);
            this.NumArticlePrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NumArticlePrice.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumArticlePrice.Name = "NumArticlePrice";
            this.NumArticlePrice.Size = new System.Drawing.Size(109, 23);
            this.NumArticlePrice.TabIndex = 74;
            // 
            // DGWChooseArticleGroup
            // 
            this.DGWChooseArticleGroup.AllowUserToAddRows = false;
            this.DGWChooseArticleGroup.AllowUserToDeleteRows = false;
            this.DGWChooseArticleGroup.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DGWChooseArticleGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGWChooseArticleGroup.Location = new System.Drawing.Point(40, 214);
            this.DGWChooseArticleGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DGWChooseArticleGroup.Name = "DGWChooseArticleGroup";
            this.DGWChooseArticleGroup.ReadOnly = true;
            this.DGWChooseArticleGroup.RowHeadersWidth = 51;
            this.DGWChooseArticleGroup.RowTemplate.Height = 29;
            this.DGWChooseArticleGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGWChooseArticleGroup.Size = new System.Drawing.Size(492, 428);
            this.DGWChooseArticleGroup.TabIndex = 88;
            // 
            // MainEditArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 670);
            this.Controls.Add(this.DGWChooseArticleGroup);
            this.Controls.Add(this.NumArticlePrice);
            this.Controls.Add(this.CmdCreateArticleancel);
            this.Controls.Add(this.CmdCreateArticleSave);
            this.Controls.Add(this.TxtArticleDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblArticle);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainEditArticle";
            this.Text = "Kunde speichern / bearbeiten";
            this.VisibleChanged += new System.EventHandler(this.UpdateArticleGroupList);
            ((System.ComponentModel.ISupportInitialize)(this.NumArticlePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGWChooseArticleGroup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox TxtArticleDescription;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label LblArticle;
        private Button CmdCreateArticleancel;
        public Button CmdCreateArticleSave;
        private NumericUpDown NumArticlePrice;
        private DataGridView DGWChooseArticleGroup;
    }
}