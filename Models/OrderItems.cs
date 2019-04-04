using System;

namespace E_Commerce.Models
{
    public class OrderItems
    {
        public string Cart_guid { get; set; }
        public int Product_id { get; set; }
        public string Product_name { get; set; }
        public int Price { get; set; }
        public int Total_price { get; set; }
    }
}