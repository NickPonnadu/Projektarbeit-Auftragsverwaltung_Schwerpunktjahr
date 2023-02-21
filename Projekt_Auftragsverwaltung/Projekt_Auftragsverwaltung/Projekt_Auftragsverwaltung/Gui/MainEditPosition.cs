

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
            if (DGWChooseOrder.SelectedRows.Count > 0)
            {
                var rows = DGWChooseOrder.SelectedRows[0];
                int orderId = Convert.ToInt32(rows.Cells[0].Value);
                dataController.CreateOrderPosition(Convert.ToInt32(NumOrderPositionQuantity.Value), orderId);
                CloseForm();
            }
            else
            { throw new Exception("Bitte Auftrag auswählen"); }
            CloseForm();
        }

        private void CmdCreatePositionCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }


        private void UpdateOrderList(object sender, EventArgs e)
        {
            if (dataController != null)
            {
                var data = dataController.ReturnOrders();
                DGWChooseOrder.DataSource = data;
            }

        }

    }
}
