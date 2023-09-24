﻿namespace Projekt_Auftragsverwaltung.Entites
{
    public class CustomerJsonDto
    {
        private string _customerNr;
        public int CustomerId { get; set; }
        public string CustomerNr 
        {
            get { return _customerNr; }
            set
            {
                var validator = RegexValidationService.GetInstance();

                    if (validator.ValidateCustomerNumber(value))
                    {
                        _customerNr = value;
                    }
                    else
                    {
                        throw new InvalidDataException("Ungültige Kundennummer");
                    }
            }
        }
        public string Name { get; set; }
        public AddressJsonDto Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public string Password { get; set; }
    }

    public class AddressJsonDto
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public AddressLocationJsonDto AddressLocation { get; set; }

    }

    public class AddressLocationJsonDto
    {
        public string Location { get; set; }
        public int ZipCode { get; set; }
        
    }
}
