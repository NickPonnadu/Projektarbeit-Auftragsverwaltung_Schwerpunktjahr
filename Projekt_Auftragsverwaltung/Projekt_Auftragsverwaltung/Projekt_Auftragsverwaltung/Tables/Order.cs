﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Auftragsverwaltung.Tables
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }


        public int CustomerId { get; set; }
        public Customer Customer { get; set; }


        public List<OrderPosition> OrderPositions { get; set; }

    }
}
