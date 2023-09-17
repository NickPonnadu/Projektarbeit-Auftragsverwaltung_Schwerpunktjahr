using Microsoft.Data.SqlClient;
using System.Data;
using Projekt_Auftragsverwaltung.Interfaces;
using Projekt_Auftragsverwaltung.Tables;

namespace Projekt_Auftragsverwaltung.Controllers;

public class ArticleController : IArticleController
{
    private readonly string _connectionString;

    public ArticleController(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DataTable ReturnArticles()
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var dbContext = new CompanyContext(_connectionString);
        var articles = from a in dbContext.Articles
                       join ag in dbContext.ArticleGroups on a.ArticleGroupId equals ag.ArticleGroupId into agGroup
                       from ag in agGroup.DefaultIfEmpty()
                       select new
                       {
                           ArtikelId = a.ArticleId,
                           Artikelname = a.ArticleName,
                           Preis = a.Price,
                           Artikelgruppe = ag != null ? ag.Name : "keine Artikelgruppe"
                       };
        var list = articles.ToList();
        var dataTable = CreateDataTable();
        foreach (var item in list)
            dataTable.Rows.Add(item.ArtikelId, item.Artikelname, item.Preis, item.Artikelgruppe);
        return dataTable;
    }

    public DataTable ReturnArticlesSearch(string columnName, string filterValue)
    {
        using var dbContext = new CompanyContext(_connectionString);
        var articles = from a in dbContext.Articles
                       join ag in dbContext.ArticleGroups on a.ArticleGroupId equals ag.ArticleGroupId
                       select new
                       {
                           ArtikelId = a.ArticleId,
                           Artikelname = a.ArticleName,
                           Preis = a.Price,
                           Artikelgruppe = ag.Name
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
        var dataTable = CreateDataTable();
        foreach (var item in list)
            dataTable.Rows.Add(item.ArtikelId, item.Artikelname, item.Preis, item.Artikelgruppe);

        return dataTable;
    }

    public void CreateArticle(string name, decimal price, int articleGroupId)
    {
        using var dbContext = new CompanyContext(_connectionString);
        var article = new Article
        {
            ArticleName = name,
            Price = price,
            ArticleGroupId = articleGroupId
        };
        dbContext.Articles.Add(article);
        dbContext.SaveChanges();
    }

    public static DataTable CreateDataTable()
    {
        var dataTable = new DataTable();
        dataTable.Columns.Add("ArtikelId", typeof(int));
        dataTable.Columns.Add("Artikelname", typeof(string));
        dataTable.Columns.Add("Preis", typeof(decimal));
        dataTable.Columns.Add("Artikelgruppe", typeof(string));
        return dataTable;
    }

    public void DeleteArticle(int articleId)
    {
        using var db = new CompanyContext(_connectionString);
        var recordToDelete = db.Articles.FirstOrDefault(r => r.ArticleId == articleId);
        if (recordToDelete != null)
        {
            var articlePositions = db.ArticlePositions.Where(ap => ap.ArticleId == articleId).ToList();
            if (articlePositions.Any())
            {
                MessageBox.Show("Artikel ist mit Positionen verknüpft!");
            }
            else
            {
                db.Articles.Remove(recordToDelete);
                db.SaveChanges();
            }
        }
    }

    public void EditArticle(int articleId, string articleName = "", decimal articlePrice = 0, int articleGroupId = 0)
    {
        using var db = new CompanyContext(_connectionString);
        var recordToEdit = db.Articles.FirstOrDefault(r => r.ArticleId == articleId);
        if (recordToEdit != null)
        {
            recordToEdit.ArticleName = articleName;
            recordToEdit.Price = articlePrice;
            recordToEdit.ArticleGroupId = articleGroupId;
            db.Articles.Update(recordToEdit);
            db.SaveChanges();
        }
    }

    public Article GetSingleArticle(int articleId)
    {
        using var db = new CompanyContext(_connectionString);
        var recordToReturn = db.Articles.FirstOrDefault(r => r.ArticleId == articleId);
        if (recordToReturn != null)
            return recordToReturn;
        else
            return null;
    }
}