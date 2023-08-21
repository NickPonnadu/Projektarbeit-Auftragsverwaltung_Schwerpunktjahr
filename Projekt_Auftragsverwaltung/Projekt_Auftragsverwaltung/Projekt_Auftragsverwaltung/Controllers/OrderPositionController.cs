using Microsoft.Data.SqlClient;
using Projekt_Auftragsverwaltung.Tables;
using System.Data;

namespace Projekt_Auftragsverwaltung.Controllers;

public class OrderPositionController : IOrderPositionController
{
    private readonly string _connectionString;

    public OrderPositionController(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DataTable ReturnOrderPositions()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (var dbContext = new CompanyContext(_connectionString))
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
                        Auftragsnummer = o.OrderId == 0 ? 0 : o.OrderId,
                        Auftragsdatum = o.Date == null ? "" : o.Date.ToString("dd.MM.yyyy"),
                        Kunde = c.Name == null ? "" : c.Name,
                        Artikelbezeichnung = a.ArticleName == null ? "" : a.ArticleName,
                        Artikelanzahl = op.amount == 0 ? 0 : op.amount,
                        Artikelbetrag = a.Price == 0 ? 0 : a.Price,
                        Totalbetrag = (op.amount == 0 ? 0 : op.amount) * (a.Price == 0 ? 0 : a.Price)
                    };

                var list = orderPositions.ToList();
                var dataTable = CreateDataTable();
                foreach (var orderPosition in list)
                    dataTable.Rows.Add(orderPosition.Positionsnummer, orderPosition.Auftragsnummer,
                        orderPosition.Auftragsdatum, orderPosition.Kunde, orderPosition.Artikelbezeichnung,
                        orderPosition.Artikelanzahl, orderPosition.Artikelbetrag.ToString("F2"),
                        orderPosition.Totalbetrag.ToString("F2"));
                return dataTable;
            }
        }
    }

    public DataTable ReturnOrderPositionsSearch(string columnName, string searchValue)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (var dbContext = new CompanyContext(_connectionString))
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
                        Positionsnummer = op.OrderPositionId == 0 ? 0 : op.OrderPositionId,
                        Auftragsnummer = o.OrderId == 0 ? 0 : o.OrderId,
                        Auftragsdatum = o.Date == null ? "" : o.Date.ToString("dd.MM.yyyy"),
                        Kunde = c.Name == null ? "" : c.Name,
                        Artikelbezeichnung = a.ArticleName == null ? "" : a.ArticleName,
                        Artikelanzahl = op.amount == 0 ? 0 : op.amount,
                        Artikelbetrag = a.Price == 0 ? 0 : a.Price,
                        Totalbetrag = (op.amount == 0 ? 0 : op.amount) * (a.Price == 0 ? 0 : a.Price)
                    };

                switch (columnName)
                {
                    case "Positionsnummer":
                        orderPositionsQuery =
                            orderPositionsQuery.Where(op => op.Positionsnummer.ToString().Contains(searchValue));
                        break;
                    case "Auftragsnummer":
                        orderPositionsQuery =
                            orderPositionsQuery.Where(op => op.Auftragsnummer.ToString().Contains(searchValue));
                        break;

                    case "Kunde":
                        orderPositionsQuery = orderPositionsQuery.Where(op => op.Kunde.Contains(searchValue));
                        break;
                    case "Artikelbezeichnung":
                        orderPositionsQuery =
                            orderPositionsQuery.Where(op => op.Artikelbezeichnung.Contains(searchValue));
                        break;
                    case "Artikelanzahl":
                        int intValue;
                        if (int.TryParse(searchValue, out intValue))
                            orderPositionsQuery = orderPositionsQuery.Where(op => op.Artikelanzahl.Equals(intValue));
                        break;
                    case "Artikelbetrag":
                        decimal decimalValue;
                        if (decimal.TryParse(searchValue, out decimalValue))
                            orderPositionsQuery =
                                orderPositionsQuery.Where(op => op.Artikelbetrag.Equals(decimalValue));
                        break;
                    case "Totalbetrag":
                        decimal decimalValue1;
                        if (decimal.TryParse(searchValue, out decimalValue1))
                            orderPositionsQuery = orderPositionsQuery.Where(op => op.Totalbetrag.Equals(decimalValue1));
                        break;
                }


                var list = orderPositionsQuery.ToList();

                var dataTable = CreateDataTable();
                foreach (var orderPosition in list)
                    dataTable.Rows.Add(orderPosition.Positionsnummer, orderPosition.Auftragsnummer,
                        orderPosition.Auftragsdatum, orderPosition.Kunde, orderPosition.Artikelbezeichnung,
                        orderPosition.Artikelanzahl, orderPosition.Artikelbetrag.ToString("F2"),
                        orderPosition.Totalbetrag.ToString("F2"));
                return dataTable;
            }
        }
    }

    public void CreateOrderPosition(int amount, int orderId, int articleId)
    {
        using (var dbContext = new CompanyContext(_connectionString))
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

    public static DataTable CreateDataTable()
    {
        var dataTable = new DataTable();
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

    public void DeleteOrderPosition(int orderPositionId)
    {
        using (var db = new CompanyContext(_connectionString))
        {
            var recordToDelete = db.OrderPositions.FirstOrDefault(r => r.OrderPositionId == orderPositionId);

            var articlePositionId = recordToDelete.OrderPositionId;

            if (recordToDelete != null)
            {
                db.OrderPositions.Remove(recordToDelete); // Den Datensatz aus der Datenbank entfernen
                db.SaveChanges(); // Änderungen speichern
            }
        }
    }

    public void EditOrderPosition(int orderPositionId, int amount, int orderId)
    {
        using (var db = new CompanyContext(_connectionString))
        {
            var recordToEdit = db.OrderPositions.FirstOrDefault(r => r.OrderPositionId == orderPositionId);
            if (recordToEdit != null)
            {
                recordToEdit.amount = amount;
                recordToEdit.OrderId = orderId;
                db.OrderPositions.Update(recordToEdit);
                db.SaveChanges();
            }
        }
    }

    public OrderPosition GetSingleOrderPosition(int orderPositionId)
    {
        using (var db = new CompanyContext(_connectionString))
        {
            var recordToReturn = db.OrderPositions.FirstOrDefault(r => r.OrderPositionId == orderPositionId);
            return recordToReturn;
        }
    }
}