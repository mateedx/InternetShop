namespace InternetShop.Api.Contracts.Products;

public class CreateProductResponse
{
    public int Id { get; }
    
    public CreateProductResponse(int id)
    {
        Id = id;
    }
}