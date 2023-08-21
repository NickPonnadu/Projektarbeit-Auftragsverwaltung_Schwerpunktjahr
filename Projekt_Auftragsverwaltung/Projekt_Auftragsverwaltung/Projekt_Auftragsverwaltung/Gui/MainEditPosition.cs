

using Projekt_Auftragsverwaltung.Controllers;
using Projekt_Auftragsverwaltung.Gui;
using Projekt_Auftragsverwaltung.Tables;

namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditPosition : FormController

    {
        private readonly OrderPositionController _orderPositionController;
        private readonly OrderController _orderController;
        private readonly ArticlePositionController _articlePositionController;
        private readonly ArticleController _articleController;
        OrderPosition? OrderPosition { get; set; }
        public bool EditMode;
        public MainEditPosition(OrderPositionController orderPositionController, ArticlePositionController articlePositionController, OrderController orderController, ArticleController articleController, OrderPosition? orderPosition = null)
        {
            InitializeComponent();

            _orderPositionController = orderPositionController;
            _articlePositionController = articlePositionController;
            _orderController = orderController;
            _articleController = articleController;
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
                    _orderPositionController.CreateOrderPosition(Convert.ToInt32(NumOrderPositionQuantity.Value), orderId, articleId);
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
                _orderPositionController.EditOrderPosition(OrderPosition.OrderPositionId, Convert.ToInt16(NumOrderPositionQuantity.Value), orderId);
                _articlePositionController.EditArticlePosition(OrderPosition.OrderPositionId, articleId);
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
            if (_orderController != null)
            {
                var data = _orderController.ReturnOrders();
                DGWChooseOrder.DataSource = data;
            }
        }

        private void UpdateArticleList()
        {
            if (_articleController != null)
            {
                var data = _articleController.ReturnArticles();
                DGWChooseArticles.DataSource = data;
            }
        }
    }
}
