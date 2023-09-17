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
            LblKunden = new Label();
            TabControl = new TabControl();
            Kunden = new TabPage();
            CmdImportXML = new Button();
            CmdImport = new Button();
            CmdExportXml = new Button();
            CmdExportJson = new Button();
            CmbCustomerSearchProperty = new ComboBox();
            CmdDeleteCustomer = new Button();
            TxtCustomerSearchProperty = new TextBox();
            LblCustomerSearchField = new Label();
            DGWCustomers = new DataGridView();
            CmdSearchResetCustomer = new Button();
            CmdCustomerSearch = new Button();
            CmdEditCustomer = new Button();
            CmdCreateCustomer = new Button();
            Artikelgruppen = new TabPage();
            CmdTreeView = new Button();
            CmdDeleteArticleGroup = new Button();
            CmdSearchResetArticleGroup = new Button();
            CmdSearchArticleGroup = new Button();
            CmdEditArticleGroup = new Button();
            CmdCreateArticleGroup = new Button();
            DGWArticleGroups = new DataGridView();
            TxtArticleGroupSearchName = new TextBox();
            LblArticleGroupSearch = new Label();
            LblArticleGroups = new Label();
            Artikel = new TabPage();
            CmbArticleSearchProperty = new ComboBox();
            DGWArticles = new DataGridView();
            TxtSearchArticleProperty = new TextBox();
            CmdDeleteArticle = new Button();
            CmdSearchResetArticle = new Button();
            CmdSearchArticle = new Button();
            CmdEditArticle = new Button();
            CmdCreateArticle = new Button();
            LblSearchName = new Label();
            LblArticle = new Label();
            Aufträge = new TabPage();
            CmbOrderSearchProperty = new ComboBox();
            DGWOrders = new DataGridView();
            TxtSearchOrderProperty = new TextBox();
            CmdDeleteOrder = new Button();
            CmdSearchResetOrder = new Button();
            CmdSearchOrder = new Button();
            CmdEditOrder = new Button();
            CmdCreateOrder = new Button();
            label6 = new Label();
            label5 = new Label();
            Positionen = new TabPage();
            CmdPositionSearchProperty = new ComboBox();
            DGWPositions = new DataGridView();
            TxtSearchPositionProperty = new TextBox();
            CmdDeletePosition = new Button();
            CmdSearchResetPosition = new Button();
            CmdSearchPosition = new Button();
            CmdEditPosition = new Button();
            CmdCreatePosition = new Button();
            label11 = new Label();
            label10 = new Label();
            Jahresvergleich = new TabPage();
            LblStatistics = new Label();
            DGWStatistic = new DataGridView();
            TabControl.SuspendLayout();
            Kunden.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGWCustomers).BeginInit();
            Artikelgruppen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGWArticleGroups).BeginInit();
            Artikel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGWArticles).BeginInit();
            Aufträge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGWOrders).BeginInit();
            Positionen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGWPositions).BeginInit();
            Jahresvergleich.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGWStatistic).BeginInit();
            SuspendLayout();
            // 
            // LblKunden
            // 
            LblKunden.AutoSize = true;
            LblKunden.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            LblKunden.Location = new Point(35, 29);
            LblKunden.Name = "LblKunden";
            LblKunden.Size = new Size(100, 35);
            LblKunden.TabIndex = 0;
            LblKunden.Text = "Kunden";
            // 
            // TabControl
            // 
            TabControl.Controls.Add(Kunden);
            TabControl.Controls.Add(Artikelgruppen);
            TabControl.Controls.Add(Artikel);
            TabControl.Controls.Add(Aufträge);
            TabControl.Controls.Add(Positionen);
            TabControl.Controls.Add(Jahresvergleich);
            TabControl.Location = new Point(11, 12);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(1441, 793);
            TabControl.TabIndex = 24;
            TabControl.Selecting += Select_Statistics;
            // 
            // Kunden
            // 
            Kunden.AccessibleName = "";
            Kunden.Controls.Add(CmdImportXML);
            Kunden.Controls.Add(CmdImport);
            Kunden.Controls.Add(CmdExportXml);
            Kunden.Controls.Add(CmdExportJson);
            Kunden.Controls.Add(CmbCustomerSearchProperty);
            Kunden.Controls.Add(CmdDeleteCustomer);
            Kunden.Controls.Add(TxtCustomerSearchProperty);
            Kunden.Controls.Add(LblCustomerSearchField);
            Kunden.Controls.Add(DGWCustomers);
            Kunden.Controls.Add(CmdSearchResetCustomer);
            Kunden.Controls.Add(CmdCustomerSearch);
            Kunden.Controls.Add(CmdEditCustomer);
            Kunden.Controls.Add(CmdCreateCustomer);
            Kunden.Controls.Add(LblKunden);
            Kunden.Location = new Point(4, 29);
            Kunden.Name = "Kunden";
            Kunden.Padding = new Padding(3, 3, 3, 3);
            Kunden.Size = new Size(1433, 760);
            Kunden.TabIndex = 4;
            Kunden.Text = "Kunden";
            Kunden.UseVisualStyleBackColor = true;
            Kunden.ContextMenuStripChanged += UpdateListsEvent;
            // 
            // CmdImportXML
            // 
            CmdImportXML.Location = new Point(1268, 7);
            CmdImportXML.Margin = new Padding(3, 4, 3, 4);
            CmdImportXML.Name = "CmdImportXML";
            CmdImportXML.Size = new Size(130, 31);
            CmdImportXML.TabIndex = 46;
            CmdImportXML.Text = "ImportXml";
            CmdImportXML.UseVisualStyleBackColor = true;
            CmdImportXML.Click += CmdImportXML_Click;
            // 
            // CmdImport
            // 
            CmdImport.Location = new Point(1268, 58);
            CmdImport.Margin = new Padding(3, 4, 3, 4);
            CmdImport.Name = "CmdImport";
            CmdImport.Size = new Size(130, 31);
            CmdImport.TabIndex = 45;
            CmdImport.Text = "Import JSON";
            CmdImport.UseVisualStyleBackColor = true;
            CmdImport.Click += CmdImportJson_Click;
            // 
            // CmdExportXml
            // 
            CmdExportXml.Location = new Point(1268, 170);
            CmdExportXml.Margin = new Padding(3, 4, 3, 4);
            CmdExportXml.Name = "CmdExportXml";
            CmdExportXml.Size = new Size(130, 31);
            CmdExportXml.TabIndex = 44;
            CmdExportXml.Text = "Export Xml";
            CmdExportXml.UseVisualStyleBackColor = true;
            CmdExportXml.Click += CmdExportXml_Click;
            // 
            // CmdExportJson
            // 
            CmdExportJson.Location = new Point(1269, 113);
            CmdExportJson.Margin = new Padding(3, 4, 3, 4);
            CmdExportJson.Name = "CmdExportJson";
            CmdExportJson.Size = new Size(129, 31);
            CmdExportJson.TabIndex = 41;
            CmdExportJson.Text = "Export Json";
            CmdExportJson.UseVisualStyleBackColor = true;
            CmdExportJson.Click += CmdExportJson_Click;
            // 
            // CmbCustomerSearchProperty
            // 
            CmbCustomerSearchProperty.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbCustomerSearchProperty.FormattingEnabled = true;
            CmbCustomerSearchProperty.Location = new Point(197, 83);
            CmbCustomerSearchProperty.Name = "CmbCustomerSearchProperty";
            CmbCustomerSearchProperty.Size = new Size(141, 28);
            CmbCustomerSearchProperty.TabIndex = 40;
            // 
            // CmdDeleteCustomer
            // 
            CmdDeleteCustomer.Location = new Point(1071, 66);
            CmdDeleteCustomer.Name = "CmdDeleteCustomer";
            CmdDeleteCustomer.Size = new Size(111, 44);
            CmdDeleteCustomer.TabIndex = 39;
            CmdDeleteCustomer.Text = "Löschen";
            CmdDeleteCustomer.UseVisualStyleBackColor = true;
            CmdDeleteCustomer.Click += CmdDeleteCustomer_Click;
            // 
            // TxtCustomerSearchProperty
            // 
            TxtCustomerSearchProperty.Location = new Point(384, 83);
            TxtCustomerSearchProperty.Name = "TxtCustomerSearchProperty";
            TxtCustomerSearchProperty.Size = new Size(370, 27);
            TxtCustomerSearchProperty.TabIndex = 37;
            // 
            // LblCustomerSearchField
            // 
            LblCustomerSearchField.AutoSize = true;
            LblCustomerSearchField.Location = new Point(35, 85);
            LblCustomerSearchField.Name = "LblCustomerSearchField";
            LblCustomerSearchField.Size = new Size(138, 20);
            LblCustomerSearchField.TabIndex = 36;
            LblCustomerSearchField.Text = "Suche nach Attribut";
            // 
            // DGWCustomers
            // 
            DGWCustomers.AllowUserToAddRows = false;
            DGWCustomers.AllowUserToDeleteRows = false;
            DGWCustomers.BackgroundColor = SystemColors.Control;
            DGWCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGWCustomers.Location = new Point(48, 223);
            DGWCustomers.MultiSelect = false;
            DGWCustomers.Name = "DGWCustomers";
            DGWCustomers.ReadOnly = true;
            DGWCustomers.RowHeadersWidth = 51;
            DGWCustomers.RowTemplate.Height = 29;
            DGWCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGWCustomers.ShowEditingIcon = false;
            DGWCustomers.Size = new Size(1350, 500);
            DGWCustomers.TabIndex = 33;
            // 
            // CmdSearchResetCustomer
            // 
            CmdSearchResetCustomer.Location = new Point(523, 5);
            CmdSearchResetCustomer.Name = "CmdSearchResetCustomer";
            CmdSearchResetCustomer.Size = new Size(230, 59);
            CmdSearchResetCustomer.TabIndex = 31;
            CmdSearchResetCustomer.Text = "Suche zurücksetzen / Datensätze aktualisieren";
            CmdSearchResetCustomer.UseVisualStyleBackColor = true;
            CmdSearchResetCustomer.Click += CmdSearchResetCustomer_Click;
            // 
            // CmdCustomerSearch
            // 
            CmdCustomerSearch.Location = new Point(384, 29);
            CmdCustomerSearch.Name = "CmdCustomerSearch";
            CmdCustomerSearch.Size = new Size(101, 35);
            CmdCustomerSearch.TabIndex = 30;
            CmdCustomerSearch.Text = "Suchen";
            CmdCustomerSearch.UseVisualStyleBackColor = true;
            CmdCustomerSearch.Click += CmdCustomerSearch_Click;
            // 
            // CmdEditCustomer
            // 
            CmdEditCustomer.Location = new Point(941, 67);
            CmdEditCustomer.Name = "CmdEditCustomer";
            CmdEditCustomer.Size = new Size(111, 44);
            CmdEditCustomer.TabIndex = 29;
            CmdEditCustomer.Text = "Bearbeiten";
            CmdEditCustomer.UseVisualStyleBackColor = true;
            CmdEditCustomer.Click += CmdEditCustomer_Click;
            // 
            // CmdCreateCustomer
            // 
            CmdCreateCustomer.Location = new Point(800, 67);
            CmdCreateCustomer.Name = "CmdCreateCustomer";
            CmdCreateCustomer.Size = new Size(111, 43);
            CmdCreateCustomer.TabIndex = 28;
            CmdCreateCustomer.Text = "Erstellen";
            CmdCreateCustomer.UseVisualStyleBackColor = true;
            CmdCreateCustomer.Click += CmdCreateCustomer_Click;
            // 
            // Artikelgruppen
            // 
            Artikelgruppen.Controls.Add(CmdTreeView);
            Artikelgruppen.Controls.Add(CmdDeleteArticleGroup);
            Artikelgruppen.Controls.Add(CmdSearchResetArticleGroup);
            Artikelgruppen.Controls.Add(CmdSearchArticleGroup);
            Artikelgruppen.Controls.Add(CmdEditArticleGroup);
            Artikelgruppen.Controls.Add(CmdCreateArticleGroup);
            Artikelgruppen.Controls.Add(DGWArticleGroups);
            Artikelgruppen.Controls.Add(TxtArticleGroupSearchName);
            Artikelgruppen.Controls.Add(LblArticleGroupSearch);
            Artikelgruppen.Controls.Add(LblArticleGroups);
            Artikelgruppen.Location = new Point(4, 29);
            Artikelgruppen.Margin = new Padding(5, 5, 5, 5);
            Artikelgruppen.Name = "Artikelgruppen";
            Artikelgruppen.Padding = new Padding(5, 5, 5, 5);
            Artikelgruppen.Size = new Size(1433, 760);
            Artikelgruppen.TabIndex = 0;
            Artikelgruppen.Text = "Artikelgruppen";
            Artikelgruppen.UseVisualStyleBackColor = true;
            Artikelgruppen.ContextMenuStripChanged += UpdateListsEvent;
            // 
            // CmdTreeView
            // 
            CmdTreeView.Location = new Point(1274, 149);
            CmdTreeView.Margin = new Padding(3, 4, 3, 4);
            CmdTreeView.Name = "CmdTreeView";
            CmdTreeView.Size = new Size(111, 69);
            CmdTreeView.TabIndex = 46;
            CmdTreeView.Text = "Tree-View anzeigen";
            CmdTreeView.UseVisualStyleBackColor = true;
            CmdTreeView.Click += CmdTreeView_Click;
            // 
            // CmdDeleteArticleGroup
            // 
            CmdDeleteArticleGroup.Location = new Point(1125, 67);
            CmdDeleteArticleGroup.Name = "CmdDeleteArticleGroup";
            CmdDeleteArticleGroup.Size = new Size(111, 44);
            CmdDeleteArticleGroup.TabIndex = 45;
            CmdDeleteArticleGroup.Text = "Löschen";
            CmdDeleteArticleGroup.UseVisualStyleBackColor = true;
            CmdDeleteArticleGroup.Click += CmdDeleteArticleGroup_Click;
            // 
            // CmdSearchResetArticleGroup
            // 
            CmdSearchResetArticleGroup.Location = new Point(523, 5);
            CmdSearchResetArticleGroup.Name = "CmdSearchResetArticleGroup";
            CmdSearchResetArticleGroup.Size = new Size(230, 59);
            CmdSearchResetArticleGroup.TabIndex = 43;
            CmdSearchResetArticleGroup.Text = "Suche zurücksetzen / Datensätze aktualisieren";
            CmdSearchResetArticleGroup.UseVisualStyleBackColor = true;
            CmdSearchResetArticleGroup.Click += CmdSearchResetArticleGroup_Click;
            // 
            // CmdSearchArticleGroup
            // 
            CmdSearchArticleGroup.Location = new Point(384, 29);
            CmdSearchArticleGroup.Name = "CmdSearchArticleGroup";
            CmdSearchArticleGroup.Size = new Size(101, 35);
            CmdSearchArticleGroup.TabIndex = 42;
            CmdSearchArticleGroup.Text = "Suchen";
            CmdSearchArticleGroup.UseVisualStyleBackColor = true;
            CmdSearchArticleGroup.Click += CmdSearchArticleGroup_Click;
            // 
            // CmdEditArticleGroup
            // 
            CmdEditArticleGroup.Location = new Point(966, 67);
            CmdEditArticleGroup.Name = "CmdEditArticleGroup";
            CmdEditArticleGroup.Size = new Size(111, 44);
            CmdEditArticleGroup.TabIndex = 41;
            CmdEditArticleGroup.Text = "Bearbeiten";
            CmdEditArticleGroup.UseVisualStyleBackColor = true;
            CmdEditArticleGroup.Click += CmdEditArticleGroup_Click;
            // 
            // CmdCreateArticleGroup
            // 
            CmdCreateArticleGroup.Location = new Point(800, 67);
            CmdCreateArticleGroup.Name = "CmdCreateArticleGroup";
            CmdCreateArticleGroup.Size = new Size(111, 43);
            CmdCreateArticleGroup.TabIndex = 40;
            CmdCreateArticleGroup.Text = "Erstellen";
            CmdCreateArticleGroup.UseVisualStyleBackColor = true;
            CmdCreateArticleGroup.Click += CmdCreateArticleGroup_Click;
            // 
            // DGWArticleGroups
            // 
            DGWArticleGroups.AllowUserToAddRows = false;
            DGWArticleGroups.AllowUserToDeleteRows = false;
            DGWArticleGroups.BackgroundColor = SystemColors.Control;
            DGWArticleGroups.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGWArticleGroups.Location = new Point(35, 149);
            DGWArticleGroups.Name = "DGWArticleGroups";
            DGWArticleGroups.ReadOnly = true;
            DGWArticleGroups.RowHeadersWidth = 51;
            DGWArticleGroups.RowTemplate.Height = 29;
            DGWArticleGroups.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGWArticleGroups.Size = new Size(1200, 500);
            DGWArticleGroups.TabIndex = 6;
            // 
            // TxtArticleGroupSearchName
            // 
            TxtArticleGroupSearchName.Location = new Point(384, 83);
            TxtArticleGroupSearchName.Name = "TxtArticleGroupSearchName";
            TxtArticleGroupSearchName.Size = new Size(370, 27);
            TxtArticleGroupSearchName.TabIndex = 5;
            // 
            // LblArticleGroupSearch
            // 
            LblArticleGroupSearch.AutoSize = true;
            LblArticleGroupSearch.Location = new Point(35, 85);
            LblArticleGroupSearch.Name = "LblArticleGroupSearch";
            LblArticleGroupSearch.Size = new Size(231, 20);
            LblArticleGroupSearch.TabIndex = 4;
            LblArticleGroupSearch.Text = "Suche nach Artikelgruppennamen";
            // 
            // LblArticleGroups
            // 
            LblArticleGroups.AutoSize = true;
            LblArticleGroups.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            LblArticleGroups.Location = new Point(35, 29);
            LblArticleGroups.Name = "LblArticleGroups";
            LblArticleGroups.Size = new Size(180, 35);
            LblArticleGroups.TabIndex = 1;
            LblArticleGroups.Text = "Artikelgruppen";
            // 
            // Artikel
            // 
            Artikel.Controls.Add(CmbArticleSearchProperty);
            Artikel.Controls.Add(DGWArticles);
            Artikel.Controls.Add(TxtSearchArticleProperty);
            Artikel.Controls.Add(CmdDeleteArticle);
            Artikel.Controls.Add(CmdSearchResetArticle);
            Artikel.Controls.Add(CmdSearchArticle);
            Artikel.Controls.Add(CmdEditArticle);
            Artikel.Controls.Add(CmdCreateArticle);
            Artikel.Controls.Add(LblSearchName);
            Artikel.Controls.Add(LblArticle);
            Artikel.Location = new Point(4, 29);
            Artikel.Name = "Artikel";
            Artikel.Padding = new Padding(3, 3, 3, 3);
            Artikel.Size = new Size(1433, 760);
            Artikel.TabIndex = 2;
            Artikel.Text = "Artikel";
            Artikel.UseVisualStyleBackColor = true;
            // 
            // CmbArticleSearchProperty
            // 
            CmbArticleSearchProperty.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbArticleSearchProperty.FormattingEnabled = true;
            CmbArticleSearchProperty.Location = new Point(200, 83);
            CmbArticleSearchProperty.Name = "CmbArticleSearchProperty";
            CmbArticleSearchProperty.Size = new Size(141, 28);
            CmbArticleSearchProperty.TabIndex = 64;
            // 
            // DGWArticles
            // 
            DGWArticles.AllowUserToAddRows = false;
            DGWArticles.AllowUserToDeleteRows = false;
            DGWArticles.BackgroundColor = SystemColors.Control;
            DGWArticles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGWArticles.Location = new Point(35, 149);
            DGWArticles.Name = "DGWArticles";
            DGWArticles.ReadOnly = true;
            DGWArticles.RowHeadersWidth = 51;
            DGWArticles.RowTemplate.Height = 29;
            DGWArticles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGWArticles.Size = new Size(1200, 500);
            DGWArticles.TabIndex = 63;
            // 
            // TxtSearchArticleProperty
            // 
            TxtSearchArticleProperty.Location = new Point(384, 83);
            TxtSearchArticleProperty.Name = "TxtSearchArticleProperty";
            TxtSearchArticleProperty.Size = new Size(370, 27);
            TxtSearchArticleProperty.TabIndex = 62;
            // 
            // CmdDeleteArticle
            // 
            CmdDeleteArticle.Location = new Point(1125, 67);
            CmdDeleteArticle.Name = "CmdDeleteArticle";
            CmdDeleteArticle.Size = new Size(111, 44);
            CmdDeleteArticle.TabIndex = 53;
            CmdDeleteArticle.Text = "Löschen";
            CmdDeleteArticle.UseVisualStyleBackColor = true;
            CmdDeleteArticle.Click += CmdDeleteArticle_Click;
            // 
            // CmdSearchResetArticle
            // 
            CmdSearchResetArticle.Location = new Point(523, 15);
            CmdSearchResetArticle.Name = "CmdSearchResetArticle";
            CmdSearchResetArticle.Size = new Size(230, 49);
            CmdSearchResetArticle.TabIndex = 51;
            CmdSearchResetArticle.Text = "Suche zurücksetzen / Datensätze aktualisieren";
            CmdSearchResetArticle.UseVisualStyleBackColor = true;
            CmdSearchResetArticle.Click += CmdSearchResetArticle_Click;
            // 
            // CmdSearchArticle
            // 
            CmdSearchArticle.Location = new Point(384, 29);
            CmdSearchArticle.Name = "CmdSearchArticle";
            CmdSearchArticle.Size = new Size(101, 35);
            CmdSearchArticle.TabIndex = 50;
            CmdSearchArticle.Text = "Suchen";
            CmdSearchArticle.UseVisualStyleBackColor = true;
            CmdSearchArticle.Click += CmdSearchArticle_Click;
            // 
            // CmdEditArticle
            // 
            CmdEditArticle.Location = new Point(966, 67);
            CmdEditArticle.Name = "CmdEditArticle";
            CmdEditArticle.Size = new Size(111, 44);
            CmdEditArticle.TabIndex = 49;
            CmdEditArticle.Text = "Bearbeiten";
            CmdEditArticle.UseVisualStyleBackColor = true;
            CmdEditArticle.Click += CmdEditArticle_Click;
            // 
            // CmdCreateArticle
            // 
            CmdCreateArticle.Location = new Point(800, 67);
            CmdCreateArticle.Name = "CmdCreateArticle";
            CmdCreateArticle.Size = new Size(111, 43);
            CmdCreateArticle.TabIndex = 48;
            CmdCreateArticle.Text = "Erstellen";
            CmdCreateArticle.UseVisualStyleBackColor = true;
            CmdCreateArticle.Click += CmdCreateArticle_Click;
            // 
            // LblSearchName
            // 
            LblSearchName.AutoSize = true;
            LblSearchName.Location = new Point(35, 85);
            LblSearchName.Name = "LblSearchName";
            LblSearchName.Size = new Size(138, 20);
            LblSearchName.TabIndex = 46;
            LblSearchName.Text = "Suche nach Attribut";
            // 
            // LblArticle
            // 
            LblArticle.AutoSize = true;
            LblArticle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            LblArticle.Location = new Point(35, 29);
            LblArticle.Name = "LblArticle";
            LblArticle.Size = new Size(85, 35);
            LblArticle.TabIndex = 2;
            LblArticle.Text = "Artikel";
            // 
            // Aufträge
            // 
            Aufträge.Controls.Add(CmbOrderSearchProperty);
            Aufträge.Controls.Add(DGWOrders);
            Aufträge.Controls.Add(TxtSearchOrderProperty);
            Aufträge.Controls.Add(CmdDeleteOrder);
            Aufträge.Controls.Add(CmdSearchResetOrder);
            Aufträge.Controls.Add(CmdSearchOrder);
            Aufträge.Controls.Add(CmdEditOrder);
            Aufträge.Controls.Add(CmdCreateOrder);
            Aufträge.Controls.Add(label6);
            Aufträge.Controls.Add(label5);
            Aufträge.Location = new Point(4, 29);
            Aufträge.Name = "Aufträge";
            Aufträge.Padding = new Padding(3, 3, 3, 3);
            Aufträge.Size = new Size(1433, 760);
            Aufträge.TabIndex = 1;
            Aufträge.Text = "Aufträge";
            Aufträge.UseVisualStyleBackColor = true;
            // 
            // CmbOrderSearchProperty
            // 
            CmbOrderSearchProperty.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbOrderSearchProperty.FormattingEnabled = true;
            CmbOrderSearchProperty.Location = new Point(200, 83);
            CmbOrderSearchProperty.Name = "CmbOrderSearchProperty";
            CmbOrderSearchProperty.Size = new Size(141, 28);
            CmbOrderSearchProperty.TabIndex = 73;
            // 
            // DGWOrders
            // 
            DGWOrders.AllowUserToAddRows = false;
            DGWOrders.AllowUserToDeleteRows = false;
            DGWOrders.BackgroundColor = SystemColors.Control;
            DGWOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGWOrders.Location = new Point(35, 149);
            DGWOrders.Name = "DGWOrders";
            DGWOrders.ReadOnly = true;
            DGWOrders.RowHeadersWidth = 51;
            DGWOrders.RowTemplate.Height = 29;
            DGWOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGWOrders.Size = new Size(1200, 500);
            DGWOrders.TabIndex = 72;
            // 
            // TxtSearchOrderProperty
            // 
            TxtSearchOrderProperty.Location = new Point(384, 83);
            TxtSearchOrderProperty.Name = "TxtSearchOrderProperty";
            TxtSearchOrderProperty.Size = new Size(370, 27);
            TxtSearchOrderProperty.TabIndex = 71;
            // 
            // CmdDeleteOrder
            // 
            CmdDeleteOrder.Location = new Point(1125, 67);
            CmdDeleteOrder.Name = "CmdDeleteOrder";
            CmdDeleteOrder.Size = new Size(111, 44);
            CmdDeleteOrder.TabIndex = 70;
            CmdDeleteOrder.Text = "Löschen";
            CmdDeleteOrder.UseVisualStyleBackColor = true;
            CmdDeleteOrder.Click += CmdDeleteOrder_Click;
            // 
            // CmdSearchResetOrder
            // 
            CmdSearchResetOrder.Location = new Point(523, 5);
            CmdSearchResetOrder.Name = "CmdSearchResetOrder";
            CmdSearchResetOrder.Size = new Size(230, 59);
            CmdSearchResetOrder.TabIndex = 68;
            CmdSearchResetOrder.Text = "Suche zurücksetzen / Datensätze aktualisieren";
            CmdSearchResetOrder.UseVisualStyleBackColor = true;
            CmdSearchResetOrder.Click += CmdSearchResetOrder_Click;
            // 
            // CmdSearchOrder
            // 
            CmdSearchOrder.Location = new Point(384, 29);
            CmdSearchOrder.Name = "CmdSearchOrder";
            CmdSearchOrder.Size = new Size(101, 35);
            CmdSearchOrder.TabIndex = 67;
            CmdSearchOrder.Text = "Suchen";
            CmdSearchOrder.UseVisualStyleBackColor = true;
            CmdSearchOrder.Click += CmdSearchOrder_Click;
            // 
            // CmdEditOrder
            // 
            CmdEditOrder.Location = new Point(966, 67);
            CmdEditOrder.Name = "CmdEditOrder";
            CmdEditOrder.Size = new Size(111, 44);
            CmdEditOrder.TabIndex = 66;
            CmdEditOrder.Text = "Bearbeiten";
            CmdEditOrder.UseVisualStyleBackColor = true;
            CmdEditOrder.Click += CmdEditOrder_Click;
            // 
            // CmdCreateOrder
            // 
            CmdCreateOrder.Location = new Point(800, 67);
            CmdCreateOrder.Name = "CmdCreateOrder";
            CmdCreateOrder.Size = new Size(111, 43);
            CmdCreateOrder.TabIndex = 65;
            CmdCreateOrder.Text = "Erstellen";
            CmdCreateOrder.UseVisualStyleBackColor = true;
            CmdCreateOrder.Click += CmdCreateOrder_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(35, 85);
            label6.Name = "label6";
            label6.Size = new Size(138, 20);
            label6.TabIndex = 63;
            label6.Text = "Suche nach Attribut";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(35, 29);
            label5.Name = "label5";
            label5.Size = new Size(283, 35);
            label5.TabIndex = 3;
            label5.Text = "Aufträge und Positionen";
            // 
            // Positionen
            // 
            Positionen.Controls.Add(CmdPositionSearchProperty);
            Positionen.Controls.Add(DGWPositions);
            Positionen.Controls.Add(TxtSearchPositionProperty);
            Positionen.Controls.Add(CmdDeletePosition);
            Positionen.Controls.Add(CmdSearchResetPosition);
            Positionen.Controls.Add(CmdSearchPosition);
            Positionen.Controls.Add(CmdEditPosition);
            Positionen.Controls.Add(CmdCreatePosition);
            Positionen.Controls.Add(label11);
            Positionen.Controls.Add(label10);
            Positionen.Location = new Point(4, 29);
            Positionen.Name = "Positionen";
            Positionen.Padding = new Padding(3, 3, 3, 3);
            Positionen.Size = new Size(1433, 760);
            Positionen.TabIndex = 3;
            Positionen.Text = "Positionen";
            Positionen.UseVisualStyleBackColor = true;
            // 
            // CmdPositionSearchProperty
            // 
            CmdPositionSearchProperty.DropDownStyle = ComboBoxStyle.DropDownList;
            CmdPositionSearchProperty.FormattingEnabled = true;
            CmdPositionSearchProperty.Location = new Point(200, 83);
            CmdPositionSearchProperty.Name = "CmdPositionSearchProperty";
            CmdPositionSearchProperty.Size = new Size(141, 28);
            CmdPositionSearchProperty.TabIndex = 82;
            // 
            // DGWPositions
            // 
            DGWPositions.AllowUserToAddRows = false;
            DGWPositions.AllowUserToDeleteRows = false;
            DGWPositions.BackgroundColor = SystemColors.Control;
            DGWPositions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGWPositions.Location = new Point(35, 149);
            DGWPositions.Name = "DGWPositions";
            DGWPositions.ReadOnly = true;
            DGWPositions.RowHeadersWidth = 51;
            DGWPositions.RowTemplate.Height = 29;
            DGWPositions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGWPositions.Size = new Size(1200, 500);
            DGWPositions.TabIndex = 81;
            // 
            // TxtSearchPositionProperty
            // 
            TxtSearchPositionProperty.Location = new Point(384, 83);
            TxtSearchPositionProperty.Name = "TxtSearchPositionProperty";
            TxtSearchPositionProperty.Size = new Size(370, 27);
            TxtSearchPositionProperty.TabIndex = 80;
            // 
            // CmdDeletePosition
            // 
            CmdDeletePosition.Location = new Point(1125, 67);
            CmdDeletePosition.Name = "CmdDeletePosition";
            CmdDeletePosition.Size = new Size(111, 44);
            CmdDeletePosition.TabIndex = 79;
            CmdDeletePosition.Text = "Löschen";
            CmdDeletePosition.UseVisualStyleBackColor = true;
            CmdDeletePosition.Click += CmdDeletePosition_Click;
            // 
            // CmdSearchResetPosition
            // 
            CmdSearchResetPosition.Location = new Point(523, 5);
            CmdSearchResetPosition.Name = "CmdSearchResetPosition";
            CmdSearchResetPosition.Size = new Size(230, 59);
            CmdSearchResetPosition.TabIndex = 77;
            CmdSearchResetPosition.Text = "Suche zurücksetzen / Datensätze aktualisieren";
            CmdSearchResetPosition.UseVisualStyleBackColor = true;
            CmdSearchResetPosition.Click += CmdSearchResetPosition_Click;
            // 
            // CmdSearchPosition
            // 
            CmdSearchPosition.Location = new Point(384, 29);
            CmdSearchPosition.Name = "CmdSearchPosition";
            CmdSearchPosition.Size = new Size(101, 35);
            CmdSearchPosition.TabIndex = 76;
            CmdSearchPosition.Text = "Suchen";
            CmdSearchPosition.UseVisualStyleBackColor = true;
            CmdSearchPosition.Click += CmdSearchPosition_Click;
            // 
            // CmdEditPosition
            // 
            CmdEditPosition.Location = new Point(966, 67);
            CmdEditPosition.Name = "CmdEditPosition";
            CmdEditPosition.Size = new Size(111, 44);
            CmdEditPosition.TabIndex = 75;
            CmdEditPosition.Text = "Bearbeiten";
            CmdEditPosition.UseVisualStyleBackColor = true;
            CmdEditPosition.Click += CmdEditPosition_Click;
            // 
            // CmdCreatePosition
            // 
            CmdCreatePosition.Location = new Point(800, 67);
            CmdCreatePosition.Name = "CmdCreatePosition";
            CmdCreatePosition.Size = new Size(111, 43);
            CmdCreatePosition.TabIndex = 74;
            CmdCreatePosition.Text = "Erstellen";
            CmdCreatePosition.UseVisualStyleBackColor = true;
            CmdCreatePosition.Click += CmdCreatePosition_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(35, 85);
            label11.Name = "label11";
            label11.Size = new Size(138, 20);
            label11.TabIndex = 72;
            label11.Text = "Suche nach Attribut";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(35, 29);
            label10.Name = "label10";
            label10.Size = new Size(130, 35);
            label10.TabIndex = 4;
            label10.Text = "Positionen";
            // 
            // Jahresvergleich
            // 
            Jahresvergleich.Controls.Add(LblStatistics);
            Jahresvergleich.Controls.Add(DGWStatistic);
            Jahresvergleich.Location = new Point(4, 29);
            Jahresvergleich.Name = "Jahresvergleich";
            Jahresvergleich.Padding = new Padding(3, 3, 3, 3);
            Jahresvergleich.Size = new Size(1433, 760);
            Jahresvergleich.TabIndex = 5;
            Jahresvergleich.Text = "Jahresvergleich";
            Jahresvergleich.UseVisualStyleBackColor = true;
            // 
            // LblStatistics
            // 
            LblStatistics.AutoSize = true;
            LblStatistics.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            LblStatistics.Location = new Point(39, 37);
            LblStatistics.Name = "LblStatistics";
            LblStatistics.Size = new Size(314, 37);
            LblStatistics.TabIndex = 1;
            LblStatistics.Text = "Jahresvergleich - Statistik";
            // 
            // DGWStatistic
            // 
            DGWStatistic.AllowUserToAddRows = false;
            DGWStatistic.AllowUserToDeleteRows = false;
            DGWStatistic.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DGWStatistic.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGWStatistic.BackgroundColor = SystemColors.Control;
            DGWStatistic.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGWStatistic.Location = new Point(39, 123);
            DGWStatistic.Margin = new Padding(3, 4, 3, 4);
            DGWStatistic.Name = "DGWStatistic";
            DGWStatistic.ReadOnly = true;
            DGWStatistic.RowHeadersWidth = 51;
            DGWStatistic.RowTemplate.Height = 25;
            DGWStatistic.Size = new Size(504, 603);
            DGWStatistic.TabIndex = 0;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1507, 805);
            Controls.Add(TabControl);
            Name = "Main";
            Text = "Auftragsverwaltung";
            FormClosed += Main_FormClosed;
            ContextMenuStripChanged += UpdateListsEvent;
            TabControl.ResumeLayout(false);
            Kunden.ResumeLayout(false);
            Kunden.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGWCustomers).EndInit();
            Artikelgruppen.ResumeLayout(false);
            Artikelgruppen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGWArticleGroups).EndInit();
            Artikel.ResumeLayout(false);
            Artikel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGWArticles).EndInit();
            Aufträge.ResumeLayout(false);
            Aufträge.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGWOrders).EndInit();
            Positionen.ResumeLayout(false);
            Positionen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGWPositions).EndInit();
            Jahresvergleich.ResumeLayout(false);
            Jahresvergleich.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGWStatistic).EndInit();
            ResumeLayout(false);
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
        private ComboBox CmbCustomerSearchProperty;
        private ComboBox CmbArticleSearchProperty;
        private ComboBox CmbOrderSearchProperty;
        private ComboBox CmdPositionSearchProperty;
        private Label LblStatistics;
        private DataGridView DGWStatistic;
        private Button CmdTreeView;
        private Button CmdExportXml;
        private Button CmdExportJson;
        private Button CmdImport;
        private Button CmdImportXML;
    }
}