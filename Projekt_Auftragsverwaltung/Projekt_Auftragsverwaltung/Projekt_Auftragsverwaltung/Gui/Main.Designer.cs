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
            this.CmdTreeView = new System.Windows.Forms.Button();
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
            this.LblKunden.Location = new System.Drawing.Point(44, 36);
            this.LblKunden.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblKunden.Name = "LblKunden";
            this.LblKunden.Size = new System.Drawing.Size(120, 41);
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
            this.TabControl.Location = new System.Drawing.Point(14, 15);
            this.TabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1801, 991);
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
            this.Kunden.Location = new System.Drawing.Point(4, 34);
            this.Kunden.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Kunden.Name = "Kunden";
            this.Kunden.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Kunden.Size = new System.Drawing.Size(1793, 953);
            this.Kunden.TabIndex = 4;
            this.Kunden.Text = "Kunden";
            this.Kunden.UseVisualStyleBackColor = true;
            // 
            // CmbCustomerSearchProperty
            // 
            this.CmbCustomerSearchProperty.FormattingEnabled = true;
            this.CmbCustomerSearchProperty.Location = new System.Drawing.Point(246, 104);
            this.CmbCustomerSearchProperty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmbCustomerSearchProperty.Name = "CmbCustomerSearchProperty";
            this.CmbCustomerSearchProperty.Size = new System.Drawing.Size(175, 33);
            this.CmbCustomerSearchProperty.TabIndex = 40;
            // 
            // CmdDeleteCustomer
            // 
            this.CmdDeleteCustomer.Location = new System.Drawing.Point(1406, 84);
            this.CmdDeleteCustomer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdDeleteCustomer.Name = "CmdDeleteCustomer";
            this.CmdDeleteCustomer.Size = new System.Drawing.Size(139, 55);
            this.CmdDeleteCustomer.TabIndex = 39;
            this.CmdDeleteCustomer.Text = "Löschen";
            this.CmdDeleteCustomer.UseVisualStyleBackColor = true;
            // 
            // TxtCustomerSearchProperty
            // 
            this.TxtCustomerSearchProperty.Location = new System.Drawing.Point(480, 104);
            this.TxtCustomerSearchProperty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtCustomerSearchProperty.Name = "TxtCustomerSearchProperty";
            this.TxtCustomerSearchProperty.Size = new System.Drawing.Size(462, 31);
            this.TxtCustomerSearchProperty.TabIndex = 37;
            // 
            // LblCustomerSearchField
            // 
            this.LblCustomerSearchField.AutoSize = true;
            this.LblCustomerSearchField.Location = new System.Drawing.Point(44, 106);
            this.LblCustomerSearchField.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblCustomerSearchField.Name = "LblCustomerSearchField";
            this.LblCustomerSearchField.Size = new System.Drawing.Size(167, 25);
            this.LblCustomerSearchField.TabIndex = 36;
            this.LblCustomerSearchField.Text = "Suche nach Attribut";
            // 
            // DGWCustomers
            // 
            this.DGWCustomers.AllowUserToAddRows = false;
            this.DGWCustomers.AllowUserToDeleteRows = false;
            this.DGWCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGWCustomers.Location = new System.Drawing.Point(44, 186);
            this.DGWCustomers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DGWCustomers.Name = "DGWCustomers";
            this.DGWCustomers.ReadOnly = true;
            this.DGWCustomers.RowHeadersWidth = 51;
            this.DGWCustomers.RowTemplate.Height = 29;
            this.DGWCustomers.Size = new System.Drawing.Size(1500, 625);
            this.DGWCustomers.TabIndex = 33;
            // 
            // CmdSearchResetCustomer
            // 
            this.CmdSearchResetCustomer.Location = new System.Drawing.Point(654, 8);
            this.CmdSearchResetCustomer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdSearchResetCustomer.Name = "CmdSearchResetCustomer";
            this.CmdSearchResetCustomer.Size = new System.Drawing.Size(288, 72);
            this.CmdSearchResetCustomer.TabIndex = 31;
            this.CmdSearchResetCustomer.Text = "Suche zurücksetzen / Datensätze aktualisieren";
            this.CmdSearchResetCustomer.UseVisualStyleBackColor = true;
            this.CmdSearchResetCustomer.Click += new System.EventHandler(this.CmdSearchResetCustomer_Click);
            // 
            // CmdCustomerSearch
            // 
            this.CmdCustomerSearch.Location = new System.Drawing.Point(480, 36);
            this.CmdCustomerSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdCustomerSearch.Name = "CmdCustomerSearch";
            this.CmdCustomerSearch.Size = new System.Drawing.Size(126, 44);
            this.CmdCustomerSearch.TabIndex = 30;
            this.CmdCustomerSearch.Text = "Suchen";
            this.CmdCustomerSearch.UseVisualStyleBackColor = true;
            this.CmdCustomerSearch.Click += new System.EventHandler(this.CmdCustomerSearch_Click);
            // 
            // CmdEditCustomer
            // 
            this.CmdEditCustomer.Location = new System.Drawing.Point(1208, 84);
            this.CmdEditCustomer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdEditCustomer.Name = "CmdEditCustomer";
            this.CmdEditCustomer.Size = new System.Drawing.Size(139, 55);
            this.CmdEditCustomer.TabIndex = 29;
            this.CmdEditCustomer.Text = "Bearbeiten";
            this.CmdEditCustomer.UseVisualStyleBackColor = true;
            this.CmdEditCustomer.Click += new System.EventHandler(this.CmdEditCustomer_Click);
            // 
            // CmdCreateCustomer
            // 
            this.CmdCreateCustomer.Location = new System.Drawing.Point(1000, 84);
            this.CmdCreateCustomer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdCreateCustomer.Name = "CmdCreateCustomer";
            this.CmdCreateCustomer.Size = new System.Drawing.Size(139, 54);
            this.CmdCreateCustomer.TabIndex = 28;
            this.CmdCreateCustomer.Text = "Erstellen";
            this.CmdCreateCustomer.UseVisualStyleBackColor = true;
            this.CmdCreateCustomer.Click += new System.EventHandler(this.CmdCreateCustomer_Click);
            // 
            // Artikelgruppen
            // 
            this.Artikelgruppen.Controls.Add(this.CmdTreeView);
            this.Artikelgruppen.Controls.Add(this.CmdDeleteArticleGroup);
            this.Artikelgruppen.Controls.Add(this.CmdSearchResetArticleGroup);
            this.Artikelgruppen.Controls.Add(this.CmdSearchArticleGroup);
            this.Artikelgruppen.Controls.Add(this.CmdEditArticleGroup);
            this.Artikelgruppen.Controls.Add(this.CmdCreateArticleGroup);
            this.Artikelgruppen.Controls.Add(this.DGWArticleGroups);
            this.Artikelgruppen.Controls.Add(this.TxtArticleGroupSearchName);
            this.Artikelgruppen.Controls.Add(this.LblArticleGroupSearch);
            this.Artikelgruppen.Controls.Add(this.LblArticleGroups);
            this.Artikelgruppen.Location = new System.Drawing.Point(4, 34);
            this.Artikelgruppen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Artikelgruppen.Name = "Artikelgruppen";
            this.Artikelgruppen.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Artikelgruppen.Size = new System.Drawing.Size(1793, 953);
            this.Artikelgruppen.TabIndex = 0;
            this.Artikelgruppen.Text = "Artikelgruppen";
            this.Artikelgruppen.UseVisualStyleBackColor = true;
            this.Artikelgruppen.ContextMenuStripChanged += new System.EventHandler(this.UpdateListsEvent);
            // 
            // CmdDeleteArticleGroup
            // 
            this.CmdDeleteArticleGroup.Location = new System.Drawing.Point(1406, 84);
            this.CmdDeleteArticleGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdDeleteArticleGroup.Name = "CmdDeleteArticleGroup";
            this.CmdDeleteArticleGroup.Size = new System.Drawing.Size(139, 55);
            this.CmdDeleteArticleGroup.TabIndex = 45;
            this.CmdDeleteArticleGroup.Text = "Löschen";
            this.CmdDeleteArticleGroup.UseVisualStyleBackColor = true;
            // 
            // CmdSearchResetArticleGroup
            // 
            this.CmdSearchResetArticleGroup.Location = new System.Drawing.Point(654, 8);
            this.CmdSearchResetArticleGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdSearchResetArticleGroup.Name = "CmdSearchResetArticleGroup";
            this.CmdSearchResetArticleGroup.Size = new System.Drawing.Size(288, 72);
            this.CmdSearchResetArticleGroup.TabIndex = 43;
            this.CmdSearchResetArticleGroup.Text = "Suche zurücksetzen / Datensätze aktualisieren";
            this.CmdSearchResetArticleGroup.UseVisualStyleBackColor = true;
            this.CmdSearchResetArticleGroup.Click += new System.EventHandler(this.CmdSearchResetArticleGroup_Click);
            // 
            // CmdSearchArticleGroup
            // 
            this.CmdSearchArticleGroup.Location = new System.Drawing.Point(480, 36);
            this.CmdSearchArticleGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdSearchArticleGroup.Name = "CmdSearchArticleGroup";
            this.CmdSearchArticleGroup.Size = new System.Drawing.Size(126, 44);
            this.CmdSearchArticleGroup.TabIndex = 42;
            this.CmdSearchArticleGroup.Text = "Suchen";
            this.CmdSearchArticleGroup.UseVisualStyleBackColor = true;
            // 
            // CmdEditArticleGroup
            // 
            this.CmdEditArticleGroup.Location = new System.Drawing.Point(1208, 84);
            this.CmdEditArticleGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdEditArticleGroup.Name = "CmdEditArticleGroup";
            this.CmdEditArticleGroup.Size = new System.Drawing.Size(139, 55);
            this.CmdEditArticleGroup.TabIndex = 41;
            this.CmdEditArticleGroup.Text = "Bearbeiten";
            this.CmdEditArticleGroup.UseVisualStyleBackColor = true;
            this.CmdEditArticleGroup.Click += new System.EventHandler(this.CmdEditArticleGroup_Click);
            // 
            // CmdCreateArticleGroup
            // 
            this.CmdCreateArticleGroup.Location = new System.Drawing.Point(1000, 84);
            this.CmdCreateArticleGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdCreateArticleGroup.Name = "CmdCreateArticleGroup";
            this.CmdCreateArticleGroup.Size = new System.Drawing.Size(139, 54);
            this.CmdCreateArticleGroup.TabIndex = 40;
            this.CmdCreateArticleGroup.Text = "Erstellen";
            this.CmdCreateArticleGroup.UseVisualStyleBackColor = true;
            this.CmdCreateArticleGroup.Click += new System.EventHandler(this.CmdCreateArticleGroup_Click);
            // 
            // DGWArticleGroups
            // 
            this.DGWArticleGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGWArticleGroups.Location = new System.Drawing.Point(44, 186);
            this.DGWArticleGroups.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DGWArticleGroups.Name = "DGWArticleGroups";
            this.DGWArticleGroups.RowHeadersWidth = 51;
            this.DGWArticleGroups.RowTemplate.Height = 29;
            this.DGWArticleGroups.Size = new System.Drawing.Size(1500, 625);
            this.DGWArticleGroups.TabIndex = 6;
            // 
            // TxtArticleGroupSearchName
            // 
            this.TxtArticleGroupSearchName.Location = new System.Drawing.Point(480, 104);
            this.TxtArticleGroupSearchName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtArticleGroupSearchName.Name = "TxtArticleGroupSearchName";
            this.TxtArticleGroupSearchName.Size = new System.Drawing.Size(462, 31);
            this.TxtArticleGroupSearchName.TabIndex = 5;
            // 
            // LblArticleGroupSearch
            // 
            this.LblArticleGroupSearch.AutoSize = true;
            this.LblArticleGroupSearch.Location = new System.Drawing.Point(44, 106);
            this.LblArticleGroupSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblArticleGroupSearch.Name = "LblArticleGroupSearch";
            this.LblArticleGroupSearch.Size = new System.Drawing.Size(278, 25);
            this.LblArticleGroupSearch.TabIndex = 4;
            this.LblArticleGroupSearch.Text = "Suche nach Artikelgruppennamen";
            // 
            // LblArticleGroups
            // 
            this.LblArticleGroups.AutoSize = true;
            this.LblArticleGroups.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblArticleGroups.Location = new System.Drawing.Point(44, 36);
            this.LblArticleGroups.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblArticleGroups.Name = "LblArticleGroups";
            this.LblArticleGroups.Size = new System.Drawing.Size(216, 41);
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
            this.Artikel.Location = new System.Drawing.Point(4, 34);
            this.Artikel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Artikel.Name = "Artikel";
            this.Artikel.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Artikel.Size = new System.Drawing.Size(1793, 953);
            this.Artikel.TabIndex = 2;
            this.Artikel.Text = "Artikel";
            this.Artikel.UseVisualStyleBackColor = true;
            // 
            // CmbArticleSearchProperty
            // 
            this.CmbArticleSearchProperty.FormattingEnabled = true;
            this.CmbArticleSearchProperty.Location = new System.Drawing.Point(250, 104);
            this.CmbArticleSearchProperty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmbArticleSearchProperty.Name = "CmbArticleSearchProperty";
            this.CmbArticleSearchProperty.Size = new System.Drawing.Size(175, 33);
            this.CmbArticleSearchProperty.TabIndex = 64;
            // 
            // DGWArticles
            // 
            this.DGWArticles.AllowUserToAddRows = false;
            this.DGWArticles.AllowUserToDeleteRows = false;
            this.DGWArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGWArticles.Location = new System.Drawing.Point(44, 186);
            this.DGWArticles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DGWArticles.Name = "DGWArticles";
            this.DGWArticles.RowHeadersWidth = 51;
            this.DGWArticles.RowTemplate.Height = 29;
            this.DGWArticles.Size = new System.Drawing.Size(1500, 625);
            this.DGWArticles.TabIndex = 63;
            // 
            // TxtSearchArticleProperty
            // 
            this.TxtSearchArticleProperty.Location = new System.Drawing.Point(480, 104);
            this.TxtSearchArticleProperty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtSearchArticleProperty.Name = "TxtSearchArticleProperty";
            this.TxtSearchArticleProperty.Size = new System.Drawing.Size(462, 31);
            this.TxtSearchArticleProperty.TabIndex = 62;
            // 
            // CmdDeleteArticle
            // 
            this.CmdDeleteArticle.Location = new System.Drawing.Point(1406, 84);
            this.CmdDeleteArticle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdDeleteArticle.Name = "CmdDeleteArticle";
            this.CmdDeleteArticle.Size = new System.Drawing.Size(139, 55);
            this.CmdDeleteArticle.TabIndex = 53;
            this.CmdDeleteArticle.Text = "Löschen";
            this.CmdDeleteArticle.UseVisualStyleBackColor = true;
            // 
            // CmdSearchResetArticle
            // 
            this.CmdSearchResetArticle.Location = new System.Drawing.Point(655, 19);
            this.CmdSearchResetArticle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdSearchResetArticle.Name = "CmdSearchResetArticle";
            this.CmdSearchResetArticle.Size = new System.Drawing.Size(288, 61);
            this.CmdSearchResetArticle.TabIndex = 51;
            this.CmdSearchResetArticle.Text = "Suche zurücksetzen / Datensätze aktualisieren";
            this.CmdSearchResetArticle.UseVisualStyleBackColor = true;
            this.CmdSearchResetArticle.Click += new System.EventHandler(this.CmdSearchResetArticle_Click);
            // 
            // CmdSearchArticle
            // 
            this.CmdSearchArticle.Location = new System.Drawing.Point(480, 36);
            this.CmdSearchArticle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdSearchArticle.Name = "CmdSearchArticle";
            this.CmdSearchArticle.Size = new System.Drawing.Size(126, 44);
            this.CmdSearchArticle.TabIndex = 50;
            this.CmdSearchArticle.Text = "Suchen";
            this.CmdSearchArticle.UseVisualStyleBackColor = true;
            this.CmdSearchArticle.Click += new System.EventHandler(this.CmdSearchArticle_Click);
            // 
            // CmdEditArticle
            // 
            this.CmdEditArticle.Location = new System.Drawing.Point(1208, 84);
            this.CmdEditArticle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdEditArticle.Name = "CmdEditArticle";
            this.CmdEditArticle.Size = new System.Drawing.Size(139, 55);
            this.CmdEditArticle.TabIndex = 49;
            this.CmdEditArticle.Text = "Bearbeiten";
            this.CmdEditArticle.UseVisualStyleBackColor = true;
            this.CmdEditArticle.Click += new System.EventHandler(this.CmdEditArticle_Click);
            // 
            // CmdCreateArticle
            // 
            this.CmdCreateArticle.Location = new System.Drawing.Point(1000, 84);
            this.CmdCreateArticle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdCreateArticle.Name = "CmdCreateArticle";
            this.CmdCreateArticle.Size = new System.Drawing.Size(139, 54);
            this.CmdCreateArticle.TabIndex = 48;
            this.CmdCreateArticle.Text = "Erstellen";
            this.CmdCreateArticle.UseVisualStyleBackColor = true;
            this.CmdCreateArticle.Click += new System.EventHandler(this.CmdCreateArticle_Click);
            // 
            // LblSearchName
            // 
            this.LblSearchName.AutoSize = true;
            this.LblSearchName.Location = new System.Drawing.Point(44, 106);
            this.LblSearchName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblSearchName.Name = "LblSearchName";
            this.LblSearchName.Size = new System.Drawing.Size(167, 25);
            this.LblSearchName.TabIndex = 46;
            this.LblSearchName.Text = "Suche nach Attribut";
            // 
            // LblArticle
            // 
            this.LblArticle.AutoSize = true;
            this.LblArticle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblArticle.Location = new System.Drawing.Point(44, 36);
            this.LblArticle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblArticle.Name = "LblArticle";
            this.LblArticle.Size = new System.Drawing.Size(102, 41);
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
            this.Aufträge.Location = new System.Drawing.Point(4, 34);
            this.Aufträge.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Aufträge.Name = "Aufträge";
            this.Aufträge.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Aufträge.Size = new System.Drawing.Size(1793, 953);
            this.Aufträge.TabIndex = 1;
            this.Aufträge.Text = "Aufträge";
            this.Aufträge.UseVisualStyleBackColor = true;
            // 
            // CmbOrderSearchProperty
            // 
            this.CmbOrderSearchProperty.FormattingEnabled = true;
            this.CmbOrderSearchProperty.Location = new System.Drawing.Point(250, 104);
            this.CmbOrderSearchProperty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmbOrderSearchProperty.Name = "CmbOrderSearchProperty";
            this.CmbOrderSearchProperty.Size = new System.Drawing.Size(175, 33);
            this.CmbOrderSearchProperty.TabIndex = 73;
            // 
            // DGWOrders
            // 
            this.DGWOrders.AllowUserToAddRows = false;
            this.DGWOrders.AllowUserToDeleteRows = false;
            this.DGWOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGWOrders.Location = new System.Drawing.Point(44, 186);
            this.DGWOrders.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DGWOrders.Name = "DGWOrders";
            this.DGWOrders.RowHeadersWidth = 51;
            this.DGWOrders.RowTemplate.Height = 29;
            this.DGWOrders.Size = new System.Drawing.Size(1500, 625);
            this.DGWOrders.TabIndex = 72;
            // 
            // TxtSearchOrderProperty
            // 
            this.TxtSearchOrderProperty.Location = new System.Drawing.Point(480, 104);
            this.TxtSearchOrderProperty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtSearchOrderProperty.Name = "TxtSearchOrderProperty";
            this.TxtSearchOrderProperty.Size = new System.Drawing.Size(462, 31);
            this.TxtSearchOrderProperty.TabIndex = 71;
            // 
            // CmdDeleteOrder
            // 
            this.CmdDeleteOrder.Location = new System.Drawing.Point(1406, 84);
            this.CmdDeleteOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdDeleteOrder.Name = "CmdDeleteOrder";
            this.CmdDeleteOrder.Size = new System.Drawing.Size(139, 55);
            this.CmdDeleteOrder.TabIndex = 70;
            this.CmdDeleteOrder.Text = "Löschen";
            this.CmdDeleteOrder.UseVisualStyleBackColor = true;
            // 
            // CmdSearchResetOrder
            // 
            this.CmdSearchResetOrder.Location = new System.Drawing.Point(654, 8);
            this.CmdSearchResetOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdSearchResetOrder.Name = "CmdSearchResetOrder";
            this.CmdSearchResetOrder.Size = new System.Drawing.Size(288, 72);
            this.CmdSearchResetOrder.TabIndex = 68;
            this.CmdSearchResetOrder.Text = "Suche zurücksetzen / Datensätze aktualisieren";
            this.CmdSearchResetOrder.UseVisualStyleBackColor = true;
            this.CmdSearchResetOrder.Click += new System.EventHandler(this.CmdSearchResetOrder_Click);
            // 
            // CmdSearchOrder
            // 
            this.CmdSearchOrder.Location = new System.Drawing.Point(480, 36);
            this.CmdSearchOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdSearchOrder.Name = "CmdSearchOrder";
            this.CmdSearchOrder.Size = new System.Drawing.Size(126, 44);
            this.CmdSearchOrder.TabIndex = 67;
            this.CmdSearchOrder.Text = "Suchen";
            this.CmdSearchOrder.UseVisualStyleBackColor = true;
            this.CmdSearchOrder.Click += new System.EventHandler(this.CmdSearchOrder_Click);
            // 
            // CmdEditOrder
            // 
            this.CmdEditOrder.Location = new System.Drawing.Point(1208, 84);
            this.CmdEditOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdEditOrder.Name = "CmdEditOrder";
            this.CmdEditOrder.Size = new System.Drawing.Size(139, 55);
            this.CmdEditOrder.TabIndex = 66;
            this.CmdEditOrder.Text = "Bearbeiten";
            this.CmdEditOrder.UseVisualStyleBackColor = true;
            this.CmdEditOrder.Click += new System.EventHandler(this.CmdEditOrder_Click);
            // 
            // CmdCreateOrder
            // 
            this.CmdCreateOrder.Location = new System.Drawing.Point(1000, 84);
            this.CmdCreateOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdCreateOrder.Name = "CmdCreateOrder";
            this.CmdCreateOrder.Size = new System.Drawing.Size(139, 54);
            this.CmdCreateOrder.TabIndex = 65;
            this.CmdCreateOrder.Text = "Erstellen";
            this.CmdCreateOrder.UseVisualStyleBackColor = true;
            this.CmdCreateOrder.Click += new System.EventHandler(this.CmdCreateOrder_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 106);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 25);
            this.label6.TabIndex = 63;
            this.label6.Text = "Suche nach Attribut";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(44, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 41);
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
            this.Positionen.Location = new System.Drawing.Point(4, 34);
            this.Positionen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Positionen.Name = "Positionen";
            this.Positionen.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Positionen.Size = new System.Drawing.Size(1793, 953);
            this.Positionen.TabIndex = 3;
            this.Positionen.Text = "Positionen";
            this.Positionen.UseVisualStyleBackColor = true;
            // 
            // CmdPositionSearchProperty
            // 
            this.CmdPositionSearchProperty.FormattingEnabled = true;
            this.CmdPositionSearchProperty.Location = new System.Drawing.Point(250, 104);
            this.CmdPositionSearchProperty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdPositionSearchProperty.Name = "CmdPositionSearchProperty";
            this.CmdPositionSearchProperty.Size = new System.Drawing.Size(175, 33);
            this.CmdPositionSearchProperty.TabIndex = 82;
            // 
            // DGWPositions
            // 
            this.DGWPositions.AllowUserToAddRows = false;
            this.DGWPositions.AllowUserToDeleteRows = false;
            this.DGWPositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGWPositions.Location = new System.Drawing.Point(44, 186);
            this.DGWPositions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DGWPositions.Name = "DGWPositions";
            this.DGWPositions.RowHeadersWidth = 51;
            this.DGWPositions.RowTemplate.Height = 29;
            this.DGWPositions.Size = new System.Drawing.Size(1500, 625);
            this.DGWPositions.TabIndex = 81;
            // 
            // TxtSearchPositionProperty
            // 
            this.TxtSearchPositionProperty.Location = new System.Drawing.Point(480, 104);
            this.TxtSearchPositionProperty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtSearchPositionProperty.Name = "TxtSearchPositionProperty";
            this.TxtSearchPositionProperty.Size = new System.Drawing.Size(462, 31);
            this.TxtSearchPositionProperty.TabIndex = 80;
            // 
            // CmdDeletePosition
            // 
            this.CmdDeletePosition.Location = new System.Drawing.Point(1406, 84);
            this.CmdDeletePosition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdDeletePosition.Name = "CmdDeletePosition";
            this.CmdDeletePosition.Size = new System.Drawing.Size(139, 55);
            this.CmdDeletePosition.TabIndex = 79;
            this.CmdDeletePosition.Text = "Löschen";
            this.CmdDeletePosition.UseVisualStyleBackColor = true;
            // 
            // CmdSearchResetPosition
            // 
            this.CmdSearchResetPosition.Location = new System.Drawing.Point(654, 8);
            this.CmdSearchResetPosition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdSearchResetPosition.Name = "CmdSearchResetPosition";
            this.CmdSearchResetPosition.Size = new System.Drawing.Size(288, 72);
            this.CmdSearchResetPosition.TabIndex = 77;
            this.CmdSearchResetPosition.Text = "Suche zurücksetzen / Datensätze aktualisieren";
            this.CmdSearchResetPosition.UseVisualStyleBackColor = true;
            this.CmdSearchResetPosition.Click += new System.EventHandler(this.CmdSearchResetPosition_Click);
            // 
            // CmdSearchPosition
            // 
            this.CmdSearchPosition.Location = new System.Drawing.Point(480, 36);
            this.CmdSearchPosition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdSearchPosition.Name = "CmdSearchPosition";
            this.CmdSearchPosition.Size = new System.Drawing.Size(126, 44);
            this.CmdSearchPosition.TabIndex = 76;
            this.CmdSearchPosition.Text = "Suchen";
            this.CmdSearchPosition.UseVisualStyleBackColor = true;
            this.CmdSearchPosition.Click += new System.EventHandler(this.CmdSearchPosition_Click);
            // 
            // CmdEditPosition
            // 
            this.CmdEditPosition.Location = new System.Drawing.Point(1208, 84);
            this.CmdEditPosition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdEditPosition.Name = "CmdEditPosition";
            this.CmdEditPosition.Size = new System.Drawing.Size(139, 55);
            this.CmdEditPosition.TabIndex = 75;
            this.CmdEditPosition.Text = "Bearbeiten";
            this.CmdEditPosition.UseVisualStyleBackColor = true;
            this.CmdEditPosition.Click += new System.EventHandler(this.CmdEditPosition_Click);
            // 
            // CmdCreatePosition
            // 
            this.CmdCreatePosition.Location = new System.Drawing.Point(1000, 84);
            this.CmdCreatePosition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CmdCreatePosition.Name = "CmdCreatePosition";
            this.CmdCreatePosition.Size = new System.Drawing.Size(139, 54);
            this.CmdCreatePosition.TabIndex = 74;
            this.CmdCreatePosition.Text = "Erstellen";
            this.CmdCreatePosition.UseVisualStyleBackColor = true;
            this.CmdCreatePosition.Click += new System.EventHandler(this.CmdCreatePosition_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(44, 106);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(167, 25);
            this.label11.TabIndex = 72;
            this.label11.Text = "Suche nach Attribut";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(44, 36);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(157, 41);
            this.label10.TabIndex = 4;
            this.label10.Text = "Positionen";
            // 
            // Jahresvergleich
            // 
            this.Jahresvergleich.Location = new System.Drawing.Point(4, 34);
            this.Jahresvergleich.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Jahresvergleich.Name = "Jahresvergleich";
            this.Jahresvergleich.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Jahresvergleich.Size = new System.Drawing.Size(1793, 953);
            this.Jahresvergleich.TabIndex = 5;
            this.Jahresvergleich.Text = "Jahresvergleich";
            this.Jahresvergleich.UseVisualStyleBackColor = true;
            // 
            // AbfrageRechnungen
            // 
            this.AbfrageRechnungen.Location = new System.Drawing.Point(4, 34);
            this.AbfrageRechnungen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AbfrageRechnungen.Name = "AbfrageRechnungen";
            this.AbfrageRechnungen.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AbfrageRechnungen.Size = new System.Drawing.Size(1793, 953);
            this.AbfrageRechnungen.TabIndex = 6;
            this.AbfrageRechnungen.Text = "Abfrage Rechnungen";
            this.AbfrageRechnungen.UseVisualStyleBackColor = true;
            // 
            // CmdTreeView
            // 
            this.CmdTreeView.Location = new System.Drawing.Point(1000, 8);
            this.CmdTreeView.Name = "CmdTreeView";
            this.CmdTreeView.Size = new System.Drawing.Size(139, 69);
            this.CmdTreeView.TabIndex = 46;
            this.CmdTreeView.Text = "Artikelgruppen TreeView";
            this.CmdTreeView.UseVisualStyleBackColor = true;
            this.CmdTreeView.Click += new System.EventHandler(this.CmdTreeView_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 1006);
            this.Controls.Add(this.TabControl);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private Button CmdTreeView;
    }
}