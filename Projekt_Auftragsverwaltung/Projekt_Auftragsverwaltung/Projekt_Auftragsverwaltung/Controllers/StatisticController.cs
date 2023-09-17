using Microsoft.Data.SqlClient;
using Projekt_Auftragsverwaltung.Tables;
using System.Data;
using Projekt_Auftragsverwaltung.Interfaces;

namespace Projekt_Auftragsverwaltung.Controllers;

public class StatisticController : IStatisticController
{
    public string ConnectionString;

    public StatisticController(string connectionString)
    {
        ConnectionString = connectionString;
    }


    public static DataTable CreateDataTableStatistics()
    {
        var dataTable = new DataTable();
        dataTable.Columns.Add("Kategorie", typeof(int));
        dataTable.Columns.Add("Q1", typeof(decimal));
        dataTable.Columns.Add("Q2", typeof(decimal));
        dataTable.Columns.Add("Q3", typeof(decimal));
        dataTable.Columns.Add("Q4", typeof(decimal));
        return dataTable;
    }


    public DataTable ReturnStatistic()
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var query =
            "\r\nSELECT 'Anzahl Aufträge' AS 'Kategorien', [1] AS 'Gesamt'\r\nFROM (\r\n    SELECT 1 AS [OrderId]\r\n    FROM Orders\r\n) AS o\r\nPIVOT (\r\n    COUNT(OrderId)\r\n    FOR OrderId IN ([1])\r\n) AS p \r\nUNION ALL\r\nSELECT 'Anzahl Artikel' AS 'Kategorien', [1] AS 'Gesamt'\r\nFROM (\r\n    SELECT 1 AS [ArticleId]\r\n    FROM Articles\r\n) AS a\r\nPIVOT (\r\n    COUNT(ArticleId)\r\n    FOR ArticleId IN ([1])\r\n) AS p UNION ALL  \r\n\r\nSELECT 'Gesamtumsatz' AS 'Kategorien', [1] AS 'Gesamt'\r\nFROM (\r\n    SELECT Orders.OrderId, SUM(OrderPositions.Amount * Articles.Price) OVER () AS [Umsatz]\r\n    FROM Articles\r\n    INNER JOIN ArticlePositions ON ArticlePositions.ArticleId = Articles.ArticleId\r\n    INNER JOIN OrderPositions ON OrderPositions.OrderPositionId = ArticlePositions.OrderPositionId\r\n    INNER JOIN Orders ON Orders.OrderId = OrderPositions.OrderId\r\n    INNER JOIN Customers ON Customers.CustomerId = Orders.CustomerId\r\n) AS a\r\nPIVOT (\r\n    AVG(Umsatz)\r\n    FOR OrderId IN ([1])\r\n) AS p \r\nUNION ALL\r\n\r\nSELECT 'Durchschnittliche Anzahl Artikel pro Auftrag' AS 'Kategorien', [1] AS 'Gesamt'\r\nFROM (\r\n    SELECT DISTINCT Orders.OrderId, AVG(OrderPositions.amount) OVER() AS cnt\r\n    FROM Articles\r\n    INNER JOIN ArticlePositions ON ArticlePositions.ArticleId = Articles.ArticleId\r\n    INNER JOIN OrderPositions ON OrderPositions.OrderPositionId = ArticlePositions.OrderPositionId\r\n    INNER JOIN Orders ON Orders.OrderId = OrderPositions.OrderId\r\n) AS t\r\nPIVOT (\r\n    AVG(cnt)\r\n    FOR OrderId IN ([1])\r\n) AS p UNION ALL \r\n\r\nSELECT 'Umsatz pro Kunde' AS 'Kategorien', AVG(Average) AS 'Gesamt'\r\nFROM (\r\n    SELECT ISNULL(SUM(OrderPositions.Amount * Articles.Price), 0) / (SELECT COUNT(Customers.CustomerId) from Customers) AS Average\r\n    FROM Customers\r\n    LEFT JOIN Orders ON Orders.CustomerId = Customers.CustomerId\r\n    LEFT JOIN OrderPositions ON OrderPositions.OrderId = Orders.OrderId\r\n    LEFT JOIN ArticlePositions ON ArticlePositions.OrderPositionId = OrderPositions.OrderPositionId\r\n    LEFT JOIN Articles ON Articles.ArticleId = ArticlePositions.ArticleId\r\n\r\n) AS a\r\n";

        using var command = new SqlCommand(query, connection);
        DataTable data = new();
        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
        {
            adapter.Fill(data);
        }

        return data;
    }

    public DataTable GetDataTableTreeView()
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var query = "WITH CTE_ArticleGroups (ArticleGroupId, Name, ParentId, Level) AS " +
                    "(SELECT ArticleGroupId, Name, ParentId, 0 AS Level FROM dbo.ArticleGroups " +
                    "WHERE ParentId IS NULL " +
                    "UNION ALL " +
                    "SELECT ag.ArticleGroupId, ag.Name, ag.ParentId, ag.Level + 1 " +
                    "FROM dbo.ArticleGroups AS ag " +
                    "INNER JOIN CTE_ArticleGroups AS p " +
                    "ON ag.ParentId = p.ArticleGroupId) " +
                    "SELECT ArticleGroupId, Name, ParentId, Level " +
                    "FROM CTE_ArticleGroups " +
                    "ORDER BY ArticleGroupId;";

        var command = new SqlCommand(query, connection);
        var adapter = new SqlDataAdapter(command);
        var table = new DataTable();
        adapter.Fill(table);
        return table;
    }
}