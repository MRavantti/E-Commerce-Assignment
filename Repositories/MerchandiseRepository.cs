using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;
using System.Transactions;

namespace E_Commerce
{
    public class MerchandiseRepository
    {
        private readonly string connectionString;

        public MerchandiseRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Merchandise> Get()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.Query<Merchandise>("SELECT * FROM Merchandise").ToList();
            }
        }

        public Merchandise Get(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.QuerySingleOrDefault<Merchandise>("SELECT * FROM Merchandise WHERE id = @id", new { id });
            }
        }

        public void Add(Merchandise merchandise)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO Merchandise (name, description, price, stock) VALUES(@name, @description, @price, @stock)", merchandise);
            }
        }

        public void Delete(int id)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (var connection = new MySqlConnection(this.connectionString))
                {
                    connection.Execute("DELETE FROM News WHERE Id = @id", new { id });
                }
                scope.Complete();
            }
        }
    }
}