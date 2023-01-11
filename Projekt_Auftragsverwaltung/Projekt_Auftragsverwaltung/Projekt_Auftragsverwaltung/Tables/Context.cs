using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatenbankProjekt.Tables
{
    public class Context : DbContext
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
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-8S98QH8\\ZBWSERVER;Database=EfCoreDemo;Trusted_Connection=True;");
        }


    }
}
