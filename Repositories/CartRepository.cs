using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using E_Commerce.Models;
using MySql.Data.MySqlClient;

namespace E_Commerce.Repositories
{
    public class ShoppingCartRepository
    {
        private readonly string ConnectionString;

        private readonly ShoppingCartRepository shoppingCartRepository;

        public ShoppingCartRepository(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        public ShoppingCart Get(int id)
        {
            using (var connection = new MySqlConnection(this.ConnectionString))
            {
                var cart = connection.QuerySingleOrDefault<ShoppingCart>("SELECT * FROM shoppingCart WHERE shoppingCartId = @id", new { id });
                if (cart == null)
                {
                    connection.Execute("INSERT INTO shoppingCart (id) VALUES (@id)", new { id });
                    var newCart = connection.QuerySingleOrDefault<ShoppingCart>("SELECT * FROM shoppingCart WHERE shoppingCartId = @id", new { id });
                    return newCart;
                }
                cart.Products = connection
                    .Query<Products>(
                        "SELECT * FROM shoppingCartitem sci INNER JOIN products p ON sci.ProductId = p.Id WHERE sci.id = @id",
                        new { id }).ToList();
                cart.Price = cart.Products.Sum(item => item.Price);
                return cart;
            }
        }

        public bool SubmitOrder(Order order)
        {
            using (var connection = new MySqlConnection(this.ConnectionString))
            {
                var result = connection.Execute(
                "INSERT INTO submittedorders (CartId, Name, Street, City, ZipCode, Telephone, Email) VALUES (@CartId, @Name, @Street, @City, @ZipCode, @Telephone, @Email)", order);

                var resultOfUpdateCartCompletion = connection.Execute("UPDATE cart SET CartCompleted = 1 WHERE CartId = @CartId", new { order.CartId });

                if (result == 0 || resultOfUpdateCartCompletion == 0)
                {
                    return false;
                }

                return true;
            }

        }
    }
}