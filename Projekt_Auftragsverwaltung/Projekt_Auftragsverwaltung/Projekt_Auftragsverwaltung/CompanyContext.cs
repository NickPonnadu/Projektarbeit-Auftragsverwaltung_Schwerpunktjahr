using Microsoft.EntityFrameworkCore;
using Projekt_Auftragsverwaltung.Tables;

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

        public string _connectionString;

        public CompanyContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CompanyContext(){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasKey(b => b.AddressId);

            modelBuilder.Entity<AddressLocation>(entity => { entity.ToTable(tb => tb.IsTemporal()); });

            modelBuilder.Entity<AddressLocation>().HasKey(b => b.ZipCode);

            modelBuilder.Entity<AddressLocation>()
               .Property(b => b.ZipCode)
               .ValueGeneratedNever();

            modelBuilder.Entity<Article>(entity => { entity.ToTable(tb => tb.IsTemporal()); });

            modelBuilder.Entity<Article>()
                .HasKey(b => b.ArticleId);
            modelBuilder.Entity<ArticleGroup>(entity => { entity.ToTable(tb => tb.IsTemporal()); });

            modelBuilder.Entity<ArticleGroup>()
                .HasKey(b => b.ArticleGroupId);

            modelBuilder.Entity<ArticlePosition>(entity => { entity.ToTable(tb => tb.IsTemporal()); });

            modelBuilder.Entity<ArticlePosition>()
                .HasKey(b => b.ArticlePositionId);

            modelBuilder.Entity<Customer>(entity => { entity.ToTable(tb => tb.IsTemporal()); });

            modelBuilder.Entity<Customer>()
                .HasKey(b => b.CustomerId);

            modelBuilder.Entity<Order>(entity => { entity.ToTable(tb => tb.IsTemporal()); });

            modelBuilder.Entity<Order>()
               .HasKey(b => b.OrderId);

            modelBuilder.Entity<OrderPosition>(entity => { entity.ToTable(tb => tb.IsTemporal()); });

            modelBuilder.Entity<OrderPosition>()
               .HasKey(b => b.OrderPositionId);


            modelBuilder.Entity<Address>()
               .HasOne(a => a.AddressLocation)
               .WithMany(al => al.Addresses)
               .HasForeignKey(a => a.ZipCode);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Address)
                .WithOne(a => a.Customer);

            modelBuilder.Entity<Article>()
                .HasOne(a => a.ArticleGroup)
                .WithMany(ag => ag.Articles)
                .HasForeignKey(a => a.ArticleGroupId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<OrderPosition>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderPositions)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<ArticlePosition>()
                .HasOne(ap => ap.OrderPosition)
                .WithMany(op => op.Articles)
                .HasForeignKey(ap => ap.OrderPositionId);

            modelBuilder.Entity<ArticlePosition>()
               .HasOne(ap => ap.Article)
               .WithMany(a => a.OrderPositions)
               .HasForeignKey(ap => ap.ArticleId);


            // Testdaten
            modelBuilder.Entity<AddressLocation>().HasData(
               new AddressLocation { ZipCode = 9000, Location = "St. Gallen" },
               new AddressLocation { ZipCode = 9426, Location = "Lutzenberg" },
               new AddressLocation { ZipCode = 9424, Location = "Rheineck" },
               new AddressLocation { ZipCode = 9001, Location = "St. Gallen" },
               new AddressLocation { ZipCode = 8000, Location = "Zürich" }
           );


            modelBuilder.Entity<Address>().HasData(
                new Address { AddressId = 1, Street = "Oberer Graben", HouseNumber = "42", ZipCode = 9000 },
                new Address { AddressId = 2, Street = "Vorderbrenden", HouseNumber = "6", ZipCode = 9426 },
                new Address { AddressId = 3, Street = "Teufener Strasse", HouseNumber = "36", ZipCode = 9001 },
                new Address { AddressId = 4, Street = "Seeblickstrasse", HouseNumber = "4", ZipCode = 9424 },
                new Address { AddressId = 5, Street = "Bahnhofsstrasse", HouseNumber = "12", ZipCode = 8000 }
            );


            modelBuilder.Entity<Article>().HasData(
                new Article { ArticleId = 1, ArticleName = "Handschuhe", Price = 10.0M, ArticleGroupId = 1 },
                new Article { ArticleId = 2, ArticleName = "Schwamm", Price = 20.0M, ArticleGroupId = 2 },
                new Article { ArticleId = 3, ArticleName = "Besen", Price = 30.0M, ArticleGroupId = 2 },
                new Article { ArticleId = 4, ArticleName = "Hüpfburg", Price = 40.0M, ArticleGroupId = 3 },
                new Article { ArticleId = 5, ArticleName = "Kettensäge", Price = 50.0M, ArticleGroupId = 1 }
            );


            modelBuilder.Entity<ArticleGroup>().HasData(
                new ArticleGroup { ArticleGroupId = 1, Name = "Werkzeuge" },
                new ArticleGroup { ArticleGroupId = 2, Name = "Hygiene" },
                new ArticleGroup { ArticleGroupId = 3, Name = "Kinder" }
            );


            modelBuilder.Entity<ArticlePosition>().HasData(
                new ArticlePosition { ArticlePositionId = 1, ArticleId = 1, OrderPositionId = 1 },
                new ArticlePosition { ArticlePositionId = 2, ArticleId = 2, OrderPositionId = 2 },
                new ArticlePosition { ArticlePositionId = 3, ArticleId = 3, OrderPositionId = 3 },
                new ArticlePosition { ArticlePositionId = 4, ArticleId = 4, OrderPositionId = 4 },
                new ArticlePosition { ArticlePositionId = 5, ArticleId = 5, OrderPositionId = 5 }
            );


            modelBuilder.Entity<Customer>().HasData(
                 new Customer { CustomerId = 1, Name = "Marco Mayer", PhoneNumber = "0123456789", EMail = "marco-mayer@gmx.com", Website = "servicesolution.com", Password = "pass1", AddressId = 1 },
                 new Customer { CustomerId = 2, Name = "Peter Steiner", PhoneNumber = "9876543210", EMail = "ps@gmail.com", Website = "funreisen.ch", Password = "pass2", AddressId = 2 },
                 new Customer { CustomerId = 3, Name = "Julia Heeb", PhoneNumber = "1234567890", EMail = "jh@gmx.com", Website = "geschenkideen.ch", Password = "pass3", AddressId = 3 },
                 new Customer { CustomerId = 4, Name = "Larissa Hugentobler", PhoneNumber = "0987654321", EMail = "lärihugi@hotmail.com", Website = "gmx.ch", Password = "pass4", AddressId = 4 },
                 new Customer { CustomerId = 5, Name = "Pascal Meier", PhoneNumber = "1023456789", EMail = "PCMeier@sunrise.com", Website = "meierbau.ch", Password = "pass5", AddressId = 5 }
             );


            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, CustomerId = 1, Date = new DateTime(2022, 10, 10) },
                new Order { OrderId = 2, CustomerId = 2, Date = new DateTime(2022, 11, 11) },
                new Order { OrderId = 3, CustomerId = 3, Date = new DateTime(2022, 12, 12) },
                new Order { OrderId = 4, CustomerId = 4, Date = new DateTime(2023, 1, 1) },
                new Order { OrderId = 5, CustomerId = 5, Date = new DateTime(2023, 2, 2) }
            );


            modelBuilder.Entity<OrderPosition>().HasData(
                new OrderPosition { OrderPositionId = 1, Amount = 5, OrderId = 1 },
                new OrderPosition { OrderPositionId = 2, Amount = 10, OrderId = 2 },
                new OrderPosition { OrderPositionId = 3, Amount = 3, OrderId = 3 },
                new OrderPosition { OrderPositionId = 4, Amount = 8, OrderId = 4 },
                new OrderPosition { OrderPositionId = 5, Amount = 15, OrderId = 5 }
                );
        }
    }
}
