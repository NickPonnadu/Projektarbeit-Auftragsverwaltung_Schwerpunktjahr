using System.ComponentModel.DataAnnotations;

namespace Projekt_Auftragsverwaltung.Tables;

public class AddressLocation
{
    [Key] public int ZipCode { get; set; }
    public string Location { get; set; }
    public List<Address> Addresses { get; set; }
}