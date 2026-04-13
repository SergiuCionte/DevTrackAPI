using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DevTrackAPI.config;
using DevTrackAPI.DTOs.AuthDTOs;
using DevTrackAPI.Models;
using DevTrackAPI.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace DevTrackAPI.Services.Servs;

public class AuthService : IAuthService
{
    private readonly AppDbContext _dbContext;
    private readonly IConfiguration _configuration;
    
    public AuthService(AppDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }

    public async Task<bool> RegisterAsync(RegisterDto registerDto)
    {
        if(_dbContext.Users.Any(u => u.Email == registerDto.Email)) 
            return  false;
        var user = new User
        {
            Name = registerDto.Name,
            Email = registerDto.Email,
            Location = registerDto.Location,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password)
        };
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<TokenDto?> LoginAsync(LoginDto loginDto)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Email == loginDto.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            return null;

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            },
            expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: creds
        );
        
        return new TokenDto(new JwtSecurityTokenHandler().WriteToken(token), user.Name);
    }
}