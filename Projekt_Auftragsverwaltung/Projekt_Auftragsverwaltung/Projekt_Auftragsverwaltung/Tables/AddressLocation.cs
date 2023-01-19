using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatenbankProjekt.Tables
{
    public class AddressLocation
    {
        public int ZipCode { get; set; }
        public string Location { get; set; }


        public int AddressId { get; set; }
        public Address Address { get; set; }

    }
}
