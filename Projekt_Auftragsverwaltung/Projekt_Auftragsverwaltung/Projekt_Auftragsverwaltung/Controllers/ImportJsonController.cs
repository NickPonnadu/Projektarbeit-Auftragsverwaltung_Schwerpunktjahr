using Projekt_Auftragsverwaltung.Entites;
using Projekt_Auftragsverwaltung.Interfaces;
using Projekt_Auftragsverwaltung.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace Projekt_Auftragsverwaltung.Controllers
{
    public class ImportJsonController : IImportJsonController
    {
        private readonly string _connectionString;

        private readonly ICustomerController _customerController;
        private readonly IAddressController _addressController;
        private readonly IAddressLocationController _addressLocationController;
        public ImportJsonController(string connectionString, ICustomerController customerController, IAddressController addressController, IAddressLocationController addressLocationController)
        {
            _connectionString = connectionString;
            _customerController = customerController;
            _addressController = addressController;
            _addressLocationController = addressLocationController;
        }


        public void ImportCustomersFromJson()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {

                        string json = File.ReadAllText(ofd.FileName);

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

                            if (deletedCheck)
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
