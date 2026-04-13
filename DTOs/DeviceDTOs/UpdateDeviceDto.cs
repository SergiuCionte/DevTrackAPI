namespace DevTrackAPI.DTOs.DeviceDto;

public record UpdateDeviceDto(
    string Name,
    string Manufacturer,
    string Type,
    string OperatingSystem,
    string OsVersion,
    string Processor,
    int RamAmount,
    string Description
);