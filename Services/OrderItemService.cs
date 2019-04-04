using System;
using System.Collections.Generic;
using System.Web.Http;
using E_Commerce.Models;
using E_Commerce.Repositories;

namespace E_Commerce.Services
{
    public class OrderItemsService
    {
        private OrderItemsRepository orderItemsRepository;

        public OrderItemsService(OrderItemsRepository orderItemsRepository)
        {
            this.orderItemsRepository = orderItemsRepository;
        }

        public List<OrderItems> Get(string guid)
        {
            return this.orderItemsRepository.Get(guid);
        }
    }
}