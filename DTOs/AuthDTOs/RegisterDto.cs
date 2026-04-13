namespace DevTrackAPI.DTOs.AuthDTOs;

public record RegisterDto(
    string Name,
    string Email,
    string Password,
    string Location
    );