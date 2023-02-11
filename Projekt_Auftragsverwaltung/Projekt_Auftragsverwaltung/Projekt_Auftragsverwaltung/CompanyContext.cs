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
        public DbSet<ArticleGroup> ArticleGroups { get; set; }
        public DbSet<ArticlePosition> ArticlePositions { get; set; }


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
            //1:n Beziehung zwischen Address und AddressLocation
            modelBuilder.Entity<AddressLocation>()
                .HasOne(at => at.Address)
                .WithMany(a => a.AddressLocations)
                .HasForeignKey(at => at.AddressId);

            //1:1 Beziehung zwischen Customer und Address
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Address)
                .WithOne(a => a.Customer)
                .HasForeignKey<Address>(a => a.AddressId);

            //1:n Beziehung zwischen Customer und Order
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            //1:n Beziehung zwischen Order und OrderPosition
            modelBuilder.Entity<OrderPosition>()
               .HasOne(op => op.Order)
               .WithMany(o => o.OrderPositions)
               .HasForeignKey(op => op.OrderId);

            //n:m Beziehung zweischen OrderPosition und Article
            modelBuilder.Entity<ArticlePosition>()
                .HasKey(sc => new { sc.OrderPositionId, sc.ArticleId });

            modelBuilder.Entity<ArticlePosition>()
                .HasOne(sc => sc.OrderPosition)
                .WithMany(s => s.Articles)
                .HasForeignKey(sc => sc.OrderPositionId);

            modelBuilder.Entity<ArticlePosition>()
                .HasOne(sc => sc.Article)
                .WithMany(c => c.OrderPositions)
                .HasForeignKey(sc => sc.ArticleId);


            //1:n Beziehung zwischen ArticleGroup und Article
            modelBuilder.Entity<Article>()
                .HasOne(a => a.ArticleGroup)
                .WithMany(ag => ag.Articles)
                .HasForeignKey(a => a.ArticleGroupId);
        }
    }
}
