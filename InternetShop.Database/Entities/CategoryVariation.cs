namespace InternetShop.Database.Entities
{
    public class CategoryVariation() : EntityBase
    {
        public string Name { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }
    }
}
