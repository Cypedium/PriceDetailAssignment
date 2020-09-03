using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceDetailAssignment.Models.Repo
{
    interface IProductRepo
    {
        Product Modified(Product product);
        List<Product> All_Raw_Data();
        List<Product> Modified_Data();
    }
}
