using MediatR;
using Nonsense.Tasks.Model;

namespace Nonsense.Tasks.BusinessLogic;

public record GetNonsenseTaskQuery(Guid Id) : IRequest<NonsenseTask>;
