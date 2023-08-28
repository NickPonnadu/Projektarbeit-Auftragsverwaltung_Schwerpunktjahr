using Projekt_Auftragsverwaltung.Controllers;
using Projekt_Auftragsverwaltung.Interfaces;

namespace Projekt_Auftragsverwaltung
{
    public partial class Login : Form
    {
        private bool Connection;

        private Form MainGui;

        public string DbConnectionString;

        private IAddressController AddressController;
        private IAddressLocationController AddressLocationController;
        private IArticleController ArticleController;
        private IArticleGroupController ArticleGroupController;
        private IArticlePositionController ArticlePositionController;
        private ICustomerController CustomerController;
        private IOrderController OrderController;
        private IOrderPositionController OrderPositionController;
        private IStatisticController StatisticController;

        public Login()
        {
            InitializeComponent();
            Connection = false;
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
                if (Connection)
                {

                    LblConnection.Text = existingDB ? "DB ist Verbunden" : "Da keine DB gefunden wurde, wurde eine neue DB mit Testdaten erstellt";
                    CmdStartApplication.Enabled = true;
                    DbConnectionString = connectionString;
                    LblConnection.ForeColor = Color.Green;
                    InitializeControllers();
                }
                else
                {
                    LblConnection.ForeColor = Color.Red;
                    LblConnection.Text = "Keine Verbindung mit der Datenbank";
                    Connection = false;
                }
            }
            else
            {
                MessageBox.Show("Beide Textfelder müssen mit einem Wert gefüllt werden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeControllers()
        {
            ArticleController = new ArticleController(DbConnectionString);
            AddressController = new AddressController(DbConnectionString);
            AddressLocationController = new AddressLocationController(DbConnectionString);
            ArticleGroupController = new ArticleGroupController(DbConnectionString);
            ArticlePositionController = new ArticlePositionController(DbConnectionString);
            CustomerController = new CustomerController(DbConnectionString);
            OrderController = new OrderController(DbConnectionString);
            OrderPositionController = new OrderPositionController(DbConnectionString);
            StatisticController = new StatisticController(DbConnectionString);

        }

        private void CmdStartApplication_Click(object sender, EventArgs e)
        {
            if (Connection)
            {
                Hide();
                MainGui = new Main(ArticleController, ArticleGroupController, ArticlePositionController, CustomerController, OrderController, OrderPositionController, StatisticController, AddressLocationController, AddressController);

                MainGui.Show();
            }
        }

    }
}
