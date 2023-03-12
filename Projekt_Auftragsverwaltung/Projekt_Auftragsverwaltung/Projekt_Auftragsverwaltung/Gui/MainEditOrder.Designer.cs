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
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DGWChooseCustomer = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGWChooseCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // LblArticle
            // 
            this.LblArticle.AutoSize = true;
            this.LblArticle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblArticle.Location = new System.Drawing.Point(41, 28);
            this.LblArticle.Name = "LblArticle";
            this.LblArticle.Size = new System.Drawing.Size(88, 28);
            this.LblArticle.TabIndex = 62;
            this.LblArticle.Text = "Aufträge";
            // 
            // CmdCreateOrderCancel
            // 
            this.CmdCreateOrderCancel.Location = new System.Drawing.Point(485, 141);
            this.CmdCreateOrderCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CmdCreateOrderCancel.Name = "CmdCreateOrderCancel";
            this.CmdCreateOrderCancel.Size = new System.Drawing.Size(116, 60);
            this.CmdCreateOrderCancel.TabIndex = 72;
            this.CmdCreateOrderCancel.Text = "Abbrechen";
            this.CmdCreateOrderCancel.UseVisualStyleBackColor = true;
            this.CmdCreateOrderCancel.Click += new System.EventHandler(this.CmdCreateOrderCancel_Click);
            // 
            // CmdCreateOrderSave
            // 
            this.CmdCreateOrderSave.Location = new System.Drawing.Point(485, 62);
            this.CmdCreateOrderSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CmdCreateOrderSave.Name = "CmdCreateOrderSave";
            this.CmdCreateOrderSave.Size = new System.Drawing.Size(116, 60);
            this.CmdCreateOrderSave.TabIndex = 71;
            this.CmdCreateOrderSave.Text = "Speichern";
            this.CmdCreateOrderSave.UseVisualStyleBackColor = true;
            this.CmdCreateOrderSave.Click += new System.EventHandler(this.CmdCreateOrderSave_Click);
            // 
            // DtpOrderDate
            // 
            this.DtpOrderDate.Location = new System.Drawing.Point(242, 135);
            this.DtpOrderDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DtpOrderDate.Name = "DtpOrderDate";
            this.DtpOrderDate.Size = new System.Drawing.Size(219, 23);
            this.DtpOrderDate.TabIndex = 86;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 15);
            this.label8.TabIndex = 82;
            this.label8.Text = "Datum";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 15);
            this.label7.TabIndex = 81;
            this.label7.Text = "Kunde auswählen:";
            // 
            // DGWChooseCustomer
            // 
            this.DGWChooseCustomer.AllowUserToAddRows = false;
            this.DGWChooseCustomer.AllowUserToDeleteRows = false;
            this.DGWChooseCustomer.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DGWChooseCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGWChooseCustomer.Location = new System.Drawing.Point(49, 232);
            this.DGWChooseCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DGWChooseCustomer.Name = "DGWChooseCustomer";
            this.DGWChooseCustomer.ReadOnly = true;
            this.DGWChooseCustomer.RowHeadersWidth = 51;
            this.DGWChooseCustomer.RowTemplate.Height = 29;
            this.DGWChooseCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGWChooseCustomer.Size = new System.Drawing.Size(984, 354);
            this.DGWChooseCustomer.TabIndex = 87;
            this.DGWChooseCustomer.VisibleChanged += new System.EventHandler(this.UpdateCustomerList);
            // 
            // MainEditOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 697);
            this.Controls.Add(this.DGWChooseCustomer);
            this.Controls.Add(this.DtpOrderDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CmdCreateOrderCancel);
            this.Controls.Add(this.CmdCreateOrderSave);
            this.Controls.Add(this.LblArticle);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainEditOrder";
            this.Text = "Auftrag speichern / bearbeiten";
            ((System.ComponentModel.ISupportInitialize)(this.DGWChooseCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label LblArticle;
        private Button CmdCreateOrderCancel;
        private Button CmdCreateOrderSave;
        private DateTimePicker DtpOrderDate;
        private Label label8;
        private Label label7;
        private DataGridView DGWChooseCustomer;
    }
}