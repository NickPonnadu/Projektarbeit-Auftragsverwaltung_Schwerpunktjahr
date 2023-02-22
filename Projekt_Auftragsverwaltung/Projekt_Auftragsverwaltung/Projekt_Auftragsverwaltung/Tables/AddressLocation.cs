using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Auftragsverwaltung.Tables
{
    public class AddressLocation
    {
        [Key]
        public int ZipCode { get; set; }
        public string Location { get; set; }

        public List<Address> Addresses { get; set; }

    }
}
