using System;
namespace E_Commerce.Models
{
    public class Products
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public string Image_url { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}