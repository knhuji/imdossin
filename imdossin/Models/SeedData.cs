using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using imdossin.Data;

namespace imdossin.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DataContext>>()))
            {
                // Look for any movies.
                if (context.Products.Any())
                {
                    return;   // DB has been seeded
                }

                context.Products.AddRange(
                    new Product
                    {
                        Prod_Name = "RABBIT TOY COLOUR T-SHIRT",
                        Price = 320000,
                        Quantity = 1,
                        Supplier = "BAD RABBITS",
                        Date = DateTime.Parse("2020-4-18"),
                        Description = "Since in 2019",
                        Status_ID = 1
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
