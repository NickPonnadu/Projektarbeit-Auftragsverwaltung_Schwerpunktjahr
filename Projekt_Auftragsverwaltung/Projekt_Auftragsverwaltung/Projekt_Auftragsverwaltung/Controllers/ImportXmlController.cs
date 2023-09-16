using Microsoft.EntityFrameworkCore;
using Projekt_Auftragsverwaltung.Interfaces;
using Projekt_Auftragsverwaltung.Tables;
using System.Xml;
using System.Xml.Linq;

namespace Projekt_Auftragsverwaltung.Controllers
{
    public class ImportXmlController : IImportXmlController
    {
        private readonly string _connectionString;

        public ImportXmlController(string connectionString)
        {
            _connectionString = connectionString;
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
                        XElement xelement = XElement.Load(ofd.FileName);
                        IEnumerable<XElement> customers = xelement.Elements("Kunde");

                        using var db = new CompanyContext(_connectionString);

                        foreach (var customerElement in customers)
                        {
                            Address newAddress = new Address
                            {
                                Street = (string)customerElement.Element("Address")?.Element("Street"),
                                HouseNumber = "Unknown",
                                ZipCode = (int?)customerElement.Element("Address")?.Element("PostalCode") ?? 0
                            };

                            db.Addresses.Add(newAddress);
                            db.SaveChanges();

                            Customer newCustomer = new Customer
                            {
                                CustomerId = int.Parse(((string)customerElement.Attribute("CustomerNr"))?.Replace("CU", "") ?? "0"),
                                Name = (string)customerElement.Element("Name"),
                                EMail = (string)customerElement.Element("EMail"),
                                Website = (string)customerElement.Element("Website"),
                                Password = (string)customerElement.Element("Password"),
                                AddressId = newAddress.AddressId
                            };

                            db.Customers.Add(newCustomer);
                        }

                        db.SaveChanges();
                    }
                    catch (XmlException ex)
                    {
                        // Handle XML format or parsing errors
                        Console.WriteLine($"XML Error: {ex.Message}");
                    }
                    catch (FormatException ex)
                    {
                        // Handle type conversion errors (like parsing strings to int)
                        Console.WriteLine($"Format Error: {ex.Message}");
                    }
                    catch (DbUpdateException ex)
                    {
                        // Handle database errors
                        Console.WriteLine(ex.Message);
                        if (ex.InnerException != null)
                        {
                            Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                        }
                    }
                    catch (Exception ex)
                    {
                        // General catch block for unexpected errors
                        Console.WriteLine($"Unexpected Error: {ex.Message}");
                    }
                }
            }
        }
    }
}
