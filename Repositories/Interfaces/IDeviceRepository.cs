using DevTrackAPI.Models;

namespace DevTrackAPI.Repositories;

public interface IDeviceRepository 
{
    Task<IEnumerable<Device>> GetAllAsync();
    Task<Device?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(string name, string manufacturer);
    Task<Device> CreateDeviceAsync(Device device);
    Task<Device> UpdateDeviceAsync(Device device);
    Task DeleteDeviceAsync(int id);
    //Task<IEnumerable<Device>> SearchDevicesAsync(string query);
}