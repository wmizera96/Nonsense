using MediatR;

namespace Nonsense.Tasks.BusinessLogic.Requests;

public record DeleteNonsenseTaskCommand(Guid Id) : IRequest<Unit>;
