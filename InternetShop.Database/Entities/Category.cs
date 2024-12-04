namespace InternetShop.Database.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }

        public ICollection<CategoryVariation> Variations { get; set; } = [];
    }
}
