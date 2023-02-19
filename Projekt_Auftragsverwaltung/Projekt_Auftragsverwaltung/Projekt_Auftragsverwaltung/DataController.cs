using Microsoft.Data.SqlClient;
using Projekt_Auftragsverwaltung.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                string query = "SELECT CustomerId as Kundennummer,Name as Name,PhoneNumber as Telefonnummer,EMail as EMail,Password as Passwort,Street as Strasse,HouseNumber as Hausnummer,Addresses.ZipCode as PLZ,Location as Ort FROM[poapsdoapsodasd].[dbo].[Customers] INNER JOIN Addresses ON Customers.AddressId = Addresses.AddressId INNER JOIN AddressLocations ON Addresses.ZipCode = AddressLocations.ZipCode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        CurrentCustomerId = dataTable.Rows.Count;

                        CurrentAddressId = dataTable.Rows.Count;
                        return dataTable;
                    }
                }
            }
        }
        public DataTable ReturnArticles()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT ArticleId as ArtikelId, ArticleName as Artikelname, Price as Preis,ArticleGroups.Name as Artikelgruppe FROM Articles INNER JOIN ArticleGroups ON Articles.ArticleGroupId = ArticleGroups.ArticleGroupId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        CurrentArticleId = dataTable.Rows.Count;
                        return dataTable;
                    }
                }


            }
        }
        //public DataTable ReturnArticleGroups()
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        connection.Open();
        //        string query = "SELECT * FROM ArticleGroups";
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
        //            {
        //                DataTable dataTable = new DataTable();
        //                adapter.Fill(dataTable);
        //                return dataTable;
        //            }
        //        }
        //    }
        //}
        public DataTable ReturnOrders()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT Orders.OrderId as Auftragsnummer, FORMAT(Date,'dd.MM.yyyy') as Datum, Name as Name,'XXX' as Positionen FROM Orders INNER JOIN OrderPositions ON Orders.CustomerId = Orders.CustomerId INNER JOIN Customers ON Orders.CustomerId = Customers.CustomerId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        CurrentOrderId = dataTable.Rows.Count;
                        return dataTable;
                    }
                }
            }
        }

        public DataTable ReturnOrderPositions()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT OrderPositionId as Positionsnummer,CustomerId as Kundennummer,amount as Betrag, FORMAT(date,'dd.MM.yyyy') as Datum, Orders.OrderId as Auftragsnummer FROM OrderPositions INNER JOIN Orders ON OrderPositions.OrderPositionId = Orders.OrderId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        CurrentOrderPositionId = dataTable.Rows.Count;
                        return dataTable;
                    }
                }
            }
        }

        public void CreateCustomer()
        {
            // Verbindung mit der Datenbank herstellen
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // SQL-Befehl definieren
                string sqlStatement = "INSERT INTO Customers (Column1, Column2, Column3) VALUES (@value1, @value2, @value3)";

                // SqlCommand-Objekt erstellen und mit Verbindung und SQL-Befehl initialisieren
                using (SqlCommand command = new SqlCommand(sqlStatement, connection))
                {
                    // Werte der Textboxen als Parameter definieren
                    command.Parameters.AddWithValue("@Kundennummer", "YourValue1");
                    command.Parameters.AddWithValue("@value2", "YourValue2");
                    command.Parameters.AddWithValue("@value3", "YourValue3");

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
                string query = $"SELECT CustomerId as Kundennummer,Name as Name,PhoneNumber as Telefonnummer,EMail as EMail,Password as Passwort,Street as Strasse,HouseNumber as Hausnummer,Addresses.ZipCode as PLZ,Location as Ort FROM[poapsdoapsodasd].[dbo].[Customers] INNER JOIN Addresses ON Customers.AddressId = Addresses.AddressId INNER JOIN AddressLocations ON Addresses.ZipCode = AddressLocations.ZipCode where {@propertyFilter} LIKE '%{@searchFilter}%'";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@propertyFilter", propertyFilter);
                    command.Parameters.AddWithValue("@searchFilter", searchFilter);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {

                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

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
