using System.Text.RegularExpressions;

namespace Projekt_Auftragsverwaltung
{
    public class RegexValidationService
    {
        private static RegexValidationService? _instance;
        private RegexValidationService() { }

        public static RegexValidationService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RegexValidationService();
            }
            return _instance;
        }

        public bool ValidateCustomerNumber(string input)
        {
            return Validate(input, CUSTOMERNUMBER_VALIDATION_PATTERN, "KundenNr");
        }

        public bool ValidateEmail(string input)
        {
            return Validate(input, EMAIL_VALIDATION_PATTERN, "E-Mail");
        }

        public bool ValidateWebsite(string input)
        {
            return Validate(input, WEBSITE_VALIDATION_PATTERN, "Webseite");
        }

        public bool ValidatePassword(string input)
        {
            return Validate(input, PASSWORD_VALIDATION_PATTERN, "Passwort");
        }

        public bool ValidateZipCode(string input) 
        {
            return Validate(input, ZIPCODE_VALIDATION_PATTERN, "Postleitzahl");
        }
        public bool ValidatePhoneNumber(string input)
        {
            return Validate(input, PHONENUMBER_VALIDATION_PATTERN, "Telefonnummer");
        }

        private bool Validate(string input, string pattern, string valueName)
        {
            if (string.IsNullOrEmpty(input) || !Regex.IsMatch(input, pattern))
            {
                MessageBox.Show($"Bitte geben Sie einen gültigen Wert für {valueName} ein.");
                return false;
            }
            return true;
        }

        private const string CUSTOMERNUMBER_VALIDATION_PATTERN = @"^CU\d{5}$";
        private const string EMAIL_VALIDATION_PATTERN = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        private const string WEBSITE_VALIDATION_PATTERN = @"^(https?://)?(www\.)?([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}$";
        private const string PASSWORD_VALIDATION_PATTERN = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
        private const string ZIPCODE_VALIDATION_PATTERN = @"^\d{1,8}$";
        private const string PHONENUMBER_VALIDATION_PATTERN = @"^\+*\d+(\ ?\d+){8}";

    }
}
