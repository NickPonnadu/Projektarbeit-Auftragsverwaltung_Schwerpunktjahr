﻿using Projekt_Auftragsverwaltung.Interfaces;
using System.Text;
using System.Text.RegularExpressions;

namespace Projekt_Auftragsverwaltung.Service
{
    public class RegexValidationService : IRegexValidationService
    {
       public RegexValidationService() { }

        
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
                var stringBuilder = new StringBuilder();
                var text = $"Bitte geben Sie einen gültigen Wert für {valueName} ein.";
                stringBuilder.Append(text);

                switch (valueName)
                {
                    case "KundenNr":
                        stringBuilder.Append(Environment.NewLine);
                        stringBuilder.Append("Format: CUXXXXX");
                        break;
                    case "Passwort":
                        stringBuilder.Append(Environment.NewLine);
                        stringBuilder.Append("Mind. 8 Zeichen, ein Grossbuchstabe & eine Zahl");
                        break;
                }
                
                MessageBox.Show(stringBuilder.ToString());
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
