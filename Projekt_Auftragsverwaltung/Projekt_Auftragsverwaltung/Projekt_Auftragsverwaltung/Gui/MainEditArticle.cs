
namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditArticle : Form

    {
        public MainEditArticle(Form ownerForm)
        {
            InitializeComponent();
           
        }

        private void CmdCreateArticleSave_Click(object sender, EventArgs e)
        {
            // Artikel speichern / updaten
            this.Hide();
            ClearTextBoxes();
        }



        private void ActivationEvent(object sender, EventArgs e)
        {
            // Befüllung der Felder, wenn Form aktiviert wird
            this.Hide();
            ClearTextBoxes();
        }


        private void CmdCreateArticleancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClearTextBoxes();
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

        private void MainEditArticle_VisibleChanged(object sender, EventArgs e)
        {
            this.ClearTextBoxes();
        }
    }
}
