using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Auftragsverwaltung.Interfaces
{
    public interface IRegexValidationService
    {
        bool ValidateCustomerNumber(string input);
        bool ValidateEmail(string input);
        bool ValidateWebsite(string input);
        bool ValidatePassword(string input);
    }
}
