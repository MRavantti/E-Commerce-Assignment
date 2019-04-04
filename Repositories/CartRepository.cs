using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using E_Commerce.Models;
namespace E_Commerce.Repositories
{
    public class CartRepository
    {
        private readonly string connectionString;

        public CartRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Cart> Get(string guid)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            {
                return connection.Query<Cart>("SELECT Cart_items.Id, Cart_items.Product_id, Cart_guid, Name, Image_url, Price FROM Cart_items LEFT JOIN Products ON Cart_items.Product_id = Products.Id WHERE Cart_guid = @guid", new { guid }).ToList();
            }
        }

    }
}