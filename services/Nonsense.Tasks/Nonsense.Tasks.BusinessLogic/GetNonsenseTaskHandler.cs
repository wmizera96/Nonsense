using MediatR;
using Microsoft.EntityFrameworkCore;
using Nonsense.Data;
using Nonsense.Tasks.Model;

namespace Nonsense.Tasks.BusinessLogic;

public class GetNonsenseTaskHandler(INonsenseDataContext dataContext)
    : IRequestHandler<GetNonsenseTaskQuery, NonsenseTask>
{
    public async Task<NonsenseTask> Handle(GetNonsenseTaskQuery request, CancellationToken cancellationToken)
    {
        return await dataContext.Tasks.FirstOrDefaultAsync(task => task.Id == request.Id, cancellationToken);
    }
}