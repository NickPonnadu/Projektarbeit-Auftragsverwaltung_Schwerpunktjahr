
namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditOrder : Form

    {

        public MainEditOrder()
        {
            InitializeComponent();

        }


        private void CmdCreateOrderSave_Click(object sender, EventArgs e)
        {
            // Auftrag speichern / updaten
            this.Hide();
        }

        private void CmdCreateOrderCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
