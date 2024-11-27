using MediatR;
using Microsoft.EntityFrameworkCore;
using Nonsense.Data;
using Nonsense.Tasks.BusinessLogic.Requests;
using Nonsense.Tasks.Model;

namespace Nonsense.Tasks.BusinessLogic.Handlers;

public class UpdateNonsenseTaskHandler(INonsenseDataContext dataContext)
    : IRequestHandler<UpdateNonsenseTaskCommand, NonsenseTask>
{
    public async Task<NonsenseTask> Handle(UpdateNonsenseTaskCommand request, CancellationToken cancellationToken)
    {
        var nonsenseTask = await dataContext.NonsenseTasks.FindAsync(request.Id, cancellationToken);

        if (nonsenseTask is null)
        {
            throw new NullReferenceException($"Task with id {request.Id} does not exist");
        }
        
        var taskWithExistingName = await dataContext.NonsenseTasks.FirstOrDefaultAsync(task => task.Name == request.Name && task.Id != request.Id, cancellationToken);

        if (taskWithExistingName is not null)
        {
            throw NonsenseTaskErrors.NameAlreadyExists();
        }
        
        nonsenseTask.Name = request.Name;
        nonsenseTask.Description = request.Description;

        await dataContext.SaveChangesAsync(cancellationToken);

        return nonsenseTask;
    }
}