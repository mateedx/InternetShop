using InternetShop.Database.Enums;

namespace InternetShop.Database.Entities
{
    public class OrderProduct : EntityBase
    {
        public decimal Price { get; set; }

        public ProductVariation ProductVariation { get; set; }

        public int ProductVariationId { get; set; }

        public double? Discount { get; set; }

        public OrderProductStatus Status { get; set; }

    }
}
