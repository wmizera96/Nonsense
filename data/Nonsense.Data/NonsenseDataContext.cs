using Microsoft.EntityFrameworkCore;
using Nonsense.Tasks.Model;

namespace Nonsense.Data;

public class NonsenseDataContext(DbContextOptions<NonsenseDataContext> options)
    : DbContext(options), INonsenseDataContext
{
    public DbSet<NonsenseTask> NonsenseTasks { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NonsenseDataContext).Assembly);
    }
}