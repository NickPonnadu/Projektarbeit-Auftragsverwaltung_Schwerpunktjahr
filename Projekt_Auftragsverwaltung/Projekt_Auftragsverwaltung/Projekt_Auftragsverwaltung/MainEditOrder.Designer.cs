namespace Projekt_Auftragsverwaltung
{
    partial class MainEditOrder
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
            this.LblArticle = new System.Windows.Forms.Label();
            this.CmdCreateOrderCancel = new System.Windows.Forms.Button();
            this.CmdCreateOrderSave = new System.Windows.Forms.Button();
            this.DtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.TxtOrderCustomer = new System.Windows.Forms.TextBox();
            this.TxtOrderNumber = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblArticle
            // 
            this.LblArticle.AutoSize = true;
            this.LblArticle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblArticle.Location = new System.Drawing.Point(47, 38);
            this.LblArticle.Name = "LblArticle";
            this.LblArticle.Size = new System.Drawing.Size(111, 35);
            this.LblArticle.TabIndex = 62;
            this.LblArticle.Text = "Aufträge";
            // 
            // CmdCreateOrderCancel
            // 
            this.CmdCreateOrderCancel.Location = new System.Drawing.Point(554, 188);
            this.CmdCreateOrderCancel.Name = "CmdCreateOrderCancel";
            this.CmdCreateOrderCancel.Size = new System.Drawing.Size(133, 80);
            this.CmdCreateOrderCancel.TabIndex = 72;
            this.CmdCreateOrderCancel.Text = "Abbrechen";
            this.CmdCreateOrderCancel.UseVisualStyleBackColor = true;
            this.CmdCreateOrderCancel.Click += new System.EventHandler(this.CmdCreateOrderCancel_Click);
            // 
            // CmdCreateOrderSave
            // 
            this.CmdCreateOrderSave.Location = new System.Drawing.Point(554, 83);
            this.CmdCreateOrderSave.Name = "CmdCreateOrderSave";
            this.CmdCreateOrderSave.Size = new System.Drawing.Size(133, 80);
            this.CmdCreateOrderSave.TabIndex = 71;
            this.CmdCreateOrderSave.Text = "Speichern";
            this.CmdCreateOrderSave.UseVisualStyleBackColor = true;
            this.CmdCreateOrderSave.Click += new System.EventHandler(this.CmdCreateOrderSave_Click);
            // 
            // DtpOrderDate
            // 
            this.DtpOrderDate.Location = new System.Drawing.Point(276, 180);
            this.DtpOrderDate.Name = "DtpOrderDate";
            this.DtpOrderDate.Size = new System.Drawing.Size(250, 27);
            this.DtpOrderDate.TabIndex = 86;
            // 
            // TxtOrderCustomer
            // 
            this.TxtOrderCustomer.Location = new System.Drawing.Point(276, 241);
            this.TxtOrderCustomer.Name = "TxtOrderCustomer";
            this.TxtOrderCustomer.Size = new System.Drawing.Size(125, 27);
            this.TxtOrderCustomer.TabIndex = 85;
            // 
            // TxtOrderNumber
            // 
            this.TxtOrderNumber.Location = new System.Drawing.Point(276, 124);
            this.TxtOrderNumber.Name = "TxtOrderNumber";
            this.TxtOrderNumber.Size = new System.Drawing.Size(125, 27);
            this.TxtOrderNumber.TabIndex = 84;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(56, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 20);
            this.label9.TabIndex = 83;
            this.label9.Text = "Auftragsnummer";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(56, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.TabIndex = 82;
            this.label8.Text = "Datum";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(56, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 81;
            this.label7.Text = "Kunde";
            // 
            // MainEditOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 641);
            this.Controls.Add(this.DtpOrderDate);
            this.Controls.Add(this.TxtOrderCustomer);
            this.Controls.Add(this.TxtOrderNumber);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CmdCreateOrderCancel);
            this.Controls.Add(this.CmdCreateOrderSave);
            this.Controls.Add(this.LblArticle);
            this.Name = "MainEditOrder";
            this.Text = "Auftrag speichern / bearbeiten";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label LblArticle;
        private Button CmdCreateOrderCancel;
        private Button CmdCreateOrderSave;
        private DateTimePicker DtpOrderDate;
        private TextBox TxtOrderCustomer;
        private TextBox TxtOrderNumber;
        private Label label9;
        private Label label8;
        private Label label7;
    }
}