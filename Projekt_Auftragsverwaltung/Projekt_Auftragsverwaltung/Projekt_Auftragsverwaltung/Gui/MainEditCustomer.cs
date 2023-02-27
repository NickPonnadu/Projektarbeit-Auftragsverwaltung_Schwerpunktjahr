

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
            var address = dataController.CreateAddress(TxtCustomerStreet.Text, TxtCustomerHouseNumber.Text, TxtCustomerPostcode.Text);
            dataController.CreateAddressLocation(TxtCustomerPostcode.Text, TxtCustomerLocation.Text);
            dataController.CreateCustomer(TxtCustomerName.Text, TxtCustomerPhoneNumber.Text, TxtCustomerMail.Text, TxtCustomerPassword.Text,address);
            CloseForm();
        }

        private void CmdEditCustomerCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
              
    }
}
