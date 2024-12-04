namespace InternetShop.Domain.Carts.Dto;

public class RemoveItemDto
{
    public int CartId { get; set; }

    public int ProductId { get; set; }
}