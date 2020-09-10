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
        public IActionResult Index()
        {
            return View(_productService.All_Raw_Data());
        }
    }
}




            //CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
            //var csvParser = new CsvParser<Product>(csvParserOptions, new CsvProductMapping());
            //var records = csvParser.ReadFromFile("price_detail.csv", Encoding.UTF8);

            //return View((records.Where(x => x.IsValid).Select(x => x.Result)).ToList());