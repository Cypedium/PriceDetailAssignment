using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceDetailAssignment.Models.Services
{
    public class ConvertService
    {
        public static List<Product> CsvToProductList(string fileName)
        {
            List<Product> products = new List<Product>();

            if (string.IsNullOrWhiteSpace(fileName))
            {
                return products;
            }

            const Int32 BufferSize = 1024;// 128 - 256 - 512 - 1024 defualt - 2048 - 4096 NTFS
            using (FileStream fileStream = File.OpenRead(fileName))
            {
                using (StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        string[] cols = line.Split('\t');

                        if (cols[0].Equals("PriceValuedId") 
                            && cols[1].Equals("Created") 
                            && cols[2].Equals("Modified") 
                            && cols[3].Equals("CatalogEntryCode")
                            && cols[4].Equals("MarketId")
                            && cols[5].Equals("CurrencyCode")
                            && cols[6].Equals("ValidFrom")
                            && cols[7].Equals("ValidUntil")
                            && cols[8].Equals("UnitPrice")
                        )
                        {
                            continue;
                        }

                        Product product = new Product();

                        int priceValuedId = 0;
                        int.TryParse(cols[0], out priceValuedId);
                        product.PriceValuedId = priceValuedId;

                        DateTime created;
                        DateTime.TryParse(cols[1], out created);
                        product.Created = created;

                        DateTime modified;
                        DateTime.TryParse(cols[2],out modified);
                        product.Modified = modified;

                        product.CatalogEntryCode = cols[3];

                        product.MarketId = cols[4];

                        product.CurrencyCode = cols[5];

                        DateTime validFrom;
                        DateTime.TryParse(cols[6], out validFrom);
                        product.ValidFrom = validFrom;

                        DateTime validUntil;
                        DateTime.TryParse(cols[7], out validUntil);
                        product.ValidUntil = validUntil;

                        decimal unitPrice = 0;
                        decimal.TryParse(cols[8],NumberStyles.Any,CultureInfo.InvariantCulture, out unitPrice);
                        product.UnitPrice = unitPrice;

                        products.Add(product);
                    }
                }
            }
            return products;
        }
    }
}
