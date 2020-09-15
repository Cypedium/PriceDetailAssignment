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
            if (!context.Products.Any())
            {
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, '\t'); //true=skippa headern
            var csvParser = new CsvParser<Product>(csvParserOptions, new CsvProductMapping());
            var records = csvParser.ReadFromFile("price_detail.csv", Encoding.UTF8)
                .Where(x => x.IsValid) //Parse Only the valid rows
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
                            Created = row.Result.Created,
                            Modified = row.Result.Modified,
                            CatalogEntryCode = row.Result.CatalogEntryCode,
                            MarketId = row.Result.MarketId,
                            CurrencyCode = row.Result.CurrencyCode,
                            ValidFrom = row.Result.ValidFrom,
                            ValidUntil = row.Result.ValidUntil,
                            UnitPrice = row.Result.UnitPrice
                            //UnitPrice = Convert.ToDecimal(row.Result.UnitPrice)
                        };
                        products.Add(product);
                    }

                    //ska detta vara med?-----------------------------------------------------------

                    //List<Product> products_sortingByCatalogEntryCode = new List<Product>();
                    //products_sortingByCatalogEntryCode = products;
                    //products_sortingByCatalogEntryCode.Sort(delegate (Product x, Product y)
                    //products.Sort(delegate (Product x, Product y)
                    //{
                    //    if (x.CatalogEntryCode == null && y.CatalogEntryCode == null) return 0;
                    //    else if (x.CatalogEntryCode == null) return -1;
                    //    else if (y.CatalogEntryCode == null) return 1;
                    //    else return x.CatalogEntryCode.CompareTo(y.CatalogEntryCode);
                    //});

                    //-----------------------------------------------------------------------------

                    //Testkod?----------------------------------------------------------------------
                    var products2 = products;
                    products2.
                    GroupBy(w => w.CatalogEntryCode).
                    Select(g => new { CatalogEntryCode = g.Key, Products2 = g }).
                    OrderBy(o => o.CatalogEntryCode).ToList();
                    //Select(g => new { Length = g.Key, Words = g }).
                    //--------------------------------------------------------------------------------

                    context.Products.AddRange(products);
                    context.SaveChanges();
                }
            }   
        }
    }
}
