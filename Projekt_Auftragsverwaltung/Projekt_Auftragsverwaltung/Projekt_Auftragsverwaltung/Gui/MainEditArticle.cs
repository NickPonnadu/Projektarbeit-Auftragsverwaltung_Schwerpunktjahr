
using Microsoft.Data.SqlClient;
using Projekt_Auftragsverwaltung.Gui;
using Projekt_Auftragsverwaltung.Tables;

namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditArticle : FormController

    {



        public MainEditArticle(Form ownerForm)
        {
            InitializeComponent();
           
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


        //private void CreateNewArticle()
        //{
        //    string articleNumber = Convert.ToString(NumArticleNumber.Value);
        //    string articleDecscription = TxtArticleDescription.Text;
        //    string articlePrice = Convert.ToString(NumArticlePrice.Value);
        //    string articleGroup = CmbArticleGroup.Text;  


        //    var conn = new SqlConnection();
        //    var cmd = new SqlCommand();


        //    cmd.CommandText = $"insert into artikel (1,2,3,4) values (";

        //    cmd.Parameters.AddWithValue(«@bezeichnung», bezeichnung);
        //    cmd.ExecuteReader();


        //}
    }
}
