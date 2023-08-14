using Projekt_Auftragsverwaltung.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Auftragsverwaltung.Interfaces
{
    public interface IArticlePositionController
    {
        void EditArticlePosition(int orderPositionId, int articleId);
        ArticlePosition GetSingleArticlePosition(int orderPositionId, int articleId);
    }

}
