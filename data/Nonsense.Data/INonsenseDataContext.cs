using Microsoft.EntityFrameworkCore;
using Nonsense.Tasks.Model;

namespace Nonsense.Data;

public interface INonsenseDataContext
{
    DbSet<NonsenseTask> NonsenseTasks { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}