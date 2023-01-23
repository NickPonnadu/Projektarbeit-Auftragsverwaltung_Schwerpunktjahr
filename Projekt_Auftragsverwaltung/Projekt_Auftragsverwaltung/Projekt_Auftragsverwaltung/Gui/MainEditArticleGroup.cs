
namespace Projekt_Auftragsverwaltung
{
    
    public partial class MainEditArticleGroup : Form

    {
       

        public MainEditArticleGroup()
        {
            InitializeComponent();
            
        }

      
        private void CmdCreateArticleGroupSave_Click(object sender, EventArgs e)
        {
            // Artikelgruppe speichern / updaten
            this.Hide();
        }

        private void CmdCreateArticleGroupCancel_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }

        private void ClearTextBoxes()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
            }
        }
        private void MainEditArticleGroup_VisibleChanged(object sender, EventArgs e)
        {
            this.ClearTextBoxes();
        }
    }
}
