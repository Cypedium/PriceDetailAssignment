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
            
            return View(ModulateService.CatalogEntryCodes(catalogEntryCodes));
        }
    }
}