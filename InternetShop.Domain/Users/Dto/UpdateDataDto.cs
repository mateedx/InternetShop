namespace InternetShop.Domain.Users.Dto;

public class UpdateDataDto
{
    public int Id { get; set; }
    
    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Password  { get; set; }
}