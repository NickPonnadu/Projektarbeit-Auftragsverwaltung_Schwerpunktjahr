using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Projekt_Auftragsverwaltung.Tables;
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
        public DbSet<ArticleGroup> ArticleGroups { get; set; }


        private string _ConnectionString;

        public CompanyContext(string connectionString)
        {
            _ConnectionString= connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_ConnectionString);
            // optionsBuilder.UseSqlServer("Server=DESKTOP-G8PTADT\MSSQLSERVERZBWGA; Database=myDataBase; Trusted_Connection=True;Encrypt=false;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressLocation>()
                .HasKey(e => e.ZipCode);
        }
    }
}
