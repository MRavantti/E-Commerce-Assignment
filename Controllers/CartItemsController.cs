﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using E_Commerce.Models;
using E_Commerce.Services;
using E_Commerce.Repositories;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    public class CartItemsController : Controller
    {
        private readonly string connectionString;
        private readonly CartItemsServices cartItemsService;

        public CartItemsController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.cartItemsService = new CartItemsServices(new CartItemsRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CartItems>), StatusCodes.Status200OK)]
        public IActionResult Get()

        {
            return Ok(this.cartItemsService.Get());
        }

        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(CartItems), StatusCodes.Status200OK)]
        [ProducesResponseTypeAttribute(StatusCodes.Status404NotFound)]
        public IActionResult Get(string guid)
        {
            var resault = this.cartItemsService.Get(guid);
            return Ok(resault);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]CartItems cartItems)
        {
            var result = this.cartItemsService.Add(cartItems);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CartItems), StatusCodes.Status200OK)]
        [ProducesResponseTypeAttribute(StatusCodes.Status404NotFound)]
        public void Delete(int id)
        {
            this.cartItemsService.Del(id);
        }
    }
}
