using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatenbankProjekt.Tables
{
    public class OrderPosition
    {
        public int OrderPositionId { get; set; }
        public int amount { get; set; }


        public int OrderId { get; set; }
        public Order Orders { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
