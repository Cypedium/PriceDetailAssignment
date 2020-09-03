using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceDetailAssignment.Models.Repo
{
    public class ProductRepo : IProductRepo
    {
        readonly HandlePriceDetailDbContext _handlePriceDetailDbContext;

        public ProductRepo(HandlePriceDetailDbContext handlePriceDetailDbContext)
        {
            _handlePriceDetailDbContext = handlePriceDetailDbContext;
        }
        public List<Product> All_Raw_Data()
        {
            throw new NotImplementedException();
        }

        public Product Modified(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> Modified_Data()
        {
            throw new NotImplementedException();
        }
    }
}
