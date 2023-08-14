using Projekt_Auftragsverwaltung.Tables;

namespace Projekt_Auftragsverwaltung.Controllers
{
    public interface IAddressLocationController
    {
        void CreateAddressLocation(string zipCode, string location);
        void EditAddressLocation(int zipCode, string location = "");
        AddressLocation GetSingleAddressLocation(int zipcode);
    }
}