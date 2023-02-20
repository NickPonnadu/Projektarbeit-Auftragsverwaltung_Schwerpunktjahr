using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Projekt_Auftragsverwaltung.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Projekt_Auftragsverwaltung
{
    public class DataController
    {
        public string ConnectionString;

        public int CurrentCustomerId;

        public int CurrentAddressId;

        public int CurrentOrderId;

        public int CurrentOrderPositionId;

        public int CurrentArticleGroupId;

        public int CurrentArticleId;

        public DataController(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public DataTable ReturnCustomers()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var dbContext = new CompanyContext(ConnectionString))
                {
                    var kunden = from k in dbContext.Customers
                                 join a in dbContext.Addresses on k.AddressId equals a.AddressId
                                 join l in dbContext.AddressLocations on a.ZipCode equals l.ZipCode
                                 select new
                                 {
                                     Kundennummer = k.CustomerId,
                                     Name = k.Name,
                                     Telefonnummer = k.PhoneNumber,
                                     EMail = k.EMail,
                                     Passwort = k.Password,
                                     Strasse = a.Street,
                                     Hausnummer = a.HouseNumber,
                                     PLZ = a.ZipCode,
                                     Ort = l.Location
                                 };
                    var list = kunden.ToList();
                    var dataTable = CreateDataTableCustomer();
                    // Füge jede Zeile aus der Ergebnisliste zur DataTable hinzu
                    foreach (var item in list)
                    {
                        dataTable.Rows.Add(item.Kundennummer, item.Name, item.Telefonnummer, item.EMail,
                            item.Passwort, item.Strasse, item.Hausnummer, item.PLZ, item.Ort);
                    }
                    // Verwende die DataTable als DataSource für das DataGridView
                    return dataTable;
                }
            }
        }
        public DataTable ReturnCustomersSearch(string columnName, string searchValue)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                //    columnName = ConvertDataBindingsCustomers(columnName);
                connection.Open();
                using (var dbContext = new CompanyContext(ConnectionString))
                {
                    var query = from customer in dbContext.Customers
                                join address in dbContext.Addresses on customer.AddressId equals address.AddressId
                                join location in dbContext.AddressLocations on address.ZipCode equals location.ZipCode
                                select new
                                {
                                    CustomerId = customer.CustomerId,
                                    Name = customer.Name,
                                    PhoneNumber = customer.PhoneNumber,
                                    EMail = customer.EMail,
                                    Password = customer.Password,
                                    Street = address.Street,
                                    HouseNumber = address.HouseNumber,
                                    ZipCode = address.ZipCode,
                                    Location = location.Location
                                };

                    if (columnName == "Kundennummer")
                    {
                        query = query.Where(c => c.CustomerId.ToString().Contains(searchValue));
                    }
                    else if (columnName == "Name")
                    {
                        query = query.Where(c => c.Name.Contains(searchValue));
                    }
                    else if (columnName == "Telefonnummer")
                    {
                        query = query.Where(c => c.PhoneNumber.Contains(searchValue));
                    }
                    else if (columnName == "EMail")
                    {
                        query = query.Where(c => c.EMail.Contains(searchValue));
                    }
                    else if (columnName == "Passwort")
                    {
                        query = query.Where(c => c.Password.Contains(searchValue));
                    }
                    else if (columnName == "Strasse")
                    {
                        query = query.Where(c => c.Street.Contains(searchValue));
                    }
                    else if (columnName == "Hausnummer")
                    {
                        query = query.Where(c => c.HouseNumber.ToString().Contains(searchValue));
                    }
                    else if (columnName == "PLZ")
                    {
                        query = query.Where(c => c.ZipCode.ToString().Contains(searchValue));
                    }
                    else if (columnName == "Ort")
                    {
                        query = query.Where(c => c.Location.Contains(searchValue));
                    }

                    var list = query.ToList();
                    var dataTable = CreateDataTableCustomer();

                    // Füge jede Zeile aus der Ergebnisliste zur DataTable hinzu
                    foreach (var item in list)
                    {
                        dataTable.Rows.Add(item.CustomerId, item.Name, item.PhoneNumber, item.EMail,
                            item.Password, item.Street, item.HouseNumber, item.ZipCode, item.Location);
                    }

                    // Verwende die DataTable als DataSource für das DataGridView
                    return dataTable;
                }
            }
        }
        public DataTable ReturnArticles()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var dbContext = new CompanyContext(ConnectionString))
                {
                    var articles = from a in dbContext.Articles
                                   join ag in dbContext.ArticleGroups on a.ArticleGroupId equals ag.ArticleGroupId
                                   select new
                                   {
                                       ArtikelId = a.ArticleId,
                                       Artikelname = a.ArticleName,
                                       Preis = a.Price,
                                       Artikelgruppe = ag.Name,
                                   };

                    var list = articles.ToList();
                    var dataTable = CreateDataTableArticles();
                    // Füge jede Zeile aus der Ergebnisliste zur DataTable hinzu
                    foreach (var item in list)
                    {
                        dataTable.Rows.Add(item.ArtikelId, item.Artikelname, item.Preis, item.Artikelgruppe);
                    }

                    // Verwende die DataTable als DataSource für das DataGridView
                    return dataTable;
                }
            }

        }
        public DataTable ReturnArticlesSearch(string columnName, string filterValue)
        {
            using (var dbContext = new CompanyContext(ConnectionString))
            {
                var articles = from a in dbContext.Articles
                               join ag in dbContext.ArticleGroups on a.ArticleGroupId equals ag.ArticleGroupId
                               select new
                               {
                                   ArtikelId = a.ArticleId,
                                   Artikelname = a.ArticleName,
                                   Preis = a.Price,
                                   Artikelgruppe = ag.Name,
                               };

                switch (columnName)
                {
                    case "ArtikelId":
                        articles = articles.Where(a => a.ArtikelId == int.Parse(filterValue));
                        break;
                    case "Artikelname":
                        articles = articles.Where(a => a.Artikelname.Contains(filterValue));
                        break;
                    case "Preis":
                        articles = articles.Where(a => a.Preis == decimal.Parse(filterValue));
                        break;
                    case "Artikelgruppe":
                        articles = articles.Where(a => a.Artikelgruppe.Contains(filterValue));
                        break;
                    default:
                        throw new ArgumentException("Ungültige Spaltenbezeichnung");
                }

                var list = articles.ToList();
                var dataTable = CreateDataTableArticles();
                // Füge jede Zeile aus der Ergebnisliste zur DataTable hinzu
                foreach (var item in list)
                {
                    dataTable.Rows.Add(item.ArtikelId, item.Artikelname, item.Preis, item.Artikelgruppe);
                }

                // Verwende die DataTable als DataSource für das DataGridView
                return dataTable;
            }
        }
        public DataTable ReturnOrders()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var dbContext = new CompanyContext(ConnectionString))
                {
                    var orders = from o in dbContext.Orders
                                 join op in dbContext.OrderPositions on o.OrderId equals op.OrderId
                                 join c in dbContext.Customers on o.CustomerId equals c.CustomerId
                                 select new
                                 {
                                     Auftragsnummer = o.OrderId,
                                     Datum = o.Date.ToString("dd.MM.yyyy"),
                                     Name = c.Name,
                                     Positionen = "XXX",
                                 };
                    var list = orders.ToList();
                    var dataTable = CreateDataTableOrders();
                    foreach (var order in list)
                    {
                        dataTable.Rows.Add(order.Auftragsnummer, order.Datum, order.Name, order.Positionen);
                    }
                    return dataTable;
                }
            }
        }
        public DataTable ReturnOrdersSearch(string column, string value)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var dbContext = new CompanyContext(ConnectionString))
                {
                    var orders = from o in dbContext.Orders
                                 join op in dbContext.OrderPositions on o.OrderId equals op.OrderId
                                 join c in dbContext.Customers on o.CustomerId equals c.CustomerId
                                 select new
                                 {
                                     Auftragsnummer = o.OrderId,
                                     Datum = o.Date.ToString("dd.MM.yyyy"),
                                     Name = c.Name,
                                     Positionen = "XXX",
                                 };

                    switch (column)
                    {
                        case "Auftragsnummer":
                            orders = orders.Where(o => o.Auftragsnummer == Convert.ToInt32(value));
                            break;
                        case "Datum":
                            orders = orders.Where(o => o.Datum == value);
                            break;
                        case "Name":
                            orders = orders.Where(o => o.Name.Contains(value));
                            break;
                        case "Positionen":
                            orders = orders.Where(o => o.Positionen.Contains(value));
                            break;
                    }

                    var list = orders.ToList();
                    var dataTable = CreateDataTableOrders();
                    foreach (var order in list)
                    {
                        dataTable.Rows.Add(order.Auftragsnummer, order.Datum, order.Name, order.Positionen);
                    }
                    return dataTable;
                }
            }
        }
        public DataTable ReturnOrderPositions()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var dbContext = new CompanyContext(ConnectionString))
                {
                    var orderPositions = from op in dbContext.OrderPositions
                                         join o in dbContext.Orders on op.OrderId equals o.OrderId
                                         select new
                                         {
                                             Positionsnummer = op.OrderPositionId,
                                             Kundennummer = o.CustomerId,
                                             Betrag = op.amount,
                                             Datum = o.Date.ToString("dd.MM.yyyy"),
                                             Auftragsnummer = o.OrderId,
                                         };
                    var list = orderPositions.ToList();
                    var dataTable = CreateDataTableOrderPositions();
                    foreach (var orderPosition in list)
                    {
                        dataTable.Rows.Add(orderPosition.Positionsnummer, orderPosition.Kundennummer, orderPosition.Betrag, orderPosition.Datum, orderPosition.Auftragsnummer);
                    }
                    return dataTable;
                }
            }
        }
        public DataTable ReturnOrderPositionsSearch(string column, string filterValue)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var dbContext = new CompanyContext(ConnectionString))
                {
                    var orderPositions = from op in dbContext.OrderPositions
                                         join o in dbContext.Orders on op.OrderId equals o.OrderId
                                         select new
                                         {
                                             Positionsnummer = op.OrderPositionId,
                                             Kundennummer = o.CustomerId,
                                             Betrag = op.amount,
                                             Datum = o.Date.ToString("dd.MM.yyyy"),
                                             Auftragsnummer = o.OrderId,
                                         };
                    switch (column.ToLower())
                    {
                        case "positionsnummer":
                            orderPositions = orderPositions.Where(op => op.Positionsnummer.ToString().Contains(filterValue));
                            break;
                        case "kundennummer":
                            orderPositions = orderPositions.Where(op => op.Kundennummer.ToString().Contains(filterValue));
                            break;
                        case "betrag":
                            orderPositions = orderPositions.Where(op => op.Betrag.ToString().Contains(filterValue));
                            break;
                        case "datum":
                            orderPositions = orderPositions.Where(op => op.Datum.Contains(filterValue));
                            break;
                        case "auftragsnummer":
                            orderPositions = orderPositions.Where(op => op.Auftragsnummer.ToString().Contains(filterValue));
                            break;
                        default:
                            break;
                    }
                    var list = orderPositions.ToList();
                    var dataTable = CreateDataTableOrderPositions();
                    foreach (var orderPosition in list)
                    {
                        dataTable.Rows.Add(orderPosition.Positionsnummer, orderPosition.Kundennummer, orderPosition.Betrag, orderPosition.Datum, orderPosition.Auftragsnummer);
                    }
                    return dataTable;
                }
            }
        }
        public void CreateCustomer(string name, string phoneNumber, string eMail, string password, Address address)
        {
            // Verbindung mit der Datenbank herstellen
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var dbContext = new CompanyContext(ConnectionString))
                {
                    var newCustomer = new Customer
                    {
                        Name = name,
                        PhoneNumber = phoneNumber,
                        EMail = eMail,
                        Password = password,
                        AddressId = address.AddressId

                    };
                    dbContext.Customers.Add(newCustomer);
                    dbContext.SaveChanges();
                }
            }
        }
        public Address CreateAddress(string street, string houseNumber, string zipCode)
        {
            // Verbindung mit der Datenbank herstellen
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                // SqlCommand-Objekt erstellen und mit Verbindung und SQL-Befehl initialisieren
                using (var dbContext = new CompanyContext(ConnectionString))
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
        public void CreateAddressLocation(string zipCode, string location, Address address)
        {
            //Suchmethode mit filter einbauen. Falls resultat zurückkommt, return, sonst neuer erstellen.
            // Verbindung mit der Datenbank herstellen
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                // SqlCommand-Objekt erstellen und mit Verbindung und SQL-Befehl initialisieren
                using (var dbContext = new CompanyContext(ConnectionString))
                {
                    var newAddressLocation = new AddressLocation
                    {
                        ZipCode = Convert.ToInt32(zipCode),
                        Location = location,
                        AddressId = address.AddressId
                    };
                    dbContext.AddressLocations.Add(newAddressLocation);
                    dbContext.SaveChanges();

                }
            }
        }
        public void CreateOrder(DateTime datetime, string customerNumber)
        {
            // Verbindung mit der Datenbank herstellen
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string dateTimeString = Convert.ToString(datetime).Substring(0, 10);
                // SQL-Befehl definieren
                string sqlStatement = $"INSERT INTO Orders (Date,CustomerId) VALUES('{dateTimeString}',{customerNumber})";

                // SqlCommand-Objekt erstellen und mit Verbindung und SQL-Befehl initialisieren
                using (SqlCommand command = new SqlCommand(sqlStatement, connection))
                {
                    // Ausführen des SQL-Befehls
                    command.ExecuteNonQuery();
                }
            }
        }
        public void CreateArticleGroup(string name)
        {
            // Verbindung mit der Datenbank herstellen
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // SQL-Befehl definieren
                string sqlStatement = $"INSERT INTO ArticleGroups(Name) VALUES('{name}')";

                // SqlCommand-Objekt erstellen und mit Verbindung und SQL-Befehl initialisieren
                using (SqlCommand command = new SqlCommand(sqlStatement, connection))
                {
                    // Ausführen des SQL-Befehls
                    command.ExecuteNonQuery();

                }
            }


        }
        public DataTable CreateDataTableCustomer()
        {
            // Erstelle eine neue DataTable
            DataTable dataTable = new DataTable();
            // Erstelle Spalten in der DataTable
            dataTable.Columns.Add("Kundennummer", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Telefonnummer", typeof(string));
            dataTable.Columns.Add("EMail", typeof(string));
            dataTable.Columns.Add("Passwort", typeof(string));
            dataTable.Columns.Add("Strasse", typeof(string));
            dataTable.Columns.Add("Hausnummer", typeof(string));
            dataTable.Columns.Add("PLZ", typeof(string));
            dataTable.Columns.Add("Ort", typeof(string));
            return dataTable;
        }

        public DataTable CreateDataTableArticles()
        {
            // Erstelle eine neue DataTable
            DataTable dataTable = new DataTable();
            // Erstelle Spalten in der DataTable
            dataTable.Columns.Add("ArtikelId", typeof(int));
            dataTable.Columns.Add("Artikelname", typeof(string));
            dataTable.Columns.Add("Preis", typeof(decimal));
            dataTable.Columns.Add("Artikelgruppe", typeof(string));
            return dataTable;
        }

        public DataTable CreateDataTableOrders()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Auftragsnummer", typeof(int));
            dataTable.Columns.Add("Datum", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Positionen", typeof(string));
            return dataTable;
        }

        public DataTable CreateDataTableOrderPositions()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Positionsnummer", typeof(int));
            dataTable.Columns.Add("Kundennummer", typeof(int));
            dataTable.Columns.Add("Betrag", typeof(decimal));
            dataTable.Columns.Add("Datum", typeof(string));
            dataTable.Columns.Add("Auftragsnummer", typeof(int));
            return dataTable;
        }




        public DataTable ReturnPositionsSearch(string propertyFilter, string searchFilter)
        {
            propertyFilter = ConvertDataBindingsPositions(propertyFilter);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = $"SELECT OrderPositionId as Positionsnummer,CustomerId as Kundennummer,amount as Betrag, FORMAT(date,'dd.MM.yyyy') as Datum, Orders.OrderId as Auftragsnummer FROM OrderPositions INNER JOIN Orders ON OrderPositions.OrderPositionId = Orders.OrderId where {@propertyFilter} LIKE '%{@searchFilter}%'";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@propertyFilter", propertyFilter);
                    command.Parameters.AddWithValue("@searchFilter", searchFilter);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {

                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        CurrentOrderPositionId = Convert.ToInt32(dataTable.Rows.Count);
                        return dataTable;
                    }
                }
            }
        }



        public string ConvertDataBindingsCustomers(string ToConvert)
        {
            switch (ToConvert)

            {
                case "Kundennummer":
                    ToConvert = "CustomerId";
                    return ToConvert;
                case "Name":
                    ToConvert = "Name";
                    return ToConvert;
                case "Telefonnummer":
                    ToConvert = "PhoneNumber";
                    return ToConvert;
                case "Email":
                    ToConvert = "EMail";
                    return ToConvert;
                case "Website":
                    ToConvert = "Website";
                    return ToConvert;
                case "Strasse":
                    ToConvert = "Addresses.Street";
                    return ToConvert;
                case "Hausnummer":
                    ToConvert = "Addresses.HouseNumber";
                    return ToConvert;
                case "PLZ":
                    ToConvert = "Addresses.ZipCode";
                    return ToConvert;
                case "Ort":
                    ToConvert = "Addresses.Location";
                    return ToConvert;
                default:
                    return ToConvert;
            }
        }

        public string ConvertDataBindingsPositions(string ToConvert)
        {
            switch (ToConvert)

            {
                case "Positionsnummer":
                    ToConvert = "OrderPositionId";
                    return ToConvert;
                case "Kundennummer":
                    ToConvert = "CustomerId";
                    return ToConvert;
                case "Betrag":
                    ToConvert = "amount";
                    return ToConvert;
                case "Datum":
                    ToConvert = "date";
                    return ToConvert;
                case "Auftragsnummer":
                    ToConvert = "Orders.OrderId";
                    return ToConvert;
                default:
                    return ToConvert;
            }
        }

        public string ConvertDataBindingsArticles(string ToConvert)
        {
            switch (ToConvert)

            {
                case "ArtikelId":
                    ToConvert = "ArticleId";
                    return ToConvert;
                case "Artikelname":
                    ToConvert = "ArticleName";
                    return ToConvert;
                case "Preis":
                    ToConvert = "Price";
                    return ToConvert;
                case "Artikelgruppe":
                    ToConvert = "ArticleGroups.Name";
                    return ToConvert;
                default:
                    return ToConvert;
            }
        }

        public string ConvertDataBindingsOrders(string ToConvert)
        {
            switch (ToConvert)

            {
                case "Auftragsnummer":
                    ToConvert = "Orders.OrderId";
                    return ToConvert;
                case "Datum":
                    ToConvert = "Date";
                    return ToConvert;
                case "Name":
                    ToConvert = "Name";
                    return ToConvert;
                case "Positionen":
                    ToConvert = "'XXX'";
                    return ToConvert;
                default:
                    return ToConvert;
            }
        }

    }
}
