using MediatR;
using Nonsense.Tasks.Model;

namespace Nonsense.Tasks.BusinessLogic.Requests;

public record ListNonsenseTasksQuery : IRequest<List<NonsenseTask>>;
