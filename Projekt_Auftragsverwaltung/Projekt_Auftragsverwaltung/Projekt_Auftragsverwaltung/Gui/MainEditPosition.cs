

using Projekt_Auftragsverwaltung.Gui;
using Projekt_Auftragsverwaltung.Tables;

namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditPosition : FormController

    {
        DataController dataController;
        public string ConnectionString;
        OrderPosition? OrderPosition { get; set; }
        public bool EditMode;
        public MainEditPosition(string connectionString, OrderPosition orderPosition = null)
        {
            InitializeComponent();
            ConnectionString = connectionString;
            dataController = new DataController(ConnectionString);

            OrderPosition = orderPosition;

            if (OrderPosition != null)
            {
                SetEditModeOn();
            }
            else SetEditModeOff();
        }

        private void SetEditModeOn()
        {
            EditMode = true;
            NumOrderPositionQuantity.Value = Convert.ToDecimal(OrderPosition.amount);

            CmdCreatePositionSave.Text = "Änderungen speichern";
        }

        private void SetEditModeOff()
        {
            OrderPosition = null;
            EditMode = false;
            NumOrderPositionQuantity.Value = 0;
            CmdCreatePositionSave.Text = "Position anlegen";
        }


        private void CmdCreatePositionSave_Click(object sender, EventArgs e)
        {

            if (EditMode == false)
            {
                if (DGWChooseOrder.SelectedRows.Count > 0 && DGWChooseArticles.SelectedRows.Count > 0)
                {
                    var rowsOrders = DGWChooseOrder.SelectedRows[0];
                    var rowsArticles = DGWChooseArticles.SelectedRows[0];
                    int orderId = Convert.ToInt32(rowsOrders.Cells[0].Value);

                    int articleId = Convert.ToInt32(rowsArticles.Cells[0].Value);

                    dataController.CreateOrderPosition(Convert.ToInt32(NumOrderPositionQuantity.Value), orderId, articleId);
                    SetEditModeOff();
                    CloseForm();
                }

                else
                { throw new Exception("Erfassung nicht möglich."); }
                CloseForm();
            }
            if (EditMode == true && OrderPosition != null)
            {
                var rowsOrders = DGWChooseOrder.SelectedRows[0];
                var rowsArticles = DGWChooseArticles.SelectedRows[0];
                int orderId = Convert.ToInt32(rowsOrders.Cells[0].Value);
                int articleId = Convert.ToInt32(rowsArticles.Cells[0].Value);
                dataController.EditOrderPosition(OrderPosition.OrderPositionId, Convert.ToInt16(NumOrderPositionQuantity.Value), orderId);
                dataController.EditArticlePosition(OrderPosition.OrderPositionId, articleId);
                // Schauen, ob es klappt so oder ob man auch articlePosition öndern muss

                SetEditModeOff();
                CloseForm();
            }
            else if (EditMode == true && OrderPosition == null)
            {
                MessageBox.Show("Falscher EditMode");
            }

        }



        private void CmdCreatePositionCancel_Click(object sender, EventArgs e)
        {
            SetEditModeOff();
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
