using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Projekt_Auftragsverwaltung.Tables;
using System.Configuration;
using System.DirectoryServices;

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
            optionsBuilder.UseSqlServer("Server=DESKTOP-G8PTADT\\MSSQLSERVERZBWGA; Database=myDataBase; Trusted_Connection=True;Encrypt=false;");

            // optionsBuilder.UseSqlServer("Server=DESKTOP-G8PTADT\MSSQLSERVERZBWGA; Database=myDataBase; Trusted_Connection=True;Encrypt=false;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressLocation>()
                .HasKey(e => e.ZipCode);
        

            //modelBuilder.Entity<Address>()
            //    .HasOne(a => a.Customer)
            //    .WithOne(c => c.Address)
            //    .HasForeignKey<Customer>(c => c.AddressId);

            //modelBuilder.Entity<AddressLocation>()
            //    .HasKey(al => al.ZipCode);

            //modelBuilder.Entity<AddressLocation>()
            //    .HasOne(al => al.Address)
            //    .WithMany(a => a.AdressLocations)
            //    .HasForeignKey(al => al.AddressId);

            //modelBuilder.Entity<Article>()
            //    .HasMany(a => a.OrderPositions)
            //    .WithOne(op => op.Articles)
            //    .HasForeignKey(op => op.ArticleId);

            //modelBuilder.Entity<ArticlePosition>()
            //    .HasMany(ap => ap.Articles)
            //    .WithOne(a => a.ArticlePosition)
            //    .HasForeignKey(a => a.ArticlePositionId);

            //modelBuilder.Entity<Customer>()
            //    .HasMany(c => c.Orders)
            //    .WithOne(o => o.Customers)
            //    .HasForeignKey(o => o.CustomerId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Order>()
            //    .HasMany(o => o.OrderPositions)
            //    .WithOne(op => op.Orders)
            //    .HasForeignKey(op => op.OrderId);

            //modelBuilder.Entity<OrderPosition>()
            //    .HasMany(op => op.ArticlePositions)
            //    .WithOne(a => a.OrderPosition)
            //    .HasForeignKey(a => a.OrderPositionId);
        }
    }
}
