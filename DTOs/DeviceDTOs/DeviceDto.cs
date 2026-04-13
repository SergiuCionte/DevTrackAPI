namespace DevTrackAPI.DTOs.DeviceDto;

public record DeviceDto(
    int Id,
    string Name,
    string Manufacturer,
    string Type,
    string OperatingSystem,
    string OsVersion,
    string Processor,
    int RamAmount,
    string Description,
    int? AssignedUserId,
    string? AssignedUserName
);