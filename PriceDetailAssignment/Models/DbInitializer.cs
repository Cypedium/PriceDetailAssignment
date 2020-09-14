using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using TinyCsvParser;
using System.Text;
using TinyCsvParser.Mapping;

namespace PriceDetailAssignment.Models
{
    public class DbInitializer
    {
        internal static void Initialize(HandlePriceDetailsDbContext context)
        {
            // Check if our database is created if not then create it
            context.Database.EnsureCreated();

            //Parsing CSV-FILE-----------------------------------------------------------------------------------
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, '\t'); //true=skippa headern
            var csvParser = new CsvParser<Product>(csvParserOptions, new CsvProductMapping());
            var records = csvParser.ReadFromFile("price_detail.csv", Encoding.UTF8)
                .Where(x => x.IsValid)
                .ToList();
            

            //Change type, convert Raw data and save to Database-------------------------------------------------

            if (!context.Products.Any())
            {
                foreach (CsvMappingResult<Product> row in records) //vilken kolumn
                {
                    Product product = new Product()
                    {
                        PriceValuedId = row.Result.PriceValuedId,
                        Created = Convert.ToDateTime(row.Result.Created),
                        Modified = Convert.ToDateTime(row.Result.Modified),
                        CatalogEntryCode = row.Result.CatalogEntryCode,
                        MarketId = row.Result.MarketId,
                        CurrencyCode = row.Result.CurrencyCode,
                        ValidFrom = Convert.ToDateTime(row.Result.ValidFrom),
                        ValidUntil = Convert.ToDateTime(row.Result.ValidUntil),
                        UnitPrice = Convert.ToDecimal(row.Result.UnitPrice)
                    };
                    context.Products.Add(product);
                    context.Products.;
                    context.SaveChanges();
                }
            }    
        }
    }
}
