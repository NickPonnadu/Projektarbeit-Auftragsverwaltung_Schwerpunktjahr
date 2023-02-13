

using Projekt_Auftragsverwaltung.Gui;

namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditArticleGroup : FormController

    {
       

        public MainEditArticleGroup()
        {
            InitializeComponent();
            
        }

      
        private void CmdCreateArticleGroupSave_Click(object sender, EventArgs e)
        {
            // Artikelgruppe speichern / updaten
            CloseForm();
        }

        private void CmdCreateArticleGroupCancel_Click(object sender, EventArgs e)
        {

            CloseForm();
        }
                 
    }
}
