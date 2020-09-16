using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCsvParser;
using TinyCsvParser.Mapping;

namespace PriceDetailAssignment.Models.Services
{
    public class ParsingService
    {
        //Parsing price_detail.csv to List of products using TinyCsvParser-----------------------------------------
        public static List<Product> CsvToProductList(string fileName)
        {
            List<Product> products = new List<Product>();

            if (string.IsNullOrWhiteSpace(fileName))
            {
                return products;
            }

            CsvParserOptions csvParserOptions = new CsvParserOptions(true, '\t'); //true=skippa headern
            var csvParser = new CsvParser<Product>(csvParserOptions, new CsvProductMapping());
            var records = csvParser.ReadFromFile("price_detail.csv", Encoding.UTF8)
                .Where(x => x.IsValid) //Parse Only the valid rows
                .ToList();

            //Change type, convert Raw data and save to Database-------------------------------------------------

            foreach (CsvMappingResult<Product> row in records) //vilken kolumn
            {
                Product product = new Product()
                {
                    PriceValuedId = row.Result.PriceValuedId,
                    Created = Convert.ToDateTime(row.Result.Created),
                    Modified = Convert.ToDateTime(row.Result.Modified),
                    CatalogEntryCode = Convert.ToString(row.Result.CatalogEntryCode),
                    MarketId = Convert.ToString(row.Result.MarketId),
                    CurrencyCode = Convert.ToString(row.Result.CurrencyCode),
                    ValidFrom = Convert.ToDateTime(row.Result.ValidFrom),
                    ValidUntil = Convert.ToDateTime(row.Result.ValidUntil),
                    UnitPrice = Convert.ToDecimal(row.Result.UnitPrice)
                };
                products.Add(product);
            }
            return products;
        }           
    }
}

//Test sort working fine-----------------------------------------------------------

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
//var products2 = products;
//products2.
//GroupBy(w => w.CatalogEntryCode).
//Select(g => new { CatalogEntryCode = g.Key, Products2 = g }).
//OrderBy(o => o.CatalogEntryCode).ToList();
//Select(g => new { Length = g.Key, Words = g }).
//--------------------------------------------------------------------------------
