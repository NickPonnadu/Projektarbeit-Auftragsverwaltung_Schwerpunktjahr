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
            this.TxtPositionNumber = new System.Windows.Forms.TextBox();
            this.TxtPositionArticle = new System.Windows.Forms.TextBox();
            this.TxtPositionQuantity = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.CmdCreatePositionCancel = new System.Windows.Forms.Button();
            this.CmdCreatePositionSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtPositionNumber
            // 
            this.TxtPositionNumber.Location = new System.Drawing.Point(282, 123);
            this.TxtPositionNumber.Name = "TxtPositionNumber";
            this.TxtPositionNumber.Size = new System.Drawing.Size(125, 27);
            this.TxtPositionNumber.TabIndex = 94;
            // 
            // TxtPositionArticle
            // 
            this.TxtPositionArticle.Location = new System.Drawing.Point(282, 181);
            this.TxtPositionArticle.Name = "TxtPositionArticle";
            this.TxtPositionArticle.Size = new System.Drawing.Size(125, 27);
            this.TxtPositionArticle.TabIndex = 93;
            // 
            // TxtPositionQuantity
            // 
            this.TxtPositionQuantity.Location = new System.Drawing.Point(282, 239);
            this.TxtPositionQuantity.Name = "TxtPositionQuantity";
            this.TxtPositionQuantity.Size = new System.Drawing.Size(125, 27);
            this.TxtPositionQuantity.TabIndex = 92;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(65, 242);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 20);
            this.label14.TabIndex = 91;
            this.label14.Text = "Anzahl";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(62, 188);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 20);
            this.label13.TabIndex = 90;
            this.label13.Text = "Artikel";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(62, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 20);
            this.label12.TabIndex = 89;
            this.label12.Text = "Positionsnummer";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(62, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 35);
            this.label10.TabIndex = 88;
            this.label10.Text = "Positionen";
            // 
            // CmdCreatePositionCancel
            // 
            this.CmdCreatePositionCancel.Location = new System.Drawing.Point(545, 229);
            this.CmdCreatePositionCancel.Name = "CmdCreatePositionCancel";
            this.CmdCreatePositionCancel.Size = new System.Drawing.Size(133, 80);
            this.CmdCreatePositionCancel.TabIndex = 96;
            this.CmdCreatePositionCancel.Text = "Abbrechen";
            this.CmdCreatePositionCancel.UseVisualStyleBackColor = true;
            this.CmdCreatePositionCancel.Click += new System.EventHandler(this.CmdCreatePositionCancel_Click);
            // 
            // CmdCreatePositionSave
            // 
            this.CmdCreatePositionSave.Location = new System.Drawing.Point(545, 96);
            this.CmdCreatePositionSave.Name = "CmdCreatePositionSave";
            this.CmdCreatePositionSave.Size = new System.Drawing.Size(133, 80);
            this.CmdCreatePositionSave.TabIndex = 95;
            this.CmdCreatePositionSave.Text = "Speichern";
            this.CmdCreatePositionSave.UseVisualStyleBackColor = true;
            this.CmdCreatePositionSave.Click += new System.EventHandler(this.CmdCreatePositionSave_Click);
            // 
            // MainEditPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 641);
            this.Controls.Add(this.CmdCreatePositionCancel);
            this.Controls.Add(this.CmdCreatePositionSave);
            this.Controls.Add(this.TxtPositionNumber);
            this.Controls.Add(this.TxtPositionArticle);
            this.Controls.Add(this.TxtPositionQuantity);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Name = "MainEditPosition";
            this.Text = "Position speichern / bearbeiten";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox TxtPositionNumber;
        private TextBox TxtPositionArticle;
        private TextBox TxtPositionQuantity;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label10;
        private Button CmdCreatePositionCancel;
        private Button CmdCreatePositionSave;
    }
}