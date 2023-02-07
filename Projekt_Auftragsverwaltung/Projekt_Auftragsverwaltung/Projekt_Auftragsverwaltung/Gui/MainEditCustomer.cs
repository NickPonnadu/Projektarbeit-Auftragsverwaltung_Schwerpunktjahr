
namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditCustomer : Form

    {

        public MainEditCustomer()
        {
            InitializeComponent();

        }


        private void CmdEditCustomerSave_Click(object sender, EventArgs e)
        {
            // Kunde speichern / updaten
            this.Hide();
        }

        private void CmdEditCustomerCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
