using System.ComponentModel.DataAnnotations;

namespace Nonsense.Tasks.API.Settings;

public record DatabaseSettings
{
    [Required]
    public string ConnectionString { get; set; }
}