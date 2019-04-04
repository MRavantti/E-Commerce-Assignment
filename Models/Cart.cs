namespace E_Commerce.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int Product_id { get; set; }
        public int Cart_id { get; set; }
        public string Name { get; set; }
        public string Image_url { get; set; }
        public int Price { get; set; }
    }
}