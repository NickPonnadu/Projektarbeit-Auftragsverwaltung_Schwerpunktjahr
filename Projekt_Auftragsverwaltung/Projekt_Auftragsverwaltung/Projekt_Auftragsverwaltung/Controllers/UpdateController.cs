using Microsoft.EntityFrameworkCore;
using Projekt_Auftragsverwaltung.Interfaces;
using Projekt_Auftragsverwaltung.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Auftragsverwaltung.Controllers
{
    public class UpdateController : IUpdateController
    {
        private readonly string _connectionString;

        public UpdateController(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Customer> GetCustomers()
        {
            using var db = new CompanyContext(_connectionString);
            return db.Customers.Include(c => c.Address).ToList();
        }


    }
}
