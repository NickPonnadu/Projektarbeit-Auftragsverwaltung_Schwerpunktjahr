﻿using Projekt_Auftragsverwaltung.Tables;
using System.Data;

namespace Projekt_Auftragsverwaltung.Interfaces
{
    public interface ICustomerController
    {
        DataTable ReturnCustomers();
        DataTable ReturnCustomersSearch(string columnName, string searchValue);
        void CreateCustomer(string customerNr, string name, string phoneNumber, string eMail, string password, string website, Address address);
        void DeleteCustomer(int customerId);
        bool DeleteCustomerWithReturn(int customerId);
        void EditCustomer(string customerNr, int customerId, string name = "", string phoneNumber = "", string eMail = "", string website = "", string Password = "");
        Customer GetSingleCustomer(int customerId);
    }
}