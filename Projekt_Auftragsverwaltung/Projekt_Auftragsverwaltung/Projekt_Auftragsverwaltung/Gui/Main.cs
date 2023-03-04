using Microsoft.Data.SqlClient;
using Projekt_Auftragsverwaltung.Gui;
using Projekt_Auftragsverwaltung.Tables;
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
            if (DGWArticleGroups.SelectedRows.Count > 0)
            {
                var rows = DGWArticleGroups.SelectedRows[0];
                int articleGroupId = Convert.ToInt32(rows.Cells[0].Value);
                var articleGroup = DataController.GetSingleArticleGroup(articleGroupId);
                this.EditGuiArticleGroup.Dispose();
                this.EditGuiArticleGroup = new MainEditArticleGroup(ConnectionString, articleGroup);
                EditGuiArticleGroup.VisibleChanged += UpdateListsEvent;
                this.EditGuiArticleGroup.ShowDialog();
                UpdateLists();
            }
        }

        private void CmdEditCustomer_Click(object sender, EventArgs e)
        {
            if (DGWCustomers.SelectedRows.Count > 0)
            {
                var rows = DGWCustomers.SelectedRows[0];
                int customerId = Convert.ToInt32(rows.Cells[0].Value);
                var customer = DataController.GetSingleCustomer(customerId);
                this.EditGuiCustomer.Dispose();
                this.EditGuiCustomer = new MainEditCustomer(ConnectionString, customer);
                EditGuiCustomer.VisibleChanged += UpdateListsEvent;
                this.EditGuiCustomer.ShowDialog();
                UpdateLists();
            }
        }

        private void CmdEditArticle_Click(object sender, EventArgs e)
        {
            if (DGWArticles.SelectedRows.Count > 0)
            {
                var rows = DGWArticles.SelectedRows[0];
                int articleId = Convert.ToInt32(rows.Cells[0].Value);
                var article = DataController.GetSingleArticle(articleId);
                this.EditGuiArticle.Dispose();
                this.EditGuiArticle = new MainEditArticle(ConnectionString, article);
                EditGuiArticle.VisibleChanged += UpdateListsEvent;
                this.EditGuiArticle.ShowDialog();
                UpdateLists();
            }
        }
        private void CmdEditPosition_Click(object sender, EventArgs e)
        {
            if (DGWPositions.SelectedRows.Count > 0)
            {
                var rows = DGWPositions.SelectedRows[0];
                int orderPositionId = Convert.ToInt32(rows.Cells[0].Value);
                var orderPosition = DataController.GetSingleOrderPosition(orderPositionId);
                this.EditGuiPosition.Dispose();
                this.EditGuiPosition = new MainEditPosition(ConnectionString, orderPosition);
                EditGuiPosition.VisibleChanged += UpdateListsEvent;
                this.EditGuiPosition.ShowDialog();
                UpdateLists();
            }
        }

        private void CmdEditOrder_Click(object sender, EventArgs e)
        {
            if (DGWOrders.SelectedRows.Count > 0)
            {
                var rows = DGWOrders.SelectedRows[0];
                int orderId = Convert.ToInt32(rows.Cells[0].Value);
                var order = DataController.GetSingleOrder(orderId);
                this.EditGuiOrder.Dispose();
                this.EditGuiOrder = new MainEditOrder(ConnectionString, order);
                EditGuiOrder.VisibleChanged += UpdateListsEvent;
                this.EditGuiOrder.ShowDialog();
                UpdateLists();
            }
            
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void SetDataBindings()
        {
            CmbCustomerSearchProperty.DataSource = new String[] { "Kundennummer", "Name", "Telefonnummer", "Email", "Website", "Strasse", "Hausnummer", "PLZ", "Ort" };
            CmdPositionSearchProperty.DataSource = new String[] { "Positionsnummer", "Auftragsnummer", "Auftragsdatum", "Kunde", "Artikelbezeichnung", "Artikelanzahl", "Artikelbetrag", "Totalbetrag" };
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
            UpdateLists();
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

        private void CmdSearchArticleGroup_Click(object sender, EventArgs e)
        {
            var dataFound = DataController.ReturnArticleGroupsSearch(TxtArticleGroupSearchName.Text);
            DGWArticleGroups.DataSource = dataFound;
        }

        private void CmdDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (DGWCustomers.SelectedRows.Count > 0)
            {
                var rows = DGWCustomers.SelectedRows[0];
                int customerId = Convert.ToInt32(rows.Cells[0].Value);
                DataController.DeleteCustomer(customerId);
                UpdateCustomers();
            }
            else
            { MessageBox.Show("Bitte Kunde auswählen"); }
        }
    }
}