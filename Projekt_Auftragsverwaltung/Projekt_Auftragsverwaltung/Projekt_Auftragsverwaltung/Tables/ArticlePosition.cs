using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatenbankProjekt.Tables
{
    public class ArticlePosition
    {
        public int OrderPositionId { get; set; }
        public OrderPosition OrderPosition { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

    }
}
