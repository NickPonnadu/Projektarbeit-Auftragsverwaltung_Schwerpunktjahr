namespace Projekt_Auftragsverwaltung
{
    public partial class Login : Form
    {
        private bool Connection;

        private Form MainGui;

        public string DBconnectionString;

        public Login()
        {
            InitializeComponent();

            this.Connection = false;
        }

        private void CmdTestConnection_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(TxtDBServer.Text) && !string.IsNullOrEmpty(TxtDBName.Text))
            {
                // Gibt Wert and DataManager weiter welcher dann auf Context zugreift und DB erstellt.
                string connectionString = DatabaseManager.BuildConnectionString(TxtDBServer.Text, TxtDBName.Text);
                // Überprüft, ob DB bereits vorhanden. Wird für Anzeige später verwendet
                bool existingDB = DatabaseManager.CheckExistingDB(connectionString);
                Connection = DatabaseManager.UseDbContext(connectionString);
                if (this.Connection)
                {
                    LblConnection.Text = existingDB ? "DB ist Verbunden" : "Da keine DB gefunden wurde, wurde eine neue DB mit Testdaten erstellt";
                    CmdStartApplication.Enabled = true;
                    DBconnectionString = connectionString;
                    LblConnection.ForeColor = Color.Green;
                }
                else
                {
                    LblConnection.ForeColor = Color.Red;
                    LblConnection.Text = "Keine Verbindung mit der Datenbank";
                    this.Connection = false;
                }
            }
            else
            {
                MessageBox.Show("Beide Textfelder müssen mit einem Wert gefüllt werden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmdStartApplication_Click(object sender, EventArgs e)
        {
            if (this.Connection)
            {
                this.Hide();
                this.MainGui = new Main(DBconnectionString);

                this.MainGui.Show();
            }
        }

    }
}
