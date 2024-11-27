using System.Text.Json.Serialization;
using MediatR;
using Nonsense.Tasks.Model;

namespace Nonsense.Tasks.BusinessLogic;

public record UpdateNonsenseTaskCommand : IRequest<NonsenseTask>
{
    [JsonIgnore] // prevents Id from being part of the request body
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
