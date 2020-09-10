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

            //CsvParserOptions csvParserOptions = new CsvParserOptions(true, new[] { ';' });
            //CsvReaderOptions csvReaderOptions = new CsvReaderOptions(new[] { Environment.NewLine });
            //CsvProductMapping csvMapper = new CsvProductMapping();
            //CsvParser<Product> csvParser = new CsvParser<Product>(csvParserOptions, csvMapper);

            CsvParserOptions csvParserOptions = new CsvParserOptions(true, '\t');
            var csvParser = new CsvParser<Product>(csvParserOptions, new CsvProductMapping());
            var records = csvParser.ReadFromFile("price_detail.csv", Encoding.UTF8);
            //Where(x => x.IsValid).Select(x => x.Result);
            //List<Product> csvProducts = new List<Product>();

            var csvProducts = records.ToList();


            if (!context.Products.Any())
            {
                foreach (Product product in csvProducts.Select(x => x.Result))
                {
                    new Product()
                    {
                        PriceValuedId = product.PriceValuedId,
                        Created = Convert.ToDateTime(product.Created),
                        Modified = Convert.ToDateTime(product.Modified),
                        CatalogEntryCode = product.CatalogEntryCode,
                        MarketId = product.MarketId,
                        CurrencyCode = product.CurrencyCode,
                        ValidFrom = Convert.ToDateTime(product.ValidFrom),
                        ValidUntil = Convert.ToDateTime(product.ValidUntil),
                        UnitPrice = Convert.ToDecimal(product.UnitPrice)
                    };
                    context.Products.Add(product);
                }
                context.SaveChanges();
            }


            //records.Where(x => x.IsValid)
            //// This get the populated Entities:
            //.Select(x => x.Result)
            //// This turn it into a List:
            //.ToList();



            //records.ElementAt(1);


            //----------Products seed---------------------------------- -//

            /*if (!context.Products.Any())
            {
                Product[] productSeed = new Product[]
                         {
                             new Product()
                             {
                             //---TestValues--------------------------------//
                                 PriceValuedId = 169530676,
            			         Created = Convert.ToDateTime("2018-08-07 00:00:00.0000000"),
                                 Modified = Convert.ToDateTime("2018-08-07 00:00:00.0000000"),
                                 CatalogEntryCode = "27773-02",
                                 MarketId = "sv",
                                 CurrencyCode = "SEK",
                                 ValidFrom = Convert.ToDateTime("1970-01-01 00:00:00.0000000"),
                                 ValidUntil = Convert.ToDateTime("1970-01-01 00:00:00.0000000"),
                                 UnitPrice = Convert.ToDecimal(439.600000000)
                             },
                             new Product()
                             {
                                 PriceValuedId = 169530677,
                                 Created = Convert.ToDateTime("2018-08-07 00:00:00.0000000"),
                                 Modified = Convert.ToDateTime("2018-08-07 00:00:00.0000000"),
                                 CatalogEntryCode = "27773-02",
                                 MarketId = "sv",
                                 CurrencyCode = "SEK" ,
                                 ValidFrom = Convert.ToDateTime("2018-06-18 00:00:00.0000000"),
                                 ValidUntil = Convert.ToDateTime("2018-08-05 00:00:00.0000000"),
                                 UnitPrice = Convert.ToDecimal(399.600000000)
                             },
                             new Product()
                             {
                                 PriceValuedId = 169530678,
                                 Created = Convert.ToDateTime("2018-08-07 00:00:00.0000000"),
                                 Modified = Convert.ToDateTime("2018-08-07 00:00:00.0000000"),
                                 CatalogEntryCode = "27773-02",
                                 MarketId = "sv",
                                 CurrencyCode = "SEK",
                                 ValidFrom = Convert.ToDateTime("2018-08-01 00:00:00.0000000"),
                                 ValidUntil = Convert.ToDateTime("2018-08-05 00:00:00.0000000"),
                                 UnitPrice = Convert.ToDecimal(326.800000000)
                             },
                             new Product()
                             {
                                 PriceValuedId = 169530679,
                                 Created = Convert.ToDateTime("2018-08-07 00:00:00.0000000"),
                                 Modified = Convert.ToDateTime("2018-08-07 00:00:00.0000000"),
                                 CatalogEntryCode = "27773-02",
                                 MarketId = "sv",
                                 CurrencyCode = "SEK",
                                 ValidFrom = Convert.ToDateTime("2018-08-07 00:00:00.0000000"),
                                 ValidUntil = Convert.ToDateTime("2018-08-19 00:00:00.0000000"),
                                 UnitPrice = Convert.ToDecimal(326.800000000)
                             }
                         };

                        if (!context.Products.Any())
                        {
                            foreach (Product product in productSeed)
                            {
                                context.Products.Add(product);
                            }
                            context.SaveChanges();
                        }
                }*/
        }
    }
}
