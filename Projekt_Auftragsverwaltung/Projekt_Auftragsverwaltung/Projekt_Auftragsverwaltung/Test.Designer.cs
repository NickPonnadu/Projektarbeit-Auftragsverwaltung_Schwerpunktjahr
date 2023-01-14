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
            this.CmdCreateString = new System.Windows.Forms.Button();
            this.CmdTestConnection = new System.Windows.Forms.Button();
            this.TxtWert = new System.Windows.Forms.TextBox();
            this.LblText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblKunden
            // 
            this.LblKunden.AutoSize = true;
            this.LblKunden.Font = new System.Drawing.Font("Segoe UI Symbol", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblKunden.Location = new System.Drawing.Point(-2, -5);
            this.LblKunden.Name = "LblKunden";
            this.LblKunden.Size = new System.Drawing.Size(220, 65);
            this.LblKunden.TabIndex = 0;
            this.LblKunden.Text = "TEST GUI";
            // 
            // CmdCreateString
            // 
            this.CmdCreateString.Location = new System.Drawing.Point(-2, 62);
            this.CmdCreateString.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CmdCreateString.Name = "CmdCreateString";
            this.CmdCreateString.Size = new System.Drawing.Size(184, 22);
            this.CmdCreateString.TabIndex = 1;
            this.CmdCreateString.Text = "Erstellen Connection String";
            this.CmdCreateString.UseVisualStyleBackColor = true;
            this.CmdCreateString.Click += new System.EventHandler(this.CmdCreate_Click);
            // 
            // CmdTestConnection
            // 
            this.CmdTestConnection.Location = new System.Drawing.Point(906, 84);
            this.CmdTestConnection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CmdTestConnection.Name = "CmdTestConnection";
            this.CmdTestConnection.Size = new System.Drawing.Size(83, 22);
            this.CmdTestConnection.TabIndex = 2;
            this.CmdTestConnection.Text = "Teste Datenbank Verbindung";
            this.CmdTestConnection.UseVisualStyleBackColor = true;
            // 
            // TxtWert
            // 
            this.TxtWert.Location = new System.Drawing.Point(124, 83);
            this.TxtWert.Name = "TxtWert";
            this.TxtWert.Size = new System.Drawing.Size(776, 23);
            this.TxtWert.TabIndex = 3;
            // 
            // LblText
            // 
            this.LblText.AutoSize = true;
            this.LblText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblText.Location = new System.Drawing.Point(-2, 86);
            this.LblText.Name = "LblText";
            this.LblText.Size = new System.Drawing.Size(120, 15);
            this.LblText.TabIndex = 4;
            this.LblText.Text = "Gewünschte Eingabe:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 130);
            this.Controls.Add(this.LblText);
            this.Controls.Add(this.TxtWert);
            this.Controls.Add(this.CmdTestConnection);
            this.Controls.Add(this.CmdCreateString);
            this.Controls.Add(this.LblKunden);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label LblKunden;
        private Button CmdCreateString;
        private Button CmdTestConnection;
        private TextBox TxtWert;
        private Label LblText;
    }
}