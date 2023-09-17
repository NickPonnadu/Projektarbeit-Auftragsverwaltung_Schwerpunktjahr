using Microsoft.EntityFrameworkCore;
using Projekt_Auftragsverwaltung.Entites;
using Projekt_Auftragsverwaltung.Interfaces;
using Projekt_Auftragsverwaltung.Service;
using System.Text.Json;

namespace Projekt_Auftragsverwaltung.Controllers
{
    public class ImportJsonController : IImportJsonController
    {
        private readonly string _connectionString;

        private readonly ICustomerController _customerController;
        private readonly IAddressController _addressController;
        private readonly IAddressLocationController _addressLocationController;
        private readonly RegexValidationService _validationService;

        public ImportJsonController(string connectionString, ICustomerController customerController, IAddressController addressController, IAddressLocationController addressLocationController)
        {
            _connectionString = connectionString;
            _customerController = customerController;
            _addressController = addressController;
            _addressLocationController = addressLocationController;
            _validationService = RegexValidationService.GetInstance();
        }

        public void ImportCustomersFromJson()
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string json = File.ReadAllText(fileDialog.FileName);

                        var jsonSerializerOptions = new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            PropertyNameCaseInsensitive = true
                        };
                        var customerDtos = JsonSerializer.Deserialize<List<CustomerImportDto>>(json, jsonSerializerOptions);

                        using var db = new CompanyContext(_connectionString);
                        if (!customerDtos.Any())
                        {
                            return;
                        }

                        foreach (var importedCustomer in customerDtos)
                        {
                            var existingCustomer = _customerController.GetSingleCustomer(importedCustomer.CustomerId);
                            var deletedCheck = true;
                            if (existingCustomer != null)
                            {
                                deletedCheck =
                                    _customerController.DeleteCustomerWithReturn(importedCustomer.CustomerId);
                            }

                            if (deletedCheck && _validationService.ValidateCustomerNumber(importedCustomer.CustomerNr))
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
                        db.SaveChanges();
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"File Read/Write Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (JsonException ex)
                    {
                        MessageBox.Show($"JSON Deserialization Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show($"Format Conversion Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
