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
            List<Product> products = new List<Product>();

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
                    products.Add(product);
                }

                //List<Product> products_sortingByCatalogEntryCode = new List<Product>();
                //products_sortingByCatalogEntryCode = products;
                //products_sortingByCatalogEntryCode.Sort(delegate (Product x, Product y)
                products.Sort(delegate (Product x, Product y)
                {
                    if (x.CatalogEntryCode == null && y.CatalogEntryCode == null) return 0;
                    else if (x.CatalogEntryCode == null) return -1;
                    else if (y.CatalogEntryCode == null) return 1;
                    else return x.CatalogEntryCode.CompareTo(y.CatalogEntryCode);
                });

                context.Products.AddRange(products);
                context.SaveChanges();
            }    
        }
    }
}
