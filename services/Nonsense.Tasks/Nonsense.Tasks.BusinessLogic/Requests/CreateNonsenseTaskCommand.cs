using MediatR;
using Nonsense.Tasks.Model;

namespace Nonsense.Tasks.BusinessLogic.Requests;

public record CreateNonsenseTaskCommand(string Name, string Description) : IRequest<NonsenseTask>;
