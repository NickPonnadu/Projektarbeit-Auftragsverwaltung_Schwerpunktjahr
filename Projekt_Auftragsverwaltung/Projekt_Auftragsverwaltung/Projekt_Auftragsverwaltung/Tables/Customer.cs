using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Auftragsverwaltung.Tables
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public string Website { get; set; }
        public string Password { get; set; }


        public List<Order> Orders { get; set; }


        public int AddressId { get; set; }
        public Address Address { get; set; }

    }
}
