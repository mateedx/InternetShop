using InternetShop.Database.Enums;

namespace InternetShop.Database.Entities
{
    public class Order : EntityBase
    {
        public DateTime CreatedAt { get; set; }

        public DateTime? ClosedAt { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public OrderStatus Status { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

        public string DeliveryAdress { get; set; }

    }
}
