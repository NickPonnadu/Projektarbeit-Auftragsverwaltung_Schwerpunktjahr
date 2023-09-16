using Microsoft.Data.SqlClient;
using Projekt_Auftragsverwaltung.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Auftragsverwaltung.Controllers;

public class OrderController : IOrderController
{
    private readonly string _connectionString;

    public OrderController(string connectionString)
    {
        _connectionString = connectionString;
    }


    public DataTable ReturnOrders()
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var dbContext = new CompanyContext(_connectionString);
        var foundOrders = from o in dbContext.Orders
                          join c in dbContext.Customers on o.CustomerId equals c.CustomerId
                          join op in dbContext.OrderPositions on o.OrderId equals op.OrderId into opGroup
                          from op in opGroup.DefaultIfEmpty()
                          join ap in dbContext.ArticlePositions on op.OrderPositionId equals ap.OrderPositionId into apGroup
                          from ap in apGroup.DefaultIfEmpty()
                          join a in dbContext.Articles on ap.ArticleId equals a.ArticleId into aGroup
                          from a in aGroup.DefaultIfEmpty()
                          group new { o, op, a } by new { o.OrderId, o.Date, c.Name }
            into g
                          select new
                          {
                              Auftragsnummer = g.Key.OrderId,
                              Datum = g.Key.Date.ToString("dd.MM.yyyy") ?? "",
                              Name = g.Key.Name ?? "",
                              PositionsId = string.Join(",",
                                  g.Select(x => x.op.OrderPositionId != null ? x.op.OrderPositionId : 0).ToList()) ?? "",
                              Totalbetrag = g.Sum(x => (x.op != null ? x.op.Amount : 0) * (x.a != null ? x.a.Price : 0))
                          };
        var list = foundOrders.ToList();
        var dataTable = CreateDataTable();
        foreach (var order in list)
            dataTable.Rows.Add(order.Auftragsnummer, order.Datum, order.Name, order.PositionsId,
                order.Totalbetrag.ToString("0.00"));
        return dataTable;
    }

    public DataTable ReturnOrdersSearch(string column, string value)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var dbContext = new CompanyContext(_connectionString);
        var foundOrders = from o in dbContext.Orders
                          join c in dbContext.Customers on o.CustomerId equals c.CustomerId
                          join op in dbContext.OrderPositions on o.OrderId equals op.OrderId into opGroup
                          from op in opGroup.DefaultIfEmpty()
                          join ap in dbContext.ArticlePositions on op.OrderPositionId equals ap.OrderPositionId into apGroup
                          from ap in apGroup.DefaultIfEmpty()
                          join a in dbContext.Articles on ap.ArticleId equals a.ArticleId into aGroup
                          from a in aGroup.DefaultIfEmpty()
                          group new { o, op, a } by new { o.OrderId, o.Date, c.Name }
            into g
                          select new
                          {
                              Auftragsnummer = g.Key.OrderId,
                              Datum = g.Key.Date.ToString("dd.MM.yyyy") ?? "",
                              Name = g.Key.Name ?? "",
                              PositionsId = string.Join(",",
                                  g.Select(x => x.op.OrderPositionId != null ? x.op.OrderPositionId : 0).ToList()) ?? "",
                              Totalbetrag = g.Sum(x => (x.op != null ? x.op.Amount : 0) * (x.a != null ? x.a.Price : 0))
                          };

        switch (column)
        {
            case "Auftragsnummer":
                foundOrders = foundOrders.Where(o => o.Auftragsnummer == Convert.ToInt32(value));
                break;

            case "Name":
                foundOrders = foundOrders.Where(o => o.Name.Contains(value));
                break;
        }

            ;

        var list = foundOrders.ToList();
        var dataTable = CreateDataTable();
        foreach (var order in list)
            dataTable.Rows.Add(order.Auftragsnummer, order.Datum, order.Name, order.PositionsId,
                order.Totalbetrag.ToString("0.00"));
        return dataTable;
    }

    public void CreateOrder(DateTime date, int customerId)
    {
        using var dbContext = new CompanyContext(_connectionString);
        var order = new Order
        {
            Date = date,
            CustomerId = customerId
        };
        dbContext.Orders.Add(order);
        dbContext.SaveChanges();
    }

    public static DataTable CreateDataTable()
    {
        var dataTable = new DataTable();
        dataTable.Columns.Add("Auftragsnummer", typeof(int));
        dataTable.Columns.Add("Datum", typeof(string));
        dataTable.Columns.Add("Name", typeof(string));
        dataTable.Columns.Add("Positionen", typeof(string));
        dataTable.Columns.Add("Totalbetrag", typeof(decimal));
        return dataTable;
    }

    public void DeleteOrder(int orderId)
    {
        using var db = new CompanyContext(_connectionString);
        var recordToDelete = db.Orders.FirstOrDefault(r => r.OrderId == orderId);
        if (recordToDelete != null)
        {
            var orderPositions = db.OrderPositions.Where(op => op.OrderId == orderId).ToList();
            if (orderPositions.Count == 0)
            {
                db.Orders.Remove(recordToDelete);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show(
                    "Der Auftrag enthält noch Positionen. Lösche zuerst die Positionen, bevor du den Auftrag löschst!");
            }
        }
        else
        {
            MessageBox.Show("Kein Auftrag ausgewählt");
        }
    }

    public void EditOrder(int orderId, DateTime date, int customerId)
    {
        using var db = new CompanyContext(_connectionString);
        var recordToEdit = db.Orders.FirstOrDefault(r => r.OrderId == orderId);
        if (recordToEdit != null)
        {
            recordToEdit.Date = date;
            recordToEdit.CustomerId = customerId;
            db.Orders.Update(recordToEdit);
            db.SaveChanges();
        }
    }

    public Order GetSingleOrder(int orderId)
    {
        using var db = new CompanyContext(_connectionString);
        var recordToReturn = db.Orders.FirstOrDefault(r => r.OrderId == orderId);
        return recordToReturn;
    }
}