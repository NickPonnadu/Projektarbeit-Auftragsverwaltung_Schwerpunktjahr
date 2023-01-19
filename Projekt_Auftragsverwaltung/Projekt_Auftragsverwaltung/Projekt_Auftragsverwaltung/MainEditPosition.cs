
namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditPosition : Form

    {

        public MainEditPosition()
        {
            InitializeComponent();

        }


        private void CmdCreatePositionSave_Click(object sender, EventArgs e)
        {
            // Position speichern / updaten
            this.Hide();
        }

        private void CmdCreatePositionCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
