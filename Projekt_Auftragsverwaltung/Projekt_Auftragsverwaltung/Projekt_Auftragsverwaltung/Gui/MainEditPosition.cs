
using Projekt_Auftragsverwaltung.Gui;

namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditPosition : FormController

    {

        public MainEditPosition()
        {
            InitializeComponent();

        }


        private void CmdCreatePositionSave_Click(object sender, EventArgs e)
        {
            // Position speichern / updaten
            CloseForm();
        }

        private void CmdCreatePositionCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
    }
}
