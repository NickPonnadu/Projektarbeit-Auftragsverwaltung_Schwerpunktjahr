using Projekt_Auftragsverwaltung.Controllers;
using Projekt_Auftragsverwaltung.Gui;
using Projekt_Auftragsverwaltung.Tables;
using System.ComponentModel.DataAnnotations;
using Projekt_Auftragsverwaltung.Interfaces;

namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditArticleGroup : FormController

    {
        private readonly IArticleGroupController _articleGroupController;
        ArticleGroup? ArticleGroup { get; set; }

        public bool EditMode;
      
        public MainEditArticleGroup(IArticleGroupController articleGroupController, ArticleGroup articleGroup = null)
        {
            InitializeComponent();

            _articleGroupController = articleGroupController;
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
                _articleGroupController.CreateArticleGroup(TxtArticleGroupEditArticleGroup.Text);
                CloseForm();
            }
            if (EditMode == true && ArticleGroup != null && TxtArticleGroupEditArticleGroup.Text.Length > 0)
            {
                _articleGroupController.EditArticleGroup(ArticleGroup.ArticleGroupId, TxtArticleGroupEditArticleGroup.Text);
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
