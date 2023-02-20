using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Projekt_Auftragsverwaltung.Tables;
using System;
using System.Collections.Generic;
using System.Data;
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

        //public DataTable ReturnCustomers()
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();
        //        string query = "SELECT CustomerId as Kundennummer,Name as Name,PhoneNumber as Telefonnummer,EMail as EMail,Password as Passwort,Street as Strasse,HouseNumber as Hausnummer,Addresses.ZipCode as PLZ,Location as Ort FROM Customers LEFT JOIN Addresses ON Customers.AddressId = Addresses.AddressId LEFT JOIN AddressLocations ON Addresses.ZipCode = AddressLocations.ZipCode";
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
        //            {
        //                DataTable dataTable = new DataTable();
        //                adapter.Fill(dataTable);
        //                CurrentCustomerId = Convert.ToInt32(dataTable.Rows.Count);
        //                CurrentAddressId = Convert.ToInt32(dataTable.Rows.Count);
        //                return dataTable;
        //            }
        //        }
        //    }
        //}


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

                    // Erstelle eine neue DataTable
                    DataTable dataTable = new DataTable();

                    // Erstelle Spalten in der DataTable
                    dataTable.Columns.Add("ArtikelId", typeof(int));
                    dataTable.Columns.Add("Artikelname", typeof(string));
                    dataTable.Columns.Add("Preis", typeof(decimal));
                    dataTable.Columns.Add("Artikelgruppe", typeof(string));

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

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Auftragsnummer", typeof(int));
                    dataTable.Columns.Add("Datum", typeof(string));
                    dataTable.Columns.Add("Name", typeof(string));
                    dataTable.Columns.Add("Positionen", typeof(string));
                    foreach (var order in orders)
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
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Positionsnummer", typeof(int));
                    dataTable.Columns.Add("Kundennummer", typeof(int));
                    dataTable.Columns.Add("Betrag", typeof(decimal));
                    dataTable.Columns.Add("Datum", typeof(string));
                    dataTable.Columns.Add("Auftragsnummer", typeof(int));
                    foreach (var orderPosition in orderPositions)
                    {
                        dataTable.Rows.Add(orderPosition.Positionsnummer, orderPosition.Kundennummer, orderPosition.Betrag, orderPosition.Datum, orderPosition.Auftragsnummer);
                    }
                    return dataTable;
                }
            }
        }

        public void CreateCustomer(string name, string phoneNumber, string eMail, string password)
        {
            // Verbindung mit der Datenbank herstellen
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string adressNumber = Convert.ToString(CurrentAddressId + 1);
                // SQL-Befehl definieren
                string sqlStatement = $"INSERT INTO Customers (Name, PhoneNumber, EMail, Password, AddressId) VALUES ('{@name}','{@phoneNumber}','{@eMail}','{@password}',{adressNumber})";

                // SqlCommand-Objekt erstellen und mit Verbindung und SQL-Befehl initialisieren
                using (SqlCommand command = new SqlCommand(sqlStatement, connection))
                {

                    // Ausführen des SQL-Befehls
                    command.ExecuteNonQuery();
                }
            }
        }


        public void CreateAddress(string street, string houseNumber, string zipCode)
        {
            // Verbindung mit der Datenbank herstellen
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // SQL-Befehl definieren
                string sqlStatement = $"INSERT INTO Addresses (AddressId, Street, HouseNumber, ZipCode) VALUES ((SELECT MAX(AddressId)+1 FROM Addresses),'{street}','{houseNumber}',{zipCode})";

                // SqlCommand-Objekt erstellen und mit Verbindung und SQL-Befehl initialisieren
                using (SqlCommand command = new SqlCommand(sqlStatement, connection))
                {
                    // Ausführen des SQL-Befehls
                    command.ExecuteNonQuery();
                    CurrentAddressId++;
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

        public DataTable ReturnCustomersSearch(string propertyFilter, string searchFilter)
        {
            propertyFilter = ConvertDataBindingsCustomers(propertyFilter);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = $"SELECT CustomerId as Kundennummer,Name as Name,PhoneNumber as Telefonnummer,EMail as EMail,Password as Passwort,Street as Strasse,HouseNumber as Hausnummer,Addresses.ZipCode as PLZ,Location as Ort FROM Customers LEFT JOIN Addresses ON Customers.AddressId = Addresses.AddressId LEFT JOIN AddressLocations ON Addresses.ZipCode = AddressLocations.ZipCode where {@propertyFilter} LIKE '%{@searchFilter}%'";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@propertyFilter", propertyFilter);
                    command.Parameters.AddWithValue("@searchFilter", searchFilter);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {

                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        CurrentCustomerId = Convert.ToInt32(dataTable.Rows.Count);
                        CurrentAddressId = Convert.ToInt32(dataTable.Rows.Count);
                        return dataTable;
                    }
                }
            }
        }

        public DataTable ReturnArticlesSearch(string propertyFilter, string searchFilter)
        {
            propertyFilter = ConvertDataBindingsArticles(propertyFilter);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = $"SELECT ArticleId as ArtikelId, ArticleName as Artikelname, Price as Preis,ArticleGroups.Name as Artikelgruppe FROM Articles INNER JOIN ArticleGroups ON Articles.ArticleGroupId = ArticleGroups.ArticleGroupId where {@propertyFilter} LIKE '%{@searchFilter}%'";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@propertyFilter", propertyFilter);
                    command.Parameters.AddWithValue("@searchFilter", searchFilter);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {

                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        CurrentArticleId = Convert.ToInt32(dataTable.Rows.Count);
                        return dataTable;
                    }
                }
            }
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

        public DataTable ReturnOrdersSearch(string propertyFilter, string searchFilter)
        {
            propertyFilter = ConvertDataBindingsOrders(propertyFilter);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = $"SELECT Orders.OrderId as Auftragsnummer, FORMAT(Date,'dd.MM.yyyy') as Datum, Name as Name,'XXX' as Positionen FROM Orders INNER JOIN OrderPositions ON Orders.CustomerId = Orders.CustomerId INNER JOIN Customers ON Orders.CustomerId = Customers.CustomerId where {@propertyFilter} LIKE '%{@searchFilter}%'";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@propertyFilter", propertyFilter);
                    command.Parameters.AddWithValue("@searchFilter", searchFilter);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {

                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        CurrentOrderId = Convert.ToInt32(dataTable.Rows.Count);
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
