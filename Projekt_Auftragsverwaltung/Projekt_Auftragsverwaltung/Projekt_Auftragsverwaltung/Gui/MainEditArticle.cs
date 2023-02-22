using Projekt_Auftragsverwaltung;
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
            ConnectionString = connectionString;
            dataController = new DataController(ConnectionString);

        }
               
        private void CmdCreateArticleSave_Click(object sender, EventArgs e)
        {
            if (DGWChooseArticleGroup.SelectedRows.Count > 0)
            {
                var rows = DGWChooseArticleGroup.SelectedRows[0];
                int articleGroupId = Convert.ToInt32(rows.Cells[0].Value);


                dataController.CreateArticle(TxtArticleDescription.Text,NumArticlePrice.Value, articleGroupId);
                CloseForm();
            }
            else
            { throw new Exception("Bitte Artikelgruppe auswählen"); }
            CloseForm();
        }


        private void CmdCreateArticleancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void UpdateArticleGroupList(object sender, EventArgs e)
        {
            if (dataController != null)
            {
                var data = dataController.ReturnArticleGroups();
                DGWChooseArticleGroup.DataSource = data;
            }
        }

        
    }
}
