
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Auftragsverwaltung.Tables
{
    public class ArticleGroup
    {
        public int ArticleGroupId { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public List<Article> Articles { get; set; }
    }
}
