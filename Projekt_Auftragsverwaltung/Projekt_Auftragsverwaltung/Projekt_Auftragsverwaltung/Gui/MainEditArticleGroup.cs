using Projekt_Auftragsverwaltung.Controllers;
using Projekt_Auftragsverwaltung.Gui;
using Projekt_Auftragsverwaltung.Tables;
using System.ComponentModel.DataAnnotations;

namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditArticleGroup : FormController

    {
        ArticleGroup? ArticleGroup { get; set; }

        public bool EditMode;
        DataController dataController;
        
        public MainEditArticleGroup(string connectionString, ArticleGroup articleGroup = null)
        {
            InitializeComponent();
            ConnectionString = connectionString;
            dataController = new DataController(ConnectionString);
            ArticleGroup = articleGroup;

            if (ArticleGroup != null)
            {
                SetEditModeOn();
            }
            else SetEditModeOff();
        }

        private void SetEditModeOn()
        {
            EditMode = true;
            TxtArticleGroupEditArticleGroup.Text = ArticleGroup.Name;
            CmdCreateArticleGroupSave.Text = "Änderungen speichern";
        }

        private void SetEditModeOff()
        {
            ArticleGroup = null;
            EditMode = false;
            TxtArticleGroupEditArticleGroup.Text = "";
            CmdCreateArticleGroupSave.Text = "Artikelgruppe anlegen";
        }

        private void CmdCreateArticleGroupSave_Click(object sender, EventArgs e)
        {
            if (EditMode == false)
            {
                dataController.CreateArticleGroup(TxtArticleGroupEditArticleGroup.Text);
                CloseForm();
            }
            if (EditMode == true && ArticleGroup != null && TxtArticleGroupEditArticleGroup.Text.Length > 0)
            {
                dataController.EditArticleGroup(ArticleGroup.ArticleGroupId, TxtArticleGroupEditArticleGroup.Text);
                SetEditModeOff();
                CloseForm();
            }
            else if (EditMode == true && ArticleGroup == null)
            {
                MessageBox.Show("Falscher EditMode");
            }
                       
        }

        private void CmdCreateArticleGroupCancel_Click(object sender, EventArgs e)
        {

            CloseForm();
            SetEditModeOff();
        }

    }
}
