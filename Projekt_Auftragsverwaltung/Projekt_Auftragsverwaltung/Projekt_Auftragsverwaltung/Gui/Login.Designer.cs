namespace Projekt_Auftragsverwaltung
{
    partial class Login
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
            this.LblAuftragsverwaltung = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtDBServer = new System.Windows.Forms.TextBox();
            this.TxtDBName = new System.Windows.Forms.TextBox();
            this.CmdTestConnection = new System.Windows.Forms.Button();
            this.LblConnection = new System.Windows.Forms.Label();
            this.CmdStartApplication = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblAuftragsverwaltung
            // 
            this.LblAuftragsverwaltung.AutoSize = true;
            this.LblAuftragsverwaltung.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblAuftragsverwaltung.Location = new System.Drawing.Point(257, 65);
            this.LblAuftragsverwaltung.Name = "LblAuftragsverwaltung";
            this.LblAuftragsverwaltung.Size = new System.Drawing.Size(248, 37);
            this.LblAuftragsverwaltung.TabIndex = 0;
            this.LblAuftragsverwaltung.Text = "Auftragsverwaltung";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "DB-Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "DB-Name";
            // 
            // TxtDBServer
            // 
            this.TxtDBServer.Location = new System.Drawing.Point(182, 137);
            this.TxtDBServer.Name = "TxtDBServer";
            this.TxtDBServer.PlaceholderText = "z.B. LAPTOP-8OK55OPV\\MSSQLZBW";
            this.TxtDBServer.Size = new System.Drawing.Size(323, 27);
            this.TxtDBServer.TabIndex = 3;
            // 
            // TxtDBName
            // 
            this.TxtDBName.Location = new System.Drawing.Point(181, 185);
            this.TxtDBName.Name = "TxtDBName";
            this.TxtDBName.PlaceholderText = "z.B. testDB";
            this.TxtDBName.Size = new System.Drawing.Size(323, 27);
            this.TxtDBName.TabIndex = 4;
            // 
            // CmdTestConnection
            // 
            this.CmdTestConnection.Location = new System.Drawing.Point(182, 235);
            this.CmdTestConnection.Name = "CmdTestConnection";
            this.CmdTestConnection.Size = new System.Drawing.Size(324, 29);
            this.CmdTestConnection.TabIndex = 5;
            this.CmdTestConnection.Text = "Verbindung testen";
            this.CmdTestConnection.UseVisualStyleBackColor = true;
            this.CmdTestConnection.Click += new System.EventHandler(this.CmdTestConnection_Click);
            // 
            // LblConnection
            // 
            this.LblConnection.AutoSize = true;
            this.LblConnection.Location = new System.Drawing.Point(182, 288);
            this.LblConnection.Name = "LblConnection";
            this.LblConnection.Size = new System.Drawing.Size(134, 20);
            this.LblConnection.TabIndex = 6;
            this.LblConnection.Text = "Bitte DB verbinden";
            // 
            // CmdStartApplication
            // 
            this.CmdStartApplication.Location = new System.Drawing.Point(181, 342);
            this.CmdStartApplication.Name = "CmdStartApplication";
            this.CmdStartApplication.Size = new System.Drawing.Size(323, 47);
            this.CmdStartApplication.TabIndex = 7;
            this.CmdStartApplication.Text = "Applikation starten";
            this.CmdStartApplication.UseVisualStyleBackColor = true;
            this.CmdStartApplication.Click += new System.EventHandler(this.CmdStartApplication_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CmdStartApplication);
            this.Controls.Add(this.LblConnection);
            this.Controls.Add(this.CmdTestConnection);
            this.Controls.Add(this.TxtDBName);
            this.Controls.Add(this.TxtDBServer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblAuftragsverwaltung);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label LblAuftragsverwaltung;
        private Label label1;
        private Label label2;
        private TextBox TxtDBServer;
        private TextBox TxtDBName;
        private Button CmdTestConnection;
        private Label LblConnection;
        private Button CmdStartApplication;
    }
}