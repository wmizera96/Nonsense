using Microsoft.EntityFrameworkCore;
using Nonsense.Tasks.Model;

namespace Nonsense.Data;

public class NonsenseDataContext(DbContextOptions<NonsenseDataContext> options)
    : DbContext(options), INonsenseDataContext
{
    public DbSet<NonsenseTask> Tasks { get; set; }
}