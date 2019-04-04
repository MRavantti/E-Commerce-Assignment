using System;
namespace E_Commerce.Models
{
    public class CartItems
    {
        public int Id { get; set; }
        public string Cart_guid { get; set; }
        public int Product_id { get; set; }
        public int Quantity { get; set; }
    }
}