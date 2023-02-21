namespace Projekt_Auftragsverwaltung
{
    partial class Main
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.Kunden = new System.Windows.Forms.TabPage();
            this.CmbCustomerSearchProperty = new System.Windows.Forms.ComboBox();
            this.CmdDeleteCustomer = new System.Windows.Forms.Button();
            this.TxtCustomerSearchProperty = new System.Windows.Forms.TextBox();
            this.LblCustomerSearchField = new System.Windows.Forms.Label();
            this.DGWCustomers = new System.Windows.Forms.DataGridView();
            this.CmdSearchResetCustomer = new System.Windows.Forms.Button();
            this.CmdCustomerSearch = new System.Windows.Forms.Button();
            this.CmdEditCustomer = new System.Windows.Forms.Button();
            this.CmdCreateCustomer = new System.Windows.Forms.Button();
            this.Artikelgruppen = new System.Windows.Forms.TabPage();
            this.CmdDeleteArticleGroup = new System.Windows.Forms.Button();
            this.CmdSearchResetArticleGroup = new System.Windows.Forms.Button();
            this.CmdSearchArticleGroup = new System.Windows.Forms.Button();
            this.CmdEditArticleGroup = new System.Windows.Forms.Button();
            this.CmdCreateArticleGroup = new System.Windows.Forms.Button();
            this.DGWArticleGroups = new System.Windows.Forms.DataGridView();
            this.TxtArticleGroupSearchName = new System.Windows.Forms.TextBox();
            this.LblArticleGroupSearch = new System.Windows.Forms.Label();
            this.LblArticleGroups = new System.Windows.Forms.Label();
            this.Artikel = new System.Windows.Forms.TabPage();
            this.CmbArticleSearchProperty = new System.Windows.Forms.ComboBox();
            this.DGWArticles = new System.Windows.Forms.DataGridView();
            this.TxtSearchArticleProperty = new System.Windows.Forms.TextBox();
            this.CmdDeleteArticle = new System.Windows.Forms.Button();
            this.CmdSearchResetArticle = new System.Windows.Forms.Button();
            this.CmdSearchArticle = new System.Windows.Forms.Button();
            this.CmdEditArticle = new System.Windows.Forms.Button();
            this.CmdCreateArticle = new System.Windows.Forms.Button();
            this.LblSearchName = new System.Windows.Forms.Label();
            this.LblArticle = new System.Windows.Forms.Label();
            this.Aufträge = new System.Windows.Forms.TabPage();
            this.CmbOrderSearchProperty = new System.Windows.Forms.ComboBox();
            this.DGWOrders = new System.Windows.Forms.DataGridView();
            this.TxtSearchOrderProperty = new System.Windows.Forms.TextBox();
            this.CmdDeleteOrder = new System.Windows.Forms.Button();
            this.CmdSearchResetOrder = new System.Windows.Forms.Button();
            this.CmdSearchOrder = new System.Windows.Forms.Button();
            this.CmdEditOrder = new System.Windows.Forms.Button();
            this.CmdCreateOrder = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Positionen = new System.Windows.Forms.TabPage();
            this.CmdPositionSearchProperty = new System.Windows.Forms.ComboBox();
            this.DGWPositions = new System.Windows.Forms.DataGridView();
            this.TxtSearchPositionProperty = new System.Windows.Forms.TextBox();
            this.CmdDeletePosition = new System.Windows.Forms.Button();
            this.CmdSearchResetPosition = new System.Windows.Forms.Button();
            this.CmdSearchPosition = new System.Windows.Forms.Button();
            this.CmdEditPosition = new System.Windows.Forms.Button();
            this.CmdCreatePosition = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Jahresvergleich = new System.Windows.Forms.TabPage();
            this.AbfrageRechnungen = new System.Windows.Forms.TabPage();
            this.TabControl.SuspendLayout();
            this.Kunden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGWCustomers)).BeginInit();
            this.Artikelgruppen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGWArticleGroups)).BeginInit();
            this.Artikel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGWArticles)).BeginInit();
            this.Aufträge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGWOrders)).BeginInit();
            this.Positionen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGWPositions)).BeginInit();
            this.SuspendLayout();
            // 
            // LblKunden
            // 
            this.LblKunden.AutoSize = true;
            this.LblKunden.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblKunden.Location = new System.Drawing.Point(35, 29);
            this.LblKunden.Name = "LblKunden";
            this.LblKunden.Size = new System.Drawing.Size(100, 35);
            this.LblKunden.TabIndex = 0;
            this.LblKunden.Text = "Kunden";
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.Kunden);
            this.TabControl.Controls.Add(this.Artikelgruppen);
            this.TabControl.Controls.Add(this.Artikel);
            this.TabControl.Controls.Add(this.Aufträge);
            this.TabControl.Controls.Add(this.Positionen);
            this.TabControl.Controls.Add(this.Jahresvergleich);
            this.TabControl.Controls.Add(this.AbfrageRechnungen);
            this.TabControl.Location = new System.Drawing.Point(11, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1441, 793);
            this.TabControl.TabIndex = 24;
            // 
            // Kunden
            // 
            this.Kunden.AccessibleName = "";
            this.Kunden.Controls.Add(this.CmbCustomerSearchProperty);
            this.Kunden.Controls.Add(this.CmdDeleteCustomer);
            this.Kunden.Controls.Add(this.TxtCustomerSearchProperty);
            this.Kunden.Controls.Add(this.LblCustomerSearchField);
            this.Kunden.Controls.Add(this.DGWCustomers);
            this.Kunden.Controls.Add(this.CmdSearchResetCustomer);
            this.Kunden.Controls.Add(this.CmdCustomerSearch);
            this.Kunden.Controls.Add(this.CmdEditCustomer);
            this.Kunden.Controls.Add(this.CmdCreateCustomer);
            this.Kunden.Controls.Add(this.LblKunden);
            this.Kunden.Location = new System.Drawing.Point(4, 29);
            this.Kunden.Name = "Kunden";
            this.Kunden.Padding = new System.Windows.Forms.Padding(3);
            this.Kunden.Size = new System.Drawing.Size(1433, 760);
            this.Kunden.TabIndex = 4;
            this.Kunden.Text = "Kunden";
            this.Kunden.UseVisualStyleBackColor = true;
            // 
            // CmbCustomerSearchProperty
            // 
            this.CmbCustomerSearchProperty.FormattingEnabled = true;
            this.CmbCustomerSearchProperty.Location = new System.Drawing.Point(197, 83);
            this.CmbCustomerSearchProperty.Name = "CmbCustomerSearchProperty";
            this.CmbCustomerSearchProperty.Size = new System.Drawing.Size(141, 28);
            this.CmbCustomerSearchProperty.TabIndex = 40;
            // 
            // CmdDeleteCustomer
            // 
            this.CmdDeleteCustomer.Location = new System.Drawing.Point(1125, 67);
            this.CmdDeleteCustomer.Name = "CmdDeleteCustomer";
            this.CmdDeleteCustomer.Size = new System.Drawing.Size(111, 44);
            this.CmdDeleteCustomer.TabIndex = 39;
            this.CmdDeleteCustomer.Text = "Löschen";
            this.CmdDeleteCustomer.UseVisualStyleBackColor = true;
            // 
            // TxtCustomerSearchProperty
            // 
            this.TxtCustomerSearchProperty.Location = new System.Drawing.Point(384, 83);
            this.TxtCustomerSearchProperty.Name = "TxtCustomerSearchProperty";
            this.TxtCustomerSearchProperty.Size = new System.Drawing.Size(370, 27);
            this.TxtCustomerSearchProperty.TabIndex = 37;
            // 
            // LblCustomerSearchField
            // 
            this.LblCustomerSearchField.AutoSize = true;
            this.LblCustomerSearchField.Location = new System.Drawing.Point(35, 85);
            this.LblCustomerSearchField.Name = "LblCustomerSearchField";
            this.LblCustomerSearchField.Size = new System.Drawing.Size(138, 20);
            this.LblCustomerSearchField.TabIndex = 36;
            this.LblCustomerSearchField.Text = "Suche nach Attribut";
            // 
            // DGWCustomers
            // 
            this.DGWCustomers.AllowUserToAddRows = false;
            this.DGWCustomers.AllowUserToDeleteRows = false;
            this.DGWCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGWCustomers.Location = new System.Drawing.Point(35, 149);
            this.DGWCustomers.Name = "DGWCustomers";
            this.DGWCustomers.ReadOnly = true;
            this.DGWCustomers.RowHeadersWidth = 51;
            this.DGWCustomers.RowTemplate.Height = 29;
            this.DGWCustomers.Size = new System.Drawing.Size(1200, 500);
            this.DGWCustomers.TabIndex = 33;
            // 
            // CmdSearchResetCustomer
            // 
            this.CmdSearchResetCustomer.Location = new System.Drawing.Point(523, 6);
            this.CmdSearchResetCustomer.Name = "CmdSearchResetCustomer";
            this.CmdSearchResetCustomer.Size = new System.Drawing.Size(230, 58);
            this.CmdSearchResetCustomer.TabIndex = 31;
            this.CmdSearchResetCustomer.Text = "Suche zurücksetzen / Datensätze aktualisieren";
            this.CmdSearchResetCustomer.UseVisualStyleBackColor = true;
            this.CmdSearchResetCustomer.Click += new System.EventHandler(this.CmdSearchResetCustomer_Click);
            // 
            // CmdCustomerSearch
            // 
            this.CmdCustomerSearch.Location = new System.Drawing.Point(384, 29);
            this.CmdCustomerSearch.Name = "CmdCustomerSearch";
            this.CmdCustomerSearch.Size = new System.Drawing.Size(101, 35);
            this.CmdCustomerSearch.TabIndex = 30;
            this.CmdCustomerSearch.Text = "Suchen";
            this.CmdCustomerSearch.UseVisualStyleBackColor = true;
            this.CmdCustomerSearch.Click += new System.EventHandler(this.CmdCustomerSearch_Click);
            // 
            // CmdEditCustomer
            // 
            this.CmdEditCustomer.Location = new System.Drawing.Point(966, 67);
            this.CmdEditCustomer.Name = "CmdEditCustomer";
            this.CmdEditCustomer.Size = new System.Drawing.Size(111, 44);
            this.CmdEditCustomer.TabIndex = 29;
            this.CmdEditCustomer.Text = "Bearbeiten";
            this.CmdEditCustomer.UseVisualStyleBackColor = true;
            this.CmdEditCustomer.Click += new System.EventHandler(this.CmdEditCustomer_Click);
            // 
            // CmdCreateCustomer
            // 
            this.CmdCreateCustomer.Location = new System.Drawing.Point(800, 67);
            this.CmdCreateCustomer.Name = "CmdCreateCustomer";
            this.CmdCreateCustomer.Size = new System.Drawing.Size(111, 43);
            this.CmdCreateCustomer.TabIndex = 28;
            this.CmdCreateCustomer.Text = "Erstellen";
            this.CmdCreateCustomer.UseVisualStyleBackColor = true;
            this.CmdCreateCustomer.Click += new System.EventHandler(this.CmdCreateCustomer_Click);
            // 
            // Artikelgruppen
            // 
            this.Artikelgruppen.Controls.Add(this.CmdDeleteArticleGroup);
            this.Artikelgruppen.Controls.Add(this.CmdSearchResetArticleGroup);
            this.Artikelgruppen.Controls.Add(this.CmdSearchArticleGroup);
            this.Artikelgruppen.Controls.Add(this.CmdEditArticleGroup);
            this.Artikelgruppen.Controls.Add(this.CmdCreateArticleGroup);
            this.Artikelgruppen.Controls.Add(this.DGWArticleGroups);
            this.Artikelgruppen.Controls.Add(this.TxtArticleGroupSearchName);
            this.Artikelgruppen.Controls.Add(this.LblArticleGroupSearch);
            this.Artikelgruppen.Controls.Add(this.LblArticleGroups);
            this.Artikelgruppen.Location = new System.Drawing.Point(4, 29);
            this.Artikelgruppen.Name = "Artikelgruppen";
            this.Artikelgruppen.Padding = new System.Windows.Forms.Padding(3);
            this.Artikelgruppen.Size = new System.Drawing.Size(1433, 760);
            this.Artikelgruppen.TabIndex = 0;
            this.Artikelgruppen.Text = "Artikelgruppen";
            this.Artikelgruppen.UseVisualStyleBackColor = true;
            this.Artikelgruppen.ContextMenuStripChanged += new System.EventHandler(this.UpdateListsEvent);
            // 
            // CmdDeleteArticleGroup
            // 
            this.CmdDeleteArticleGroup.Location = new System.Drawing.Point(1125, 67);
            this.CmdDeleteArticleGroup.Name = "CmdDeleteArticleGroup";
            this.CmdDeleteArticleGroup.Size = new System.Drawing.Size(111, 44);
            this.CmdDeleteArticleGroup.TabIndex = 45;
            this.CmdDeleteArticleGroup.Text = "Löschen";
            this.CmdDeleteArticleGroup.UseVisualStyleBackColor = true;
            // 
            // CmdSearchResetArticleGroup
            // 
            this.CmdSearchResetArticleGroup.Location = new System.Drawing.Point(523, 6);
            this.CmdSearchResetArticleGroup.Name = "CmdSearchResetArticleGroup";
            this.CmdSearchResetArticleGroup.Size = new System.Drawing.Size(230, 58);
            this.CmdSearchResetArticleGroup.TabIndex = 43;
            this.CmdSearchResetArticleGroup.Text = "Suche zurücksetzen / Datensätze aktualisieren";
            this.CmdSearchResetArticleGroup.UseVisualStyleBackColor = true;
            this.CmdSearchResetArticleGroup.Click += new System.EventHandler(this.CmdSearchResetArticleGroup_Click);
            // 
            // CmdSearchArticleGroup
            // 
            this.CmdSearchArticleGroup.Location = new System.Drawing.Point(384, 29);
            this.CmdSearchArticleGroup.Name = "CmdSearchArticleGroup";
            this.CmdSearchArticleGroup.Size = new System.Drawing.Size(101, 35);
            this.CmdSearchArticleGroup.TabIndex = 42;
            this.CmdSearchArticleGroup.Text = "Suchen";
            this.CmdSearchArticleGroup.UseVisualStyleBackColor = true;
            // 
            // CmdEditArticleGroup
            // 
            this.CmdEditArticleGroup.Location = new System.Drawing.Point(966, 67);
            this.CmdEditArticleGroup.Name = "CmdEditArticleGroup";
            this.CmdEditArticleGroup.Size = new System.Drawing.Size(111, 44);
            this.CmdEditArticleGroup.TabIndex = 41;
            this.CmdEditArticleGroup.Text = "Bearbeiten";
            this.CmdEditArticleGroup.UseVisualStyleBackColor = true;
            this.CmdEditArticleGroup.Click += new System.EventHandler(this.CmdEditArticleGroup_Click);
            // 
            // CmdCreateArticleGroup
            // 
            this.CmdCreateArticleGroup.Location = new System.Drawing.Point(800, 67);
            this.CmdCreateArticleGroup.Name = "CmdCreateArticleGroup";
            this.CmdCreateArticleGroup.Size = new System.Drawing.Size(111, 43);
            this.CmdCreateArticleGroup.TabIndex = 40;
            this.CmdCreateArticleGroup.Text = "Erstellen";
            this.CmdCreateArticleGroup.UseVisualStyleBackColor = true;
            this.CmdCreateArticleGroup.Click += new System.EventHandler(this.CmdCreateArticleGroup_Click);
            // 
            // DGWArticleGroups
            // 
            this.DGWArticleGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGWArticleGroups.Location = new System.Drawing.Point(35, 149);
            this.DGWArticleGroups.Name = "DGWArticleGroups";
            this.DGWArticleGroups.RowHeadersWidth = 51;
            this.DGWArticleGroups.RowTemplate.Height = 29;
            this.DGWArticleGroups.Size = new System.Drawing.Size(1200, 500);
            this.DGWArticleGroups.TabIndex = 6;
            // 
            // TxtArticleGroupSearchName
            // 
            this.TxtArticleGroupSearchName.Location = new System.Drawing.Point(384, 83);
            this.TxtArticleGroupSearchName.Name = "TxtArticleGroupSearchName";
            this.TxtArticleGroupSearchName.Size = new System.Drawing.Size(370, 27);
            this.TxtArticleGroupSearchName.TabIndex = 5;
            // 
            // LblArticleGroupSearch
            // 
            this.LblArticleGroupSearch.AutoSize = true;
            this.LblArticleGroupSearch.Location = new System.Drawing.Point(35, 85);
            this.LblArticleGroupSearch.Name = "LblArticleGroupSearch";
            this.LblArticleGroupSearch.Size = new System.Drawing.Size(231, 20);
            this.LblArticleGroupSearch.TabIndex = 4;
            this.LblArticleGroupSearch.Text = "Suche nach Artikelgruppennamen";
            // 
            // LblArticleGroups
            // 
            this.LblArticleGroups.AutoSize = true;
            this.LblArticleGroups.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblArticleGroups.Location = new System.Drawing.Point(35, 29);
            this.LblArticleGroups.Name = "LblArticleGroups";
            this.LblArticleGroups.Size = new System.Drawing.Size(180, 35);
            this.LblArticleGroups.TabIndex = 1;
            this.LblArticleGroups.Text = "Artikelgruppen";
            // 
            // Artikel
            // 
            this.Artikel.Controls.Add(this.CmbArticleSearchProperty);
            this.Artikel.Controls.Add(this.DGWArticles);
            this.Artikel.Controls.Add(this.TxtSearchArticleProperty);
            this.Artikel.Controls.Add(this.CmdDeleteArticle);
            this.Artikel.Controls.Add(this.CmdSearchResetArticle);
            this.Artikel.Controls.Add(this.CmdSearchArticle);
            this.Artikel.Controls.Add(this.CmdEditArticle);
            this.Artikel.Controls.Add(this.CmdCreateArticle);
            this.Artikel.Controls.Add(this.LblSearchName);
            this.Artikel.Controls.Add(this.LblArticle);
            this.Artikel.Location = new System.Drawing.Point(4, 29);
            this.Artikel.Name = "Artikel";
            this.Artikel.Padding = new System.Windows.Forms.Padding(3);
            this.Artikel.Size = new System.Drawing.Size(1433, 760);
            this.Artikel.TabIndex = 2;
            this.Artikel.Text = "Artikel";
            this.Artikel.UseVisualStyleBackColor = true;
            // 
            // CmbArticleSearchProperty
            // 
            this.CmbArticleSearchProperty.FormattingEnabled = true;
            this.CmbArticleSearchProperty.Location = new System.Drawing.Point(200, 83);
            this.CmbArticleSearchProperty.Name = "CmbArticleSearchProperty";
            this.CmbArticleSearchProperty.Size = new System.Drawing.Size(141, 28);
            this.CmbArticleSearchProperty.TabIndex = 64;
            // 
            // DGWArticles
            // 
            this.DGWArticles.AllowUserToAddRows = false;
            this.DGWArticles.AllowUserToDeleteRows = false;
            this.DGWArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGWArticles.Location = new System.Drawing.Point(35, 149);
            this.DGWArticles.Name = "DGWArticles";
            this.DGWArticles.RowHeadersWidth = 51;
            this.DGWArticles.RowTemplate.Height = 29;
            this.DGWArticles.Size = new System.Drawing.Size(1200, 500);
            this.DGWArticles.TabIndex = 63;
            // 
            // TxtSearchArticleProperty
            // 
            this.TxtSearchArticleProperty.Location = new System.Drawing.Point(384, 83);
            this.TxtSearchArticleProperty.Name = "TxtSearchArticleProperty";
            this.TxtSearchArticleProperty.Size = new System.Drawing.Size(370, 27);
            this.TxtSearchArticleProperty.TabIndex = 62;
            // 
            // CmdDeleteArticle
            // 
            this.CmdDeleteArticle.Location = new System.Drawing.Point(1125, 67);
            this.CmdDeleteArticle.Name = "CmdDeleteArticle";
            this.CmdDeleteArticle.Size = new System.Drawing.Size(111, 44);
            this.CmdDeleteArticle.TabIndex = 53;
            this.CmdDeleteArticle.Text = "Löschen";
            this.CmdDeleteArticle.UseVisualStyleBackColor = true;
            // 
            // CmdSearchResetArticle
            // 
            this.CmdSearchResetArticle.Location = new System.Drawing.Point(524, 15);
            this.CmdSearchResetArticle.Name = "CmdSearchResetArticle";
            this.CmdSearchResetArticle.Size = new System.Drawing.Size(230, 49);
            this.CmdSearchResetArticle.TabIndex = 51;
            this.CmdSearchResetArticle.Text = "Suche zurücksetzen / Datensätze aktualisieren";
            this.CmdSearchResetArticle.UseVisualStyleBackColor = true;
            this.CmdSearchResetArticle.Click += new System.EventHandler(this.CmdSearchResetArticle_Click);
            // 
            // CmdSearchArticle
            // 
            this.CmdSearchArticle.Location = new System.Drawing.Point(384, 29);
            this.CmdSearchArticle.Name = "CmdSearchArticle";
            this.CmdSearchArticle.Size = new System.Drawing.Size(101, 35);
            this.CmdSearchArticle.TabIndex = 50;
            this.CmdSearchArticle.Text = "Suchen";
            this.CmdSearchArticle.UseVisualStyleBackColor = true;
            this.CmdSearchArticle.Click += new System.EventHandler(this.CmdSearchArticle_Click);
            // 
            // CmdEditArticle
            // 
            this.CmdEditArticle.Location = new System.Drawing.Point(966, 67);
            this.CmdEditArticle.Name = "CmdEditArticle";
            this.CmdEditArticle.Size = new System.Drawing.Size(111, 44);
            this.CmdEditArticle.TabIndex = 49;
            this.CmdEditArticle.Text = "Bearbeiten";
            this.CmdEditArticle.UseVisualStyleBackColor = true;
            this.CmdEditArticle.Click += new System.EventHandler(this.CmdEditArticle_Click);
            // 
            // CmdCreateArticle
            // 
            this.CmdCreateArticle.Location = new System.Drawing.Point(800, 67);
            this.CmdCreateArticle.Name = "CmdCreateArticle";
            this.CmdCreateArticle.Size = new System.Drawing.Size(111, 43);
            this.CmdCreateArticle.TabIndex = 48;
            this.CmdCreateArticle.Text = "Erstellen";
            this.CmdCreateArticle.UseVisualStyleBackColor = true;
            this.CmdCreateArticle.Click += new System.EventHandler(this.CmdCreateArticle_Click);
            // 
            // LblSearchName
            // 
            this.LblSearchName.AutoSize = true;
            this.LblSearchName.Location = new System.Drawing.Point(35, 85);
            this.LblSearchName.Name = "LblSearchName";
            this.LblSearchName.Size = new System.Drawing.Size(138, 20);
            this.LblSearchName.TabIndex = 46;
            this.LblSearchName.Text = "Suche nach Attribut";
            // 
            // LblArticle
            // 
            this.LblArticle.AutoSize = true;
            this.LblArticle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblArticle.Location = new System.Drawing.Point(35, 29);
            this.LblArticle.Name = "LblArticle";
            this.LblArticle.Size = new System.Drawing.Size(85, 35);
            this.LblArticle.TabIndex = 2;
            this.LblArticle.Text = "Artikel";
            // 
            // Aufträge
            // 
            this.Aufträge.Controls.Add(this.CmbOrderSearchProperty);
            this.Aufträge.Controls.Add(this.DGWOrders);
            this.Aufträge.Controls.Add(this.TxtSearchOrderProperty);
            this.Aufträge.Controls.Add(this.CmdDeleteOrder);
            this.Aufträge.Controls.Add(this.CmdSearchResetOrder);
            this.Aufträge.Controls.Add(this.CmdSearchOrder);
            this.Aufträge.Controls.Add(this.CmdEditOrder);
            this.Aufträge.Controls.Add(this.CmdCreateOrder);
            this.Aufträge.Controls.Add(this.label6);
            this.Aufträge.Controls.Add(this.label5);
            this.Aufträge.Location = new System.Drawing.Point(4, 29);
            this.Aufträge.Name = "Aufträge";
            this.Aufträge.Padding = new System.Windows.Forms.Padding(3);
            this.Aufträge.Size = new System.Drawing.Size(1433, 760);
            this.Aufträge.TabIndex = 1;
            this.Aufträge.Text = "Aufträge";
            this.Aufträge.UseVisualStyleBackColor = true;
            // 
            // CmbOrderSearchProperty
            // 
            this.CmbOrderSearchProperty.FormattingEnabled = true;
            this.CmbOrderSearchProperty.Location = new System.Drawing.Point(200, 83);
            this.CmbOrderSearchProperty.Name = "CmbOrderSearchProperty";
            this.CmbOrderSearchProperty.Size = new System.Drawing.Size(141, 28);
            this.CmbOrderSearchProperty.TabIndex = 73;
            // 
            // DGWOrders
            // 
            this.DGWOrders.AllowUserToAddRows = false;
            this.DGWOrders.AllowUserToDeleteRows = false;
            this.DGWOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGWOrders.Location = new System.Drawing.Point(35, 149);
            this.DGWOrders.Name = "DGWOrders";
            this.DGWOrders.RowHeadersWidth = 51;
            this.DGWOrders.RowTemplate.Height = 29;
            this.DGWOrders.Size = new System.Drawing.Size(1200, 500);
            this.DGWOrders.TabIndex = 72;
            // 
            // TxtSearchOrderProperty
            // 
            this.TxtSearchOrderProperty.Location = new System.Drawing.Point(384, 83);
            this.TxtSearchOrderProperty.Name = "TxtSearchOrderProperty";
            this.TxtSearchOrderProperty.Size = new System.Drawing.Size(370, 27);
            this.TxtSearchOrderProperty.TabIndex = 71;
            // 
            // CmdDeleteOrder
            // 
            this.CmdDeleteOrder.Location = new System.Drawing.Point(1125, 67);
            this.CmdDeleteOrder.Name = "CmdDeleteOrder";
            this.CmdDeleteOrder.Size = new System.Drawing.Size(111, 44);
            this.CmdDeleteOrder.TabIndex = 70;
            this.CmdDeleteOrder.Text = "Löschen";
            this.CmdDeleteOrder.UseVisualStyleBackColor = true;
            // 
            // CmdSearchResetOrder
            // 
            this.CmdSearchResetOrder.Location = new System.Drawing.Point(523, 6);
            this.CmdSearchResetOrder.Name = "CmdSearchResetOrder";
            this.CmdSearchResetOrder.Size = new System.Drawing.Size(230, 58);
            this.CmdSearchResetOrder.TabIndex = 68;
            this.CmdSearchResetOrder.Text = "Suche zurücksetzen / Datensätze aktualisieren";
            this.CmdSearchResetOrder.UseVisualStyleBackColor = true;
            this.CmdSearchResetOrder.Click += new System.EventHandler(this.CmdSearchResetOrder_Click);
            // 
            // CmdSearchOrder
            // 
            this.CmdSearchOrder.Location = new System.Drawing.Point(384, 29);
            this.CmdSearchOrder.Name = "CmdSearchOrder";
            this.CmdSearchOrder.Size = new System.Drawing.Size(101, 35);
            this.CmdSearchOrder.TabIndex = 67;
            this.CmdSearchOrder.Text = "Suchen";
            this.CmdSearchOrder.UseVisualStyleBackColor = true;
            this.CmdSearchOrder.Click += new System.EventHandler(this.CmdSearchOrder_Click);
            // 
            // CmdEditOrder
            // 
            this.CmdEditOrder.Location = new System.Drawing.Point(966, 67);
            this.CmdEditOrder.Name = "CmdEditOrder";
            this.CmdEditOrder.Size = new System.Drawing.Size(111, 44);
            this.CmdEditOrder.TabIndex = 66;
            this.CmdEditOrder.Text = "Bearbeiten";
            this.CmdEditOrder.UseVisualStyleBackColor = true;
            this.CmdEditOrder.Click += new System.EventHandler(this.CmdEditOrder_Click);
            // 
            // CmdCreateOrder
            // 
            this.CmdCreateOrder.Location = new System.Drawing.Point(800, 67);
            this.CmdCreateOrder.Name = "CmdCreateOrder";
            this.CmdCreateOrder.Size = new System.Drawing.Size(111, 43);
            this.CmdCreateOrder.TabIndex = 65;
            this.CmdCreateOrder.Text = "Erstellen";
            this.CmdCreateOrder.UseVisualStyleBackColor = true;
            this.CmdCreateOrder.Click += new System.EventHandler(this.CmdCreateOrder_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 20);
            this.label6.TabIndex = 63;
            this.label6.Text = "Suche nach Attribut";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(35, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 35);
            this.label5.TabIndex = 3;
            this.label5.Text = "Aufträge";
            // 
            // Positionen
            // 
            this.Positionen.Controls.Add(this.CmdPositionSearchProperty);
            this.Positionen.Controls.Add(this.DGWPositions);
            this.Positionen.Controls.Add(this.TxtSearchPositionProperty);
            this.Positionen.Controls.Add(this.CmdDeletePosition);
            this.Positionen.Controls.Add(this.CmdSearchResetPosition);
            this.Positionen.Controls.Add(this.CmdSearchPosition);
            this.Positionen.Controls.Add(this.CmdEditPosition);
            this.Positionen.Controls.Add(this.CmdCreatePosition);
            this.Positionen.Controls.Add(this.label11);
            this.Positionen.Controls.Add(this.label10);
            this.Positionen.Location = new System.Drawing.Point(4, 29);
            this.Positionen.Name = "Positionen";
            this.Positionen.Padding = new System.Windows.Forms.Padding(3);
            this.Positionen.Size = new System.Drawing.Size(1433, 760);
            this.Positionen.TabIndex = 3;
            this.Positionen.Text = "Positionen";
            this.Positionen.UseVisualStyleBackColor = true;
            // 
            // CmdPositionSearchProperty
            // 
            this.CmdPositionSearchProperty.FormattingEnabled = true;
            this.CmdPositionSearchProperty.Location = new System.Drawing.Point(200, 83);
            this.CmdPositionSearchProperty.Name = "CmdPositionSearchProperty";
            this.CmdPositionSearchProperty.Size = new System.Drawing.Size(141, 28);
            this.CmdPositionSearchProperty.TabIndex = 82;
            // 
            // DGWPositions
            // 
            this.DGWPositions.AllowUserToAddRows = false;
            this.DGWPositions.AllowUserToDeleteRows = false;
            this.DGWPositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGWPositions.Location = new System.Drawing.Point(35, 149);
            this.DGWPositions.Name = "DGWPositions";
            this.DGWPositions.RowHeadersWidth = 51;
            this.DGWPositions.RowTemplate.Height = 29;
            this.DGWPositions.Size = new System.Drawing.Size(1200, 500);
            this.DGWPositions.TabIndex = 81;
            // 
            // TxtSearchPositionProperty
            // 
            this.TxtSearchPositionProperty.Location = new System.Drawing.Point(384, 83);
            this.TxtSearchPositionProperty.Name = "TxtSearchPositionProperty";
            this.TxtSearchPositionProperty.Size = new System.Drawing.Size(370, 27);
            this.TxtSearchPositionProperty.TabIndex = 80;
            // 
            // CmdDeletePosition
            // 
            this.CmdDeletePosition.Location = new System.Drawing.Point(1125, 67);
            this.CmdDeletePosition.Name = "CmdDeletePosition";
            this.CmdDeletePosition.Size = new System.Drawing.Size(111, 44);
            this.CmdDeletePosition.TabIndex = 79;
            this.CmdDeletePosition.Text = "Löschen";
            this.CmdDeletePosition.UseVisualStyleBackColor = true;
            // 
            // CmdSearchResetPosition
            // 
            this.CmdSearchResetPosition.Location = new System.Drawing.Point(523, 6);
            this.CmdSearchResetPosition.Name = "CmdSearchResetPosition";
            this.CmdSearchResetPosition.Size = new System.Drawing.Size(230, 58);
            this.CmdSearchResetPosition.TabIndex = 77;
            this.CmdSearchResetPosition.Text = "Suche zurücksetzen / Datensätze aktualisieren";
            this.CmdSearchResetPosition.UseVisualStyleBackColor = true;
            this.CmdSearchResetPosition.Click += new System.EventHandler(this.CmdSearchResetPosition_Click);
            // 
            // CmdSearchPosition
            // 
            this.CmdSearchPosition.Location = new System.Drawing.Point(384, 29);
            this.CmdSearchPosition.Name = "CmdSearchPosition";
            this.CmdSearchPosition.Size = new System.Drawing.Size(101, 35);
            this.CmdSearchPosition.TabIndex = 76;
            this.CmdSearchPosition.Text = "Suchen";
            this.CmdSearchPosition.UseVisualStyleBackColor = true;
            this.CmdSearchPosition.Click += new System.EventHandler(this.CmdSearchPosition_Click);
            // 
            // CmdEditPosition
            // 
            this.CmdEditPosition.Location = new System.Drawing.Point(966, 67);
            this.CmdEditPosition.Name = "CmdEditPosition";
            this.CmdEditPosition.Size = new System.Drawing.Size(111, 44);
            this.CmdEditPosition.TabIndex = 75;
            this.CmdEditPosition.Text = "Bearbeiten";
            this.CmdEditPosition.UseVisualStyleBackColor = true;
            this.CmdEditPosition.Click += new System.EventHandler(this.CmdEditPosition_Click);
            // 
            // CmdCreatePosition
            // 
            this.CmdCreatePosition.Location = new System.Drawing.Point(800, 67);
            this.CmdCreatePosition.Name = "CmdCreatePosition";
            this.CmdCreatePosition.Size = new System.Drawing.Size(111, 43);
            this.CmdCreatePosition.TabIndex = 74;
            this.CmdCreatePosition.Text = "Erstellen";
            this.CmdCreatePosition.UseVisualStyleBackColor = true;
            this.CmdCreatePosition.Click += new System.EventHandler(this.CmdCreatePosition_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(35, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 20);
            this.label11.TabIndex = 72;
            this.label11.Text = "Suche nach Attribut";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(35, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 35);
            this.label10.TabIndex = 4;
            this.label10.Text = "Positionen";
            // 
            // Jahresvergleich
            // 
            this.Jahresvergleich.Location = new System.Drawing.Point(4, 29);
            this.Jahresvergleich.Name = "Jahresvergleich";
            this.Jahresvergleich.Padding = new System.Windows.Forms.Padding(3);
            this.Jahresvergleich.Size = new System.Drawing.Size(1433, 760);
            this.Jahresvergleich.TabIndex = 5;
            this.Jahresvergleich.Text = "Jahresvergleich";
            this.Jahresvergleich.UseVisualStyleBackColor = true;
            // 
            // AbfrageRechnungen
            // 
            this.AbfrageRechnungen.Location = new System.Drawing.Point(4, 29);
            this.AbfrageRechnungen.Name = "AbfrageRechnungen";
            this.AbfrageRechnungen.Padding = new System.Windows.Forms.Padding(3);
            this.AbfrageRechnungen.Size = new System.Drawing.Size(1433, 760);
            this.AbfrageRechnungen.TabIndex = 6;
            this.AbfrageRechnungen.Text = "Abfrage Rechnungen";
            this.AbfrageRechnungen.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1507, 805);
            this.Controls.Add(this.TabControl);
            this.Name = "Main";
            this.Text = "Auftragsverwaltung";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.TabControl.ResumeLayout(false);
            this.Kunden.ResumeLayout(false);
            this.Kunden.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGWCustomers)).EndInit();
            this.Artikelgruppen.ResumeLayout(false);
            this.Artikelgruppen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGWArticleGroups)).EndInit();
            this.Artikel.ResumeLayout(false);
            this.Artikel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGWArticles)).EndInit();
            this.Aufträge.ResumeLayout(false);
            this.Aufträge.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGWOrders)).EndInit();
            this.Positionen.ResumeLayout(false);
            this.Positionen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGWPositions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label LblKunden;
        private TabControl TabControl;
        private TabPage Artikelgruppen;
        private TabPage Aufträge;
        private TabPage Artikel;
        private TabPage Positionen;
        private TabPage Kunden;
        private DataGridView DGWCustomers;
        private Button CmdSearchResetCustomer;
        private Button CmdCustomerSearch;
        private Button CmdEditCustomer;
        private Button CmdCreateCustomer;
        private TextBox TxtCustomerSearchProperty;
        private Label LblCustomerSearchField;
        private Button CmdDeleteCustomer;
        private Button CmdDeleteArticleGroup;
        private Button CmdSearchResetArticleGroup;
        private Button CmdSearchArticleGroup;
        private Button CmdEditArticleGroup;
        private Button CmdCreateArticleGroup;
        private DataGridView DGWArticleGroups;
        private TextBox TxtArticleGroupSearchName;
        private Label LblArticleGroupSearch;
        private Label LblArticleGroups;
        private DataGridView DGWArticles;
        private TextBox TxtSearchArticleProperty;
        private Button CmdDeleteArticle;
        private Button CmdSearchResetArticle;
        private Button CmdSearchArticle;
        private Button CmdEditArticle;
        private Button CmdCreateArticle;
        private Label LblSearchName;
        private Label LblArticle;
        private DataGridView DGWOrders;
        private TextBox TxtSearchOrderProperty;
        private Button CmdDeleteOrder;
        private Button CmdSearchResetOrder;
        private Button CmdSearchOrder;
        private Button CmdEditOrder;
        private Button CmdCreateOrder;
        private Label label6;
        private Label label5;
        private DataGridView DGWPositions;
        private TextBox TxtSearchPositionProperty;
        private Button CmdDeletePosition;
        private Button CmdSearchResetPosition;
        private Button CmdSearchPosition;
        private Button CmdEditPosition;
        private Button CmdCreatePosition;
        private Label label11;
        private Label label10;
        private TabPage Jahresvergleich;
        private TabPage AbfrageRechnungen;
        private ComboBox CmbCustomerSearchProperty;
        private ComboBox CmbArticleSearchProperty;
        private ComboBox CmbOrderSearchProperty;
        private ComboBox CmdPositionSearchProperty;
    }
}