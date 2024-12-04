namespace InternetShop.Api.Contracts.Categories;

public class UpdateCategoryRequest
{
    public int CategoryId { get; set; }

    public int ProductId { get; set; }
}