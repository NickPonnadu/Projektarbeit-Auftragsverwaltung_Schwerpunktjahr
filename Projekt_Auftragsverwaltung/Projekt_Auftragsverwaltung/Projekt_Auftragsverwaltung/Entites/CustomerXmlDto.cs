using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Projekt_Auftragsverwaltung.Entites
{
    public class CustomerXmlDto
    {
        public int CustomerId { get; set; }
        public string CustomerNr { get; set; }
        public string Name { get; set; }
        public AddressXmlDto Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public string Password { get; set; }
    }



    public class AddressXmlDto
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public AddressLocationXmlDto AddressLocation { get; set; }
    }



    public class AddressLocationXmlDto
    {
        public string Location { get; set; }
        public int ZipCode { get; set; }
    }



}