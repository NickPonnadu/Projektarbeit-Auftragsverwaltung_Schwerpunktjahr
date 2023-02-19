

using Projekt_Auftragsverwaltung.Gui;

namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditOrder : FormController

    {
        DataController dataController;
        public string ConnectionString;
        public MainEditOrder(string connectionString)
        {
            InitializeComponent();
            ConnectionString = connectionString;
            dataController = new DataController(ConnectionString);

        }


        private void CmdCreateOrderSave_Click(object sender, EventArgs e)
        {
            // Auftrag speichern / updaten
            CloseForm();
        }

        private void CmdCreateOrderCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
    }
}
