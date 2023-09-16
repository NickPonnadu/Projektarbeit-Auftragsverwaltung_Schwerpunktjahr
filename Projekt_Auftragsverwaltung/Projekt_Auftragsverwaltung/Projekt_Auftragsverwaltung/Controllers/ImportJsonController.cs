using Microsoft.EntityFrameworkCore;
using Projekt_Auftragsverwaltung.Entites;
using Projekt_Auftragsverwaltung.Interfaces;
using Projekt_Auftragsverwaltung.Tables;
using System.Text.Json;

namespace Projekt_Auftragsverwaltung.Controllers
{
    public class ImportJsonController : IImportJsonController
    {
        private readonly string _connectionString;

        public ImportJsonController(string connectionString)
        {
            _connectionString = connectionString;
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
                        var customerDtos = JsonSerializer.Deserialize<List<CustomerImportDto>>(json);

                        using var db = new CompanyContext(_connectionString);
                        foreach (var importedCustomer in customerDtos)
                        {
                            if (importedCustomer != null && importedCustomer.Address != null)
                            {
                                Address newAddress = new Address
                                {
                                    Street = importedCustomer.Address.Street,
                                    HouseNumber = "Unknown",
                                    ZipCode = importedCustomer.Address.PostalCode
                                };

                                db.Addresses.Add(newAddress);
                                db.SaveChanges();

                                Customer newCustomer = new Customer
                                {
                                    CustomerId = int.Parse(importedCustomer.CustomerNr.Replace("CU", "")),
                                    Name = importedCustomer.Name,
                                    EMail = importedCustomer.Email,
                                    Website = importedCustomer.Website,
                                    Password = importedCustomer.Password,
                                    AddressId = newAddress.AddressId
                                };

                                db.Customers.Add(newCustomer);
                            }
                        }
                        db.SaveChanges();
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine($"File Read/Write Error: {ex.Message}");
                    }
                    catch (JsonException ex)
                    {
                        Console.WriteLine($"JSON Deserialization Error: {ex.Message}");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Format Conversion Error: {ex.Message}");
                    }
                    catch (DbUpdateException ex)
                    {
                        Console.WriteLine($"Database Update Error: {ex.Message}");
                        if (ex.InnerException != null)
                        {
                            Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                        }
                    }
                }
            }
        }
    }
}
