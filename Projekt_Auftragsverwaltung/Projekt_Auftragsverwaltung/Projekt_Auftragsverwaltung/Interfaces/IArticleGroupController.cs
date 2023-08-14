using System.Data;
using Projekt_Auftragsverwaltung.Tables;

namespace Projekt_Auftragsverwaltung.Interfaces
{
    public interface IArticleGroupController
    {
        DataTable ReturnArticleGroups();
        DataTable ReturnArticleGroupsSearch(string searchValue);
        void CreateArticleGroup(string name);
        void DeleteArticleGroup(int ArticleGroupId);
        void EditArticleGroup(int articleGroupId, string articleGroupName = "");
        ArticleGroup GetSingleArticleGroup(int articleGroupId);
    }
}