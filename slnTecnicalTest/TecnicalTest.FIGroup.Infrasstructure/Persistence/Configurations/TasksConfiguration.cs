using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TecnicalTest.FIGroup.Domain.Entities;
using TecnicalTest.FIGroup.Domain.Enums;

namespace TecnicalTest.FIGroup.Infrastructure.Persistence.Configurations;

internal sealed class TasksConfiguration : IEntityTypeConfiguration<Tasks>
{
    public void Configure(EntityTypeBuilder<Tasks> builder)
    {
        builder.ToTable("Task", "FIGroup");
        builder.HasKey(i => i.Id);
        builder.HasIndex(i => i.Id).IsUnique();
           builder.Property(u => u.Description)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(u => u.Status)
            .HasDefaultValue(LocaleStatusEnum.Enabled);

    }
}

