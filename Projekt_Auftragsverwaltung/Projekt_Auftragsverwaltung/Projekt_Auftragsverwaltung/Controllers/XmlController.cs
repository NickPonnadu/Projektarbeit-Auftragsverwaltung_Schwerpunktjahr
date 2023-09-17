using Projekt_Auftragsverwaltung;
using Projekt_Auftragsverwaltung.Interfaces;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;


public class XmlController : IXmlController
{
    private readonly string _connectionString;

    public XmlController(string connectionString)
    {
        _connectionString = connectionString;
    }

    public static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }
        return builder.ToString();
    }

    public void ExportCustomerToXml()
    {
        using var db = new CompanyContext(_connectionString);

        var customers = db.Customers.Select(c => new
        {
            c.CustomerId,
            c.CustomerNr,
            c.Name,
            AddressStreet = c.Address.Street,
            AddressHouseNumber = c.Address.HouseNumber,
            AddressLocation = c.Address.AddressLocation.Location,
            AddressPostalCode = c.Address.AddressLocation.ZipCode,
            c.EMail,
            c.PhoneNumber,
            c.Website,
            HashedPassword = HashPassword(c.Password)
        })
        .ToList()
        .Select(c => new XElement("Kunde",
            new XAttribute("CustomerId", c.CustomerId),
            new XAttribute("CustomerNr", c.CustomerNr),
            new XElement("Name", c.Name),
            new XElement("Address",
                new XElement("Street", c.AddressStreet),
                new XElement("HouseNumber", c.AddressHouseNumber),
        new XElement("PostalCode", c.AddressPostalCode),
        new XElement("Location", c.AddressLocation)
            ),
            new XElement("EMail", c.EMail),
            new XElement("PhoneNumber", c.PhoneNumber),
            new XElement("Website", c.Website),
            new XElement("Password", c.HashedPassword)
        )).ToList();

        var xmlDocument = new XDocument();
        var root = new XElement("Kunden", customers);
        xmlDocument.Add(root);

        using (SaveFileDialog sfd = new SaveFileDialog())
        {
            sfd.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            sfd.FileName = "exportedData";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                xmlDocument.Save(sfd.FileName);
            }
        }
    }
}