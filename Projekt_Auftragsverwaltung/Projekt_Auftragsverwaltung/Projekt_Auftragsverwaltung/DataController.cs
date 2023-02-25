using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Projekt_Auftragsverwaltung.Tables;
using System.Collections.Concurrent;
using System.Data;
using System.Windows.Forms;

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
                        AddressId = address.AddressId
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

        // ChatGPT 1.
        public DataTable AnnualComparison()
        {
            using (var context = new CompanyContext(ConnectionString))
            {
                var startDate = DateTime.Now.Date.AddYears(-2);
                var endDate = DateTime.Now.Date;
                var query = from order in context.Orders
                            where order.Date >= startDate && order.Date < endDate
                            group order by new
                            {
                                Quarter = DbFunctions.DiffQuarter(startDate, order.Date) + 1
                            } into g
                            orderby g.Key.Quarter
                            select new
                            {
                                Quarter = g.Key.Quarter,
                                NumOrders = g.Count(),
                                AvgArticlesPerOrder = g.Average(o => context.OrderItems.Count(i => i.OrderId == o.OrderId)),
                                RevenuePerCustomer = g.Sum(o => o.TotalRevenue) / g.Select(o => o.CustomerId).Distinct().Count(),
                                TotalRevenue = g.Sum(o => o.TotalRevenue),
                                TotalArticles = g.Sum(o => context.OrderItems.Where(i => i.OrderId == o.OrderId).Sum(i => i.Quantity))
                            };

                foreach (var result in query)
                {
                    Console.WriteLine($"Quarter: {result.Quarter}, Num Orders: {result.NumOrders}, Total Articles: {result.TotalArticles}, Avg Articles Per Order: {result.AvgArticlesPerOrder}, Total Revenue: {result.TotalRevenue}, Revenue Per Customer: {result.RevenuePerCustomer}");
                }
            }
        }


        public DataTable MolLuegeTwo()
        {
            using (var context = new CompanyContext(ConnectionString))
            {
                var results = from order in context.Orders
                              join orderPosition in context.OrderPositions on order.OrderId equals orderPosition.OrderId
                              where order.Date >= DateTime.Now.AddYears(-3)
                              group orderPosition by new
                              {
                                  Year = order.Date.Year,
                                  Quarter = (order.Date.Month - 1) / 3 + 1
                              } into quarterlyData
                              select new
                              {
                                  Year = quarterlyData.Key.Year,
                                  Quarter = quarterlyData.Key.Quarter,
                                  NumOrders = quarterlyData.Select(op => op.order_id).Distinct().Count(),
                                  NumItems = quarterlyData.Sum(op => op.quantity),
                                  TotalRevenue = quarterlyData.Sum(op => op.quantity * op.price),
                                  AvgItemsPerOrder = quarterlyData.Average(op => (double)op.quantity)
                                                    over(partition by quarterlyData.Select(op => op.order_id).Distinct().Count());

                // Konvertieren Sie die Ergebnisse in eine Liste, damit sie in der DataGridView angezeigt werden können
                var resultList = results.ToList();

                // Legen Sie die DataSource-Eigenschaft der DataGridView auf die Ergebnisliste fest
                DATAGRIDNAME.DataSource = resultList;
            }
        }


    }


}
}
