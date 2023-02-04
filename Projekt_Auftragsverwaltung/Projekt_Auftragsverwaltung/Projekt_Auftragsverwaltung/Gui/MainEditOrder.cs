
using Projekt_Auftragsverwaltung.Gui;

namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditOrder : FormController

    {

        public MainEditOrder()
        {
            InitializeComponent();

        }


        private void CmdCreateOrderSave_Click(object sender, EventArgs e)
        {
            // Auftrag speichern / updaten
            CloseForm();
        }

        private void CmdCreateOrderCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
    }
}
