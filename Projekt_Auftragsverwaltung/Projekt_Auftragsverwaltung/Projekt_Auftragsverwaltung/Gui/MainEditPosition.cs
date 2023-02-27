

using Projekt_Auftragsverwaltung.Gui;

namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditPosition : FormController

    {
        DataController dataController;
        public string ConnectionString;
        public MainEditPosition(string connectionString)
        {
            InitializeComponent();
            ConnectionString = connectionString;
            dataController = new DataController(ConnectionString);
        }


        private void CmdCreatePositionSave_Click(object sender, EventArgs e)
        {
            if (DGWChooseOrder.SelectedRows.Count > 0 && DGWChooseArticles.SelectedRows.Count > 0)
            {
                var rowsOrders = DGWChooseOrder.SelectedRows[0];
                var rowsArticles = DGWChooseArticles.SelectedRows[0];
                int orderId = Convert.ToInt32(rowsOrders.Cells[0].Value);

                int articleId = Convert.ToInt32(rowsArticles.Cells[0].Value);

                dataController.CreateOrderPosition(Convert.ToInt32(NumOrderPositionQuantity.Value), orderId, articleId);
                CloseForm();
            }

            else
            { throw new Exception("Erfassung nicht möglich."); }
            CloseForm();
        }

        private void CmdCreatePositionCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void UpdateLists(object sender, EventArgs e)
        {
            UpdateOrderList();
            UpdateArticleList();
        }
        private void UpdateOrderList()
        {
            if (dataController != null)
            {
                var data = dataController.ReturnOrders();
                DGWChooseOrder.DataSource = data;
            }
        }

        private void UpdateArticleList()
        {
            if (dataController != null)
            {
                var data = dataController.ReturnArticles();
                DGWChooseArticles.DataSource = data;
            }
        }

    }
}
