using MediatR;
using Nonsense.Tasks.Model;

namespace Nonsense.Tasks.BusinessLogic;

public record ListNonsenseTasksQuery : IRequest<List<NonsenseTask>>;
