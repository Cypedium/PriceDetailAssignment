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
        
        [HttpGet()]
        public IActionResult Index(string market_Id, string currency_Code, string catalogEntryCode)
        {
            List<Product> catalogEntryCodes = new List<Product>();
            
            if (ModelState.IsValid)
            {
                
                ViewBag.Message_Market = market_Id;
                ViewBag.Message_Currency = currency_Code;
                ViewBag.Message_CatalogEntryCode = catalogEntryCode;

                catalogEntryCodes = _productService.All_Raw_Data().Where(x => x.CatalogEntryCode == catalogEntryCode).ToList();

                return View(ModulateService.CatalogEntryCodes(catalogEntryCodes, market_Id, currency_Code));
            }
            else
            {
                return View(catalogEntryCodes);
            }
            
        }
    }
}