using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Auftragsverwaltung.Tables
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public int ZipCode { get; set; }

        public List<AddressLocation> AdressLocations { get; set; }

        public Customer Customer { get; set; }
    }
}
