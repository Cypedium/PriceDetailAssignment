using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace PriceDetailAssignment.Models
{
    public class DbInitializer
    {
        internal static void Initialize(
            HandlePriceDetailsDbContext context)
        {
			// Check if our database is created if not then create it
			context.Database.EnsureCreated();

			//----------Products seed-----------------------------------//

			if (!context.Products.Any())
            {
				Product[] productSeed = new Product[]
				{
					new Product()
					{
                        //---TestValues--------------------------------//
						PriceValuedId = 0, //169530676
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
                        PriceValuedId = 0,//169530677,
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
                        PriceValuedId = 0,//169530678,
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
                        PriceValuedId = 0, //169530679,
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
            }
        }
    }
}
