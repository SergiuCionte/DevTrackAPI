namespace DevTrackAPI.DTOs.DeviceDto;

public record CreateDeviceDto(
    string Name,
    string Manufacturer, 
    string Type, 
    string OperatingSystem, 
    string OsVersion, 
    string Processor,
    int RamAmount
);
