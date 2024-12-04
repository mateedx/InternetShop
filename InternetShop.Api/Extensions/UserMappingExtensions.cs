using InternetShop.Api.Contracts.Users;
using InternetShop.Domain.Users.Dto;
using LoginRequest = InternetShop.Api.Contracts.Logins.LoginRequest;


namespace InternetShop.Api.Extensions;

public static class UserMappingExtensions
{
    public static RegisterUserDto ToDto(this RegisterUserRequest request)
    {
        return new RegisterUserDto()
        {
            Email = request.Email,
            Name = request.Name,
            Lastname = request.Lastname,
            Password = request.Password,
            PhoneNumber = request.PhoneNumber,
            Role = request.Role,
        };
    }

    public static UpdateProfileDto ToDto(this UpdateProfileRequest request, int userId)
    {
        return new UpdateProfileDto
        {
            UserId = userId,
            Lastname = request.LastName,
            Name = request.Name,
        };
    }

    public static LoginUserDto ToDto(this LoginRequest request)
    {
        return new LoginUserDto()
        {
            Email = request.Email, 
            Password = request.Password
        };
    }   
}