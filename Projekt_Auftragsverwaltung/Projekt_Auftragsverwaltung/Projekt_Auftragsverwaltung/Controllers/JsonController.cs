using Projekt_Auftragsverwaltung;
using Projekt_Auftragsverwaltung.Interfaces;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

public class JsonController : IJsonController
{
    private readonly string _connectionString;

    public JsonController(string connectionString)
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


    public void ExportCustomersToJson()
    {
        using var db = new CompanyContext(_connectionString);

        var customers = db.Customers.Select(c => new
        {
            customerId = c.CustomerId,
            customerNr = c.CustomerNr,
            name = c.Name,
            address = new
            {
                street = c.Address.Street,
                houseNumber = c.Address.HouseNumber,
                addressLocation = new
                {
                    location = c.Address.AddressLocation.Location,
                    zipCode = c.Address.AddressLocation.ZipCode
                }
            },
            email = c.EMail,
            phoneNumber = c.PhoneNumber,
            website = c.Website,
            password = HashPassword(c.Password)
        }).ToList();

        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(customers, options);

        using (SaveFileDialog sfd = new SaveFileDialog())
        {
            sfd.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            sfd.FileName = "export";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, json);
            }
        }
    }
}