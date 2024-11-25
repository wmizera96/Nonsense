using System.ComponentModel.DataAnnotations;

namespace Nonsense.Common.Settings;

public record DatabaseSettings
{
    [Required]
    public string ConnectionString { get; set; }
}