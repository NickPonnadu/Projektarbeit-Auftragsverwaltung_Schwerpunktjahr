namespace Projekt_Auftragsverwaltung.Tables;

public class Address
{
    public int AddressId { get; set; }
    public string Street { get; set; }
    public string HouseNumber { get; set; }
    public int ZipCode { get; set; }
    public AddressLocation AddressLocation { get; set; }
    public Customer Customer { get; set; }

   
}