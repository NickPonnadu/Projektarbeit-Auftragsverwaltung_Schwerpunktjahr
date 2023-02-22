

using Projekt_Auftragsverwaltung.Gui;
using TreeView = Projekt_Auftragsverwaltung.Gui.TreeView;

namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditArticleGroup : FormController

    {
        DataController dataController;
        public string ConnectionString;
        public MainEditArticleGroup(string connectionString)
        {
            InitializeComponent();
            ConnectionString = connectionString;
            
            dataController = new DataController(ConnectionString);

        }

      
        private void CmdCreateArticleGroupSave_Click(object sender, EventArgs e)
        {
            dataController.CreateArticleGroup(TxtArticleGroupEditArticleGroup.Text);
            CloseForm();
        }

        private void CmdCreateArticleGroupCancel_Click(object sender, EventArgs e)
        {

            CloseForm();
        }

        
    }
}
