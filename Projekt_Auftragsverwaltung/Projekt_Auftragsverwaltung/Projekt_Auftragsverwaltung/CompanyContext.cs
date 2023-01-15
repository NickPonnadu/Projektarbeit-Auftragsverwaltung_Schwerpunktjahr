using DatenbankProjekt.Tables;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Projekt_Auftragsverwaltung
{
    public class CompanyContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressLocation> AddressLocations { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderPosition> OrderPositions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ArticlePosition> ArticlePositions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // zieht von der App.config Datei den connectionString
            string connectionString = ConfigurationManager.ConnectionStrings["GaborNeueString"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);

            // optionsBuilder.UseSqlServer("Data Source=DESKTOP-8S98QH8\\ZBWSERVER;Database=EfCoreDemo;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
