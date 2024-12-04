namespace InternetShop.Domain.Products.Dto;

public class AddProductVariationDto
{
    public decimal Price { get; set; }

    public int AvailableCount { get; set; }

    public double Size { get; set; }

    public string Type { get; set; }
    
    public int ProductId { get; set; }
}