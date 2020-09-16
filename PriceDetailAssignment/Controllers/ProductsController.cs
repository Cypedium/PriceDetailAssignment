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
            string[] temp_Array = new string[3];
            temp_Array = id.Split('=', 3);

            string catalogEntryCode = temp_Array[0];
            string market_Id = temp_Array[1];
            string currency_Code = temp_Array[2];

            ViewBag.Message_CatalogEntryCode = catalogEntryCode;
            ViewBag.Message_Market = market_Id;

            List<Product> catalogEntryCodes = new List<Product>();
            catalogEntryCodes = _productService.All_Raw_Data().Where(x => x.CatalogEntryCode == catalogEntryCode).ToList();
            
            return View(ModulateService.CatalogEntryCodes(catalogEntryCodes, market_Id, currency_Code));
        }
    }
}