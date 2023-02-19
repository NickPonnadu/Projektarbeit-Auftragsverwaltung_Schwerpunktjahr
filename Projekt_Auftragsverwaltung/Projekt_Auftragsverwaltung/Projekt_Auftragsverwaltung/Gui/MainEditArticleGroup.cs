﻿

using Projekt_Auftragsverwaltung.Gui;

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
            // Artikelgruppe speichern / updaten
            CloseForm();
        }

        private void CmdCreateArticleGroupCancel_Click(object sender, EventArgs e)
        {

            CloseForm();
        }
                 
    }
}
