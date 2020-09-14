using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using TinyCsvParser;
using System.Text;
using TinyCsvParser.Mapping;
using PriceDetailAssignment.Models.Services;

namespace PriceDetailAssignment.Models
{
    public class DbInitializer__
    {
        internal static void Initialize(HandlePriceDetailsDbContext context)
        {
            // Check if our database is created if not then create it
            context.Database.EnsureCreated();

            if (!context.Products.Any())
            {
                context.Products.AddRange(ConvertService.CsvToProductList("price_detail.csv"));

                context.SaveChanges();
            }
        }
    }
}
