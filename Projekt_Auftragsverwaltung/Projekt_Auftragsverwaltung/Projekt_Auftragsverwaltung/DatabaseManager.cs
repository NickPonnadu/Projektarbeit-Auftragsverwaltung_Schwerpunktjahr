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

        public static bool UseDbContext(string connectionString)
        {
            using (var context = new CompanyContext(connectionString))
            {
                try
                {
                    context.Database.EnsureCreated();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }


        public static bool CheckExistingDB(string connectionString)
        {

            using (var context = new CompanyContext(connectionString))
            {
                if (context.Database.CanConnect())
                {
                    return true;
                }
                else
                    return false;
            }
        }

    }
}
