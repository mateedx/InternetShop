
namespace InternetShop.Database.Entities
{
    public class Cart : EntityBase
    {
        public ICollection<ProductVariation> ProductVariations { get; set; } = [];

        public User User { get; set; }

        public int UserId { get; set; }
    }
}
