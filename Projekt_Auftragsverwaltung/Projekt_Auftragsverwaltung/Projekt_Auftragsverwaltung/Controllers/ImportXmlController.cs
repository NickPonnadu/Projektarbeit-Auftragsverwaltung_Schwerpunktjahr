using Microsoft.EntityFrameworkCore;
using Projekt_Auftragsverwaltung.Entites;
using Projekt_Auftragsverwaltung.Interfaces;
using System.Xml.Serialization;



namespace Projekt_Auftragsverwaltung.Controllers
{
    public class ImportXmlController : IImportXmlController
    {
        private readonly string _connectionString;
        private readonly ICustomerController _customerController;
        private readonly IAddressController _addressController;
        private readonly IAddressLocationController _addressLocationController;
        private readonly IRegexValidationService _regexValidationService;



        public ImportXmlController(string connectionString, ICustomerController customerController, IAddressController addressController, IAddressLocationController addressLocationController, IRegexValidationService regexValidationService)
        {
            _connectionString = connectionString;
            _customerController = customerController;
            _addressController = addressController;
            _addressLocationController = addressLocationController;
            _regexValidationService = regexValidationService;
        }



        public void ImportCustomerFromXml()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<CustomerXmlDto>));
                        using FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                        var customerDtos = (List<CustomerXmlDto>)serializer.Deserialize(fs);
                        

                        using var db = new CompanyContext(_connectionString);
                        if (!customerDtos.Any())
                        {
                            return;
                        }
                        
                        foreach (var importedCustomer in customerDtos)
                        {
                            var existingCustomer = _customerController.GetSingleCustomer(importedCustomer.CustomerId);

                            if (_regexValidationService.ValidateCustomerNumber(importedCustomer.CustomerNr)
                                && _regexValidationService.ValidateEmail(importedCustomer.Email)
                                && _regexValidationService.ValidatePassword(importedCustomer.Password)
                                && _regexValidationService.ValidateWebsite(importedCustomer.Website))

                            {
                                if (existingCustomer != null)
                                {
                                    _customerController.EditCustomer(importedCustomer.CustomerNr, importedCustomer.CustomerId, importedCustomer.Name, importedCustomer.PhoneNumber, importedCustomer.Email, importedCustomer.Website, importedCustomer.Password);

                                    _addressLocationController.CreateAddressLocation(importedCustomer.Address.AddressLocation.ZipCode.ToString(), importedCustomer.Address.AddressLocation.Location);

                                    _addressController.EditAddress(existingCustomer.AddressId,
                                        importedCustomer.Address.Street, importedCustomer.Address.HouseNumber,
                                        importedCustomer.Address.AddressLocation.ZipCode);

                                }
                                else
                                {
                                    _addressLocationController.CreateAddressLocation(
                                        importedCustomer.Address.AddressLocation.ZipCode.ToString(),
                                        importedCustomer.Address.AddressLocation.Location);


                                    var address = _addressController.CreateAddress(importedCustomer.Address.Street,
                                        importedCustomer.Address.HouseNumber,
                                        importedCustomer.Address.AddressLocation.ZipCode.ToString());

                                    _customerController.CreateCustomer(importedCustomer.CustomerNr, importedCustomer.Name,
                                        importedCustomer.PhoneNumber, importedCustomer.Email, importedCustomer.Password,
                                        importedCustomer.Website, address);
                                }
                            }
                            
                        }
                        db.SaveChanges();
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"File Read/Write Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show($"XML Deserialization Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (DbUpdateException ex)
                    {
                        MessageBox.Show($"Database Update Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (ex.InnerException != null)
                        {
                            MessageBox.Show($"Inner Exception: {ex.InnerException.Message}", "Inner Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}