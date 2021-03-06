﻿using System;
using System.Collections.Generic;
using E_Commerce.Models;
using E_Commerce.Repositories;

namespace E_Commerce.Services
{
    public class CartItemsServices
    {
        private readonly CartItemsRepository cartItemsRepository;

        public CartItemsServices(CartItemsRepository cartItemsRepository)
        {
            this.cartItemsRepository = cartItemsRepository;
        }

        public List<CartItems> Get()
        {
            return this.cartItemsRepository.Get();
        }

        public CartItems Get(string guid)
        {
            return this.cartItemsRepository.Get(guid);
        }

        public bool Add(CartItems cartItems)
        {
            if (cartItems != null)
            {
                this.cartItemsRepository.Add(cartItems);
                return true;
            }

            return false;
        }

        public void Del(int id)
        {
            this.cartItemsRepository.Del(id);
        }
    }
}