using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

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
                connection.Execute("INSERT INTO Merchandise (Header, Body) VALUES(@header, @body)", merchandise);
            }
        }
    }
}