﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatenbankProjekt.Tables
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string ArticleName { get; set; }
        public decimal price { get; set; }


        public virtual ICollection<OrderPosition> OrderPositions { get; set; }




    }
}