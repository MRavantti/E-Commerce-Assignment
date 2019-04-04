using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using E_Commerce.Models;
using E_Commerce.Repositories;
using E_Commerce.Services;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    public class OrderItemsController : Controller
    {
        private readonly OrderItemsService orderItemsService;

        public OrderItemsController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.orderItemsService = new OrderItemsService(new OrderItemsRepository(connectionString));
        }

        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(OrderItems), StatusCodes.Status200OK)]
        [ProducesResponseTypeAttribute(StatusCodes.Status404NotFound)]
        public IActionResult Get(string guid)
        {
            var resault = this.orderItemsService.Get(guid);
            return Ok(resault);
        }
    }
}