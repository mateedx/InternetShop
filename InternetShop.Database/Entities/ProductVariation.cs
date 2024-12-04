namespace InternetShop.Database.Entities
{
    public class ProductVariation : EntityBase
    {
        
        public decimal Price { get; set; }

        public int AvailableCount { get; set; }

        public double Size { get; set; }

        public string Type { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }

        public ICollection<Cart> Carts { get; set; } = [];
    }
}
