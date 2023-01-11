using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Auftragsverwaltung
{
    public class ConnectionStrings 
    {
        public string server { get; set; }
        public string database { get; set; }  = "your_database";
        public string username { get; set; }  = "your_username";
        public string password { get; set; }  = "your_password";

        private StringBuilder connectionStringBuilder = new StringBuilder();

        public ConnectionStrings(StringBuilder connectionString)
        {
            connectionString.Append("Server=" + server + ";");
            connectionString.Append("Database=" + database + ";");
            connectionString.Append("User=" + username + ";");
            connectionString.Append("Password=" + password + ";");

            connectionString.AppendFormat("Server={0};Database={1};User={2};Password={3};", server, database, username, password);

            string realConnectionString = connectionString.ToString();
        }



    }
}
