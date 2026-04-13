using DevTrackAPI.config;
using DevTrackAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DevTrackAPI.Repositories.Repos;

public class DeviceRepository : IDeviceRepository
{
    private readonly AppDbContext _dbContext;
    public DeviceRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Device>> GetAllAsync() =>
        await _dbContext.Devices.Include(d => d.AssignedUser).ToListAsync();
    
    public async Task<Device?> GetByIdAsync(int id) =>
        await _dbContext.Devices.Include(d => d.AssignedUser)
            .FirstOrDefaultAsync(d => d.Id == id);

    public async Task<bool> ExistsAsync(string name, string manufacturer) =>
        await _dbContext.Devices.AnyAsync(d => 
            d.Name.ToLower() == name.ToLower() &&
            d.Manufacturer.ToLower() == manufacturer.ToLower());

    public async Task<Device> CreateDeviceAsync(Device device)
    {
        _dbContext.Devices.Add(device);
        await _dbContext.SaveChangesAsync();
        return device;
    }

    public async Task<Device> UpdateDeviceAsync(Device device)
    {
        _dbContext.Devices.Update(device);
        await _dbContext.SaveChangesAsync();
        return device;
    }
    
    public async Task DeleteDeviceAsync(int id)
    {
        var d = await _dbContext.Devices.FindAsync(id);
        if (d != null)
        {
            _dbContext.Devices.Remove(d);
            await _dbContext.SaveChangesAsync();
        }
    }
}