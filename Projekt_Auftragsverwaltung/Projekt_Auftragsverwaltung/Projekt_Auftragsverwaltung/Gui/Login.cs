using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            //this.Connection = false;
            this.Connection = true;
        }

        private void CmdTestConnection_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtDBServer.Text) && !string.IsNullOrEmpty(TxtDBName.Text))
            {               
                string connectionString = DatabaseManager.BuildConnectionString(TxtDBServer.Text, TxtDBName.Text);
                LblConnection.Text = "testet Verbindung..";
                if (DatabaseManager.TestConnection(connectionString))
                {
                    DatabaseManager.UseDbContext(connectionString);
                }
                else
                {
                    this.Connection = false;
                }


                if (this.Connection)
                {
                    LblConnection.Text = "DB ist Verbunden";
                    CmdStartApplication.Enabled = true;
                    DBconnectionString = connectionString;
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

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
