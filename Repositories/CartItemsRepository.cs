using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;
using E_Commerce.Models;

namespace E_Commerce.Repositories
{
    public class CartItemsRepository
    {
        private readonly string connectionString;

        public CartItemsRepository(string connectionstring)
        {
            this.connectionString = connectionstring;
        }

        public List<CartItems> Get()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.Query<CartItems>("SELECT * FROM Cart_items").ToList();
            }
        }

        public CartItems Get(string guid)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                return connection.QuerySingleOrDefault<CartItems>("SELECT Cart_guid, COUNT(Product_id) AS items FROM Cart_items WHERE Cart_guid = @guid", new { guid });
            }
        }

        public void Add(CartItems cartItems)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO Cart_items (Cart_guid, Product_id, Quantity) VALUES (@Cart_guid, @Product_id, @quantity)", cartItems);
            }
        }

        public void Del(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("DELETE FROM Cart_items WHERE Id = @id", new { id });
            }
        }
    }
}