using InternetShop.Database;
using InternetShop.Database.Entities;
using InternetShop.Database.Enums;
using InternetShop.Database.Exceptions;
using InternetShop.Domain;
using InternetShop.Domain.Jwts;
using InternetShop.Domain.Jwts.Dto;
using InternetShop.Domain.Users;
using InternetShop.Domain.Users.Dto;
using Microsoft.EntityFrameworkCore;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace InternetShop.Services;

public class UserService : IUsersService
{
    private readonly InternetShopDbContext _context;
    private readonly IJwtService _jwtService;

    public UserService(InternetShopDbContext context, IJwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
        
    }
    
    public async Task<UserDto> GetAsync(int id)
    {
        var user = await _context.Set<User>().Where(w => w.Id == id).Select(s => new UserDto()
        {
            Email = s.Email,
            Name = s.Name,
            Lastname = s.Lastname,
            Password = s.Password,
            Role = s.Role,
            PhoneNumber = s.PhoneNumber,
        }).FirstOrDefaultAsync();


        if (user == null)
        {
            throw new NotFoundException($"User with id {id} not found");
        }

        return user;
    }

    

    public async Task UpdateProfileAsync(UpdateProfileDto request)
    {
        var user = await GetAsync(request.UserId);
        if (user == null)
            throw new NotFoundException($"User with id {request.UserId} not found");

        user.Lastname = request.Lastname;
        user.Name = request.Name;


        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await GetAsync(id);
        if (user == null)
            throw new NotFoundException($"User with id {id} not found");

        _context.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<string> LoginAsync(LoginUserDto request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(f => f.Email == request.Email);

        if (user == null)
            throw new NotFoundException($"User with email {request.Email} not found");
        
        if (user.Password != Tools.GetSha256Hash(request.Password))
            throw new ValidationException("Passwords don't match");

        var token = _jwtService.CreateToken(new JwtUserDto(user.Email, user.Id, user.Role));

        return token;
    }
    
    public async Task RegisterAsync(RegisterUserDto request)
    {
        var isUserExists = await _context.Set<User>().AnyAsync(u => u.Email == request.Email);
        
        if (isUserExists)
        {
            throw new ConflictException($"Email {request.Email} already exists");
        }
        
        var isNumberTaken = await _context.Set<User>().AnyAsync(u => u.PhoneNumber == request.PhoneNumber);
        
        if (isNumberTaken)
        {
            throw new ConflictException($"Phone number {request.PhoneNumber} is taken");
        }

        User user = new User
        {
            Email = request.Email,
            Name = request.Name,
            Lastname = request.Lastname,
            Password = Tools.GetSha256Hash(request.Password),
            Role = request.Role,
            PhoneNumber = request.PhoneNumber,
            Cart = new Cart()
        };
        
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}