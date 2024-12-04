namespace InternetShop.Api.Contracts.Products;

public class AddProductVariationRequest
{
    public decimal Price { get; set; }

    public int AvailableCount { get; set; }

    public double Size { get; set; }

    public string Type { get; set; }
    
    public int ProductId { get; set; }
}