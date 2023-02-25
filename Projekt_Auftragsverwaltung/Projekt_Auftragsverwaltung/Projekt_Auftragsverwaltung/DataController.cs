using Azure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
                        dataTable.Rows.Add(order.Auftragsnummer, order.Datum, order.Name, order.PositionsId, order.Totalbetrag);
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
                            foundOrders = foundOrders.Where(o => o.Datum == value);
                            break;
                        case "Name":
                            foundOrders = foundOrders.Where(o => o.Name.Contains(value));
                            break;

                    }

                    var list = foundOrders.ToList();
                    var dataTable = CreateDataTableOrders();
                    foreach (var order in list)
                    {
                        dataTable.Rows.Add(order.Auftragsnummer, order.Datum, order.Name, order.PositionsId, order.Totalbetrag);
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
                                             Positionsnummer = op.OrderPositionId == 0 ? 0 : op.OrderPositionId,
                                             Auftragsnummer = o.OrderId == 0 ? 0 : op.OrderId,
                                             Auftragsdatum = o.Date.ToString("dd.MM.yyyy") ?? "",
                                             Kunde = c.Name ?? "",
                                             Artikelbezeichnung = a.ArticleName ?? "",
                                             Artikelanzahl = op.amount == 0 ? 0 : op.amount,
                                             Artikelbetrag = a.Price == 0 ? 0 : a.Price,
                                             Totalbetrag = (op.amount == 0 ? 0 : op.amount) * (a.Price == 0 ? 0 : a.Price),

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
                                              join o in dbContext.Orders on op.OrderId equals o.OrderId
                                              join ap in dbContext.ArticlePositions on op.OrderPositionId equals ap.OrderPositionId into apGroup
                                              from ap in apGroup.DefaultIfEmpty()
                                              join a in dbContext.Articles on ap.ArticleId equals a.ArticleId into aGroup
                                              from a in aGroup.DefaultIfEmpty()
                                              join c in dbContext.Customers on o.CustomerId equals c.CustomerId
                                              select new
                                              {
                                                  Positionsnummer = op.OrderPositionId,
                                                  Auftragsnummer = o.OrderId,
                                                  Auftragsdatum = o.Date.ToString("dd.MM.yyyy"),
                                                  Kunde = c.Name,
                                                  Artikelbezeichnung = a != null ? a.ArticleName : "",
                                                  Artikelanzahl = op.amount,
                                                  Artikelbetrag = a.Price,
                                                  Totalbetrag = (op.amount * a.Price),

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
                        AddressId = address.AddressId,
                        //Address = address
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
                    db.ArticleGroups.Remove(recordToDelete); // Den Datensatz aus der Datenbank entfernen
                    db.SaveChanges(); // Änderungen speichern
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

        public void DeleteOrderPosition(int orderPositionId)
        {
            using (var db = new CompanyContext(ConnectionString))
            {
                var recordToDelete = db.OrderPositions.FirstOrDefault(r => r.OrderPositionId == orderPositionId);
                if (recordToDelete != null)
                {
                    db.OrderPositions.Remove(recordToDelete); // Den Datensatz aus der Datenbank entfernen
                    db.SaveChanges(); // Änderungen speichern
                }
            }

        }

        public void DeleteCustomer(int orderPositionId)
        {
            using (var db = new CompanyContext(ConnectionString))
            {
                var recordToDelete = db.OrderPositions.FirstOrDefault(r => r.OrderPositionId == orderPositionId);
                if (recordToDelete != null)
                {
                    db.OrderPositions.Remove(recordToDelete); // Den Datensatz aus der Datenbank entfernen
                    db.SaveChanges(); // Änderungen speichern
                }
            }

            // Adresse und AdressLocations muss auch noch deleted werden
        }

    }
}
