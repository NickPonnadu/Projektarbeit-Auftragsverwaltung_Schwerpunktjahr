using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Auftragsverwaltung
{
    public class ConnectionStrings 
    {
        private string _Server;
        private string _Database;

        public StringBuilder connectionStringBuilder = new StringBuilder();

        public ConnectionStrings(string server, string database)
        {
            _Server = server;
            _Database = database;

            connectionStringBuilder.Append("Server=" + server + "; ");
            connectionStringBuilder.Append("Database=" + database + "; ");
            connectionStringBuilder.Append(" Trusted_Connection=True; Encrypt=false");
        }
    }
}
