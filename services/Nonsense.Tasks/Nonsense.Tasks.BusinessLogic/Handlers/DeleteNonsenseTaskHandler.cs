using MediatR;
using Nonsense.Data;
using Nonsense.Tasks.BusinessLogic.Requests;

namespace Nonsense.Tasks.BusinessLogic.Handlers;

public class DeleteNonsenseTaskHandler(INonsenseDataContext dataContext) 
    : IRequestHandler<DeleteNonsenseTaskCommand, Unit>
{
    public async Task<Unit> Handle(DeleteNonsenseTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await dataContext.Tasks.FindAsync(request.Id, cancellationToken);

        if (task is null)
        {
            throw NonsenseTaskErrors.NotFound();
        }
        
        dataContext.Tasks.Remove(task);

        await dataContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}