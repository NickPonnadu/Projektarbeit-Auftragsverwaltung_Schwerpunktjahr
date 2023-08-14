using Projekt_Auftragsverwaltung.Interfaces;
using Projekt_Auftragsverwaltung.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Auftragsverwaltung.Controllers
{
    public class ArticlePositionController : IArticlePositionController
    {
        private readonly string _connectionString;

        public ArticlePositionController(string connectionString)
        {
            _connectionString = connectionString;
        }


        public void EditArticlePosition(int orderPositionId, int articleId)
        {
            using (var db = new CompanyContext(_connectionString))
            {
                var recordToEdit = db.ArticlePositions.FirstOrDefault(r => r.OrderPositionId == orderPositionId);
                if (recordToEdit != null)
                {
                    recordToEdit.OrderPositionId = orderPositionId;
                    recordToEdit.ArticleId = articleId;
                    db.ArticlePositions.Update(recordToEdit);
                    db.SaveChanges();
                }
            }
        }

        public ArticlePosition GetSingleArticlePosition(int orderPositionId, int articleId)
        {
            using (var db = new CompanyContext(_connectionString))
            {
                var recordToReturn = db.ArticlePositions.FirstOrDefault(r => r.OrderPositionId == orderPositionId && r.ArticleId == articleId);
                return recordToReturn;
            }
        }
    }
}
