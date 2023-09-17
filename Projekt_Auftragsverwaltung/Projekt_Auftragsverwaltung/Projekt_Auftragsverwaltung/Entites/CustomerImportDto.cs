using Projekt_Auftragsverwaltung.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Auftragsverwaltung.Entites
{
    public class CustomerImportDto
    {
        public int CustomerId { get; set; }
        public string CustomerNr { get; set; }
        public string Name { get; set; }
        public AddressImportDto Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public string Password { get; set; }
    }

    public class AddressImportDto
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public AddressLocationDto AddressLocation { get; set; }

    }

    public class AddressLocationDto
    {
        public string Location { get; set; }
        public int ZipCode { get; set; }
        
    }
}
