namespace InternetShop.Domain.Users.Dto;

public class UpdateProfileDto
{
    public int UserId { get; set; }
    public string Name { get; set; }

    public string Lastname { get; set; }
}