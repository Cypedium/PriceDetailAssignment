using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceDetailAssignment.Models.Repo
{
    public class ProductRepo : IProductRepo
    {
        readonly HandlePriceDetailsDbContext _handlePriceDetailsDbContext;

        public ProductRepo(HandlePriceDetailsDbContext handlePriceDetailsDbContext)
        {
            _handlePriceDetailsDbContext = handlePriceDetailsDbContext;
        }
        public List<Product> All_Raw_Data()
        {
            return _handlePriceDetailsDbContext.Products.ToList();
        }
        public List<Product> Modified_Data()
        {
            return _handlePriceDetailsDbContext.Products.ToList();
        }

        public Product Create(Product product)
        {
            _handlePriceDetailsDbContext.Products.Add(product);
            _handlePriceDetailsDbContext.SaveChanges();
            return product;
        }

    }
}
