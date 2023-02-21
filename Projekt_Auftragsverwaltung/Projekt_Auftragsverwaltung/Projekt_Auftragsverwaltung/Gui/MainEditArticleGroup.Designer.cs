namespace Projekt_Auftragsverwaltung
{
    partial class MainEditArticleGroup
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
            this.label3 = new System.Windows.Forms.Label();
            this.CmdCreateArticleGroupSave = new System.Windows.Forms.Button();
            this.TxtArticleGroupEditArticleGroup = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmdCreateArticleGroupCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(51, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 35);
            this.label3.TabIndex = 67;
            this.label3.Text = "Artikelgruppen";
            // 
            // CmdCreateArticleGroupSave
            // 
            this.CmdCreateArticleGroupSave.Location = new System.Drawing.Point(494, 103);
            this.CmdCreateArticleGroupSave.Name = "CmdCreateArticleGroupSave";
            this.CmdCreateArticleGroupSave.Size = new System.Drawing.Size(133, 80);
            this.CmdCreateArticleGroupSave.TabIndex = 66;
            this.CmdCreateArticleGroupSave.Text = "Speichern";
            this.CmdCreateArticleGroupSave.UseVisualStyleBackColor = true;
            this.CmdCreateArticleGroupSave.Click += new System.EventHandler(this.CmdCreateArticleGroupSave_Click);
            // 
            // TxtArticleGroupEditArticleGroup
            // 
            this.TxtArticleGroupEditArticleGroup.Location = new System.Drawing.Point(238, 188);
            this.TxtArticleGroupEditArticleGroup.Name = "TxtArticleGroupEditArticleGroup";
            this.TxtArticleGroupEditArticleGroup.Size = new System.Drawing.Size(197, 27);
            this.TxtArticleGroupEditArticleGroup.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 69;
            this.label1.Text = "Bezeichnung";
            // 
            // CmdCreateArticleGroupCancel
            // 
            this.CmdCreateArticleGroupCancel.Location = new System.Drawing.Point(494, 225);
            this.CmdCreateArticleGroupCancel.Name = "CmdCreateArticleGroupCancel";
            this.CmdCreateArticleGroupCancel.Size = new System.Drawing.Size(133, 80);
            this.CmdCreateArticleGroupCancel.TabIndex = 70;
            this.CmdCreateArticleGroupCancel.Text = "Abbrechen";
            this.CmdCreateArticleGroupCancel.UseVisualStyleBackColor = true;
            this.CmdCreateArticleGroupCancel.Click += new System.EventHandler(this.CmdCreateArticleGroupCancel_Click);
            // 
            // MainEditArticleGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 641);
            this.Controls.Add(this.CmdCreateArticleGroupCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmdCreateArticleGroupSave);
            this.Controls.Add(this.TxtArticleGroupEditArticleGroup);
            this.Name = "MainEditArticleGroup";
            this.Text = "Artikelgruppe speichern / bearbeiten";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label3;
        private Button CmdCreateArticleGroupSave;
        private TextBox TxtArticleGroupEditArticleGroup;
        private Label label1;
        private Button CmdCreateArticleGroupCancel;
    }
}