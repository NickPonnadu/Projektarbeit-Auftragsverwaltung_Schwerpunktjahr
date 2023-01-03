namespace Projekt_Auftragsverwaltung
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblKunden = new System.Windows.Forms.Label();
            this.CmdCreate = new System.Windows.Forms.Button();
            this.CmdEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblKunden
            // 
            this.LblKunden.AutoSize = true;
            this.LblKunden.Location = new System.Drawing.Point(71, 45);
            this.LblKunden.Name = "LblKunden";
            this.LblKunden.Size = new System.Drawing.Size(59, 20);
            this.LblKunden.TabIndex = 0;
            this.LblKunden.Text = "Kunden";
            // 
            // CmdCreate
            // 
            this.CmdCreate.Location = new System.Drawing.Point(468, 54);
            this.CmdCreate.Name = "CmdCreate";
            this.CmdCreate.Size = new System.Drawing.Size(94, 29);
            this.CmdCreate.TabIndex = 1;
            this.CmdCreate.Text = "Erstellen";
            this.CmdCreate.UseVisualStyleBackColor = true;
            // 
            // CmdEdit
            // 
            this.CmdEdit.Location = new System.Drawing.Point(468, 110);
            this.CmdEdit.Name = "CmdEdit";
            this.CmdEdit.Size = new System.Drawing.Size(94, 29);
            this.CmdEdit.TabIndex = 2;
            this.CmdEdit.Text = "Bearbeiten";
            this.CmdEdit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CmdEdit);
            this.Controls.Add(this.CmdCreate);
            this.Controls.Add(this.LblKunden);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label LblKunden;
        private Button CmdCreate;
        private Button CmdEdit;
    }
}