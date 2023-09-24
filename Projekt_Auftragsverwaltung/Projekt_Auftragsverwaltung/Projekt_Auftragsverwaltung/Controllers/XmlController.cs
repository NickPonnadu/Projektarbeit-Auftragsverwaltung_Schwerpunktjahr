using Projekt_Auftragsverwaltung;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Projekt_Auftragsverwaltung.Interfaces;
using Projekt_Auftragsverwaltung.Entites;



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



        var customers = db.Customers.Select(c => new CustomerXmlDto
        {
            CustomerId = c.CustomerId,
            CustomerNr = c.CustomerNr,
            Name = c.Name,
            Address = new AddressXmlDto
            {
                Street = c.Address.Street,
                HouseNumber = c.Address.HouseNumber,
                AddressLocation = new AddressLocationXmlDto
                {
                    Location = c.Address.AddressLocation.Location,
                    ZipCode = c.Address.AddressLocation.ZipCode
                }
            },
            Email = c.EMail,
            PhoneNumber = c.PhoneNumber,
            Website = c.Website,
            Password = HashPassword(c.Password)
        }).ToList();





        var serializer = new XmlSerializer(typeof(List<CustomerXmlDto>));



        using (SaveFileDialog sfd = new SaveFileDialog())
        {
            sfd.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            sfd.FileName = "export";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                serializer.Serialize(fs, customers);
            }
        }
    }
}