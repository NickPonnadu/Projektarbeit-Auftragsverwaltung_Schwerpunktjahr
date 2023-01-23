using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_Auftragsverwaltung
{
    public partial class Login : Form
    {

        private bool Connection;

        private Form MainGui;
        public Login()
        {
            InitializeComponent();
            //this.Connection = false;
            this.Connection = true;
        }

        private void CmdTestConnection_Click(object sender, EventArgs e)
        {
            // Mit diesem Buttonclick wird die Verbindung geprüft.

           // Verbindung bestehend -> Label soll Text anzeigen, dass DB verbunden ist und Connection auf true setzen. Button Apllikation starten auf enabled setzen

            // Keine Verbindung -> Text zeigt an, dass keine Verbindung besteht. Kein Login möglich.
         }

        private void CmdStartApplication_Click(object sender, EventArgs e)
        {
            if (this.Connection)
            {
                this.Hide();
                this.MainGui = new Main();
                this.MainGui.Show();
            }

        }
    }
}
