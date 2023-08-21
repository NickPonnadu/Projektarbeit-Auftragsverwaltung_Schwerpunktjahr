using Projekt_Auftragsverwaltung.Controllers;
using Projekt_Auftragsverwaltung.Gui;

namespace Projekt_Auftragsverwaltung;

public partial class Main : FormController
{
    private readonly AddressController _addressController;
    private readonly AddressLocationController _addressLocationController;
    private readonly ArticleController _articleController;
    private readonly ArticleGroupController _articleGroupController;
    private readonly ArticlePositionController _articlePositionController;
    private readonly CustomerController _customerController;
    private readonly OrderController _orderController;
    private readonly OrderPositionController _orderPositionController;
    private readonly StatisticController _statisticController;
    public Form EditGuiArticle;
    public Form EditGuiArticleGroup;
    public Form EditGuiCustomer;
    public Form EditGuiOrder;
    public Form EditGuiPosition;
    public Form TreeViewClass;

    public Main(ArticleController articleController, ArticleGroupController articleGroupController,
        ArticlePositionController articlePositionController, CustomerController customerController,
        OrderController orderController, OrderPositionController orderPositionController,
        StatisticController statisticController, AddressLocationController addressLocationController,
        AddressController addressController)
    {
        _articleController = articleController;
        _articleGroupController = articleGroupController;
        _articlePositionController = articlePositionController;
        _customerController = customerController;
        _orderController = orderController;
        _orderPositionController = orderPositionController;
        _statisticController = statisticController;
        _addressLocationController = addressLocationController;
        _addressController = addressController;
        InitializeComponent();

        EditGuiArticleGroup = new MainEditArticleGroup(_articleGroupController);
        EditGuiCustomer = new MainEditCustomer(_addressController, _addressLocationController, _customerController);
        EditGuiArticle = new MainEditArticle(_articleGroupController, _articleController);
        EditGuiPosition = new MainEditPosition(_orderPositionController, _articlePositionController, _orderController,
            _articleController);
        EditGuiOrder = new MainEditOrder(_customerController, _orderController);
        TreeViewClass = new TreeViewClass(_statisticController);

        EditGuiArticleGroup.VisibleChanged += UpdateListsEvent;
        EditGuiCustomer.VisibleChanged += UpdateListsEvent;
        EditGuiOrder.VisibleChanged += UpdateListsEvent;
        EditGuiArticle.VisibleChanged += UpdateListsEvent;
        EditGuiPosition.VisibleChanged += UpdateListsEvent;
        UpdateLists();
        SetDataBindings();
    }

    private void CmdCreateArticleGroup_Click(object sender, EventArgs e)
    {
        EditGuiArticleGroup.ShowDialog();
    }

    private void CmdCreateCustomer_Click(object sender, EventArgs e)
    {
        EditGuiCustomer.Location = new Point(15, 15);
        EditGuiCustomer.ShowDialog();
    }

    private void CmdCreateArticle_Click(object sender, EventArgs e)
    {
        EditGuiArticle.ShowDialog();
    }

    private void CmdCreateOrder_Click(object sender, EventArgs e)
    {
        EditGuiOrder.ShowDialog();
    }

    private void CmdCreatePosition_Click(object sender, EventArgs e)
    {
        EditGuiPosition.ShowDialog();
    }

    private void CmdEditArticleGroup_Click(object sender, EventArgs e)
    {
        if (DGWArticleGroups.SelectedRows.Count > 0)
        {
            var rows = DGWArticleGroups.SelectedRows[0];
            var articleGroupId = Convert.ToInt32(rows.Cells[0].Value);
            var articleGroup = _articleGroupController.GetSingleArticleGroup(articleGroupId);
            EditGuiArticleGroup.Dispose();
            EditGuiArticleGroup = new MainEditArticleGroup(_articleGroupController, articleGroup);
            EditGuiArticleGroup.VisibleChanged += UpdateListsEvent;
            EditGuiArticleGroup.ShowDialog();
            UpdateLists();
        }
    }

