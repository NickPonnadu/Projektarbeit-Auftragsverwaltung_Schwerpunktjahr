using Microsoft.Data.SqlClient;
using Projekt_Auftragsverwaltung.Gui;
using System;
using System.Data;
using System.Reflection.Metadata;

namespace Projekt_Auftragsverwaltung

{

    public partial class Main : FormController
    {
        public Form EditGuiArticleGroup;
        public Form EditGuiCustomer;
        public Form EditGuiArticle;
        public Form EditGuiOrder;
        public Form EditGuiPosition;

        public string ConnectionString;
        public DataController DataController;

        public Main(string connectionString)
        {
            InitializeComponent();
            this.ConnectionString = connectionString;
            this.EditGuiArticleGroup = new MainEditArticleGroup(ConnectionString);
            this.EditGuiCustomer = new MainEditCustomer(ConnectionString);
            this.EditGuiArticle = new MainEditArticle(ConnectionString);
            this.EditGuiPosition = new MainEditPosition(ConnectionString);
            this.EditGuiOrder = new MainEditOrder(ConnectionString);

            DataController = new DataController(ConnectionString);
            EditGuiArticleGroup.VisibleChanged += UpdateListsEvent;
            EditGuiCustomer.VisibleChanged += UpdateListsEvent;
            EditGuiOrder.VisibleChanged += UpdateListsEvent;
            EditGuiArticle.VisibleChanged += UpdateListsEvent;
            EditGuiPosition.VisibleChanged += UpdateListsEvent;


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
            CmdPositionSearchProperty.DataSource = new String[] { "Positionsnummer", "Auftragsnummer", "Auftragsdatum", "Kunde", "Artikelbezeichnung","Artikelanzahl", "Artikelbetrag", "Totalbetrag" };
            CmbArticleSearchProperty.DataSource = new String[] { "ArtikelId", "Artikelname", "Preis", "Artikelgruppe" };
            CmbOrderSearchProperty.DataSource = new String[] { "Auftragsnummer", "Datum", "Name", };


        }

        public void UpdateListsEvent(object sender, EventArgs e)
        {
            UpdateCustomers();
            UpdateArticles();
            UpdateOrders();
            UpdateOrderPositions();
            UpdateArticleGroups();
        }
        public void UpdateLists()
        {
            UpdateCustomers();
            UpdateArticles();
            UpdateOrders();
            UpdateOrderPositions();
            UpdateArticleGroups();

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
        private void UpdateArticleGroups()
        {
            var data = DataController.ReturnArticleGroups();
            DGWArticleGroups.DataSource = data;
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
            var dataFound = DataController.ReturnOrderPositionsSearch(CmdPositionSearchProperty.Text, TxtSearchPositionProperty.Text);
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

        private void CmdSearchResetArticleGroup_Click(object sender, EventArgs e)
        {
            UpdateArticleGroups();
        }

        private void CmdDeleteArticleGroup_Click(object sender, EventArgs e)
        {
            if (DGWArticleGroups.SelectedRows.Count > 0)
            {
                var rows = DGWArticleGroups.SelectedRows[0];
                int articleGroupId = Convert.ToInt32(rows.Cells[0].Value);
                DataController.DeleteArticleGroup(articleGroupId);
                UpdateArticleGroups();
            }
            else
            { MessageBox.Show("Bitte Artikelgruppe auswählen"); }
        }

        private void CmdDeleteArticle_Click(object sender, EventArgs e)
        {
            if (DGWArticles.SelectedRows.Count > 0)
            {
                var rows = DGWArticles.SelectedRows[0];
                int articleId = Convert.ToInt32(rows.Cells[0].Value);
                DataController.DeleteArticle(articleId);
                UpdateArticles();
            }
            else
            { MessageBox.Show("Bitte Artikel auswählen"); }
        }

        private void CmdDeleteOrder_Click(object sender, EventArgs e)
        {
            if (DGWOrders.SelectedRows.Count > 0)
            {
                var rows = DGWOrders.SelectedRows[0];
                int orderId = Convert.ToInt32(rows.Cells[0].Value);
                DataController.DeleteOrder(orderId);
                UpdateOrders();
            }
            else
            { MessageBox.Show("Bitte Auftrag auswählen"); }
        }

        private void CmdDeletePosition_Click(object sender, EventArgs e)
        {
            if (DGWPositions.SelectedRows.Count > 0)
            {
                var rows = DGWPositions.SelectedRows[0];
                int orderPosiionId = Convert.ToInt32(rows.Cells[0].Value);
                DataController.DeleteOrderPosition(orderPosiionId);
                UpdateLists();
            }
            else
            { MessageBox.Show("Bitte Position auswählen"); }
        }
    }
}