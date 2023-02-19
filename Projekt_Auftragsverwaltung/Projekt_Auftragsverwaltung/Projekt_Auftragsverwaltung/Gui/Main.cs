using Microsoft.Data.SqlClient;
using Projekt_Auftragsverwaltung.Gui;
using System;
using System.Data;
using System.Reflection.Metadata;

namespace Projekt_Auftragsverwaltung

{

    public partial class Main : FormController
    {
        private Form EditGuiArticleGroup;
        private Form EditGuiCustomer;
        private Form EditGuiArticle;
        private Form EditGuiOrder;
        private Form EditGuiPosition;

        public string ConnectionString;
        private DataController DataController;

        public Main(string connectionString)
        {
            InitializeComponent();
            this.EditGuiArticleGroup = new MainEditArticleGroup();
            this.EditGuiCustomer = new MainEditCustomer();
            this.EditGuiArticle = new MainEditArticle(this);
            this.EditGuiPosition = new MainEditPosition();
            this.EditGuiOrder = new MainEditOrder();
            this.ConnectionString = connectionString;
            DataController = new DataController(ConnectionString);
            UpdateLists();
            SetDataBindings();
        }


        private void CmdCreateArticleGroup_Click(Object sender, EventArgs e)
        {
            this.EditGuiArticleGroup.ShowDialog();

        }

        private void CmdCreateCustomer_Click(object sender, EventArgs e)
        {
            this.EditGuiCustomer.Location = new Point(15, 15);
            this.EditGuiCustomer.ShowDialog();
        }

        private void CmdCreateArticle_Click(object sender, EventArgs e)
        {
            this.EditGuiArticle.ShowDialog();

        }

        private void CmdCreateOrder_Click(object sender, EventArgs e)
        {
            this.EditGuiOrder.ShowDialog();
        }

        private void CmdCreatePosition_Click(object sender, EventArgs e)
        {
            this.EditGuiPosition.ShowDialog();
        }


        private void CmdEditArticleGroup_Click(Object sender, EventArgs e)
        {
            this.EditGuiArticleGroup.ShowDialog();

        }

        private void CmdEditCustomer_Click(object sender, EventArgs e)
        {
            this.EditGuiCustomer.ShowDialog();
        }

        private void CmdEditArticle_Click(object sender, EventArgs e)
        {
            this.EditGuiArticle.ShowDialog();
        }


        private void CmdEditPosition_Click(object sender, EventArgs e)
        {
            this.EditGuiPosition.ShowDialog();
        }

        private void CmdEditOrder_Click(object sender, EventArgs e)
        {
            this.EditGuiOrder.ShowDialog();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void SetDataBindings()
        {
            CmbCustomerSearchProperty.DataSource = new String[] { "Kundennummer", "Name", "Telefonnummer", "Email", "Website", "Strasse", "Hausnummer", "PLZ", "Ort" };
            CmdPositionSearchProperty.DataSource = new String[] { "Positionsnummer", "Kundennummer", "Betrag", "Datum", "Auftragsnummer" };
            CmbArticleSearchProperty.DataSource = new String[] { "ArtikelId", "Artikelname", "Preis", "Artikelgruppe" };
            CmbOrderSearchProperty.DataSource = new String[] { "Auftragsnummer", "Datum", "Name", "Positionen" };
        }

        public void UpdateLists()
        {
            UpdateCustomers();
            UpdateArticles();
            UpdateOrders();
            UpdateOrderPositions();
        }
        private void UpdateCustomers()
        {
            var data = DataController.ReturnCustomers();
            DGWCustomers.DataSource = data;
        }

        private void UpdateArticles()
        {
            var data = DataController.ReturnArticles();
            DGWArticles.DataSource = data;
        }

        private void UpdateOrders()
        {
            var data = DataController.ReturnOrders();
            DGWOrders.DataSource = data;
        }

        private void UpdateOrderPositions()
        {
            var data = DataController.ReturnOrderPositions();
            DGWPositions.DataSource = data;
        }

        private void CmdCustomerSearch_Click(object sender, EventArgs e)
        {
            var dataFound = DataController.ReturnCustomersSearch(CmbCustomerSearchProperty.Text, TxtCustomerSearchProperty.Text);
            DGWCustomers.DataSource = dataFound;
        }

        private void CmdSearchResetCustomer_Click(object sender, EventArgs e)
        {
            UpdateCustomers();
        }

        private void CmdSearchArticle_Click(object sender, EventArgs e)
        {
            var dataFound = DataController.ReturnArticlesSearch(CmbArticleSearchProperty.Text, TxtSearchArticleProperty.Text);
            DGWArticles.DataSource = dataFound;
        }

        private void CmdSearchResetArticle_Click(object sender, EventArgs e)
        {
            UpdateArticles();
        }

        private void CmdSearchPosition_Click(object sender, EventArgs e)
        {
            var dataFound = DataController.ReturnPositionsSearch(CmdPositionSearchProperty.Text, TxtSearchPositionProperty.Text);
            DGWPositions.DataSource = dataFound;
        }

        private void CmdSearchResetPosition_Click(object sender, EventArgs e)
        {
            UpdateOrderPositions();
        }

        private void CmdSearchOrder_Click(object sender, EventArgs e)
        {
            var dataFound = DataController.ReturnOrdersSearch(CmbOrderSearchProperty.Text, TxtSearchOrderProperty.Text);
            DGWOrders.DataSource = dataFound;
        }

        private void CmdSearchResetOrder_Click(object sender, EventArgs e)
        {
            UpdateOrders();
        }
    }
}