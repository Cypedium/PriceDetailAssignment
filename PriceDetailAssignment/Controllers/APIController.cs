using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriceDetailAssignment.Models;
using PriceDetailAssignment.Models.Services;

namespace PriceDetailAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        //private readonly IProductService _productService;

        //public APIController(IProductService productService)
        //{
        //    _productService = productService;
        //}

        //TextReader reader = new StreamReader("price_detail.csv");
        //EnvironmentVariableTarget csvReader = new CsvReader(reader);
        //readonly EnvironmentVariableTarget records = CsvReader.GetRecords<Product>();
        // Get: API

        //[HttpGet]

        //public string Get()
        //{
        //    string 
        //}
    }
}
