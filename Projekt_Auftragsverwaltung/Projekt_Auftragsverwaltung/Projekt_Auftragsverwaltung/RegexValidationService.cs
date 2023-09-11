using System.Text.RegularExpressions;

namespace Projekt_Auftragsverwaltung
{
    public class RegexValidationService
    {
        private static RegexValidationService? _instance;
        private RegexValidationService() { }

        public static RegexValidationService GetInstance()
        {
            if(_instance == null)
            {
                _instance = new RegexValidationService();
            }
            return _instance;
        }

        public bool ValidateCustomerNumber(string input)
        {
            return Validate(input, _customerIdPattern, "KundenNr");
        }

        public bool ValidateEmail(string input)
        {
            return Validate(input, _emailPattern, "E-Mail");
        }

        public bool ValidateWebsite(string input)
        {
            return Validate(input, _websitePattern, "Webseite");
        }

        public bool ValidatePassword(string input)
        {
            return Validate(input, _passwordPattern, "Passwort");
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

        private readonly string _websitePattern = @"^(https?://)?(www\.)?([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}$";
        private readonly string _passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
        private readonly string _customerIdPattern = @"^CU\d{5}$";
        private readonly string _emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    }
}
