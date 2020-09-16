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
    public class DbInitializer
    {
        internal static void Initialize(HandlePriceDetailsDbContext context)
        {
            // Check if our database is created if not then create it
            context.Database.EnsureCreated();

            //Adding list of products to database-------------------------------------------------------------------------------
            if (!context.Products.Any())
            {
                context.Products.AddRange(ParsingService.CsvToProductList("price_detail.csv"));
                context.SaveChanges();
            }
            //-------------------------------------------------------------------------------------------------------------------
        }
    }
}
