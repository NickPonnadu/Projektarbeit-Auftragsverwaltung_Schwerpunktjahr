using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Projekt_Auftragsverwaltung
{   
    public class DatabaseManager
    {   
        public static string BuildConnectionString(string serverName, string databaseName)
        {
            return $"Server={serverName}; Database={databaseName}; Trusted_Connection=True; Encrypt=false";
        }

        public static void UseDbContext(string connectionString)
        {
            using (var context = new CompanyContext(connectionString))
            {
                context.Database.EnsureCreated(); 
            }
        }
    }
}
