using DatenbankProjekt.Tables;

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
        }
    }
}