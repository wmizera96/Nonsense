using System.ComponentModel.DataAnnotations;

namespace Nonsense.Common.Settings;

public record AppSettings
{
    [Required]
    public DatabaseSettings Database { get; set; }
}