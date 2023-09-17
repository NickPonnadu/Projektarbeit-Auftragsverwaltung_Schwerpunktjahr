using System.Xml.Serialization;

namespace Projekt_Auftragsverwaltung.Entites
{
    [XmlRoot("Kunden")]
    public class CustomersXmlWrapper
    {
        [XmlElement("Kunde")]
        public List<CustomerXmlDto> Customers { get; set; }

        public class CustomerXmlDto
        {
            [XmlAttribute("CustomerNr")]
            public string CustomerNr { get; set; }

            [XmlElement("Name")]
            public string Name { get; set; }

            [XmlElement("Address")]
            public AddressXmlDto Address { get; set; }

            [XmlElement("EMail")]
            public string Email { get; set; }

            [XmlElement("Website")]
            public string Website { get; set; }

            [XmlElement("Password")]
            public string Password { get; set; }
        }

        public class AddressXmlDto
        {
            [XmlElement("Street")]
            public string Street { get; set; }

            [XmlElement("PostalCode")]
            public int PostalCode { get; set; }
        }
    }
}
