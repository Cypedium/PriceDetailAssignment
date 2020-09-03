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
        ProductService(IProductRepo productRepo)
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

        public Product Modified(Product product)
        {
            return _productRepo.Modified(product);
        }

    }
}
