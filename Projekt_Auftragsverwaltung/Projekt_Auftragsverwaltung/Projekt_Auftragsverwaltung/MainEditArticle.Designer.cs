﻿namespace Projekt_Auftragsverwaltung
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
            this.TxtArticleNumber = new System.Windows.Forms.TextBox();
            this.TxtArticleDescription = new System.Windows.Forms.TextBox();
            this.TxtArticlePrice = new System.Windows.Forms.TextBox();
            this.TxtArticleArticlegroup = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblArticle = new System.Windows.Forms.Label();
            this.CmdCreateArticleancel = new System.Windows.Forms.Button();
            this.CmdCreateArticleSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtArticleNumber
            // 
            this.TxtArticleNumber.Location = new System.Drawing.Point(230, 123);
            this.TxtArticleNumber.Name = "TxtArticleNumber";
            this.TxtArticleNumber.Size = new System.Drawing.Size(125, 27);
            this.TxtArticleNumber.TabIndex = 70;
            // 
            // TxtArticleDescription
            // 
            this.TxtArticleDescription.Location = new System.Drawing.Point(230, 179);
            this.TxtArticleDescription.Name = "TxtArticleDescription";
            this.TxtArticleDescription.Size = new System.Drawing.Size(125, 27);
            this.TxtArticleDescription.TabIndex = 69;
            // 
            // TxtArticlePrice
            // 
            this.TxtArticlePrice.Location = new System.Drawing.Point(230, 228);
            this.TxtArticlePrice.Name = "TxtArticlePrice";
            this.TxtArticlePrice.Size = new System.Drawing.Size(125, 27);
            this.TxtArticlePrice.TabIndex = 68;
            // 
            // TxtArticleArticlegroup
            // 
            this.TxtArticleArticlegroup.Location = new System.Drawing.Point(230, 271);
            this.TxtArticleArticlegroup.Name = "TxtArticleArticlegroup";
            this.TxtArticleArticlegroup.Size = new System.Drawing.Size(125, 27);
            this.TxtArticleArticlegroup.TabIndex = 67;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 66;
            this.label4.Text = "Bezeichnung";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 65;
            this.label3.Text = "Preis";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 64;
            this.label2.Text = "Artikelgruppe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 63;
            this.label1.Text = "Artikelnummer";
            // 
            // LblArticle
            // 
            this.LblArticle.AutoSize = true;
            this.LblArticle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblArticle.Location = new System.Drawing.Point(46, 31);
            this.LblArticle.Name = "LblArticle";
            this.LblArticle.Size = new System.Drawing.Size(85, 35);
            this.LblArticle.TabIndex = 62;
            this.LblArticle.Text = "Artikel";
            // 
            // CmdCreateArticleancel
            // 
            this.CmdCreateArticleancel.Location = new System.Drawing.Point(466, 228);
            this.CmdCreateArticleancel.Name = "CmdCreateArticleancel";
            this.CmdCreateArticleancel.Size = new System.Drawing.Size(133, 80);
            this.CmdCreateArticleancel.TabIndex = 72;
            this.CmdCreateArticleancel.Text = "Abbrechen";
            this.CmdCreateArticleancel.UseVisualStyleBackColor = true;
            this.CmdCreateArticleancel.Click += new System.EventHandler(this.CmdCreateArticleancel_Click);
            // 
            // CmdCreateArticleSave
            // 
            this.CmdCreateArticleSave.Location = new System.Drawing.Point(466, 123);
            this.CmdCreateArticleSave.Name = "CmdCreateArticleSave";
            this.CmdCreateArticleSave.Size = new System.Drawing.Size(133, 80);
            this.CmdCreateArticleSave.TabIndex = 71;
            this.CmdCreateArticleSave.Text = "Speichern";
            this.CmdCreateArticleSave.UseVisualStyleBackColor = true;
            this.CmdCreateArticleSave.Click += new System.EventHandler(this.CmdCreateArticleSave_Click);
            // 
            // MainEditArticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 641);
            this.Controls.Add(this.CmdCreateArticleancel);
            this.Controls.Add(this.CmdCreateArticleSave);
            this.Controls.Add(this.TxtArticleNumber);
            this.Controls.Add(this.TxtArticleDescription);
            this.Controls.Add(this.TxtArticlePrice);
            this.Controls.Add(this.TxtArticleArticlegroup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblArticle);
            this.Name = "MainEditArticle";
            this.Text = "Kunde speichern / bearbeiten";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox TxtArticleNumber;
        private TextBox TxtArticleDescription;
        private TextBox TxtArticlePrice;
        private TextBox TxtArticleArticlegroup;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label LblArticle;
        private Button CmdCreateArticleancel;
        public Button CmdCreateArticleSave;
    }
}