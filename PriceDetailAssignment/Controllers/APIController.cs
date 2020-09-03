using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriceDetailAssignment.Models.Services;

namespace PriceDetailAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly IProductService _productService;

        public APIController(IProductService productService)
        {
            _productService = productService;
        }

        // Get: API

        //[HttpGet]

        //public string Get()
        //{
        //    string 
        //}
    }
}
