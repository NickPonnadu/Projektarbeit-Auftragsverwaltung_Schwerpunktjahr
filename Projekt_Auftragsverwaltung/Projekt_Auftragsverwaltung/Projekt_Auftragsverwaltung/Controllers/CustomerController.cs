using Microsoft.Data.SqlClient;
using Projekt_Auftragsverwaltung.Interfaces;
using Projekt_Auftragsverwaltung.Service;
using Projekt_Auftragsverwaltung.Tables;
using System.Data;

namespace Projekt_Auftragsverwaltung.Controllers;

public class CustomerController : ICustomerController
{
    private readonly string _connectionString;

    public CustomerController(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DataTable ReturnCustomers()
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var dbContext = new CompanyContext(_connectionString);
        var kunden = from k in dbContext.Customers
                     join a in dbContext.Addresses on k.AddressId equals a.AddressId into aGroup
                     from a in aGroup.DefaultIfEmpty()
                     join l in dbContext.AddressLocations on a.ZipCode equals l.ZipCode into lGroup
                     from l in lGroup.DefaultIfEmpty()
                     select new
                     {
                         Id = k.CustomerId,
                         KundenNr = k.CustomerNr,
                         k.Name,
                         Telefonnummer = k.PhoneNumber,
                         k.EMail,
                         Webseite = k.Website,
                         Passwort = k.Password,
                         Strasse = a.Street != null ? a.Street : null,
                         Hausnummer = a.HouseNumber != null ? a.HouseNumber : null,
                         PLZ = a.ZipCode != 0 ? a.ZipCode : 0,
                         Ort = l.Location != null ? l.Location : null
                     };
        var list = kunden.ToList();
        var dataTable = CreateDataTable();
        foreach (var item in list)
            dataTable.Rows.Add(item.Id, item.KundenNr, item.Name, item.Telefonnummer, item.EMail, item.Webseite,
                item.Passwort, item.Strasse, item.Hausnummer, item.PLZ, item.Ort);
        return dataTable;
    }

    public DataTable ReturnCustomersSearch(string columnName, string searchValue)
    {
        using var connection = new SqlConnection(_connectionString);
        //    columnName = ConvertDataBindingsCustomers(columnName);
        connection.Open();
        using var dbContext = new CompanyContext(_connectionString);
        var query = from k in dbContext.Customers
                    join a in dbContext.Addresses on k.AddressId equals a.AddressId into aGroup
                    from a in aGroup.DefaultIfEmpty()
                    join l in dbContext.AddressLocations on a.ZipCode equals l.ZipCode into lGroup
                    from l in lGroup.DefaultIfEmpty()
                    select new
                    {
                        Id = k.CustomerId,
                        Kundennummer = k.CustomerNr,
                        k.Name,
                        Telefonnummer = k.PhoneNumber,
                        k.EMail,
                        Webseite = k.Website,
                        Passwort = k.Password,
                        Strasse = a.Street != null ? a.Street : null,
                        Hausnummer = a.HouseNumber != null ? a.HouseNumber : null,
                        PLZ = a.ZipCode != 0 ? a.ZipCode : 0,
                        Ort = l.Location != null ? l.Location : null
                    };

        switch (columnName)
        {
            case "Id":
                query = query.Where(c => c.Id.ToString().Contains(searchValue));
                break;
            case "Kundennummer":
                query = query.Where(c => c.Kundennummer.Contains(searchValue));
                break;
            case "Name":
                query = query.Where(c => c.Name.Contains(searchValue));
                break;
            case "Telefonnummer":
                query = query.Where(c => c.Telefonnummer.Contains(searchValue));
                break;
            case "Email":
                query = query.Where(c => c.EMail.Contains(searchValue));
                break;
            case "Website":
                query = query.Where(c => c.Webseite.Contains(searchValue));
                break;
            case "Passwort":
                query = query.Where(c => c.Passwort.Contains(searchValue));
                break;
            case "Strasse":
                query = query.Where(c => c.Strasse.Contains(searchValue));
                break;
            case "Hausnummer":
                query = query.Where(c => c.Hausnummer.Contains(searchValue));
                break;
            case "PLZ":
                query = query.Where(c => c.PLZ.ToString().Contains(searchValue));
                break;
            case "Ort":
                query = query.Where(c => c.Ort.Contains(searchValue));
                break;
            default:
                // Handle the case where columnName is not recognized
                throw new ArgumentException("Invalid columnName: " + columnName);
        }

        var list = query.ToList();
        var dataTable = CreateDataTable();

        foreach (var item in list)
            dataTable.Rows.Add(item.Kundennummer, item.Name, item.Telefonnummer, item.EMail, item.Webseite,
                item.Passwort, item.Strasse, item.Hausnummer, item.PLZ, item.Ort);

        // Verwende die DataTable als DataSource für das DataGridView
        return dataTable;
    }

