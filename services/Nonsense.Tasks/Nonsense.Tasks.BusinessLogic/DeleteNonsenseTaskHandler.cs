using MediatR;
using Nonsense.Data;

namespace Nonsense.Tasks.BusinessLogic;

public class DeleteNonsenseTaskHandler(INonsenseDataContext dataContext) 
    : IRequestHandler<DeleteNonsenseTaskCommand, Unit>
{
    public async Task<Unit> Handle(DeleteNonsenseTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await dataContext.Tasks.FindAsync(request.Id, cancellationToken);
        
        dataContext.Tasks.Remove(task);

        await dataContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}