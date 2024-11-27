using MediatR;
using Nonsense.Data;
using Nonsense.Tasks.BusinessLogic.Requests;
using Nonsense.Tasks.Model;

namespace Nonsense.Tasks.BusinessLogic.Handlers;

public class GetNonsenseTaskHandler(INonsenseDataContext dataContext)
    : IRequestHandler<GetNonsenseTaskQuery, NonsenseTask>
{
    public async Task<NonsenseTask> Handle(GetNonsenseTaskQuery request, CancellationToken cancellationToken)
    {
        var task = await dataContext.NonsenseTasks.FindAsync(request.Id, cancellationToken);

        if (task is null)
        {
            throw NonsenseTaskErrors.NotFound();
        }
        
        return task;
    }
}