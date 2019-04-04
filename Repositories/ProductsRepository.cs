using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using E_Commerce.Models;

namespace E_Commerce.Repositories
{
    public class ProductRepository
    {
        private readonly string connectionString;

        public ProductRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Products> Get()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var allProducts = connection.Query<Products>("SELECT * FROM Products").ToList();
                return allProducts;
            }
        }

        public Products Get(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var products = connection.QuerySingleOrDefault<Products>("SELECT * FROM Products WHERE Id = @Id", new { id });
                return products;
            };
        }

        public void Add(Products products)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO Products (Header, Body) VALUES(@header, @body)", products);
            }
        }

        public void Delete(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("DELETE FROM Products WHERE Id = @Id", new { id });

            };
        }

    }
}