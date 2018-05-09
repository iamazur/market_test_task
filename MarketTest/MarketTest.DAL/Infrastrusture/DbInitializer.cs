using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarketTest.DAL.Contexts;
using MarketTest.DAL.Entites;

namespace MarketTest.DAL.Infrastrusture
{
    public static class DbInitializer
    {
        public static void Initialize(MarketContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Set<ProductEntity>().Any())
            {
                return;   // DB has been seeded
            }

            var products = new ProductEntity[]
            {
                new ProductEntity{Code = "39533028", Name = "Elcykel Allegro", Description = "En smart och tillförlitlig elcykel för dam från Batavus utmärkt både för långa och kortare turer.", Category = "Sport", Price = 18499},
                new ProductEntity{Code = "40266837", Name = "Lapierre Overvolt Urban 300", Description = "Praktisk och bekväm elcykel med upprätt körställning.", Category = "Sport", Price = 20990},
                new ProductEntity{Code = "p35372817", Name = "Chrome cast 2nd generationen", Description = "Visar film eller annan media från mobilen på TV:n", Category = "Hemelektronik", Price = 390},
                new ProductEntity{Code = "35552289", Name = "Apple TV 64GB 4th generation", Description = "Nu kommer App Store till din tv. Du kan förvänta dig massor av spännande spel.", Category = "Hemelektronik", Price = 1990},
                new ProductEntity{Code = "40151785", Name = "Big Foot truck 2wd", Description = "Det här är bilen som startade alltihop och skapade den idag enorma monster-truck trenden.", Category = "Leksaker", Price = 2795}
                
            };

            foreach (var prod in products)
            {
                context.Set<ProductEntity>().Add(prod);
            }
            context.SaveChanges();
        }
    }
}
