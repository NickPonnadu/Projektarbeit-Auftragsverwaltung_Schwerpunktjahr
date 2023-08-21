using Projekt_Auftragsverwaltung.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Auftragsverwaltung.Interfaces
{
    public interface IAddressController
    {
        Address CreateAddress(string street, string houseNumber, string zipCode);
        void DeleteAddress(int addressId);
        void EditAddress(int addressId, string street = "", string houseNumber = "", int postCode = 0000);
        object GetSingleAddress(int addressId);
    }

}
