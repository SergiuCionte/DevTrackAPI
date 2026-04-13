namespace DevTrackAPI.DTOs.AuthDTOs;

public record LoginDto(
    string Email,
    string Password
    );