    public void CreateCustomer(string customerNr, string name, string phoneNumber, string eMail, string password, string website,
        Address address)
    {
        // Verbindung mit der Datenbank herstellen
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using var dbContext = new CompanyContext(_connectionString);
        var newCustomer = new Customer
        {
            CustomerNr = customerNr,
            Name = name,
            PhoneNumber = phoneNumber,
            Website = website,
            EMail = eMail,
            Password = password,
            AddressId = address.AddressId
        };
        
        dbContext.Customers.Add(newCustomer);
        dbContext.SaveChanges();
    }

    private static DataTable CreateDataTable()
    {
        var dataTable = new DataTable();
        dataTable.Columns.Add("Id", typeof(int));
        dataTable.Columns.Add("Kundennummer", typeof(string));
        dataTable.Columns.Add("Name", typeof(string));
        dataTable.Columns.Add("Telefonnummer", typeof(string));
        dataTable.Columns.Add("EMail", typeof(string));
        dataTable.Columns.Add("Webseite", typeof(string));
        dataTable.Columns.Add("Passwort", typeof(string));
        dataTable.Columns.Add("Strasse", typeof(string));
        dataTable.Columns.Add("Hausnummer", typeof(string));
        dataTable.Columns.Add("PLZ", typeof(string));
        dataTable.Columns.Add("Ort", typeof(string));
        return dataTable;
    }

    public void DeleteCustomer(int customerId)
    {
        using var db = new CompanyContext(_connectionString);
        var hasOrders = db.Orders.Any(o => o.CustomerId == customerId);
        var customerName = GetSingleCustomer(customerId).Name;
        if (hasOrders)
        {
            MessageBox.Show($"Kunde {customerName} hat laufende Aufträge und kann deshalb nicht gelöscht werden!");
        }
        else
        {
            var customer = db.Customers.FirstOrDefault(c => c.CustomerId == customerId);
            var address = db.Addresses.FirstOrDefault(a => a.AddressId == customer.AddressId);
            if (customer != null)
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
            }

            if (address != null)
            {
                db.Addresses.Remove(address);
                db.SaveChanges();
            }
        }
    }

    public bool DeleteCustomerWithReturn(int customerId)
    {
        using var db = new CompanyContext(_connectionString);
        var hasOrders = db.Orders.Any(o => o.CustomerId == customerId);
        var customerName = GetSingleCustomer(customerId).Name;
        if (hasOrders)
        {
            MessageBox.Show($"Kunde {customerName} hat laufende Aufträge und kann deshalb nicht gelöscht werden!");
            return false;
        }
        else
        {
            var customer = db.Customers.FirstOrDefault(c => c.CustomerId == customerId);
            var address = db.Addresses.FirstOrDefault(a => a.AddressId == customer.AddressId);
            if (customer != null)
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
            }

            if (address != null)
            {
                db.Addresses.Remove(address);
                db.SaveChanges();
            }

            return true;
        }
    }

    public void EditCustomer(string customerNr, int customerId, string name = "", string phoneNumber = "", string eMail = "",
        string website = "", string Password = "")
    {
        using var db = new CompanyContext(_connectionString);
        var recordToEdit = db.Customers.FirstOrDefault(r => r.CustomerId == customerId);
        if (recordToEdit != null)
        {
            recordToEdit.CustomerNr = customerNr;
            recordToEdit.EMail = eMail;
            recordToEdit.Password = Password;
            recordToEdit.Website = website;
            recordToEdit.Name = name;
            recordToEdit.PhoneNumber = phoneNumber;
            db.Customers.Update(recordToEdit);
            db.SaveChanges();
        }
    }

    public Customer GetSingleCustomer(int customerId)
    {
        using var db = new CompanyContext(_connectionString);
        var recordToReturn = db.Customers.FirstOrDefault(r => r.CustomerId == customerId);
        return recordToReturn;
    }
}