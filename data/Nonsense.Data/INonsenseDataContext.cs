using Microsoft.EntityFrameworkCore;
using Nonsense.Tasks.Model;

namespace Nonsense.Data;

public interface INonsenseDataContext
{
    DbSet<NonsenseTask> Tasks { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}