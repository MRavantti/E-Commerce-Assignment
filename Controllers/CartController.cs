using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using E_Commerce.Models;
using E_Commerce.Repositories;
using E_Commerce.Services;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly CartService cartService;

        public CartController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.cartService = new CartService(new CartRepository(connectionString));
        }

        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(List<Cart>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(string guid)
        {
            var result = this.cartService.Get(guid);
            return Ok(result);
        }
    }
}