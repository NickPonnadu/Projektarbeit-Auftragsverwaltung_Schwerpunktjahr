

using Projekt_Auftragsverwaltung.Gui;
using Projekt_Auftragsverwaltung.Tables;

namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditCustomer : FormController

    {
        DataController dataController;
        public string ConnectionString;

        Customer? Customer { get; set; }
        public bool EditMode;

        public MainEditCustomer(string connectionString, Customer customer = null)
        {
            InitializeComponent();

            ConnectionString = connectionString;
            dataController = new DataController(ConnectionString);
            Customer = customer;

            if (Customer != null)
            {
                SetEditModeOn();
            }
            else SetEditModeOff();
        }

        private void SetEditModeOn()
        {
            var address = dataController.GetSingleAddress(Customer.AddressId);
            var addressLocation = dataController.GetSingleAddressLocation(address.ZipCode);
            EditMode = true;
            TxtCustomerName.Text = Customer.Name;
            TxtCustomerPhoneNumber.Text = Customer.PhoneNumber;
            TxtCustomerMail.Text = Customer.EMail;
            TxtCustomerWebsite.Text = Customer.Website;
            TxtCustomerPassword.Text = Customer.Password;
            TxtCustomerStreet.Text = address.Street;
            TxtCustomerHouseNumber.Text = address.HouseNumber;
            TxtCustomerPostcode.Text = Convert.ToString(addressLocation.ZipCode);
            TxtCustomerLocation.Text = addressLocation.Location;
            CmdEditCustomerSave.Text = "Änderungen speichern";
        }

        private void SetEditModeOff()
        {
            Customer = null;
            EditMode = false;
            TxtCustomerPhoneNumber.Text = "";
            TxtCustomerMail.Text = "";
            TxtCustomerWebsite.Text = "";
            TxtCustomerPassword.Text = "";
            TxtCustomerStreet.Text = "";
            TxtCustomerHouseNumber.Text = "";
            TxtCustomerPostcode.Text = "";
            TxtCustomerLocation.Text = "";
            CmdEditCustomerSave.Text = "Kunde anlegen";
        }

        private void CmdEditCustomerSave_Click(object sender, EventArgs e)
        {
            if (EditMode == false)
            {
                dataController.ReturnCustomers();
                dataController.CreateAddressLocation(TxtCustomerPostcode.Text, TxtCustomerLocation.Text);
                var address = dataController.CreateAddress(TxtCustomerStreet.Text, TxtCustomerHouseNumber.Text, TxtCustomerPostcode.Text);
                dataController.CreateCustomer(TxtCustomerName.Text, TxtCustomerPhoneNumber.Text, TxtCustomerMail.Text, TxtCustomerPassword.Text, TxtCustomerWebsite.Text, address);
                CloseForm();
            }
            if (EditMode == true && Customer != null)
            {
                dataController.EditCustomer(Customer.CustomerId, TxtCustomerName.Text, TxtCustomerPhoneNumber.Text, TxtCustomerMail.Text, TxtCustomerWebsite.Text, TxtCustomerPassword.Text);
                dataController.EditAddress(Customer.AddressId, TxtCustomerStreet.Text, TxtCustomerHouseNumber.Text, Convert.ToInt32(TxtCustomerPostcode.Text));
                var addressLocation = dataController.GetSingleAddressLocation(Convert.ToInt32(TxtCustomerPostcode.Text));
                if (addressLocation != null)
                {
                    dataController.EditAddressLocation(Convert.ToInt32(TxtCustomerPostcode.Text), TxtCustomerLocation.Text);
                }
                else
                {
                    dataController.CreateAddressLocation(TxtCustomerPostcode.Text, TxtCustomerLocation.Text);
                }
                
                SetEditModeOff();
                CloseForm();
            }
            else if (EditMode == true && Customer == null)
            {
                MessageBox.Show("Falscher EditMode");
            }
        }

        private void CmdEditCustomerCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

    }
}
