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
        public string database { get; set; }  

        public StringBuilder connectionStringBuilder = new StringBuilder();

        public ConnectionStrings()
        {
            connectionStringBuilder.Append("Database Source=" + server + ";");
            connectionStringBuilder.Append("Database=" + database + ";");

            connectionStringBuilder.AppendFormat("Database Source={0};Database=={1}; Trusted_Connection=True;", server, database);
            // Muster String: "Data Source=.; Database=EFCoreDemo; Trusted_Connection=True"
            string realConnectionString = connectionStringBuilder.ToString();
        }
    }
}
