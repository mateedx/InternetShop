namespace InternetShop.Api.Contracts.Categories;

public class AddCategoryVariationRequest
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int CategoryId { get; set; }
}