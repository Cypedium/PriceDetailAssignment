using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceDetailAssignment.Models.Services
{
    public interface IProductService
    {
        Product Create(Product product);
        List<Product> All_Raw_Data();
        List<Product> Modified_Data();
    }
}
