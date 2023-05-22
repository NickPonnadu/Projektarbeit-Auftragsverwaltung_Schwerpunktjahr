using Microsoft.Data.SqlClient;
using Projekt_Auftragsverwaltung.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Auftragsverwaltung.Controllers
{
    public class AddressController : IDataControllerAddressEntities

    {
        private string _connectionString { get; }

        public AddressController(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Address CreateEntity(string street, string houseNumber, string zipCode)
        {
            // Verbindung mit der Datenbank herstellen
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                // SqlCommand-Objekt erstellen und mit Verbindung und SQL-Befehl initialisieren
                using (var dbContext = new CompanyContext(_connectionString))
                {
                    var newAddress = new Address
                    {
                        Street = street,
                        HouseNumber = houseNumber,
                        ZipCode = Convert.ToInt32(zipCode)
                    };
                    dbContext.Addresses.Add(newAddress);
                    dbContext.SaveChanges();
                    return newAddress;
                }
            }




        }
        public void DeleteEntity(int addressId)
        {
            using (var db = new CompanyContext(_connectionString))
            {
                var recordToDelete = db.Addresses.FirstOrDefault(r => r.AddressId == addressId);
                if (recordToDelete != null)
                {
                    db.Addresses.Remove(recordToDelete); // Den Datensatz aus der Datenbank entfernen
                    db.SaveChanges(); // Änderungen speichern
                }
            }

        }
        public void EditAddress(int addressId, string street = "", string houseNumber = "", int postCode = 0000)
        {
            using (var db = new CompanyContext(_connectionString))
            {
                var recordToEdit = db.Addresses.FirstOrDefault(r => r.AddressId == addressId);
                if (recordToEdit != null)
                {

                    recordToEdit.Street = street;
                    recordToEdit.HouseNumber = houseNumber;
                    recordToEdit.ZipCode = postCode == 0000 ? 0000 : postCode;
                    db.Addresses.Update(recordToEdit);
                    db.SaveChanges();
                }
            }
        }

        public object GetSingleEntity(int adressId)
        {
            using (var db = new CompanyContext(_connectionString))
            {   
                var recordToReturn = db.Addresses.FirstOrDefault(r => r.AddressId == adressId);
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
