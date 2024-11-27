using MediatR;
using Microsoft.EntityFrameworkCore;
using Nonsense.Data;
using Nonsense.Tasks.Model;

namespace Nonsense.Tasks.BusinessLogic;

public class UpdateNonsenseTaskHandler(INonsenseDataContext dataContext)
    : IRequestHandler<UpdateNonsenseTaskCommand, NonsenseTask>
{
    public async Task<NonsenseTask> Handle(UpdateNonsenseTaskCommand request, CancellationToken cancellationToken)
    {
        var nonsenseTask = await dataContext.Tasks.FirstOrDefaultAsync(task => task.Id == request.Id, cancellationToken);

        if (nonsenseTask is null)
        {
            throw new NullReferenceException($"Task with id {request.Id} does not exist");
        }
        
        nonsenseTask.Name = request.Name;
        nonsenseTask.Description = request.Description;

        await dataContext.SaveChangesAsync(cancellationToken);

        return nonsenseTask;
    }
}