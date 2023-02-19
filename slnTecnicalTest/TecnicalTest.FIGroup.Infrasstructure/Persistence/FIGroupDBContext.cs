using Microsoft.EntityFrameworkCore;

using TecnicalTest.FIGroup.Domain.Entities;

namespace TecnicalTest.FIGroup.Infrastructure.Persistence;

public class FIGroupDBContext : DbContext
{
    public FIGroupDBContext(DbContextOptions<FIGroupDBContext> options) : base(options) { }

    public DbSet<Tasks> Task { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }
}

