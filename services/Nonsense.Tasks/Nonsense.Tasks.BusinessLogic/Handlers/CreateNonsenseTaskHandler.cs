using MediatR;
using Microsoft.EntityFrameworkCore;
using Nonsense.Data;
using Nonsense.Tasks.BusinessLogic.Requests;
using Nonsense.Tasks.Model;

namespace Nonsense.Tasks.BusinessLogic.Handlers;

public class CreateNonsenseTaskHandler(INonsenseDataContext dataContext)
    : IRequestHandler<CreateNonsenseTaskCommand, NonsenseTask>
{
    public async Task<NonsenseTask> Handle(CreateNonsenseTaskCommand request, CancellationToken cancellationToken)
    {
        // var existingTask = dataContext.Tasks.FirstOrDefaultAsync(t => t.Name == request.Name, cancellationToken);

        // if (existingTask is not null)
        // {
            // throw NonsenseTaskErrors.NameAlreadyExists();
        // }
        
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