    private void CmdEditCustomer_Click(object sender, EventArgs e)
    {
        if (DGWCustomers.SelectedRows.Count > 0)
        {
            var rows = DGWCustomers.SelectedRows[0];
            var customerId = Convert.ToInt32(rows.Cells[0].Value);
            var customer = _customerController.GetSingleCustomer(customerId);
            EditGuiCustomer.Dispose();
            EditGuiCustomer = new MainEditCustomer(_addressController, _addressLocationController, _customerController,
                customer);
            EditGuiCustomer.VisibleChanged += UpdateListsEvent;
            EditGuiCustomer.ShowDialog();
            UpdateLists();
        }
    }

    private void CmdEditArticle_Click(object sender, EventArgs e)
    {
        if (DGWArticles.SelectedRows.Count > 0)
        {
            var rows = DGWArticles.SelectedRows[0];
            var articleId = Convert.ToInt32(rows.Cells[0].Value);
            var article = _articleController.GetSingleArticle(articleId);
            EditGuiArticle.Dispose();
            EditGuiArticle = new MainEditArticle(_articleGroupController, _articleController, article);
            EditGuiArticle.VisibleChanged += UpdateListsEvent;
            EditGuiArticle.ShowDialog();
            UpdateLists();
        }
    }

    private void CmdEditPosition_Click(object sender, EventArgs e)
    {
        if (DGWPositions.SelectedRows.Count > 0)
        {
            var rows = DGWPositions.SelectedRows[0];
            var orderPositionId = Convert.ToInt32(rows.Cells[0].Value);
            var orderPosition = _orderPositionController.GetSingleOrderPosition(orderPositionId);
            EditGuiPosition.Dispose();
            EditGuiPosition = new MainEditPosition(_orderPositionController, _articlePositionController,
                _orderController, _articleController, orderPosition);
            EditGuiPosition.VisibleChanged += UpdateListsEvent;
            EditGuiPosition.ShowDialog();
            UpdateLists();
        }
    }

    private void CmdEditOrder_Click(object sender, EventArgs e)
    {
        if (DGWOrders.SelectedRows.Count > 0)
        {
            var rows = DGWOrders.SelectedRows[0];
            var orderId = Convert.ToInt32(rows.Cells[0].Value);
            var order = _orderController.GetSingleOrder(orderId);
            EditGuiOrder.Dispose();
            EditGuiOrder = new MainEditOrder(_customerController, _orderController, order);
            EditGuiOrder.VisibleChanged += UpdateListsEvent;
            EditGuiOrder.ShowDialog();
            UpdateLists();
        }
    }


    public void SetDataBindings()
    {
        CmbCustomerSearchProperty.DataSource = new[]
            { "Kundennummer", "Name", "Telefonnummer", "Email", "Website", "Strasse", "Hausnummer", "PLZ", "Ort" };
        CmdPositionSearchProperty.DataSource = new[]
        {
            "Positionsnummer", "Auftragsnummer", "Kunde", "Artikelbezeichnung", "Artikelanzahl", "Artikelbetrag",
            "Totalbetrag"
        };
        CmbArticleSearchProperty.DataSource = new[] { "ArtikelId", "Artikelname", "Preis", "Artikelgruppe" };
        CmbOrderSearchProperty.DataSource = new[] { "Auftragsnummer", "Name" };
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
        var data = _customerController.ReturnCustomers();
        DGWCustomers.DataSource = data;
    }

    private void UpdateArticles()
    {
        var data = _articleController.ReturnArticles();
        DGWArticles.DataSource = data;
    }

    private void UpdateOrders()
    {
        var data = _orderController.ReturnOrders();
        DGWOrders.DataSource = data;
    }

    private void UpdateOrderPositions()
    {
        var data = _orderPositionController.ReturnOrderPositions();
        DGWPositions.DataSource = data;
    }

    private void UpdateArticleGroups()
    {
        var data = _articleGroupController.ReturnArticleGroups();
        DGWArticleGroups.DataSource = data;
    }

    private void CmdCustomerSearch_Click(object sender, EventArgs e)
    {
        var dataFound =
            _customerController.ReturnCustomersSearch(CmbCustomerSearchProperty.Text, TxtCustomerSearchProperty.Text);
        DGWCustomers.DataSource = dataFound;
    }

