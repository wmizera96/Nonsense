using MediatR;
using Nonsense.Data;
using Nonsense.Tasks.Model;

namespace Nonsense.Tasks.BusinessLogic;

public class CreateNonsenseTaskHandler(INonsenseDataContext dataContext)
    : IRequestHandler<CreateNonsenseTaskCommand, NonsenseTask>
{
    public async Task<NonsenseTask> Handle(CreateNonsenseTaskCommand request, CancellationToken cancellationToken)
    {
        var nonsenseTask = new NonsenseTask
        {
            Name = request.Name,
            Description = request.Description,
        };
        
        dataContext.Tasks.Add(nonsenseTask);
        
        await dataContext.SaveChangesAsync(cancellationToken);
        
        return nonsenseTask;
    }
}
