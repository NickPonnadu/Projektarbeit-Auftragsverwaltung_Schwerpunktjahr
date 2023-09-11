using Projekt_Auftragsverwaltung.Controllers;
using Projekt_Auftragsverwaltung.Gui;
using Projekt_Auftragsverwaltung.Tables;

namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditCustomer : FormController
    {
        AddressController AddressController { get; }
        AddressLocationController AddressLocationController { get; }
        CustomerController CustomerController { get; }
        Customer? Customer { get; set; }

        public bool EditMode;

        public MainEditCustomer(AddressController addressController, AddressLocationController addressLocationController, CustomerController customerController, Customer? customer = null)
        {
            InitializeComponent();

            Customer = customer;

            if (Customer != null)
            {
                SetEditModeOn();
            }
            else SetEditModeOff();
            AddressController = addressController;
            AddressLocationController = addressLocationController;
            CustomerController = customerController;

        }

        private void SetEditModeOn()
        {
            var address = AddressController.GetSingleAddress(Customer.AddressId);
            var addressLocation = AddressLocationController.GetSingleAddressLocation(address.ZipCode);
            EditMode = true;
            TxtCustomerMail.Text = Customer.EMail;
            TxtCustomerPassword.Text = Customer.Password;
            TxtCustomerWebsite.Text = Customer.Website;
            TxtCustomerName.Text = Customer.Name;
            TxtCustomerPhoneNumber.Text = Customer.PhoneNumber;
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
                CustomerController.ReturnCustomers();
                AddressLocationController.CreateAddressLocation(TxtCustomerPostcode.Text, TxtCustomerLocation.Text);
                var address = AddressController.CreateAddress(TxtCustomerStreet.Text, TxtCustomerHouseNumber.Text, TxtCustomerPostcode.Text);
                CustomerController.CreateCustomer(TxtCustomerName.Text, TxtCustomerPhoneNumber.Text, TxtCustomerMail.Text, TxtCustomerPassword.Text, TxtCustomerWebsite.Text, address);
                CloseForm();
            }
            if (EditMode == true && Customer != null)
            {
                CustomerController.EditCustomer(Customer.CustomerId, TxtCustomerName.Text, TxtCustomerPhoneNumber.Text, TxtCustomerMail.Text, TxtCustomerWebsite.Text, TxtCustomerPassword.Text);

                var addressLocation = AddressLocationController.GetSingleAddressLocation(Convert.ToInt32(TxtCustomerPostcode.Text));
                if (addressLocation != null)
                {
                    AddressLocationController.EditAddressLocation(Convert.ToInt32(TxtCustomerPostcode.Text), TxtCustomerLocation.Text);
                }
                else
                {
                    AddressLocationController.CreateAddressLocation(TxtCustomerPostcode.Text, TxtCustomerLocation.Text);
                }
                AddressController.EditAddress(Customer.AddressId, TxtCustomerStreet.Text, TxtCustomerHouseNumber.Text, Convert.ToInt32(TxtCustomerPostcode.Text));

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
            SetEditModeOff();
            CloseForm();
        }
    }
}
