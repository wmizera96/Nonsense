using MediatR;

namespace Nonsense.Tasks.BusinessLogic;

public record DeleteNonsenseTaskCommand(Guid Id) : IRequest<Unit>;
