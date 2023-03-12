using Projekt_Auftragsverwaltung;
using Microsoft.Data.SqlClient;
using Projekt_Auftragsverwaltung.Gui;
using Projekt_Auftragsverwaltung.Tables;

namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditArticle : FormController

    {
        DataController dataController;

        Article? Article { get; set; }
        public bool EditMode;
        public MainEditArticle(string connectionString, Article article = null)
        {
            InitializeComponent();
            ConnectionString = connectionString;
            dataController = new DataController(ConnectionString);
            Article = article;

            if (Article != null)
            {
                SetEditModeOn();
            }
            else SetEditModeOff();
        }

        private void SetEditModeOn()
        {
            EditMode = true;
            TxtArticleDescription.Text = Article.ArticleName;
            NumArticlePrice.Value = Article.Price;
            CmdCreateArticleSave.Text = "Änderungen speichern";
        }

        private void SetEditModeOff()
        {
            Article = null;
            EditMode = false;
            TxtArticleDescription.Text = "";
            NumArticlePrice.Value = 0;
            CmdCreateArticleSave.Text = "Artikel anlegen";
        }


        private void CmdCreateArticleSave_Click(object sender, EventArgs e)
        {
            if (DGWChooseArticleGroup.SelectedRows.Count > 0)
            {
                var rows = DGWChooseArticleGroup.SelectedRows[0];
                int articleGroupId = Convert.ToInt32(rows.Cells[0].Value);

                if (EditMode == false)
                {
                    dataController.CreateArticle(TxtArticleDescription.Text, NumArticlePrice.Value, articleGroupId);
                    CloseForm();
                }
                if (EditMode == true && Article != null)
                {
                    dataController.EditArticle(Article.ArticleId, TxtArticleDescription.Text, NumArticlePrice.Value, articleGroupId);
                    SetEditModeOff();
                    CloseForm();
                }
                else if (EditMode == true && Article == null)
                {
                    MessageBox.Show("Falscher EditMode");
                }

            }
            else
            { throw new Exception("Bitte Artikelgruppe auswählen"); }
            CloseForm();
        }


        private void CmdCreateArticleancel_Click(object sender, EventArgs e)
        {
            CloseForm();
            SetEditModeOff();
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
