namespace InternetShop.Api.Contracts.Categories;

public class CreateCategoryResponse
{
    public int Id { get; }
    
    public CreateCategoryResponse(int id)
    {
        Id = id;
    }
}