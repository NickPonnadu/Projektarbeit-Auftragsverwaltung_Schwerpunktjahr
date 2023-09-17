using Projekt_Auftragsverwaltung.Tables;

namespace Projekt_Auftragsverwaltung.Interfaces
{
    public interface IAddressController
    {
        Address CreateAddress(string street, string houseNumber, string zipCode);
        void DeleteAddress(int addressId);
        void EditAddress(int addressId, string street = "", string houseNumber = "", int postCode = 0000);
        Address GetSingleAddress(int addressId);
    }

}
