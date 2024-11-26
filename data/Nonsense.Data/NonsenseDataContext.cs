using Microsoft.EntityFrameworkCore;
using Nonsense.Tasks.Model;

namespace Nonsense.Data;

public class NonsenseDataContext(DbContextOptions<NonsenseDataContext> options)
    : DbContext(options), INonsenseDataContext
{
    DbSet<NonsenseTask> Tasks { get; set; }
}