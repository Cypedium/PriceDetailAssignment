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
        public IActionResult Index(string sortOrder)
        {
            return View(_productService.All_Raw_Data());
        }
    }
}