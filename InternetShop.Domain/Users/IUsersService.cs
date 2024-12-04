using InternetShop.Domain.Users.Dto;

namespace InternetShop.Domain.Users;

public interface IUsersService
{
    Task<UserDto> GetAsync(int id);

    Task UpdateProfileAsync(UpdateProfileDto request);

    Task DeleteAsync(int id);

    Task<string> LoginAsync(LoginUserDto request);
    
    Task RegisterAsync(RegisterUserDto request);
}