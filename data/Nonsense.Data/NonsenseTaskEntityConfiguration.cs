using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nonsense.Tasks.Model;

namespace Nonsense.Data;

public class NonsenseTaskEntityConfiguration : IEntityTypeConfiguration<NonsenseTask>
{
    public void Configure(EntityTypeBuilder<NonsenseTask> builder)
    {
        builder.HasIndex(task => task.Name).IsUnique();
    }
}