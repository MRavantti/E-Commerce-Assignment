
using System;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class ShoppingCartItem
    {
        public int CartItemId { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }
    }
}