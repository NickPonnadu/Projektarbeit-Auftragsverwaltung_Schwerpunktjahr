using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Auftragsverwaltung.Entites
{
    public class CustomerImportDto
    {
        public string CustomerNr { get; set; }
        public string Name { get; set; }
        public AddressImportDto Address { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Password { get; set; }
    }

    public class AddressImportDto
    {
        public string Street { get; set; }
        public int PostalCode { get; set; }
    }
}
