using Microsoft.Data.SqlClient;
using Projekt_Auftragsverwaltung.Interfaces;
using Projekt_Auftragsverwaltung.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Auftragsverwaltung.Controllers;

public class ArticleGroupController : IArticleGroupController
{
    private readonly string _connectionString;

    public ArticleGroupController(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DataTable ReturnArticleGroups()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (var dbContext = new CompanyContext(_connectionString))
            {
                var articleGroups = from a in dbContext.ArticleGroups
                    select new
                    {
                        ArtikelgruppeId = a.ArticleGroupId,
                        a.Name
                    };

                var list = articleGroups.ToList();
                var dataTable = CreateDataTable();
                foreach (var item in list) dataTable.Rows.Add(item.ArtikelgruppeId, item.Name);

                return dataTable;
            }
        }
    }

    public DataTable ReturnArticleGroupsSearch(string searchValue)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (var dbContext = new CompanyContext(_connectionString))
            {
                var articleGroups = from a in dbContext.ArticleGroups
                    select new
                    {
                        ArtikelgruppeId = a.ArticleGroupId,
                        a.Name
                    };

                articleGroups = articleGroups.Where(o => o.Name.Contains(searchValue));

                var list = articleGroups.ToList();
                var dataTable = CreateDataTable();
                foreach (var item in list) dataTable.Rows.Add(item.ArtikelgruppeId, item.Name);

                return dataTable;
            }
        }
    }

    public void CreateArticleGroup(string name)
    {
        using (var dbContext = new CompanyContext(_connectionString))
        {
            var articleGroup = new ArticleGroup { Name = name };
            dbContext.ArticleGroups.Add(articleGroup);
            dbContext.SaveChanges();
        }
    }

    public static DataTable CreateDataTable()
    {
        var dataTable = new DataTable();
        dataTable.Columns.Add("ArtikelgruppeId", typeof(int));
        dataTable.Columns.Add("Name", typeof(string));
        return dataTable;
    }

    public void DeleteArticleGroup(int ArticleGroupId)
    {
        using (var db = new CompanyContext(_connectionString))
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
                    db.ArticleGroups.Remove(recordToDelete);
                    db.SaveChanges();
                }
            }
        }
    }


    public void EditArticleGroup(int articleGroupId, string articleGroupName = "")
    {
        using (var db = new CompanyContext(_connectionString))
        {
            var recordToEdit = db.ArticleGroups.FirstOrDefault(r => r.ArticleGroupId == articleGroupId);
            if (recordToEdit != null)
            {
                recordToEdit.Name = articleGroupName;
                db.ArticleGroups.Update(recordToEdit);
                db.SaveChanges();
            }
        }
    }

    public ArticleGroup GetSingleArticleGroup(int articleGroupId)
    {
        using (var db = new CompanyContext(_connectionString))
        {
            var recordToReturn = db.ArticleGroups.FirstOrDefault(r => r.ArticleGroupId == articleGroupId);

            return recordToReturn;
        }
    }
}