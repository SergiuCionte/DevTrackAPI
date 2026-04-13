using DevTrackAPI.DTOs.DeviceDto;
using DevTrackAPI.Models;
using DevTrackAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevTrackAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DeviceController : ControllerBase
{
    private readonly IDeviceRepository _deviceRepository;

    public DeviceController(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll() =>
    Ok(await _deviceRepository.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var device = await _deviceRepository.GetByIdAsync(id);
        if (device is null) return NotFound();
        return Ok(device);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDevice([FromBody] CreateDeviceDto createDeviceDto)
    {
        if (await _deviceRepository.ExistsAsync(createDeviceDto.Name, createDeviceDto.Manufacturer))
            return Conflict("Device already exists");

        var device = new Device
        {
            Name = createDeviceDto.Name,
            Manufacturer = createDeviceDto.Manufacturer,
            Type = createDeviceDto.Type,
            OperatingSystem = createDeviceDto.OperatingSystem,
            OsVersion = createDeviceDto.OsVersion,
            Processor = createDeviceDto.Processor,
            RamAmount = createDeviceDto.RamAmount
        };
        
        var created = await _deviceRepository.CreateDeviceAsync(device);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDevice(int id, [FromBody] UpdateDeviceDto updateDeviceDto)
    {
        var device = await _deviceRepository.GetByIdAsync(id);
        if (device == null) return NotFound();
        
        device.Name = updateDeviceDto.Name;
        device.Manufacturer = updateDeviceDto.Manufacturer;
        device.Type = updateDeviceDto.Type;
        device.OperatingSystem = updateDeviceDto.OperatingSystem;
        device.OsVersion = updateDeviceDto.OsVersion;
        device.Processor = updateDeviceDto.Processor;
        device.RamAmount = updateDeviceDto.RamAmount;
        device.Description = updateDeviceDto.Description;
        
        return Ok(await _deviceRepository.UpdateDeviceAsync(device));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDevice(int id)
    {
        await _deviceRepository.DeleteDeviceAsync(id);
        return NoContent();
    }

    [HttpPost("{id}/assign")]
    public async Task<IActionResult> Assign(int id)
    {
        var device = await _deviceRepository.GetByIdAsync(id);
        if (device == null) return NotFound();
        if (device.AssignedUserId != null) return Conflict("Device already assigned");
        
        var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);
        device.AssignedUserId =  userId;
        return Ok(await _deviceRepository.UpdateDeviceAsync(device));
    }

    [HttpPost("{id}/unassign")]
    public async Task<IActionResult> Unassign(int id)
    {
        var device = await _deviceRepository.GetByIdAsync(id);
        if (device == null) return NotFound();
        
        device.AssignedUserId = null;
        return Ok(await _deviceRepository.UpdateDeviceAsync(device));
    }

}