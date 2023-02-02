using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Projekt_Auftragsverwaltung
{
    public partial class Login : Form
    {

        private bool Connection;

        private Form MainGui;

        //private ConnectionStrings testString;


        public Login()
        {
            InitializeComponent();
            //this.Connection = false;
            this.Connection = true;
        }

        private void CmdTestConnection_Click(object sender, EventArgs e)
        {

            string dataBase = TxtDBName.Text;
            string server = TxtDBServer.Text;
            ConnectionStrings testString = new ConnectionStrings(server, dataBase);


            using (var context = new CompanyContext())
            {

                context.Database.Migrate();
                this.Connection = true;

            }

            if (this.Connection)
                LblConnection.Text = "DB ist Verbunden";         
            else
                LblConnection.Text = "Keine Verbindung mit der Datenbank";

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
