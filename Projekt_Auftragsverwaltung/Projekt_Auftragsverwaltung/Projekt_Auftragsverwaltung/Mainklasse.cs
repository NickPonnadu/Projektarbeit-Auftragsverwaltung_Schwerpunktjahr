using DatenbankProjekt.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Auftragsverwaltung
{
    internal class Mainklasse
    {
        static void Main(string[] args)
        {
            List<AddressLocation> addresseLocations = new List<AddressLocation>
            {
                new AddressLocation{ZipCode = 9425, Location = "Thal"},
                new AddressLocation{ZipCode = 9424, Location = "Rheineck"},
                new AddressLocation{ZipCode = 9000, Location = "St. Gallen"},
                new AddressLocation{ZipCode = 9426, Location = "Musterort"}
            };

            List<Address> addresses = new List<Address>
            {
                new Address{Street = "Künggass", HouseNumber = "31", ZipCode = 9425},
                new Address{Street = "Tobelmühlistrasse 5", HouseNumber = "35", ZipCode = 9425},
                new Address{Street = "Künggass", HouseNumber = "64", ZipCode = 9424},
                new Address{Street = "Birnenstrasse", HouseNumber = "36", ZipCode = 9000}
            };

            List<Customer> customers = new List<Customer>
            {
                new Customer{Name = "Marco Schläpfer", PhoneNumber = "079 815 16 01", EMail = "marcoschlaepfer@gmail.com", Password = "1234"},
                new Customer{Name = "Nick Ponadu", PhoneNumber = "079 589 18 78", EMail = "nickponnadu@gmail.com", Password = "5678"},
                new Customer{Name = "Gabor Elayoubi", PhoneNumber = "079 879 45 65", EMail = "gaborel@gmail.com", Password = "9123"},
                new Customer{Name = "John Doe", PhoneNumber = "076 548 98 78", EMail = "johndoe@example.com", Password = "password"}
            };


            List<Order> orders = new List<Order>
            {
                new Order{Date = DateTime.Now},
                new Order{Date = DateTime.Now},
                new Order{Date = DateTime.Now},
                new Order{Date = DateTime.Now}
            };


            List<OrderPosition> orderPositions = new List<OrderPosition>
            {
                new OrderPosition{amount = 4},
                new OrderPosition{amount = 5},
                new OrderPosition{amount = 6},
                new OrderPosition{amount = 7}
            };

            List<ArticlePosition> articlePositions = new List<ArticlePosition>
            {
                new ArticlePosition{},
                new ArticlePosition{},
                new ArticlePosition{},
                new ArticlePosition{}
            };

            List<Article> articles = new List<Article>
            {
                new Article{ArticleName = "Bananen", price = Convert.ToDecimal(1.20)},
                new Article{ArticleName = "Kiwi", price = Convert.ToDecimal(1.35)},
                new Article{ArticleName = "Pfirsich", price = Convert.ToDecimal(1.40)},
                new Article{ArticleName = "Zitrone", price = Convert.ToDecimal(1.60)}

            };

            using (var context = new CompanyContext())
            {
                context.AddressLocations.AddRange(addresseLocations);
                context.Addresses.AddRange(addresses);
                context.Customers.AddRange(customers);
                context.Orders.AddRange(orders);
                context.OrderPositions.AddRange(orderPositions);
                context.ArticlePositions.AddRange(articlePositions);


                context.SaveChanges();
            }

        }
    }
}
