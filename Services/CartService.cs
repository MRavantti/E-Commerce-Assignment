using System;
using System.Collections.Generic;
using E_Commerce.Models;
using E_Commerce.Repositories;
namespace E_Commerce.Services
{
    public class CartService
    {
        private readonly CartRepository cartRepository;

        public CartService(CartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public List<Cart> Get(string guid)
        {
            return this.cartRepository.Get(guid);
        }
    }
}