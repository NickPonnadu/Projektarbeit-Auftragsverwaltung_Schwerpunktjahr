using Projekt_Auftragsverwaltung.Controllers;
using Projekt_Auftragsverwaltung.Gui;
using Projekt_Auftragsverwaltung.Interfaces;
using Projekt_Auftragsverwaltung.Service;
using Projekt_Auftragsverwaltung.Tables;

namespace Projekt_Auftragsverwaltung
{

    public partial class MainEditCustomer : FormController
    {

        private readonly IAddressController _addressController;
        private readonly IAddressLocationController _addressLocationController;
        private readonly ICustomerController _customerController;
        Customer? Customer { get; set; }

        public bool EditMode;


        public MainEditCustomer(IAddressController addressController, IAddressLocationController addressLocationController, ICustomerController customerController, Customer? customer = null )

        {
            InitializeComponent();
            _validationService = RegexValidationService.GetInstance();

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
            TxtCustomerNr.Text = Customer.CustomerNr;
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
            TxtCustomerNr.Text = "";
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
            if (!EditMode)
            {
                _customerController.ReturnCustomers();
                _addressLocationController.CreateAddressLocation(TxtCustomerPostcode.Text, TxtCustomerLocation.Text);
                var address = _addressController.CreateAddress(TxtCustomerStreet.Text, TxtCustomerHouseNumber.Text, TxtCustomerPostcode.Text);

                if (InputIsValid())
                {
                    _customerController.CreateCustomer(TxtCustomerNr.Text, TxtCustomerName.Text, TxtCustomerPhoneNumber.Text, TxtCustomerMail.Text, TxtCustomerPassword.Text, TxtCustomerWebsite.Text, address);

                    CloseForm();
                }
            }
            if (EditMode == true && Customer != null && InputIsValid())
            {
                _customerController.EditCustomer(TxtCustomerNr.Text, Customer.CustomerId, TxtCustomerName.Text, TxtCustomerPhoneNumber.Text, TxtCustomerMail.Text, TxtCustomerWebsite.Text, TxtCustomerPassword.Text);

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
        public bool InputIsValid()
        {
            return _validationService.ValidateCustomerNumber(TxtCustomerNr.Text) &&
                _validationService.ValidateEmail(TxtCustomerMail.Text) &&
                _validationService.ValidateWebsite(TxtCustomerWebsite.Text) &&
                _validationService.ValidatePassword(TxtCustomerPassword.Text);
        }
        private void CmdEditCustomerCancel_Click(object sender, EventArgs e)
        {
            SetEditModeOff();
            CloseForm();
        }

        private readonly RegexValidationService _validationService;
    }
}