    private void CmdSearchResetCustomer_Click(object sender, EventArgs e)
    {
        UpdateCustomers();
    }

    private void CmdSearchArticle_Click(object sender, EventArgs e)
    {
        var dataFound =
            _articleController.ReturnArticlesSearch(CmbArticleSearchProperty.Text, TxtSearchArticleProperty.Text);
        DGWArticles.DataSource = dataFound;
    }

    private void CmdSearchResetArticle_Click(object sender, EventArgs e)
    {
        UpdateArticles();
    }

    private void CmdSearchPosition_Click(object sender, EventArgs e)
    {
        var dataFound =
            _orderPositionController.ReturnOrderPositionsSearch(CmdPositionSearchProperty.Text,
                TxtSearchPositionProperty.Text);
        DGWPositions.DataSource = dataFound;
    }

    private void CmdSearchResetPosition_Click(object sender, EventArgs e)
    {
        UpdateOrderPositions();
    }

    private void CmdSearchOrder_Click(object sender, EventArgs e)
    {
        var dataFound = _orderController.ReturnOrdersSearch(CmbOrderSearchProperty.Text, TxtSearchOrderProperty.Text);
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
            var articleGroupId = Convert.ToInt32(rows.Cells[0].Value);
            _articleGroupController.DeleteArticleGroup(articleGroupId);
            UpdateArticleGroups();
        }
        else
        {
            MessageBox.Show("Bitte Artikelgruppe auswählen");
        }

        UpdateLists();
    }

    private void CmdDeleteArticle_Click(object sender, EventArgs e)
    {
        if (DGWArticles.SelectedRows.Count > 0)
        {
            var rows = DGWArticles.SelectedRows[0];
            var articleId = Convert.ToInt32(rows.Cells[0].Value);
            _articleController.DeleteArticle(articleId);
            UpdateArticles();
        }
        else
        {
            MessageBox.Show("Bitte Artikel auswählen");
        }
    }

    private void CmdDeleteOrder_Click(object sender, EventArgs e)
    {
        if (DGWOrders.SelectedRows.Count > 0)
        {
            var rows = DGWOrders.SelectedRows[0];
            var orderId = Convert.ToInt32(rows.Cells[0].Value);
            _orderController.DeleteOrder(orderId);
            UpdateOrders();
        }
        else
        {
            MessageBox.Show("Bitte Auftrag auswählen");
        }
    }

    private void CmdDeletePosition_Click(object sender, EventArgs e)
    {
        if (DGWPositions.SelectedRows.Count > 0)
        {
            var rows = DGWPositions.SelectedRows[0];
            var orderPosiionId = Convert.ToInt32(rows.Cells[0].Value);
            _orderPositionController.DeleteOrderPosition(orderPosiionId);
            UpdateLists();
        }
        else
        {
            MessageBox.Show("Bitte Position auswählen");
        }
    }

    private void CmdSearchArticleGroup_Click(object sender, EventArgs e)
    {
        var dataFound = _articleGroupController.ReturnArticleGroupsSearch(TxtArticleGroupSearchName.Text);
        DGWArticleGroups.DataSource = dataFound;
    }

    private void CmdDeleteCustomer_Click(object sender, EventArgs e)
    {
        if (DGWCustomers.SelectedRows.Count > 0)
        {
            var rows = DGWCustomers.SelectedRows[0];
            var customerId = Convert.ToInt32(rows.Cells[0].Value);
            _customerController.DeleteCustomer(customerId);
            UpdateCustomers();
        }
        else
        {
            MessageBox.Show("Bitte Kunde auswählen");
        }
    }


    private void Select_Statistics(object sender, TabControlCancelEventArgs e)
    {
        DGWStatistic.DataSource = _statisticController.ReturnStatistic();
    }


    private void CmdTreeView_Click(object sender, EventArgs e)
    {
        TreeViewClass.ShowDialog();
    }

    private void Main_FormClosed(object sender, FormClosedEventArgs e)
    {
        Application.Exit();
    }
}