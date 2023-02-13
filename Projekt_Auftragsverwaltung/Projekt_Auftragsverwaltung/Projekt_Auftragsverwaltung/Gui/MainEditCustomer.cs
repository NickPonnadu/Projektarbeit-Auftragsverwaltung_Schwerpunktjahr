

using Projekt_Auftragsverwaltung.Gui;

namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditCustomer : FormController

    {

        public MainEditCustomer()
        {
            InitializeComponent();

        }


        private void CmdEditCustomerSave_Click(object sender, EventArgs e)
        {
            // Kunde speichern / updaten
            CloseForm();
        }

        private void CmdEditCustomerCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
    }
}
