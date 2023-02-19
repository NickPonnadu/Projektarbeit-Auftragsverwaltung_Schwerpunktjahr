
using Microsoft.Data.SqlClient;
using Projekt_Auftragsverwaltung.Gui;
using Projekt_Auftragsverwaltung.Tables;

namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditArticle : FormController

    {
        DataController dataController;
        public string ConnectionString;

        public MainEditArticle(string connectionString)
        {
            InitializeComponent();
            ConnectionString= connectionString;
            dataController = new DataController(ConnectionString);
           
        }

        private void CmdCreateArticleSave_Click(object sender, EventArgs e)
        {
            // Artikel speichern / updaten
            CloseForm();
        }


        private void CmdCreateArticleancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }


    }
}
