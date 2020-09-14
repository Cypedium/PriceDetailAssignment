using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PriceDetailAssignment.Models;
using PriceDetailAssignment.Models.Services;
using TinyCsvParser;

namespace PriceDetailAssignment.Controllers
{
    public class ProductsController : Controller
    {
        readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult Index(string id)
        {
            string catalogEntryCode = id;
            ViewBag.Message = catalogEntryCode;
            List<Product> catalogEntryCodes = new List<Product>();
            catalogEntryCodes = _productService.All_Raw_Data().Where(x => x.CatalogEntryCode == catalogEntryCode).ToList();

            catalogEntryCodes.Sort(delegate (Product x, Product y)
                    {
                        if (x.PriceValuedId == 0 && y.PriceValuedId == 0) return 0;
                        else if (x.PriceValuedId == 0) return -1;
                        else if (y.PriceValuedId == 0) return 1;
                        else return x.PriceValuedId.CompareTo(y.PriceValuedId);
                    });

            List<Product> catalogEntryCodes_Market = new List<Product>();
            catalogEntryCodes_Market = catalogEntryCodes.Where(x => x.MarketId == "sv").ToList();

            //for (int i = 0; i < catalogEntryCodes_Market.Count; i++)
            //    catalogEntryCodes_Market.Add(delegate (Product x, Product y)
            //    {
            //        if (i==0)
            //        {
            //            x.ValidUntil = y.ValidUntil;
            //        }
                        
            //    });

            return View(catalogEntryCodes_Market);
        }
    }
}