using DevTrackAPI.DTOs.AuthDTOs;

namespace DevTrackAPI.Services.Interfaces;

public interface IAuthService
{
    Task<TokenDto?> LoginAsync(LoginDto loginDto);
    Task<bool>RegisterAsync(RegisterDto registerDto);
}