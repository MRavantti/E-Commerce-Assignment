using System;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using E_Commerce.Models;
using MySql.Data.MySqlClient;

namespace E_Commerce.Repositories
{
    public class CustomerRepository
    {
        private readonly string connectionString;

        public CustomerRepository(string connectionstring)
        {
            this.connectionString = connectionstring;
        }

        public List<Customer> Get()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.Query<Customer>("SELECT * FROM Customers").ToList();
            }
        }

        public Customer Get(string guid)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                return connection.QuerySingleOrDefault<Customer>("SELECT Id, Name, Adress, Zipcode, City, Cart_guid, Email FROM Customers WHERE cart_guid = @guid", new { guid });
            }
        }

        public void Add(Customer costumer)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO Customers (Name, Adress, Zipcode, City, Cart_guid, Email) VALUES (@Name, @Adress, @Zipcode, @City, @Cart_guid, @Email)", costumer);
            }
        }
    }
}