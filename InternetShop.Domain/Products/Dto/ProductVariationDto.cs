namespace InternetShop.Domain.Products.Dto;

public class ProductVariationDto
{
    public int Id { get; set; }
    public decimal Price { get; set; }

    public int AvailableCount { get; set; }

    public double Size { get; set; }

    public string Type { get; set; }
}