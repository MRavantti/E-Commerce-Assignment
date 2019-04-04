using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using E_Commerce.Models;
using MySql.Data.MySqlClient;

namespace E_Commerce.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly string connectionString;

        public ProductsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Products> Get()
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                return connection.Query<Products>("SELECT * FROM Products").ToList();
            }
        }

        public List<Products> Get(string id)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                return connection.Query<Products>("SELECT * FROM Products WHERE Id = @id", new { id }).ToList();
            }
        }

    }
}