using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using E_Commerce.Services;
using E_Commerce.Models;
using E_Commerce.Repositories;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ProductsService productsService;

        public ProductsController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.productsService = new ProductsService(new ProductsRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(Products), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var products = this.productsService.Get();
            return Ok(products);
        }

        [HttpGet("{key}")]
        [ProducesResponseType(typeof(Products), StatusCodes.Status200OK)]
        [ProducesResponseTypeAttribute(StatusCodes.Status404NotFound)]
        public IActionResult Get(string key)
        {
            var resault = this.productsService.Get(key);
            return Ok(resault);
        }
    }
}