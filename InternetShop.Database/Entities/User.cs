using InternetShop.Database.Enums;

namespace InternetShop.Database.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public UserRole Role { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public Cart Cart { get; set; } = new Cart();

    }
}
