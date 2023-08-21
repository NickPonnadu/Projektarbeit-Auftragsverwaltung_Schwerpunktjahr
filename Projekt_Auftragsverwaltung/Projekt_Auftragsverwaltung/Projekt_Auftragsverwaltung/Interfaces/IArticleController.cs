using Projekt_Auftragsverwaltung.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Auftragsverwaltung.Interfaces
{
    public interface IArticleController
    {
        DataTable ReturnArticles();
        DataTable ReturnArticlesSearch(string columnName, string filterValue);
        void CreateArticle(string name, decimal price, int articleGroupId);
        void DeleteArticle(int articleId);
        void EditArticle(int articleId, string articleName = "", decimal articlePrice = 0, int articleGroupId = 0);
        Article GetSingleArticle(int articleId);
    }
}
