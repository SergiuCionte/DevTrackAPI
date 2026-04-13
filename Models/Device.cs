using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevTrackAPI.Models;


[Table("Devices")]
public class Device
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(128)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(128)]
    public string Manufacturer { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(128)]
    public string Type { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(128)]
    public string OperatingSystem { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(128)]
    public string OsVersion { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(128)]
    public string Processor { get; set; } = string.Empty;
    
    [Required]
    public int RamAmount { get; set; }
    
    [MaxLength(1000)]
    public string Description { get; set; } = string.Empty;
    
    public int? AssignedUserId { get; set; }
    
    [ForeignKey("AssignedUserId")]
    public virtual User? AssignedUser { get; set; }
}