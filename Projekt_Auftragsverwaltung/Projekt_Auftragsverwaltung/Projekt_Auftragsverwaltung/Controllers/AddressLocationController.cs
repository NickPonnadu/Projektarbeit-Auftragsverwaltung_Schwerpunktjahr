using Microsoft.Data.SqlClient;
using Projekt_Auftragsverwaltung.Tables;

namespace Projekt_Auftragsverwaltung.Controllers
{
    public class AddressLocationController : IAddressLocationController
    {
        private readonly string _connectionString;

        public AddressLocationController(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateAddressLocation(string zipCode, string location)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var dbContext = new CompanyContext(_connectionString))
                {
                    var existingRecord = dbContext.AddressLocations.FirstOrDefault(al => al.ZipCode == Convert.ToInt32(zipCode));

                    if (existingRecord != null)
                    {
                        return;
                    }

                    var newAddressLocation = new AddressLocation
                    {
                        ZipCode = Convert.ToInt32(zipCode),
                        Location = location
                    };
                    dbContext.AddressLocations.Add(newAddressLocation);
                    dbContext.SaveChanges();
                }
            }
        }

        public void EditAddressLocation(int zipCode, string location = "")
        {
            using (var db = new CompanyContext(_connectionString))
            {
                var recordToEdit = db.AddressLocations.FirstOrDefault(r => r.ZipCode == zipCode);
                if (recordToEdit != null)
                {

                    recordToEdit.Location = location;
                    db.AddressLocations.Update(recordToEdit);
                    db.SaveChanges();
                }
            }
        }

        
        public AddressLocation GetSingleAddressLocation(int zipcode)
        {
            using (var db = new CompanyContext(_connectionString))
            {
                var recordToReturn = db.AddressLocations.FirstOrDefault(r => r.ZipCode == zipcode);
                if (recordToReturn != null)
                {
                    return recordToReturn;
                }
                else
                {
                    return null;
                }
            }
        }


    }
}
