

using Projekt_Auftragsverwaltung.Gui;

namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditCustomer : FormController

    {
        DataController dataController;
        public string ConnectionString;

        public MainEditCustomer(string connectionString)
        {
            InitializeComponent();
            
            ConnectionString = connectionString;
            dataController = new DataController(ConnectionString);
        }


        private void CmdEditCustomerSave_Click(object sender, EventArgs e)
        {
            dataController.ReturnCustomers();
            dataController.CreateCustomer(TxtCustomerName.Text, TxtCustomerPhoneNumber.Text, TxtCustomerMail.Text, TxtCustomerPassword.Text);
            System.Threading.Thread.Sleep(1000);
            dataController.CreateAddress(TxtCustomerStreet.Text, TxtCustomerHouseNumber.Text, TxtCustomerPostcode.Text);
           
            
            CloseForm();
        }

        private void CmdEditCustomerCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
              
    }
}
