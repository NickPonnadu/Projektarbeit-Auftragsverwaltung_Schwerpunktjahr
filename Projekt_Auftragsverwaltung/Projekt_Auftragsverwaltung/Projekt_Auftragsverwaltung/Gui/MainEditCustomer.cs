

using Projekt_Auftragsverwaltung.Controllers;
using Projekt_Auftragsverwaltung.Gui;
using Projekt_Auftragsverwaltung.Interfaces;
using Projekt_Auftragsverwaltung.Tables;

namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditCustomer : FormController

    {
        IAddressController _addressController { get; }
        IAddressLocationController _addressLocationController { get; }
        ICustomerController _customerController { get; }
        Customer? Customer { get; set; }

        public bool EditMode;

        public MainEditCustomer(IAddressController addressController, IAddressLocationController addressLocationController, ICustomerController customerController, Customer? customer = null )
        {
            InitializeComponent();

            Customer = customer;

            _addressController = addressController;
            _addressLocationController = addressLocationController;
            _customerController = customerController;

            if (Customer != null)
            {
                SetEditModeOn();
            }
            else SetEditModeOff();
            
        }

        private void SetEditModeOn()
        {
            var addressId = Customer.AddressId;
            var address = _addressController.GetSingleAddress(addressId);
            var addressLocation = _addressLocationController.GetSingleAddressLocation(address.ZipCode);
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
                _customerController.ReturnCustomers();
                _addressLocationController.CreateAddressLocation(TxtCustomerPostcode.Text, TxtCustomerLocation.Text);
                var address = _addressController.CreateAddress(TxtCustomerStreet.Text, TxtCustomerHouseNumber.Text, TxtCustomerPostcode.Text);
                _customerController.CreateCustomer(TxtCustomerName.Text, TxtCustomerPhoneNumber.Text, TxtCustomerMail.Text, TxtCustomerPassword.Text, TxtCustomerWebsite.Text, address);
                CloseForm();
            }
            if (EditMode == true && Customer != null)
            {
                _customerController.EditCustomer(Customer.CustomerId, TxtCustomerName.Text, TxtCustomerPhoneNumber.Text, TxtCustomerMail.Text, TxtCustomerWebsite.Text, TxtCustomerPassword.Text);

                var addressLocation = _addressLocationController.GetSingleAddressLocation(Convert.ToInt32(TxtCustomerPostcode.Text));
                if (addressLocation != null)
                {
                    _addressLocationController.EditAddressLocation(Convert.ToInt32(TxtCustomerPostcode.Text), TxtCustomerLocation.Text);
                }
                else
                {
                    _addressLocationController.CreateAddressLocation(TxtCustomerPostcode.Text, TxtCustomerLocation.Text);
                }
                _addressController.EditAddress(Customer.AddressId, TxtCustomerStreet.Text, TxtCustomerHouseNumber.Text, Convert.ToInt32(TxtCustomerPostcode.Text));

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
