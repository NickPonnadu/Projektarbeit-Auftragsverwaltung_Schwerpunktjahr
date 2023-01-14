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
    public class CompanyContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressLocation> AddressLocations { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderPosition> OrderPositions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ArticlePosition> ArticlePositions { get; set; }


        // Wenn wir verschieden ConnectionString haben, müssen wir das anders lösen
        // Aus Sicherheitsgründen ist es Sinnvoller die ConnectionStrings im App.config File zu hinterlegen.
        // Eine andere Methode, um verschieden ConnectionStrings zu nutzten, die aber innerhalb des Codes niedergeschrieben werden, ist die Verwendung des StringBuilders.
        // Info zu StringBuilder: https://www.youtube.com/watch?v=V3EPT1R6seQ
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-8S98QH8\\ZBWSERVER;Database=EfCoreDemo;Trusted_Connection=True;");
        }
    }
}
