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
            _ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_ConnectionString);
            // optionsBuilder.UseSqlServer("Server=DESKTOP-G8PTADT\MSSQLSERVERZBWGA; Database=myDataBase; Trusted_Connection=True;Encrypt=false;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressLocation>()
                .HasKey(b => b.ZipCode);


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


            modelBuilder.Entity<Address>().HasData(
                new Address { AddressId = 1, Street = "Teststraße 1", HouseNumber = "1", ZipCode = 12345 },
                new Address { AddressId = 2, Street = "Teststraße 2", HouseNumber = "2", ZipCode = 12345 },
                new Address { AddressId = 3, Street = "Teststraße 3", HouseNumber = "3", ZipCode = 12345 },
                new Address { AddressId = 4, Street = "Teststraße 4", HouseNumber = "4", ZipCode = 12345 },
                new Address { AddressId = 5, Street = "Teststraße 5", HouseNumber = "5", ZipCode = 12345 }
            );

            modelBuilder.Entity<AddressLocation>().HasData(
                new AddressLocation { ZipCode = 12345, Location = "Testort 1", AddressId = 1 },
                new AddressLocation { ZipCode = 123456, Location = "Testort 2", AddressId = 2 },
                new AddressLocation { ZipCode = 123457, Location = "Testort 3", AddressId = 3 },
                new AddressLocation { ZipCode = 123458, Location = "Testort 4", AddressId = 4 },
                new AddressLocation { ZipCode = 123459, Location = "Testort 5", AddressId = 5 }
            );


            modelBuilder.Entity<Article>().HasData(
                new Article { ArticleId = 1, ArticleName = "Artikel 1", Price = 10.0M, ArticleGroupId = 1 },
                new Article { ArticleId = 2, ArticleName = "Artikel 2", Price = 20.0M, ArticleGroupId = 1 },
                new Article { ArticleId = 3, ArticleName = "Artikel 3", Price = 30.0M, ArticleGroupId = 2 },
                new Article { ArticleId = 4, ArticleName = "Artikel 4", Price = 40.0M, ArticleGroupId = 2 },
                new Article { ArticleId = 5, ArticleName = "Artikel 5", Price = 50.0M, ArticleGroupId = 3 }
            );

            modelBuilder.Entity<ArticleGroup>().HasData(
                new ArticleGroup { ArticleGroupId = 1, Name = "Gruppe 1" },
                new ArticleGroup { ArticleGroupId = 2, Name = "Gruppe 2" },
                new ArticleGroup { ArticleGroupId = 3, Name = "Gruppe 3" }
            );

            modelBuilder.Entity<ArticlePosition>().HasData(
                new ArticlePosition { ArticlePositionId = 1, ArticleId = 1, OrderPositionId = 1 },
                new ArticlePosition { ArticlePositionId = 2, ArticleId = 2, OrderPositionId = 2 },
                new ArticlePosition { ArticlePositionId = 3, ArticleId = 3, OrderPositionId = 3 },
                new ArticlePosition { ArticlePositionId = 4, ArticleId = 4, OrderPositionId = 4 },
                new ArticlePosition { ArticlePositionId = 5, ArticleId = 5, OrderPositionId = 5 }
            );

            modelBuilder.Entity<Customer>().HasData(
                 new Customer { CustomerId = 1, Name = "Test Kunde 1", PhoneNumber = "0123456789", EMail = "test1@test.com", Password = "pass1", AddressId = 1 },
                 new Customer { CustomerId = 2, Name = "Test Kunde 2", PhoneNumber = "9876543210", EMail = "test2@test.com", Password = "pass2", AddressId = 2 },
                 new Customer { CustomerId = 3, Name = "Test Kunde 3", PhoneNumber = "1234567890", EMail = "test3@test.com", Password = "pass3", AddressId = 3 },
                 new Customer { CustomerId = 4, Name = "Test Kunde 4", PhoneNumber = "0987654321", EMail = "test4@test.com", Password = "pass4", AddressId = 4 },
                 new Customer { CustomerId = 5, Name = "Test Kunde 5", PhoneNumber = "1023456789", EMail = "test5@test.com", Password = "pass5", AddressId = 5 }
             );

            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, CustomerId = 1, Date = new DateTime(2022, 10, 10) },
                new Order { OrderId = 2, CustomerId = 2, Date = new DateTime(2022, 11, 11) },
                new Order { OrderId = 3, CustomerId = 3, Date = new DateTime(2022, 12, 12) },
                new Order { OrderId = 4, CustomerId = 4, Date = new DateTime(2023, 1, 1) },
                new Order { OrderId = 5, CustomerId = 5, Date = new DateTime(2023, 2, 2) }
            );

            modelBuilder.Entity<OrderPosition>().HasData(
                new OrderPosition { OrderPositionId = 1, amount = 5, OrderId = 1 },
                new OrderPosition { OrderPositionId = 2, amount = 10, OrderId = 2 },
                new OrderPosition { OrderPositionId = 3, amount = 3, OrderId = 3 },
                new OrderPosition { OrderPositionId = 4, amount = 8, OrderId = 4 },
                new OrderPosition { OrderPositionId = 5, amount = 15, OrderId = 5 }
                );
        }
    }
}
