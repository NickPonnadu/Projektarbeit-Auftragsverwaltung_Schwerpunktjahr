

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
            // Position speichern / updaten
            CloseForm();
        }

        private void CmdCreatePositionCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
    }
}
