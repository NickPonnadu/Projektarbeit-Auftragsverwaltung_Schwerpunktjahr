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

            using (var session = new CompanyContext()) { }
        }
    }
}