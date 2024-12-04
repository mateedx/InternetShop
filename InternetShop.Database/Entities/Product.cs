namespace InternetShop.Database.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public CategoryVariation CategoryVariation { get; set; }

        public int CategoryVariationId { get; set; }

        public ICollection<ProductVariation> Variations { get; set; } = [];
    }
}
