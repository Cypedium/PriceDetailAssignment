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

        string market_Id;
        string currency_Code;
        string catalog_Entry_Code;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public IActionResult Search()
        {
            
            //List<Product> filtred_List_of_products = new List<Product>();

            //filtred_List_of_products = _productService.All_Raw_Data().Where(x => x.CatalogEntryCode == "27773-02")
            //                                                         .Where(x => x.ValidFrom == Convert.ToDateTime("1970-01-01 00:00:00"))
            //                                                         .Where(x => x.ValidUntil == Convert.ToDateTime("0001-01-01 00:00:00"))
            //                                                         .ToList();
            //return View(filtred_List_of_products);
            return View();
        }

        [HttpPost]
        public IActionResult Search(Product product)
        {
            if (ModelState.IsValid)
            {              
                return RedirectToAction("Index", new {market_Id = product.MarketId.ToLower(), currency_Code = product.CurrencyCode.ToUpper() ,catalogEntryCode = product.CatalogEntryCode });
            }
            else
            {
                return View(product);
            }
        }

        [HttpGet]
        public IActionResult Index(string market_Id, string currency_Code, string catalogEntryCode)
        {
            ViewBag.Message_Market = market_Id;
            ViewBag.Message_Currency = currency_Code;
            ViewBag.Message_CatalogEntryCode = catalogEntryCode;

            List<Product> catalogEntryCodes = _productService.All_Raw_Data().Where(x => x.CatalogEntryCode == catalogEntryCode).ToList();

            List<Product> finishedList_After_Modulate_Service = new List<Product>();

            finishedList_After_Modulate_Service = ModulateService.CatalogEntryCodes(catalogEntryCodes, market_Id, currency_Code);
            
            return View(finishedList_After_Modulate_Service);          
        }
    }
}


            //public IActionResult Index(string market_Id, string currency_Code, string catalogEntryCode)
            //List<Product> catalogEntryCodes = new List<Product>();

            //if (ModelState.IsValid)
            //{

            //ViewBag.Message_Market = market_Id;
            //ViewBag.Message_Currency = currency_Code;
            //ViewBag.Message_CatalogEntryCode = catalogEntryCode;

            //catalogEntryCodes = _productService.All_Raw_Data().Where(x => x.CatalogEntryCode == catalogEntryCode).ToList();

            //return View(ModulateService.CatalogEntryCodes(catalogEntryCodes, market_Id, currency_Code));
            //}
            //else
            //{
            //return View(catalogEntryCodes);

            //List<Product> finishedList_After_LastProductRow = finishedList_After_LastProductRow_;