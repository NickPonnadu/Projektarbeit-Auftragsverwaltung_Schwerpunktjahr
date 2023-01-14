using DatenbankProjekt.Tables;
using System.Text;

namespace Projekt_Auftragsverwaltung
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            // Erstellt eine neue Datenbank // existiert diese wird nichts gemacht
            using (var context = new CompanyContext())
            {
                context.Database.EnsureCreated();
            }

            // Muster für StringBuilder
            string server = "your_server";
            string database = "your_database";
            string username = "your_username";
            string password = "your_password";

            StringBuilder connectionStringBuilder = new StringBuilder();
            connectionStringBuilder.Append("Server=" + server + ";");
            connectionStringBuilder.Append("Database=" + database + ";");
            connectionStringBuilder.Append("User=" + username + ";");
            connectionStringBuilder.Append("Password=" + password + ";");

            string connectionString = connectionStringBuilder.ToString();

            connectionStringBuilder.AppendFormat("Server={0};Database={1};User={2};Password={3};", server, database, username, password);

      

        }
    }
}