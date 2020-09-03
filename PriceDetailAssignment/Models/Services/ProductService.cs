using PriceDetailAssignment.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceDetailAssignment.Models.Services
{
    public class ProductService : IProductService
    {
        readonly IProductRepo _productRepo;
        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public List<Product> All_Raw_Data()
        {
            return _productRepo.All_Raw_Data();
        }
        public List<Product> Modified_Data()
        {
            return _productRepo.Modified_Data();
        }

        public Product Create(Product product)
        {
            Product newProduct = new Product()
            {
                PriceValuedId       = product.PriceValuedId,
                Created             = product.Created,
                Modified            = product.Modified,
                CatalogEntryCode    = product.CatalogEntryCode,
                MarketId            = product.MarketId,
                CurrencyCode        = product.CurrencyCode,
                ValidFrom           = product.ValidFrom,
                ValidUntil          = product.ValidUntil,
                UnitPrice           = product.UnitPrice
            };
            return _productRepo.Create(newProduct);
        }

    }
}
