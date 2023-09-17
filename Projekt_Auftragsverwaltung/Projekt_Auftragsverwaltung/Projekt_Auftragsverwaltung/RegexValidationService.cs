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
            return Validate(input, CUSTOMERNUMBER_VALIDATION_PATTER, "KundenNr");
        }

        public bool ValidateEmail(string input)
        {
            return Validate(input, EMAIL_VALIDATION_PATTER, "E-Mail");
        }

        public bool ValidateWebsite(string input)
        {
            return Validate(input, WEBSITE_VALIDATION_PATTER, "Webseite");
        }

        public bool ValidatePassword(string input)
        {
            return Validate(input, PASSWORD_VALIDATION_PATTER, "Passwort");
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

        private const string WEBSITE_VALIDATION_PATTER = @"^(https?://)?(www\.)?([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}$";
        private const string PASSWORD_VALIDATION_PATTER = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
        private const string CUSTOMERNUMBER_VALIDATION_PATTER = @"^CU\d{5}$";
        private const string EMAIL_VALIDATION_PATTER = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    }
}
