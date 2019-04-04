using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using E_Commerce.Models;
using MySql.Data.MySqlClient;

namespace E_Commerce.Repositories
{
    public class OrderItemsRepository
    {
        private string connectionString;

        public OrderItemsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<OrderItems> Get(string guid)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.Query<OrderItems>("SELECT Cart_guid, Cart_items.product_id, Name, Price, SUM(Price) AS total_price FROM Cart_items LEFT JOIN Products ON Cart_items.product_id = Products.Id WHERE cart_guid = @guid GROUP BY Cart_items.product_id", new { guid }).ToList();
            }
        }
    }
}