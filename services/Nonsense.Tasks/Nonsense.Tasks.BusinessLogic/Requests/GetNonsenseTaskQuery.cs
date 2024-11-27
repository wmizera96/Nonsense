using MediatR;
using Nonsense.Tasks.Model;

namespace Nonsense.Tasks.BusinessLogic.Requests;

public record GetNonsenseTaskQuery(Guid Id) : IRequest<NonsenseTask>;
