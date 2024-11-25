using System.ComponentModel.DataAnnotations;

namespace Nonsense.Tasks.API.Settings;

public record AppSettings
{
    [Required]
    public DatabaseSettings Database { get; set; }
}