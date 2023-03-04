using Azure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Projekt_Auftragsverwaltung;
using Projekt_Auftragsverwaltung.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
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
                                 join a in dbContext.Addresses on k.AddressId equals a.AddressId into aGroup
                                 from a in aGroup.DefaultIfEmpty()
                                 join l in dbContext.AddressLocations on a.ZipCode equals l.ZipCode into lGroup
                                 from l in lGroup.DefaultIfEmpty()
                                 select new
                                 {
                                     Kundennummer = k.CustomerId,
                                     Name = k.Name,
                                     Telefonnummer = k.PhoneNumber,
                                     EMail = k.EMail,
                                     Webseite = k.Website,
                                     Passwort = k.Password,
                                     Strasse = a.Street != null ? a.Street : null,
                                     Hausnummer = a.HouseNumber != null ? a.HouseNumber : null,
                                     PLZ = a.ZipCode != 0 ? a.ZipCode : 0,
                                     Ort = l.Location != null ? l.Location : null,
                                 };
                    var list = kunden.ToList();
                    var dataTable = CreateDataTableCustomer();
                    // Füge jede Zeile aus der Ergebnisliste zur DataTable hinzu
                    foreach (var item in list)
                    {
                        dataTable.Rows.Add(item.Kundennummer, item.Name, item.Telefonnummer, item.EMail, item.Webseite,
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
                    var query = from k in dbContext.Customers
                                join a in dbContext.Addresses on k.AddressId equals a.AddressId into aGroup
                                from a in aGroup.DefaultIfEmpty()
                                join l in dbContext.AddressLocations on a.ZipCode equals l.ZipCode into lGroup
                                from l in lGroup.DefaultIfEmpty()
                                select new
                                {
                                    Kundennummer = k.CustomerId,
                                    Name = k.Name,
                                    Telefonnummer = k.PhoneNumber,
                                    EMail = k.EMail,
                                    Webseite = k.Website,
                                    Passwort = k.Password,
                                    Strasse = a.Street != null ? a.Street : null,
                                    Hausnummer = a.HouseNumber != null ? a.HouseNumber : null,
                                    PLZ = a.ZipCode != 0 ? a.ZipCode : 0,
                                    Ort = l.Location != null ? l.Location : null,
                                };

                    switch (columnName)
                    {
                        case "Kundennummer":
                            query = query.Where(c => c.Kundennummer.ToString().Contains(searchValue));
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
                    var dataTable = CreateDataTableCustomer();

                    foreach (var item in list)
                    {
                        dataTable.Rows.Add(item.Kundennummer, item.Name, item.Telefonnummer, item.EMail, item.Webseite,
                            item.Passwort, item.Strasse, item.Hausnummer, item.PLZ, item.Ort);
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
                                   join ag in dbContext.ArticleGroups on a.ArticleGroupId equals ag.ArticleGroupId into agGroup
                                   from ag in agGroup.DefaultIfEmpty()
                                   select new
                                   {
                                       ArtikelId = a.ArticleId,
                                       Artikelname = a.ArticleName,
                                       Preis = a.Price,
                                       Artikelgruppe = ag != null ? ag.Name : "keine Artikelgruppe",
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

                    var foundOrders = from o in dbContext.Orders
                                      join c in dbContext.Customers on o.CustomerId equals c.CustomerId
                                      join op in dbContext.OrderPositions on o.OrderId equals op.OrderId into opGroup
                                      from op in opGroup.DefaultIfEmpty()
                                      join ap in dbContext.ArticlePositions on op.OrderPositionId equals ap.OrderPositionId into apGroup
                                      from ap in apGroup.DefaultIfEmpty()
                                      join a in dbContext.Articles on ap.ArticleId equals a.ArticleId into aGroup
                                      from a in aGroup.DefaultIfEmpty()
                                      group new { o, op, a } by new { o.OrderId, o.Date, c.Name } into g
                                      select new
                                      {
                                          Auftragsnummer = g.Key.OrderId,
                                          Datum = g.Key.Date.ToString("dd.MM.yyyy") ?? "",
                                          Name = g.Key.Name ?? "",
                                          PositionsId = string.Join(",", g.Select(x => x.op.OrderPositionId != null ? x.op.OrderPositionId : 0).ToList()) ?? "",
                                          Totalbetrag = g.Sum(x => (x.op != null ? x.op.amount : 0) * (x.a != null ? x.a.Price : 0))
                                      };
                    var list = foundOrders.ToList();
                    var dataTable = CreateDataTableOrders();
                    foreach (var order in list)
                    {
                        dataTable.Rows.Add(order.Auftragsnummer, order.Datum, order.Name, order.PositionsId, order.Totalbetrag.ToString("0.00"));

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

                    DateTime dateTime;

                    if (column == "Datum")
                    {

                        try
                        {
                            dateTime = DateTime.ParseExact(value, "dd.MM.yyyy", null);
                        }
                        catch
                        {
                            MessageBox.Show("Ungültiges Datumsformat");
                            return null;
                        }
                    }




                    var foundOrders = from o in dbContext.Orders
                                      join c in dbContext.Customers on o.CustomerId equals c.CustomerId
                                      join op in dbContext.OrderPositions on o.OrderId equals op.OrderId into opGroup
                                      from op in opGroup.DefaultIfEmpty()
                                      join ap in dbContext.ArticlePositions on op.OrderPositionId equals ap.OrderPositionId into apGroup
                                      from ap in apGroup.DefaultIfEmpty()
                                      join a in dbContext.Articles on ap.ArticleId equals a.ArticleId into aGroup
                                      from a in aGroup.DefaultIfEmpty()
                                      group new { o, op, a } by new { o.OrderId, o.Date, c.Name } into g
                                      select new
                                      {
                                          Auftragsnummer = g.Key.OrderId,
                                          Datum = g.Key.Date.ToString("dd.MM.yyyy") ?? "",
                                          Name = g.Key.Name ?? "",
                                          PositionsId = string.Join(",", g.Select(x => x.op.OrderPositionId != null ? x.op.OrderPositionId : 0).ToList()) ?? "",
                                          Totalbetrag = g.Sum(x => (x.op != null ? x.op.amount : 0) * (x.a != null ? x.a.Price : 0))
                                      };

                    switch (column)
                    {
                        case "Auftragsnummer":
                            foundOrders = foundOrders.Where(o => o.Auftragsnummer == Convert.ToInt32(value));
                            break;
                        case "Datum":
                            foundOrders = foundOrders.Where(o => o.Datum.Equals(DateTime.ParseExact(value, "dd.MM.yyyy", null)));
                            break;
                        case "Name":
                            foundOrders = foundOrders.Where(o => o.Name.Contains(value));
                            break;
                    }


                    var list = foundOrders.ToList();
                    var dataTable = CreateDataTableOrders();
                    foreach (var order in list)
                    {
                        dataTable.Rows.Add(order.Auftragsnummer, order.Datum, order.Name, order.PositionsId, order.Totalbetrag.ToString("0.00"));

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
                                         join o in dbContext.Orders on op.OrderId equals o.OrderId into orders
                                         from o in orders.DefaultIfEmpty()
                                         join ap in dbContext.ArticlePositions on op.OrderPositionId equals ap.OrderPositionId into apGroup
                                         from ap in apGroup.DefaultIfEmpty()
                                         join a in dbContext.Articles on ap.ArticleId equals a.ArticleId into aGroup
                                         from a in aGroup.DefaultIfEmpty()
                                         join c in dbContext.Customers on o.CustomerId equals c.CustomerId
                                         select new
                                         {
                                             Positionsnummer = op.OrderPositionId == null ? 0 : op.OrderPositionId,
                                             Auftragsnummer = o.OrderId == null ? 0 : o.OrderId,
                                             Auftragsdatum = o.Date == null ? "" : o.Date.ToString("dd.MM.yyyy"),
                                             Kunde = c.Name == null ? "" : c.Name,
                                             Artikelbezeichnung = a.ArticleName == null ? "" : a.ArticleName,
                                             Artikelanzahl = op.amount == null ? 0 : op.amount,
                                             Artikelbetrag = a.Price == null ? 0 : a.Price,
                                             Totalbetrag = (op.amount == null ? 0 : op.amount) * (a.Price == null ? 0 : a.Price)
                                         };

                    var list = orderPositions.ToList();
                    var dataTable = CreateDataTableOrderPositions();
                    foreach (var orderPosition in list)
                    {
                        dataTable.Rows.Add(orderPosition.Positionsnummer, orderPosition.Auftragsnummer, orderPosition.Auftragsdatum, orderPosition.Kunde, orderPosition.Artikelbezeichnung,
                                           orderPosition.Artikelanzahl, orderPosition.Artikelbetrag.ToString("F2"),
                                           orderPosition.Totalbetrag.ToString("F2"));

                    }
                    return dataTable;
                }
            }
        }

        public DataTable ReturnOrderPositionsSearch(string columnName, string searchValue)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var dbContext = new CompanyContext(ConnectionString))
                {
                    var orderPositionsQuery = from op in dbContext.OrderPositions
                                         join o in dbContext.Orders on op.OrderId equals o.OrderId into orders
                                         from o in orders.DefaultIfEmpty()
                                         join ap in dbContext.ArticlePositions on op.OrderPositionId equals ap.OrderPositionId into apGroup
                                         from ap in apGroup.DefaultIfEmpty()
                                         join a in dbContext.Articles on ap.ArticleId equals a.ArticleId into aGroup
                                         from a in aGroup.DefaultIfEmpty()
                                         join c in dbContext.Customers on o.CustomerId equals c.CustomerId
                                         select new
                                         {
                                             Positionsnummer = op.OrderPositionId == null ? 0 : op.OrderPositionId,
                                             Auftragsnummer = o.OrderId == null ? 0 : o.OrderId,
                                             Auftragsdatum = o.Date == null ? "" : o.Date.ToString("dd.MM.yyyy"),
                                             Kunde = c.Name == null ? "" : c.Name,
                                             Artikelbezeichnung = a.ArticleName == null ? "" : a.ArticleName,
                                             Artikelanzahl = op.amount == null ? 0 : op.amount,
                                             Artikelbetrag = a.Price == null ? 0 : a.Price,
                                             Totalbetrag = (op.amount == null ? 0 : op.amount) * (a.Price == null ? 0 : a.Price)
                                         };

                    switch (columnName)
                    {
                        case "Positionsnummer":
                            orderPositionsQuery = orderPositionsQuery.Where(op => op.Positionsnummer.ToString().Contains(searchValue));
                            break;
                        case "Auftragsnummer":
                            orderPositionsQuery = orderPositionsQuery.Where(op => op.Auftragsnummer.ToString().Contains(searchValue));
                            break;
                        case "Auftragsdatum":
                            DateTime dateValue;
                            if (DateTime.TryParse(searchValue, out dateValue))
                            {
                                orderPositionsQuery = orderPositionsQuery.Where(op => op.Auftragsdatum.Equals(dateValue.ToString("dd.MM.yyyy")));
                            }
                            break;
                        case "Kunde":
                            orderPositionsQuery = orderPositionsQuery.Where(op => op.Kunde.Contains(searchValue));
                            break;
                        case "Artikelbezeichnung":
                            orderPositionsQuery = orderPositionsQuery.Where(op => op.Artikelbezeichnung.Contains(searchValue));
                            break;
                        case "Artikelanzahl":
                            int intValue;
                            if (int.TryParse(searchValue, out intValue))
                            {
                                orderPositionsQuery = orderPositionsQuery.Where(op => op.Artikelanzahl.Equals(intValue));
                            }
                            break;
                        case "Artikelbetrag":
                            double doubleValue;
                            if (double.TryParse(searchValue, out doubleValue))
                            {
                                orderPositionsQuery = orderPositionsQuery.Where(op => op.Artikelbetrag.Equals(doubleValue));
                            }
                            break;
                        case "Totalbetrag":
                            if (double.TryParse(searchValue, out doubleValue))
                            {
                                orderPositionsQuery = orderPositionsQuery.Where(op => op.Totalbetrag.Equals(doubleValue));
                            }
                            break;
                    }

                    var list = orderPositionsQuery.ToList();
                    var dataTable = CreateDataTableOrderPositions();
                    foreach (var orderPosition in list)
                    {
                        dataTable.Rows.Add(orderPosition.Positionsnummer, orderPosition.Auftragsnummer, orderPosition.Auftragsdatum, orderPosition.Kunde, orderPosition.Artikelbezeichnung,
                                           orderPosition.Artikelanzahl, orderPosition.Artikelbetrag.ToString("F2"),
                                           orderPosition.Totalbetrag.ToString("F2"));

                    }
                    return dataTable;
                }
            }
        }

        public DataTable ReturnArticleGroups()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var dbContext = new CompanyContext(ConnectionString))
                {
                    var articleGroups = from a in dbContext.ArticleGroups
                                        select new
                                        {
                                            ArtikelgruppeId = a.ArticleGroupId,
                                            Name = a.Name
                                        };



                    var list = articleGroups.ToList();
                    var dataTable = CreateDataTableArticleGroups();
                    // Füge jede Zeile aus der Ergebnisliste zur DataTable hinzu
                    foreach (var item in list)
                    {
                        dataTable.Rows.Add(item.ArtikelgruppeId, item.Name);
                    }

                    // Verwende die DataTable als DataSource für das DataGridView
                    return dataTable;
                }
            }
        }

        public DataTable ReturnArticleGroupsSearch(string searchValue)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var dbContext = new CompanyContext(ConnectionString))
                {
                    var articleGroups = from a in dbContext.ArticleGroups
                                        select new
                                        {
                                            ArtikelgruppeId = a.ArticleGroupId,
                                            Name = a.Name
                                        };


                    articleGroups = articleGroups.Where(o => o.Name.Contains(searchValue));

                    var list = articleGroups.ToList();
                    var dataTable = CreateDataTableArticleGroups();
                    // Füge jede Zeile aus der Ergebnisliste zur DataTable hinzu
                    foreach (var item in list)
                    {
                        dataTable.Rows.Add(item.ArtikelgruppeId, item.Name);
                    }

                    // Verwende die DataTable als DataSource für das DataGridView
                    return dataTable;
                }
            }
        }

        public void CreateCustomer(string name, string phoneNumber, string eMail, string password, string website, Address address)
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
                        Website = website,
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
        public void CreateAddressLocation(string zipCode, string location)
        {
            // Verbindung mit der Datenbank herstellen
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                // SqlCommand-Objekt erstellen und mit Verbindung und SQL-Befehl initialisieren
                using (var dbContext = new CompanyContext(ConnectionString))
                {
                    // Prüfen, ob Datensatz bereits vorhanden ist
                    var existingRecord = dbContext.AddressLocations.FirstOrDefault(al => al.ZipCode == Convert.ToInt32(zipCode));

                    if (existingRecord != null)
                    {
                        // Datensatz bereits vorhanden
                        return;
                    }

                    // Datensatz neu erstellen
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

        public void CreateOrder(DateTime date, int customerId)
        {
            // Verbindung mit der Datenbank herstellen
            using (var dbContext = new CompanyContext(ConnectionString))
            {
                var order = new Order
                {
                    Date = date,
                    CustomerId = customerId
                };
                dbContext.Orders.Add(order);
                dbContext.SaveChanges();
            }
        }

        public void CreateOrderPosition(int amount, int orderId, int articleId)
        {
            // Verbindung mit der Datenbank herstellen
            using (var dbContext = new CompanyContext(ConnectionString))
            {
                var orderPosition = new OrderPosition
                {
                    amount = amount,
                    OrderId = orderId
                };


                dbContext.OrderPositions.Add(orderPosition);
                dbContext.SaveChanges();

                var articlePosition = new ArticlePosition
                {
                    ArticleId = articleId,
                    OrderPositionId = orderPosition.OrderPositionId
                };

                dbContext.ArticlePositions.Add(articlePosition);
                dbContext.SaveChanges();
            }
        }
        public void CreateArticleGroup(string name)
        {
            // Verbindung mit der Datenbank herstellen
            using (var dbContext = new CompanyContext(ConnectionString))
            {
                var articleGroup = new ArticleGroup { Name = name };
                dbContext.ArticleGroups.Add(articleGroup);
                dbContext.SaveChanges();
            }
        }
        public void CreateArticle(string name, decimal price, int articleGroupId)
        {
            // Verbindung mit der Datenbank herstellen
            using (var dbContext = new CompanyContext(ConnectionString))
            {
                var article = new Article
                {

                    ArticleName = name,
                    Price = price,
                    ArticleGroupId = articleGroupId

                };
                dbContext.Articles.Add(article);
                dbContext.SaveChanges();
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
            dataTable.Columns.Add("Webseite", typeof(string));
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
        public DataTable CreateDataTableArticleGroups()
        {
            // Erstelle eine neue DataTable
            DataTable dataTable = new DataTable();
            // Erstelle Spalten in der DataTable
            dataTable.Columns.Add("ArtikelgruppeId", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            return dataTable;
        }
        public DataTable CreateDataTableOrders()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Auftragsnummer", typeof(int));
            dataTable.Columns.Add("Datum", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Positionen", typeof(string));
            dataTable.Columns.Add("Totalbetrag", typeof(decimal));
            return dataTable;
        }

        public DataTable CreateDataTableOrderPositions()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Positionsnummer", typeof(int));
            dataTable.Columns.Add("Auftragsnummer", typeof(int));
            dataTable.Columns.Add("Autragsdatum", typeof(string));
            dataTable.Columns.Add("Kunde", typeof(string));
            dataTable.Columns.Add("Artikelbezeichnung", typeof(string));
            dataTable.Columns.Add("Artikelanzahl", typeof(int));
            dataTable.Columns.Add("Artikelbetrag", typeof(string));
            dataTable.Columns.Add("Totalbetrag", typeof(string));
            return dataTable;
        }

        public void DeleteArticle(int articleId)
        {
            using (var db = new CompanyContext(ConnectionString))
            {
                var recordToDelete = db.Articles.FirstOrDefault(r => r.ArticleId == articleId);
                if (recordToDelete != null)
                {
                    db.Articles.Remove(recordToDelete); // Den Datensatz aus der Datenbank entfernen
                    db.SaveChanges(); // Änderungen speichern
                }
            }
        }

        public void DeleteArticleGroup(int ArticleGroupId)
        {
            using (var db = new CompanyContext(ConnectionString))
            {
                var recordToDelete = db.ArticleGroups.FirstOrDefault(r => r.ArticleGroupId == ArticleGroupId);
                if (recordToDelete != null)
                {
                    var hasArticleGroups = db.Articles.Any(o => o.ArticleGroupId == ArticleGroupId);

                    if (hasArticleGroups)
                    {
                        MessageBox.Show("Artikelgruppe ist mit Artikeln verknüpft!");
                    }
                    else
                    {
                        db.ArticleGroups.Remove(recordToDelete); // Den Datensatz aus der Datenbank entfernen
                        db.SaveChanges(); // Änderungen speichern
                    }
                }
            }
        }


        public void DeleteOrder(int orderId)
        {
            using (var db = new CompanyContext(ConnectionString))
            {
                var recordToDelete = db.Orders.FirstOrDefault(r => r.OrderId == orderId);
                if (recordToDelete != null)
                {
                    var orderPositions = db.OrderPositions.Where(op => op.OrderId == orderId).ToList();
                    if (orderPositions.Count == 0)
                    {
                        db.Orders.Remove(recordToDelete); // Den Datensatz aus der Datenbank entfernen
                        db.SaveChanges(); // Änderungen speichern
                    }
                    else
                    {
                        MessageBox.Show("Der Auftrag enthält noch Positionen. Lösche zuerst die Positionen, bevor du den Auftrag löschst!");
                    }
                }
                else
                {
                    MessageBox.Show("Kein Auftrag ausgewählt");
                }
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (var db = new CompanyContext(ConnectionString))
            {
                // Kunden-Bestellungen prüfen
                var hasOrders = db.Orders.Any(o => o.CustomerId == customerId);
                if (hasOrders)
                {
                    MessageBox.Show("Kunde hat laufende Aufträge und kann deshalb nicht gelöscht werden!");
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
        }

        public void DeleteOrderPosition(int orderPositionId)
        {
            using (var db = new CompanyContext(ConnectionString))
            {

                var recordToDelete = db.OrderPositions.FirstOrDefault(r => r.OrderPositionId == orderPositionId);

                int articlePositionId = recordToDelete.OrderPositionId;

                if (recordToDelete != null)
                {
                    db.OrderPositions.Remove(recordToDelete); // Den Datensatz aus der Datenbank entfernen
                    db.SaveChanges(); // Änderungen speichern
                }

            }
        }

        public void DeleteAddress(int addressId)
        {
            using (var db = new CompanyContext(ConnectionString))
            {
                var recordToDelete = db.Addresses.FirstOrDefault(r => r.AddressId == addressId);
                if (recordToDelete != null)
                {
                    db.Addresses.Remove(recordToDelete); // Den Datensatz aus der Datenbank entfernen
                    db.SaveChanges(); // Änderungen speichern
                }
            }

        }

        public void EditArticleGroup(int articleGroupId, string articleGroupName = "")
        {
            using (var db = new CompanyContext(ConnectionString))
            {
                var recordToEdit = db.ArticleGroups.FirstOrDefault(r => r.ArticleGroupId == articleGroupId);
                if (recordToEdit != null)
                {
                    recordToEdit.Name = articleGroupName;
                    db.ArticleGroups.Update(recordToEdit);
                    db.SaveChanges(); // Änderungen speichern
                }
            }
        }
        public void EditArticle(int articleId, string articleName = "", decimal articlePrice = 0, int articleGroupId = 0)
        {
            using (var db = new CompanyContext(ConnectionString))
            {
                var recordToEdit = db.Articles.FirstOrDefault(r => r.ArticleId == articleId);
                if (recordToEdit != null)
                {

                    recordToEdit.ArticleName = articleName;
                    recordToEdit.Price = articlePrice;
                    recordToEdit.ArticleGroupId = articleGroupId;
                    db.Articles.Update(recordToEdit);
                    db.SaveChanges(); // Änderungen speichern
                }
            }
        }

        public void EditOrder(int orderId, DateTime date, int customerId)
        {
            using (var db = new CompanyContext(ConnectionString))
            {
                var recordToEdit = db.Orders.FirstOrDefault(r => r.OrderId == orderId);
                if (recordToEdit != null)
                {
                    recordToEdit.Date = date;
                    recordToEdit.CustomerId = customerId;
                    db.Orders.Update(recordToEdit);
                    db.SaveChanges(); // Änderungen speichern
                }
            }
        }


        public void EditOrderPosition(int orderPositionId, int amount, int orderId)
        {
            using (var db = new CompanyContext(ConnectionString))
            {
                var recordToEdit = db.OrderPositions.FirstOrDefault(r => r.OrderPositionId == orderPositionId);
                if (recordToEdit != null)
                {
                    recordToEdit.amount = amount;
                    recordToEdit.OrderId = orderId;
                    db.OrderPositions.Update(recordToEdit);
                    db.SaveChanges(); // Änderungen speichern
                }
            }
        }

        public void EditArticlePosition(int orderPositionId, int articleId)
        {
            using (var db = new CompanyContext(ConnectionString))
            {
                var recordToEdit = db.ArticlePositions.FirstOrDefault(r => r.OrderPositionId == orderPositionId);
                if (recordToEdit != null)
                {
                    recordToEdit.OrderPositionId = orderPositionId;
                    recordToEdit.ArticleId = articleId;
                    db.ArticlePositions.Update(recordToEdit);
                    db.SaveChanges(); // Änderungen speichern
                }
            }
        }

        public void EditCustomer(int customerId, string name = "", string phoneNumber = "", string eMail = "", string website = "", string Password = "")
        {
            using (var db = new CompanyContext(ConnectionString))
            {
                var recordToEdit = db.Customers.FirstOrDefault(r => r.CustomerId == customerId);
                if (recordToEdit != null)
                {

                    recordToEdit.Name = name;
                    recordToEdit.PhoneNumber = phoneNumber;
                    recordToEdit.EMail = eMail;
                    recordToEdit.Website = website;
                    recordToEdit.Password = Password;
                    db.Customers.Update(recordToEdit);
                    db.SaveChanges(); // Änderungen speichern
                }
            }
        }

        public void EditAddress(int addressId, string street = "", string houseNumber = "", int postCode = 0000)
        {
            using (var db = new CompanyContext(ConnectionString))
            {
                var recordToEdit = db.Addresses.FirstOrDefault(r => r.AddressId == addressId);
                if (recordToEdit != null)
                {

                    recordToEdit.Street = street;
                    recordToEdit.HouseNumber = houseNumber;
                    recordToEdit.ZipCode = postCode == 0000 ? 0000 : postCode;
                    db.Addresses.Update(recordToEdit);
                    db.SaveChanges(); // Änderungen speichern
                }
            }
        }
        public void EditAddressLocation(int zipCode, string location = "")
        {
            using (var db = new CompanyContext(ConnectionString))
            {
                var recordToEdit = db.AddressLocations.FirstOrDefault(r => r.ZipCode == zipCode);
                if (recordToEdit != null)
                {

                    recordToEdit.Location = location;
                    db.AddressLocations.Update(recordToEdit);
                    db.SaveChanges(); // Änderungen speichern
                }
            }
        }



        public ArticleGroup GetSingleArticleGroup(int articleGroupId)
        {
            using (var db = new CompanyContext(ConnectionString))
            {
                var recordToReturn = db.ArticleGroups.FirstOrDefault(r => r.ArticleGroupId == articleGroupId);
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

        public Article GetSingleArticle(int articleId)
        {
            using (var db = new CompanyContext(ConnectionString))
            {
                var recordToReturn = db.Articles.FirstOrDefault(r => r.ArticleId == articleId);
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

        public Customer GetSingleCustomer(int customerId)
        {
            using (var db = new CompanyContext(ConnectionString))
            {
                var recordToReturn = db.Customers.FirstOrDefault(r => r.CustomerId == customerId);
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

        public Address GetSingleAddress(int adressId)
        {
            using (var db = new CompanyContext(ConnectionString))
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

        public AddressLocation GetSingleAddressLocation(int zipcode)
        {
            using (var db = new CompanyContext(ConnectionString))
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

        public Order GetSingleOrder(int orderId)
        {
            using (var db = new CompanyContext(ConnectionString))
            {
                var recordToReturn = db.Orders.FirstOrDefault(r => r.OrderId == orderId);
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

        public OrderPosition GetSingleOrderPosition(int orderPositionId)
        {
            using (var db = new CompanyContext(ConnectionString))
            {
                var recordToReturn = db.OrderPositions.FirstOrDefault(r => r.OrderPositionId == orderPositionId);
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

        public ArticlePosition GetSingleArticlePosition(int orderPositionId, int articleId)
        {
            using (var db = new CompanyContext(ConnectionString))
            {
                var recordToReturn = db.ArticlePositions.FirstOrDefault(r => r.OrderPositionId == orderPositionId && r.ArticleId == articleId);
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
