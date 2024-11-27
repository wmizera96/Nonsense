using MediatR;
using Microsoft.EntityFrameworkCore;
using Nonsense.Data;
using Nonsense.Tasks.Model;

namespace Nonsense.Tasks.BusinessLogic;

public class ListNonsenseTaskHandler(INonsenseDataContext dataContext) 
    : IRequestHandler<ListNonsenseTasksQuery, List<NonsenseTask>>
{
    public async Task<List<NonsenseTask>> Handle(ListNonsenseTasksQuery request, CancellationToken cancellationToken)
    {
        return await dataContext.Tasks.ToListAsync(cancellationToken);
    }
}